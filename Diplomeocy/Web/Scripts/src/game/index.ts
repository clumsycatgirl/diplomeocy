import * as signalR from '@microsoft/signalr'

const connection: signalR.HubConnection = new signalR.HubConnectionBuilder()
	.withUrl('/game')
	.build()
