import Swal from 'sweetalert2'
import Result, { isErrorResult, isRedirectResult } from '../results'

$(() => {
	$('#form').on('click', async function (event) {
		event.preventDefault()

		const formData = new FormData(this as HTMLFormElement)

		const csrfToken = $(
			'input[name="__RequestVerificationToken"]',
		).val() as string

		try {
			const response: Response = await fetch('/Player/StartGame', {
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

			if (isErrorResult(result)) {
				window.location.reload()
				return
			}

			if (isRedirectResult(result)) {
				window.location.href = result.destination
				return
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
