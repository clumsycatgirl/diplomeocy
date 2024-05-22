import Swal from 'sweetalert2'
import Result, {
	isErrorResult,
	isNotFoundResult,
	isRedirectResult,
} from './results'

// input field will reset errors when focusing
$(() => {
	$('input').on('focus', function () {
		console.log('meow')
		$(this).removeClass('is-invalid')
		$(this).siblings('.text-danger').text('')
	})

	$('#createButton').on('click', async function (event) {
		// avoid empty submit but we're not using the form so shouldn't need
		event.preventDefault()

		const form = document.getElementById('form') as HTMLFormElement
		const formData = new FormData(form) // automatically gengerate data to send with given inputs inside form

		// cross-site request forgery token
		const csrfToken = $(
			'input[name="__RequestVerificationToken"]',
		).val() as string

		// console.table(formData) // check what you're sending to the backend

		try {
			// execute request as POAST with given BODY with CSRF_TOKEN
			const response: Response = await fetch(`/Users/Create`, {
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

			console.table(result) // view data inside json if you need to

			if (isRedirectResult(result)) {
				// redirect
				window.location.href = result.destination
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

	$('#loginButton').on('click', async function (event) {
		event.preventDefault()

		const form = document.getElementById('log-in-form') as HTMLFormElement
		const formData = new FormData(form)

		const csrfToken = $(
			'input[name="__RequestVerificationToken"]',
		).val() as string

		try {
			const response: Response = await fetch(`/Users/LogIn`, {
				method: 'POST',
				body: formData,
				headers: {
					RequestVerificationToken: csrfToken,
				},
			})

			if (!response.ok) {
				console.error(await response.text())
				throw new Error(`HTTP error! status: ${response.status}`)
			}

			const result: Result = await response.json()
			console.table(result)
			console.table({
				err: isErrorResult(result),
				notFound: isNotFoundResult(result),
				redirect: isRedirectResult(result),
			})

			if (isErrorResult(result)) {
				console.table(result)
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

			if (isNotFoundResult(result)) {
				console.log('fuck')
				Swal.fire({
					title: result.what,
					icon: 'error',
					position: 'top-right',
					showConfirmButton: false,
					backdrop: false,
					timer: 5000,
				})
			}

			if (isRedirectResult(result)) {
				window.location.href = result.destination
			}
		} catch (error) {
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
