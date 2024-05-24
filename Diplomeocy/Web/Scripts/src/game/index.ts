import * as signalR from '@microsoft/signalr'

const iconHeight = 50
const iconWidht = 50

interface Territory {
	Name: string
}

interface Country {
	Name: string
	Territories: Territory[]
}

interface Unit {
	Country: number
	Type: number
	Location: string
}

interface Player {
	Name: string
	Countries: Country[]
	Units: Unit[]
}

const gameConnection: signalR.HubConnection = new signalR.HubConnectionBuilder()
	.withUrl('/hubs/game')
	.build()

const colors: { [key: string]: string } = {
	England: 'blue',
	France: 'lavander',
	Germany: 'grey',
	Austria: 'red',
	Italy: 'green',
	Russia: 'purple',
	Turkey: 'yellow',
}

const gameId: string = $('#group').val() as string
const country: string = $('#own-country').val() as string
console.log(`Loaded game: '${gameId}' as '${country}'`)

let provinceData: {
	[name: string]: {
		unit: {
			x: number
			y: number
		}
		dislodgedUnit: {
			x: number
			y: number
		}
	}
} = {}

$(() => {
	gameConnection
		.start()
		.then(() => {
			console.log('[JoinGameGroup sending]')
			gameConnection.invoke('JoinGameGroup', gameId)
		})
		.catch((error) => {
			console.error("Error in 'gameConnection': ", error)
		})

	$('jdipns\\:province').each(function () {
		const $provinceDataElement = $(this)
		const name = $provinceDataElement.attr('name')

		provinceData[name] = {
			unit: {
				x: parseFloat(
					$provinceDataElement.find('jdipns\\:unit').attr('x'),
				),
				y: parseFloat(
					$provinceDataElement.find('jdipns\\:unit').attr('y'),
				),
			},
			dislodgedUnit: {
				x: parseFloat(
					$provinceDataElement
						.find('jdipns\\:dislodged_unit')
						.attr('x'),
				),
				y: parseFloat(
					$provinceDataElement
						.find('jdipns\\:dislodged_unit')
						.attr('y'),
				),
			},
		}
	})

	Object.keys(provinceData).forEach((province) => {
		$(province.toLowerCase()).off('click')
		$(`m-${province.toLowerCase()}`).off('click')
	})
})

gameConnection.on('RequestError', (error: string) => {
	console.log('[RequestError received]')
	console.error(error)
})

gameConnection.on('JoinGameGroupConfirm', (groupId) => {
	console.log('[JoinGameGroupConfirm received]')
	gameConnection.invoke('RequestState', groupId)
	console.log('[RequestState sending]')
	gameConnection.invoke('RequestAvailableMovements', groupId, country)
	console.log('[RequestAvailableMovements sending]')
})

gameConnection.on('RequestStateResponse', (json: string) => {
	console.log('[RequestStateResponse received]')
	const data: Player[] = JSON.parse(json)
	console.log(data)

	const orderLayer = $('#OrderLayer #Layer2').get(0)
	orderLayer.innerHTML = ''

	const unitLayer = $('#UnitLayer').get(0)
	unitLayer.innerHTML = ''
	data.forEach((player) => {
		player.Countries.forEach((country) => {
			country.Territories.forEach(async (territory) => {
				$(`#m-${territory.Name.toLowerCase()}`).each(function () {
					$(this)
						.removeClass('nopower')
						.addClass(country.Name.toLowerCase())
				})
				$(`#${territory.Name.toLowerCase()}`).on('click', function () {
					console.log(`Clicked ${territory.Name.toLowerCase()}`)
				})
			})
		})

		player.Units.forEach((unit) => {
			const unitType = unit.Type === 0 ? 'Army' : 'Fleet'
			const coordinates = provinceData[unit.Location!.toLowerCase()]
			unitLayer.innerHTML += `<use x="${coordinates.unit.x}" y="${
				coordinates.unit.y
			}" height="${iconHeight}" width="${iconWidht}" xlink:href="#${unitType}" class="unit${player.Countries[0].Name.toLowerCase()}" />`
		})
	})
})

let firstTerritorySelection: string = null
let secondTerritorySelection: string = null
gameConnection.on('RequestAvailableMovementsResponse', (json: string) => {
	const data: {
		[territory: string]: string[]
	} = JSON.parse(json)

	const previousClasses: { [territory: string]: string } = {}

	const resetTerritories = () => {
		Object.keys(data).forEach((territory) => {
			// console.log(territory, ' restoring to ', previousClasses[territory])
			// console.log('fuck1 ', territory)
			if ($(`#m-${territory.toLowerCase()}`).hasClass('highlight'))
				$(`#m-${territory.toLowerCase()}`).attr(
					'class',
					previousClasses[territory],
				)
			$(`#m-${territory.toLowerCase()}`).removeClass('highlight')

			$(`#${territory.toLowerCase()}`).off('click')

			data[territory].forEach((adjacency) => {
				if ($(`#m-${adjacency.toLowerCase()}`).hasClass('highlight'))
					$(`#m-${adjacency.toLowerCase()}`).attr(
						'class',
						previousClasses[adjacency],
					)
				$(`#m-${adjacency.toLowerCase()}`).removeClass('highlight')

				$(`#${adjacency.toLowerCase()}`).off('click')
			})
		})

		Object.keys(data).forEach((territory) => {
			$(`#${territory.toLowerCase()}`).on('click', function () {
				if (firstTerritorySelection !== null) return
				// console.log('started order from ' + territory)

				firstTerritorySelection = territory

				const adjacencies = data[territory]
				adjacencies.forEach((adjacency) => {
					previousClasses[adjacency] = $(
						`#m-${adjacency.toLowerCase()}`,
					).attr('class')
					$(`#m-${adjacency.toLowerCase()}`).attr(
						'class',
						'highlight',
					)
					$(`#${adjacency.toLowerCase()}`)
						.off('click')
						.on('click', function () {
							secondTerritorySelection = adjacency

							console.log(
								`MoveOrder: ${firstTerritorySelection} -> ${secondTerritorySelection}`,
							)

							gameConnection
								.invoke(
									'AddOrder',
									gameId,
									country,
									firstTerritorySelection,
									secondTerritorySelection,
									'move',
								)
								.catch((error) =>
									console.error(
										'Error sending ordwer',
										error,
									),
								)

							const coordFirst =
								provinceData[
									firstTerritorySelection.toLowerCase()
								].unit
							const coordSecond =
								provinceData[
									secondTerritorySelection.toLowerCase()
								].unit

							$('#Layer2 line').each(function () {
								const $line = $(this)
								if (
									parseFloat($line.attr('x1')) ===
										coordFirst.x &&
									parseFloat($line.attr('y1')) ===
										coordFirst.y
								) {
									$line.remove()
								}
							})

							const $arrow = $(
								document.createElementNS(
									'http://www.w3.org/2000/svg',
									'line',
								),
							)
							$arrow
								.attr('x1', coordFirst.x)
								.attr('y1', coordFirst.y)
								.attr('x2', coordSecond.x)
								.attr('y2', coordSecond.y)
								.attr('stroke', 'black')
								.attr('stroke-width', '8')
								.attr('marker-end', 'url(#arrow)')

							$('#Layer2').append($arrow)

							firstTerritorySelection = null
							secondTerritorySelection = null
							resetTerritories()
						})
				})

				$(`#${territory.toLowerCase()}`)
					.off('click')
					.on('click', function () {
						secondTerritorySelection = territory

						gameConnection.invoke(
							'AddOrder',
							gameId,
							country,
							firstTerritorySelection,
							secondTerritorySelection,
							'hold',
						)

						console.log(`HoldOrder: ${firstTerritorySelection}`)

						firstTerritorySelection = null
						secondTerritorySelection = null
						resetTerritories()
					})
			})
		})
	}

	resetTerritories()

	console.log(data)
})

gameConnection.on('AdvanceTurn', () => {
	console.log('[AdvanceTurn received]')
	gameConnection.invoke('RequestState', gameId)
	console.log('[RequestState sending]')
	gameConnection.invoke('RequestAvailableMovements', gameId, country)
	console.log('[RequestAvailableMovements sending]')
})
