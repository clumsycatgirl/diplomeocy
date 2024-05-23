import * as signalR from '@microsoft/signalr'

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
		player.Countries.forEach((country) => {
			const color = colors[country.Name]
			country.Territories.forEach((territory) => {
				$(`#m-${territory.Name.toLowerCase()}`).each(function () {
					$(this)
						.removeClass('nopower')
						.addClass(country.Name.toLowerCase())
				})
				console.log(
					territory.Name.toLowerCase(),
					$(`#m-${territory.Name.toLowerCase()}`),
				)
			})
		})
	})
})

gameConnection.on('RequestError', (error: string) => {
	console.log('[RequestError received]')
	console.error(error)
})
