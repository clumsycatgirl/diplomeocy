import createPanZoom from 'panzoom'

window.Diplomeocy.Game.setupMap = () => {
	const element = $('#map')
	const container = element.parent()

	element.width(container.width())
	element.height(container.height())

	const panzoom = createPanZoom(element.get(0), {
		minZoom: 1,
		maxZoom: 3,
		smoothScroll: true,
		bounds: true,
		boundsPadding: 0,
	})

	let progMov = false

	const applyPanBoundaries = () => {
		const transform = panzoom.getTransform()
		const containerWidth = container.width()
		const containerHeight = container.height()

		const mapWidth = element.width() * transform.scale
		const mapHeight = element.height() * transform.scale

		const minX = containerWidth - mapWidth
		const maxX = 0

		const minY = containerHeight - mapHeight
		const maxY = 0

		const restrictedX = Math.max(minX, Math.min(maxX, transform.x))
		const restrictedY = Math.max(minY, Math.min(maxY, transform.y))
		if (!progMov) {
			progMov = true
			panzoom.moveTo(restrictedX, restrictedY)
			progMov = false
		}
	}

	window.addEventListener('resize', () => {
		element.width(container.width())
		element.height(container.height())

		applyPanBoundaries()
	})

	panzoom.on('pan', applyPanBoundaries)
	panzoom.on('zoom', applyPanBoundaries)
}
