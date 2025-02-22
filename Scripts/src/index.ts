interface Window {
	htmx: {
		process: (element: HTMLElement) => void
	}
}

declare var diplomeocy: {
	meow?: () => void
	updateTheme?: (theme: string) => void
	reloadHtmx: () => void

	auth?: {
		login: (htmx: any, element: HTMLElement, event: any) => void
		register: (htmx: any, element: HTMLElement, event: any) => void
		pfpOnChange: () => void
	}
}

window.diplomeocy = window.diplomeocy || {
	meow() {
		console.log('meow')
	},

	updateTheme(theme) {
		document.querySelector('html').className = theme
	},

	reloadHtmx() {
		console.log('htmx: reloading document.body')
		window.htmx.process(document.body)
	},
}

window.diplomeocy.meow()
