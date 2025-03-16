import HSCollapse from '@preline/collapse'
import Result from './results'

export namespace Diplomeocy {
	export function meow(): void {
		console.log('meow')
	}

	export function updateTheme(theme: string): void {
		document.documentElement.className = theme.toLowerCase()
	}

	export function reloadHtmx(): void {
		console.log('htmx: reloading document.body')
		window.htmx?.process(document.body)
	}

	export function reloadCollapse(): void {
		HSCollapse.autoInit()
	}

	export namespace Auth {
		export let login: ((htmx: any, element: HTMLElement, event: Event) => Promise<void>) | undefined
		export let register: ((htmx: any, element: HTMLElement, event: Event) => Promise<void>) | undefined
		export let pfpOnChange: (() => void) | undefined
	}

	export namespace Header {
		export let setup: (() => void) | undefined
	}

	export namespace Tables {
		export namespace Sidebar {
			export let setup: (() => void) | undefined
		}
	}

	export namespace Game {
		export let setupMap: (() => void) | undefined
	}
}

declare global {
	interface Window {
		Diplomeocy: typeof Diplomeocy
		htmx: {
			process: (element: HTMLElement) => void
		}
	}
}

window.Diplomeocy = window.Diplomeocy || Diplomeocy
window.Diplomeocy.meow?.()

export const onLoad = (callback: (this: Document, ev: Event) => any) => {
	document.addEventListener('DOMContentLoaded', callback)
}
