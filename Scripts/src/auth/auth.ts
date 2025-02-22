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

	async login(): Promise<void> {
		const result: Result = await window.diplomeocy.Request('/Auth/Login', {
			username: $('#username').val() as string,
			password: $('#password').val() as string,
			__RequestVerificationToken: $('#antiforgery-token').val() as string,
		})
		handleResult(result)
	},

	async register(): Promise<void> {
		const result: Result = await window.diplomeocy.Request('/Auth/Register', {
			username: $('#username').val() as string,
			password: $('#password').val() as string,
			passwordconfirmation: $('#passwordconfirmation').val() as string,
			picturepath: $('#profile-picture').val() as string,
		})
		handleResult(result)
	},
}
