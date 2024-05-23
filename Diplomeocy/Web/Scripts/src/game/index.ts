import * as signalR from '@microsoft/signalr'

const gameConnection: signalR.HubConnection = new signalR.HubConnectionBuilder()
	.withUrl('/hubs/game')
	.build()

const gameId: string = $('#group').val() as string
console.log(`Loaded game: '${gameId}'`)

$(() => {
	gameConnection
		.start()
		.then(() => {
			gameConnection.invoke('JoinGameGroup', gameId)
		})
		.catch((error) => {
			console.error("Error in 'gameConnection': ", error)
		})
})

gameConnection.on('JoinGameGroupConfirm', (groupId) => {
	gameConnection.invoke('RequestState', groupId)
})

gameConnection.on('RequestStateResponse', (data: string) => {
	console.log(JSON.parse(data))
})

gameConnection.on('RequestError', (error: string) => {
	console.error(error)
})
