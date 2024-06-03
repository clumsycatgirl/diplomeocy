import * as signalR from '@microsoft/signalr'

const connection: signalR.HubConnection = new signalR.HubConnectionBuilder().withUrl('/hubs/table').build()

const maxConnectionAttempts: number = 5
let connectionAttempts: number = 0
$(async function setup() {
	if (connectionAttempts === maxConnectionAttempts) {
		console.error('Connection to the hub failed')
		return
	}

	connectionAttempts++

	try {
		await connection.start()
	} catch (error) {
		console.error('Connection to the hub failed', error, connectionAttempts < maxConnectionAttempts ? 'retrying' : '')
		setTimeout(setup, 125)
		return
	}

	const maxJoinAttempts = 5
	let joinAttempts = 0
	const joinTable = async () => {
		if (joinAttempts === maxJoinAttempts) {
			console.error('Failed to join table')
			return
		}
		joinAttempts++
		try {
			const groupId: string = $('#group-id').val() as string
			await connection.send('JoinTable', groupId)
		} catch (error) {
			console.error('Failed to join table', error, joinAttempts < maxJoinAttempts ? 'retrying' : '')
		}
	}

	await joinTable()
})

connection.on('EnableGameStart', () => {
	$('#start-game-button').prop('disabled', false)
})

$('#start-game-button').on('click', async function () {
	//
})
