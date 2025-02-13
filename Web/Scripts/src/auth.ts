import Swal from 'sweetalert2'
import Result, { isErrorResult, isNotFoundResult, isRedirectResult } from './results'
import select2 from 'select2'

declare var window: any

const handleResult = (result: Result) => {
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

window.registerCallback = (htmx: any, element: HTMLElement, event: any) => {
	const result: Result = JSON.parse(event.detail.xhr.responseText)
	console.log(result)
	handleResult(result)
}

window.loginCallback = (htmx: any, element: HTMLElement, event: any) => {
	const result: Result = JSON.parse(event.detail.xhr.responseText)
	handleResult(result)
}

window.pfpOnChange = () => {
	const $element = $('#profile-picture')
	const $image = $('#profile-picture-preview')

	$image.attr('src', $element.val() as string)
}
