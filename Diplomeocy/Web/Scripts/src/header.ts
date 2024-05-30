$(function () {
	const $joinLink = $('#join-link')
	const $inputContainer = $('#join-input-container')
	const $input = $('#join-input')
	const $submitButton = $('#join-submit-button')

	$joinLink.on('mouseenter', function () {
		$inputContainer.removeClass('hidden-container').addClass('visible-container')
		$joinLink.addClass('hidden')
	})

	const hideInput = () => {
		if ($input.is(':focus') || $inputContainer.is(':hover')) return
		$inputContainer.removeClass('visible-container').addClass('hidden-container')
		$joinLink.removeClass('hidden')
		$input.val('')
	}

	$inputContainer.on('mouseleave', hideInput)

	$input.on('blur', hideInput)
	$input.on('mouseleave', hideInput)

	$input.on('keypress', function (e) {
		if (e.which === 13) {
			$submitButton.trigger('click')
		}
	})
})
