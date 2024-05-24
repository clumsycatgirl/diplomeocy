import Swal from 'sweetalert2'
import Result, {
	isErrorResult,
	isNotFoundResult,
	isRedirectResult,
} from '../results'

// input field will reset errors when focusing
$(() => {

	
	$('input').on('focus', function () {
		console.log('meow')
		$(this).removeClass('is-invalid')
		$(this).siblings('.text-danger').text('')
	})

	$('#button').on('click', async function (event) {
		
		// avoid empty submit but we're not using the form so shouldn't need
		event.preventDefault()

		const form = document.getElementById('form') as HTMLFormElement
		const formData = new FormData(form) // automatically genegerate data to send with given inputs inside form

		// cross-site request forgery token
		const csrfToken = $(
			'input[name="__RequestVerificationToken"]',
		).val() as string

		// console.table(formData) // check what you're sending to the backend

		try {
			// execute request as POAST with given BODY with CSRF_TOKEN
			const response: Response = await fetch(`/Players/Create`, {
				method: 'POST',
				body: formData,
				headers: {
					RequestVerificationToken: csrfToken,
				},
			})
			
			// check if not 200
			if (!response.ok) {
				console.error(await response.text())
				throw new Error(`HTTP error! status: ${response.status}`)
			}
			
			// parse received response into json
			const result: Result = await response.json()
			return;
			console.table(result) // view data inside json if you need to

			if (isRedirectResult(result)) {
				// redirect
				
				//window.location.href = result.destination
			}

			if (isErrorResult(result)) {
				// reset inputs errors
				$('.is-invalid').removeClass('is-invalid')
				$('.text-danger').text('')

				// Show validation errors
				result.errors.forEach((error) => {
					$(`#${error.field.toLowerCase()}`).addClass('is-invalid')
					$(`#${error.field.toLowerCase()}`)
						.siblings('.text-danger') // siblings finds the elements next to it
						.text(error.errors.join(', '))
				})
			}
		} catch (error) {
			// show the toast with the error
			Swal.fire({
				title: 'upsie daisie :3',
				text: "something went wrong we're sorry, check the console logs for more info, meow",
				icon: 'error',
				backdrop: true,
			})
			console.error('Error:', error)
		}
	})

	
})
