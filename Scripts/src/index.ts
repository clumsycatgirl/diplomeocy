import HSCollapse from '@preline/collapse'
import Result from './results'

declare global {
	interface Window {
		htmx: {
			process: (element: HTMLElement) => void
		}
		diplomeocy: Diplomeocy
	}
}

interface Diplomeocy {
	meow?: () => void
	updateTheme?: (theme: string) => void
	reloadHtmx: () => void
	reloadCollapse: () => void

	Request: (endpoint: string, body: object, method?: string) => Promise<Result>

	auth?: {
		login: (htmx: any, element: HTMLElement, event: Event) => Promise<void>
		register: (htmx: any, element: HTMLElement, event: Event) => Promise<void>
		pfpOnChange: () => void
	}
}

window.diplomeocy = window.diplomeocy || {
	meow() {
		console.log('meow')
	},

	updateTheme(theme: string) {
		document.documentElement.className = theme
	},

	reloadHtmx() {
		console.log('htmx: reloading document.body')
		window.htmx?.process(document.body)
	},

	reloadCollapse() {
		HSCollapse.autoInit()
	},

	Request(endpoint: string, body: object, method: string = 'POST') {
		const formBody = Object.keys(body)
			.map((key) => encodeURIComponent(key) + '=' + encodeURIComponent(body[key as keyof typeof body] as string))
			.join('&')

		return fetch(endpoint, {
			method: method.toUpperCase(),
			body: formBody,
			headers: {
				'Content-Type': 'application/x-www-form-urlencoded',
			},
		}).toResult()
	},
}

window.diplomeocy.meow?.()
