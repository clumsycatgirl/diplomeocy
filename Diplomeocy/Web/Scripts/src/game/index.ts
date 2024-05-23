import * as signalR from '@microsoft/signalr'

const iconHeight = 40
const iconWidht = 40

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
console.log(`Loaded game: '${gameId}'`)

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
})

gameConnection.on('JoinGameGroupConfirm', (groupId) => {
	console.log('[JoinGameGroupConfirm received]')
	gameConnection.invoke('RequestState', groupId)
	console.log('[RequestState sending]')
})

gameConnection.on('RequestStateResponse', (json: string) => {
	console.log('[RequestStateResponse received]')
	const data: Player[] = JSON.parse(json)
	console.log(data)

	data.forEach((player) => {
		const color = colors[player.Countries[0].Name]
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

		const unitLayer = $('#UnitLayer').get(0)
		player.Units.forEach((unit) => {
			const unitType = unit.Type === 0 ? 'Army' : 'Fleet'
			const coordinates = provinceData[unit.Location!.toLowerCase()]
			unitLayer.innerHTML += `<use x="${coordinates.unit.x}" y="${
				coordinates.unit.y
			}" height="${iconHeight}" width="${iconWidht}" xlink:href="#${unitType}" class="unit${player.Countries[0].Name.toLowerCase()}" />`
		})
	})
})

gameConnection.on('RequestError', (error: string) => {
	console.log('[RequestError received]')
	console.error(error)
})
