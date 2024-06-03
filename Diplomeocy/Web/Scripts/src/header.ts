$(function () {
	const $joinLink = $('#join-link')
	const $inputContainer = $('#join-input-container')
	const $input = $('#join-input')
	const $submitButton = $('#join-submit-button')

	$joinLink.on('mouseenter', function () {
		$inputContainer.removeClass('hidden').removeClass('hidden-container').addClass('visible-container')
		$joinLink.addClass('absolute').addClass('opacity-0')
		$('#my-tables-link').removeClass('translate-x-[-300%]').addClass('translate-x-[-560%]')
		$('#create-table-link').removeClass('translate-x-[-50%]').addClass('translate-x-[-200%]')
	})

	const hideInput = () => {
		if ($input.is(':focus') || $inputContainer.is(':hover')) return
		$inputContainer.removeClass('visible-container').addClass('hidden-container').addClass('hidden')
		$joinLink.removeClass('absolute').removeClass('opacity-0')
		$input.val('')
		$('#my-tables-link').addClass('translate-x-[-300%]').removeClass('translate-x-[-560%]')
		$('#create-table-link').addClass('translate-x-[-50%]').removeClass('translate-x-[-150%]')
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
