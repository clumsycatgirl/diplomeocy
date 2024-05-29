interface Window {
	registerCallback: (htmx: any, element: HTMLElement, event: Event) => void
	loginCallback: () => void
}

window.registerCallback = (htmx, element, event) => {
	console.log('meow')
	console.log(typeof htmx, typeof element, typeof event)
}
