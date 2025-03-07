import { onLoad } from '.'
import Result, { isRedirectResult, ResultRequest } from './results'

window.Diplomeocy.Header.setup = () => {
	const joinLink = $('#join-link')
	const inputContainer = $('#join-input-container')
	const input = $('#join-input')
	const submitButton = $('#join-submit-button')

	joinLink.on('mouseenter', () => {
		inputContainer.removeClass('translate-x-[100%] hidden')
		joinLink.addClass('translate-x-[200%]')
	})

	const hideInput = () => {
		if (!input.is(':focus') && !inputContainer.is(':hover')) {
			inputContainer.addClass('translate-x-[100%]')
			joinLink.removeClass('translate-x-[200%]')
			input.val('')
		}
	}

	inputContainer.on('mouseleave', hideInput)
	input.on('blur', hideInput)
	input.on('mouseleave', hideInput)

	input.on('keypress', (e) => {
		if (e.which === 13) {
			submitButton.trigger('click')
		}
		if (!/[0-9]/.test(e.key)) {
			e.preventDefault()
		}
	})

	submitButton.on('click', async () => {
		const tableId = input.val() as string
		console.log(tableId)

		const result: Result = await ResultRequest(`/Table/Join/${tableId}`, {})
		if (isRedirectResult(result)) {
			window.location.href = result.destination
			return
		}

		// not gonna handle errors for this I just don't feel like it
		// TODO: show a message of some sort idk idc i want to kms
	})
}

window.Diplomeocy.Tables.Sidebar = {
	setup: function () {
		const tabButtons = document.querySelectorAll('[data-hs-tab]')
		const tabPanels = document.querySelectorAll('[role="tabpanel"]')

		tabButtons.forEach((button) => {
			button.addEventListener('click', function () {
				const targetTab = document.querySelector(this.getAttribute('data-hs-tab'))

				tabPanels.forEach((panel) => {
					panel.classList.add('hidden')
					panel.classList.remove('block')
				})

				targetTab.classList.remove('hidden')
				targetTab.classList.add('block')

				tabButtons.forEach((btn) => btn.classList.remove('active'))
				this.classList.add('active')
			})
		})

		// Automatically activate the first tab
		if (tabButtons.length > 0) {
			;(tabButtons[0] as HTMLButtonElement).click()
		}
	},
}
