declare var diplomeocy: {
	meow: () => void
	updateTheme: (theme: string) => void
}
window.diplomeocy = window.diplomeocy || {
	meow() {
		console.log('meow')
	},

	updateTheme(theme) {
		document.querySelector('html').className = theme
	},
}

window.diplomeocy.meow()
