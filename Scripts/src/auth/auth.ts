import Result, { isErrorResult, isNotFoundResult, isRedirectResult } from '../results'

const handleResult = (result: Result): void => {
	$('.is-invalid').removeClass('is-invalid')
	$('.text-danger').text('')

	if (isErrorResult(result)) {
		result.errors.forEach((error) => {
			$(`#${error.field.toLowerCase()}`).addClass('is-invalid')
			$(`#${error.field.toLowerCase()}`).siblings('.text-danger').text(error.errors.join(', '))
		})
	}

	if (isNotFoundResult(result)) {
		$(`#username`).addClass('is-invalid').siblings('.text-danger').text(result.what)
	}

	if (isRedirectResult(result)) {
		window.location.href = result.destination
	}
}

window.diplomeocy.auth = {
	pfpOnChange() {
		const $element = $('#profile-picture')
		const $image = $('#profile-picture-preview')

		$image.attr('src', $element.val() as string)
	},

	login(htmx: any, element: HTMLElement, event: any): void {
		const result = JSON.parse(event.detail.xhr.responseText)
		handleResult(result)
	},

	register(htmx: any, element: HTMLElement, event: any): void {
		const result = JSON.parse(event.detail.xhr.responseText)
		handleResult(result)
	},
}
