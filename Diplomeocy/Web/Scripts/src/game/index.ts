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

const gameConnection: signalR.HubConnection = new signalR.HubConnectionBuilder().withUrl('/hubs/game').build()

const gameId: string = $('#group').val() as string
export let country: string = $('#own-country').val() as string
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
				x: parseFloat($provinceDataElement.find('jdipns\\:unit').attr('x')),
				y: parseFloat($provinceDataElement.find('jdipns\\:unit').attr('y')),
			},
			dislodgedUnit: {
				x: parseFloat($provinceDataElement.find('jdipns\\:dislodged_unit').attr('x')),
				y: parseFloat($provinceDataElement.find('jdipns\\:dislodged_unit').attr('y')),
			},
		}
	})

	Object.keys(provinceData).forEach((province) => {
		$(province.toLowerCase()).off('click')
		$(`m-${province.toLowerCase()}`).off('click')
	})
})

const getAllData = () => {
	gameConnection.invoke('RequestState', gameId)
	console.log('[RequestState sending]')
	gameConnection.invoke('RequestAvailableMovements', gameId, country)
	console.log('[RequestAvailableMovements sending]')
	gameConnection.invoke('RequestAvailableSupports', gameId, country)
	console.log('[RequestAvailableSupports sending]')
	gameConnection.invoke('RequestConvoyRoutes', gameId, country)
	console.log('[RequestConvoyRoutes sending]')
}

gameConnection.on('RequestError', (error: string) => {
	console.log('[RequestError received]')
	console.error(error)
})

gameConnection.on('JoinGameGroupConfirm', (groupId) => {
	console.log('[JoinGameGroupConfirm received]')
	getAllData()
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
					$(this).removeClass('nopower').addClass(country.Name.toLowerCase())
				})
				$(`#${territory.Name.toLowerCase()}`).on('click', function () {
					console.log(`Clicked ${territory.Name.toLowerCase()}`)
				})
			})
		})

		player.Units.forEach((unit) => {
			if (!unit.Location) return
			const unitType = unit.Type === 0 ? 'Army' : 'Fleet'
			const coordinates = provinceData[unit.Location!.toLowerCase()]
			unitLayer.innerHTML += `<use x="${coordinates.unit.x}" y="${
				coordinates.unit.y
			}" height="${iconHeight}" width="${iconWidht}" xlink:href="#${unitType}" class="unit${player.Countries[0].Name.toLowerCase()}" />`
		})
	})
})

let unit: string = null
let firstTerritorySelection: string = null
let secondTerritorySelection: string = null
const previousClasses: { [territory: string]: string } = {}
gameConnection.on('RequestAvailableMovementsResponse', (json: string) => {
	const data: {
		[territory: string]: string[]
	} = JSON.parse(json)

	console.log('[RequestAvailableMovementsResponse received]')
	console.log(data)

	const $movementType = $(`input[type="radio"][name="type"][value="regular"]`)

	const resetTerritories = () => {
		Object.keys(data).forEach((territory) => {
			// console.log(territory, ' restoring to ', previousClasses[territory])
			// console.log('fuck1 ', territory)
			if ($(`#m-${territory.toLowerCase()}`).hasClass('highlight') || $(`#m-${territory.toLowerCase()}`).hasClass('highlight-unit'))
				$(`#m-${territory.toLowerCase()}`).attr('class', previousClasses[territory])
			$(`#m-${territory.toLowerCase()}`).removeClass('highlight').removeClass('highlight-unit')

			$(`#${territory.toLowerCase()}`).off('click')

			data[territory].forEach((adjacency) => {
				if ($(`#m-${adjacency.toLowerCase()}`).hasClass('highlight') || $(`#m-${adjacency.toLowerCase()}`).hasClass('highlight-unit'))
					$(`#m-${adjacency.toLowerCase()}`).attr('class', previousClasses[adjacency])
				$(`#m-${adjacency.toLowerCase()}`).removeClass('highlight').removeClass('highlight-unit')

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
					if ($(`#m-${adjacency.toLowerCase()}`).attr('class') !== 'highlight')
						previousClasses[adjacency] = $(`#m-${adjacency.toLowerCase()}`).attr('class')
					$(`#m-${adjacency.toLowerCase()}`).attr('class', 'highlight')
					$(`#${adjacency.toLowerCase()}`)
						.off('click')
						.on('click', function () {
							secondTerritorySelection = adjacency

							console.log(`MoveOrder: ${firstTerritorySelection} -> ${secondTerritorySelection}`)

							gameConnection
								.invoke('AddOrder', gameId, country, firstTerritorySelection, secondTerritorySelection, 'move', unit)
								.catch((error) => console.error('Error sending ordwer', error))

							const coordFirst = provinceData[firstTerritorySelection.toLowerCase()].unit
							const coordSecond = provinceData[secondTerritorySelection.toLowerCase()].unit

							$('#Layer2 line').each(function () {
								const $line = $(this)
								if (parseFloat($line.attr('x1')) === coordFirst.x && parseFloat($line.attr('y1')) === coordFirst.y) {
									$line.remove()
								}
							})

							const $arrow = $(document.createElementNS('http://www.w3.org/2000/svg', 'line'))
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

						$('#Layer2 line').each(function () {
							const $line = $(this)
							if (
								parseFloat($line.attr('x1')) === provinceData[territory.toLowerCase()].unit.x &&
								parseFloat($line.attr('y1')) === provinceData[territory.toLowerCase()].unit.y
							) {
								$line.remove()
							}
						})

						gameConnection.invoke('AddOrder', gameId, country, firstTerritorySelection, secondTerritorySelection, 'hold', unit)

						console.log(`HoldOrder: ${firstTerritorySelection}`)

						firstTerritorySelection = null
						secondTerritorySelection = null
						resetTerritories()
					})
			})
		})
	}

	$movementType.on('change', function () {
		if (!$(this).is(':checked')) return

		console.log('chcked regular')
		resetTerritories()
	})

	$movementType.prop('checked', true).trigger('change')
})

let supportOrderCounter = 0
gameConnection.on('RequestAvailableSupportsResponse', (json: string) => {
	console.log('[RequestAvailableSupportsResponse received]')
	const data: {
		[unitLocation: string]: {
			[supportOrigin: string]: string[]
		}
	} = JSON.parse(json)

	const resetTerritories = () => {
		Object.keys(data).forEach((unitLocation) => {
			if ($(`#m-${unitLocation.toLowerCase()}`).hasClass('highlight') || $(`#m-${unitLocation.toLowerCase()}`).hasClass('highlight-unit'))
				$(`#m-${unitLocation.toLowerCase()}`).attr('class', previousClasses[unitLocation])
			$(`#m-${unitLocation.toLowerCase()}`).removeClass('highlight').removeClass('highlight-unit')
			$(`#${unitLocation.toLowerCase()}`).off('click')

			Object.keys(data[unitLocation]).forEach((supportOrigin) => {
				if ($(`#m-${supportOrigin.toLowerCase()}`).hasClass('highlight') || $(`#m-${supportOrigin.toLowerCase()}`).hasClass('highlight-unit'))
					$(`#m-${supportOrigin.toLowerCase()}`).attr('class', previousClasses[supportOrigin])
				$(`#m-${supportOrigin.toLowerCase()}`).removeClass('highlight').removeClass('highlight-unit')
				$(`#${supportOrigin.toLowerCase()}`).off('click')

				data[unitLocation][supportOrigin].forEach((target) => {
					if ($(`#m-${target.toLowerCase()}`).hasClass('highlight') || $(`#m-${target.toLowerCase()}`).hasClass('highlight-unit'))
						$(`#m-${target.toLowerCase()}`).attr('class', previousClasses[target])
					$(`#m-${target.toLowerCase()}`).removeClass('highlight').removeClass('highlight-unit')
					$(`#${target.toLowerCase()}`).off('click')
				})
			})
		})

		Object.keys(data).forEach((unitLocation) => {
			const $unitLocationM = $(`#m-${unitLocation.toLowerCase()}`)
			const $unitLocation = $(`#${unitLocation.toLowerCase()}`)
			$unitLocation.on('click', function () {
				// highlight support orders
				Object.keys(data[unitLocation]).forEach((supportOrigin) => {
					const $supportLocationM = $(`#m-${supportOrigin.toLowerCase()}`)
					const $supportLocation = $(`#${supportOrigin.toLowerCase()}`)

					if ($supportLocationM.attr('class') !== 'highlight') previousClasses[supportOrigin] = $supportLocationM.attr('class')
					$supportLocationM.attr('class', 'highlight')

					$supportLocation.on('click', function () {
						firstTerritorySelection = supportOrigin

						resetTerritories()
						Object.keys(data).forEach((t) => $(`#${t.toLowerCase()}`).off('click'))
						Object.keys(data[unitLocation]).forEach((t) => $(`#${t.toLowerCase()}`).off('click'))
						previousClasses[unitLocation] = $unitLocationM.attr('class')
						$unitLocationM.attr('class', 'highlight-unit')

						previousClasses[supportOrigin] = $supportLocationM.attr('class')
						$supportLocationM.attr('class', 'highlight-unit')
						data[unitLocation][supportOrigin].forEach((supportTarget) => {
							const $supportTarget = $(`#${supportTarget.toLowerCase()}`)
							const $supportTargetM = $(`#m-${supportTarget.toLowerCase()}`)

							previousClasses[supportTarget] = $supportTargetM.attr('class')
							$supportTargetM.attr('class', 'highlight')

							$supportTarget.on('click', function () {
								secondTerritorySelection = supportTarget

								console.log('support from ', unitLocation, ' for ', firstTerritorySelection, ' -> ', secondTerritorySelection)

								const coordFirst = provinceData[firstTerritorySelection.toLowerCase()].unit
								const coordSecond = provinceData[secondTerritorySelection.toLowerCase()].unit
								const coordUnit = provinceData[unitLocation.toLowerCase()].unit

								const midX = (coordFirst.x + coordSecond.x) / 2
								const midY = (coordFirst.y + coordSecond.y) / 2

								let supportOrderCount: number
								$('#Layer2 line').each(function () {
									const $line = $(this)
									if (parseFloat($line.attr('x1')) === coordUnit.x && parseFloat($line.attr('y1')) === coordUnit.y) {
										$line.remove()
										supportOrderCount = parseInt($line.attr('data-so-count'))
									}
								})

								console.log('deleting ', supportOrderCount)
								$('#Layer2 line').each(function () {
									const $line = $(this)
									if (parseInt($line.attr('data-so-count')) === supportOrderCount) {
										$line.remove()
									}
								})

								const arrowExists = (x1: number, y1: number, x2: number, y2: number) => {
									let exists = false
									$('#Layer2 line').each(function () {
										const $line = $(this)
										if (
											parseFloat($line.attr('x1')) === x1 &&
											parseFloat($line.attr('y1')) === y1 &&
											parseFloat($line.attr('x2')) === x2 &&
											parseFloat($line.attr('y2')) === y2
										) {
											exists = true
											return false
										}
									})
									return exists
								}

								if (!arrowExists(coordFirst.x, coordFirst.y, coordSecond.x, coordSecond.y)) {
									const $greyArrow = $(document.createElementNS('http://www.w3.org/2000/svg', 'line'))
									$greyArrow
										.attr('x1', coordFirst.x)
										.attr('y1', coordFirst.y)
										.attr('x2', coordSecond.x)
										.attr('y2', coordSecond.y)
										.attr('stroke', 'white')
										.attr('stroke-dasharray', '5, 5')
										.attr('stroke-width', '8')
										.attr('marker-end', 'url(#arrow)')
										.attr('data-so-count', supportOrderCounter)
									$('#Layer2').append($greyArrow)
								}

								const $blackArrow = $(document.createElementNS('http://www.w3.org/2000/svg', 'line'))
								$blackArrow
									.attr('x1', coordUnit.x)
									.attr('y1', coordUnit.y)
									.attr('x2', midX)
									.attr('y2', midY)
									.attr('stroke', 'black')
									.attr('stroke-dasharray', '5, 5')
									.attr('stroke-width', '8')
									.attr('marker-end', 'url(#arrow)')
									.attr('data-so-count', supportOrderCounter)
								$('#Layer2').append($blackArrow)

								supportOrderCounter++

								unit = unitLocation
								gameConnection.invoke('AddOrder', gameId, country, firstTerritorySelection, secondTerritorySelection, 'support', unit)

								firstTerritorySelection = null
								secondTerritorySelection = null
								unit = null
								resetTerritories()
							})
						})
					})
				})
			})
		})
	}

	const $movementType = $(`input[type="radio"][name="type"][value="support"]`)
	$movementType.on('change', function () {
		if (!$(this).is(':checked')) return

		console.log('chcked support')
		resetTerritories()
	})

	console.log(data)
})

let convoyOrderCounter = 0
gameConnection.on('RequestConvoyRoutesResponse', (json: string) => {
	console.log('[RequestConvoyRoutesResponse received]')
	const data: {
		[unit: string]: {
			units: string[]
			destinations: string[]
		}
	} = JSON.parse(json)
	console.log(data)

	const resetTerritories = () => {
		console.log(previousClasses)

		Object.keys(data).forEach((convoyingUnit) => {
			const convoyableUnits = data[convoyingUnit].units
			const convoyDestinations = data[convoyingUnit].destinations

			const $convoyingUnit = $(`#${convoyingUnit.toLowerCase()}`)
			const $convoyingUnitM = $(`#m-${convoyingUnit.toLowerCase()}`)

			// console.log('restoring ', previousClasses[convoyingUnit], ' to ', $convoyingUnitM)

			if ($convoyingUnitM.hasClass('highlight') || $convoyingUnitM.hasClass('highlight-unit')) {
				$convoyingUnitM.attr('class', previousClasses[convoyingUnit])
			}
			$convoyingUnitM.removeClass('highlight').removeClass('highlight-unit')
			$convoyingUnit.off('click')

			convoyableUnits.forEach((convoyableUnit) => {
				const $convoyableUnitM = $(`#m-${convoyableUnit.toLowerCase()}`)
				const $convoyableUnit = $(`#${convoyableUnit.toLowerCase()}`)

				// console.log('restoring ', previousClasses[convoyableUnit], ' to ', $convoyableUnitM)

				if ($convoyableUnitM.hasClass('highlight') || $convoyableUnitM.hasClass('highlight-unit')) {
					$convoyableUnitM.attr('class', previousClasses[convoyableUnit])
				}
				$convoyableUnitM.removeClass('highlight').removeClass('highlight-unit')
				$convoyableUnit.off('click')

				convoyDestinations.forEach((convoyDestination) => {
					const $convoyDestionationM = $(`#m-${convoyDestination.toLowerCase()}`)
					const $convoyDestionation = $(`#${convoyDestination.toLowerCase()}`)

					// console.log('restoring ', previousClasses[convoyDestination], ' to ', $convoyDestionationM)

					if ($convoyDestionationM.hasClass('highlight') || $convoyDestionationM.hasClass('highlight-unit')) {
						$convoyDestionationM.attr('class', previousClasses[convoyDestination])
					}
					$convoyDestionationM.removeClass('highlight').removeClass('highlight-unit')
					$convoyDestionation.off('click')
				})
			})
		})

		Object.keys(data).forEach((convoyingUnit) => {
			const $convoyingUnit = $(`#${convoyingUnit.toLowerCase()}`)
			const $convoyingUnitM = $(`#m-${convoyingUnit.toLowerCase()}`)

			$convoyingUnit.on('click', function () {
				Object.keys(data).forEach((unit) => $(`#${unit.toLowerCase()}`).off('click'))
				Object.keys(data).forEach((unit) => $(`#m-${unit.toLowerCase()}`).off('click'))

				if (!$convoyingUnitM.hasClass('highlight') && !$convoyingUnitM.hasClass('highlight-unit'))
					previousClasses[convoyingUnit] = $convoyingUnitM.attr('class')
				$convoyingUnitM.attr('class', 'highlight-unit')

				const convoyableUnits = data[convoyingUnit].units
				const convoyDestinations = data[convoyingUnit].destinations

				convoyableUnits.forEach((convoyableUnit) => {
					const $convoyableUnit = $(`#${convoyableUnit.toLowerCase()}`)
					const $convoyableUnitM = $(`#m-${convoyableUnit.toLowerCase()}`)

					if (!$convoyableUnitM.hasClass('highlight') && !$convoyableUnitM.hasClass('highlight-unit'))
						previousClasses[convoyableUnit] = $convoyableUnitM.attr('class')
					$convoyableUnitM.attr('class', 'highlight')

					$convoyableUnit.on('click', function () {
						resetTerritories()

						Object.keys(data).forEach((unit) => $(`#${unit.toLowerCase()}`).off('click'))
						Object.keys(data).forEach((unit) => $(`#m-${unit.toLowerCase()}`).off('click'))

						const $convoyableUnit = $(`#${convoyableUnit.toLowerCase()}`)
						const $convoyableUnitM = $(`#m-${convoyableUnit.toLowerCase()}`)

						if (!$convoyableUnitM.hasClass('highlight') && !$convoyableUnitM.hasClass('highlight-unit'))
							previousClasses[convoyableUnit] = $convoyableUnitM.attr('class')
						$convoyableUnitM.attr('class', 'highlight-unit')

						convoyDestinations.forEach((convoyDestination) => {
							const $convoyDestination = $(`#${convoyDestination.toLowerCase()}`)
							const $convoyDestinationM = $(`#m-${convoyDestination.toLowerCase()}`)

							if (convoyDestination === 'Sweden') console.log('die', $convoyDestinationM)
							if (!$convoyDestinationM.hasClass('highlight') && !$convoyDestinationM.hasClass('highlight-unit'))
								previousClasses[convoyDestination] = $convoyDestinationM.attr('class')
							$convoyDestinationM.attr('class', 'highlight')

							$convoyDestination.on('click', function () {
								console.log('convoy ', convoyingUnit, ' from ', convoyableUnit, ' to ', convoyDestination)

								gameConnection.invoke('AddOrder', gameId, country, convoyableUnit, convoyDestination, 'convoy', convoyingUnit)

								const coordFirst = provinceData[convoyableUnit.toLowerCase()].unit
								const coordSecond = provinceData[convoyDestination.toLowerCase()].unit
								const coordUnit = provinceData[convoyingUnit.toLowerCase()].unit

								const midX = (coordFirst.x + coordSecond.x) / 2
								const midY = (coordFirst.y + coordSecond.y) / 2

								let convoyOrderCounter: number
								$('#Layer2 line').each(function () {
									const $line = $(this)
									if (parseFloat($line.attr('x1')) === coordUnit.x && parseFloat($line.attr('y1')) === coordUnit.y) {
										$line.remove()
										convoyOrderCounter = parseInt($line.attr('data-co-count'))
									}
								})

								console.log('deleting ', convoyOrderCounter)
								$('#Layer2 line').each(function () {
									const $line = $(this)
									if (parseInt($line.attr('data-co-count')) === convoyOrderCounter) {
										$line.remove()
									}
								})

								const arrowExists = (x1: number, y1: number, x2: number, y2: number) => {
									let exists = false
									$('#Layer2 line').each(function () {
										const $line = $(this)
										if (
											parseFloat($line.attr('x1')) === x1 &&
											parseFloat($line.attr('y1')) === y1 &&
											parseFloat($line.attr('x2')) === x2 &&
											parseFloat($line.attr('y2')) === y2
										) {
											exists = true
											return false
										}
									})
									return exists
								}

								if (!arrowExists(coordFirst.x, coordFirst.y, coordSecond.x, coordSecond.y)) {
									const $greyArrow = $(document.createElementNS('http://www.w3.org/2000/svg', 'line'))
									$greyArrow
										.attr('x1', coordFirst.x)
										.attr('y1', coordFirst.y)
										.attr('x2', coordSecond.x)
										.attr('y2', coordSecond.y)
										.attr('stroke', 'white')
										.attr('stroke-dasharray', '5, 5')
										.attr('stroke-width', '8')
										.attr('marker-end', 'url(#arrow)')
										.attr('data-co-count', convoyOrderCounter)
									$('#Layer2').append($greyArrow)
								}

								const $blackArrow = $(document.createElementNS('http://www.w3.org/2000/svg', 'line'))
								$blackArrow
									.attr('x1', coordUnit.x)
									.attr('y1', coordUnit.y)
									.attr('x2', midX)
									.attr('y2', midY)
									.attr('stroke', 'black')
									.attr('stroke-dasharray', '5, 5')
									.attr('stroke-width', '8')
									.attr('marker-end', 'url(#arrow)')
									.attr('data-co-count', convoyOrderCounter)
								$('#Layer2').append($blackArrow)

								convoyOrderCounter++

								firstTerritorySelection = null
								secondTerritorySelection = null
								unit = null
								resetTerritories()
							})
						})
					})
				})
			})
		})
	}

	const $movementType = $(`input[type="radio"][name="type"][value="convoy"]`)
	$movementType.on('change', function () {
		if (!$(this).is(':checked')) return

		console.log('chcked convoy')
		resetTerritories()
	})
})

gameConnection.on('AdvanceTurn', (data: { phase: string; year: number; season: string }) => {
	console.log('[AdvanceTurn received]')

	const phases = ['Diplomacy', 'OrderResolution', 'Retreat', 'Build', 'AdvanceYear']
	const seasons = ['Spring', 'Autumn']
	data.phase = phases[parseInt(data.phase)]
	data.season = seasons[parseInt(data.season)]

	console.log(data)

	$('#year').text(data.year)
	$('#season').text(data.season)

	if (data.phase === 'Diplomacy') {
		getAllData()
	}

	if (data.phase === 'OrderResolution') {
		getAllData()
	}

	if (data.phase === 'Retreat') {
		gameConnection.invoke('RequestRetreats', gameId, country)
		console.log('[RequestRetreats sending]')
	}
})

gameConnection.on('RequestRetreatsResponse', (json: string) => {
	const data = JSON.parse(json) as {
		own: { [unit: string]: string[] }
		others: { [unit: string]: string[] }
		units: { [country: string]: string[] }
	}

	// Clear previous units and orders
	$('#UnitLayer').get(0).innerHTML = ''
	$('#OrderLayer #Layer2').get(0).innerHTML = ''
	$('#DislodgedUnitLayer').get(0).innerHTML = ''

	// Display all units
	Object.entries(data.units).forEach(([country, units]) => {
		units.forEach((unitStr) => {
			if (!unitStr) return
			const unit = JSON.parse(unitStr)
			const unitType = unit.type === 0 ? 'Army' : 'Fleet'
			const coordinates = provinceData[unit.location.toLowerCase()]
			$('#UnitLayer').get(0).innerHTML += `<use x="${coordinates.unit.x}" y="${
				coordinates.unit.y
			}" height="${iconHeight}" width="${iconWidht}" xlink:href="#${unitType}" class="unit${country.toLowerCase()}" />`
		})
	})

	// Display dislodged units
	Object.entries(data.others)
		.concat(Object.entries(data.own))
		.forEach(([unit, territories]) => {
			const coordinates = provinceData[unit.toLowerCase()]
			const $unit = $(`#UnitLayer use[x="${coordinates.unit.x}"][y="${coordinates.unit.y}"]`)
			$unit.attr('xlink:href', $unit.attr('xlink:href') === '#Army' ? '#DislodgedArmy' : '#DislodgedFleet')
			$('#DislodgedUnitLayer').get(0).innerHTML += $unit.html()
		})

	// Handle own dislodged units
	Object.entries(data.own).forEach(([unit, retreatLocations]) => {
		const $unit = $(`#${unit.toLowerCase()}`)
		$unit.off('click').on('click', () => {
			// Highlight possible retreat locations
			retreatLocations.forEach((location) => {
				const $location = $(`#${location.toLowerCase()}`)
				const $locationM = $(`#m-${location.toLowerCase()}`)

				if ($locationM.attr('class') !== 'highlight') previousClasses[location] = $locationM.attr('class')
				$locationM.attr('class', 'highlight')

				$location.off('click').on('click', () => {
					// Send retreat order to server
					gameConnection.invoke('AddRetreat', gameId, country, unit, location)

					// Draw arrow from unit to retreat location
					const start = provinceData[unit.toLowerCase()].dislodgedUnit
					const end = provinceData[location.toLowerCase()].unit
					$('#Layer2').get(0).innerHTML += $(
						`<line x1="${start.x}" y1="${start.y}" x2="${end.x}" y2="${end.y}" stroke="black" stroke-width="8" marker-end="url(#arrow)" />`,
					).html()

					// Reset highlights
					retreatLocations.forEach((location) => $(`#m-${location.toLowerCase()}`).attr('class', previousClasses[location]))
				})
			})
		})
	})
})

gameConnection.on('AddRetreatResponse', () => {
	console.log('[AddRetreatResponse received]')
})
