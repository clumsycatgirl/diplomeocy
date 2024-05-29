interface Window {
	reloadComponentHtmx: () => void
	htmx: any
}

window.reloadComponentHtmx = () => {
	console.log('htmx: reloading document.body')
	window.htmx.process(document.body)
}
