import { HubConnection, HubConnectionBuilder } from '@microsoft/signalr'

export const SignalREndpoints = {
	chat: '',
}

export const SignalRBuilder = {
	chat: () => new SignalR(SignalREndpoints.chat),
}

export class SignalR {
	private _endpoint: string
	private _connection: HubConnection

	private _group: string

	private _onmessage: ((data: SignalRData | null) => void) | null

	constructor(endpoint: string) {
		this._endpoint = endpoint
	}

	public get endpoint(): string {
		return this._endpoint
	}

	public connect(
		onfulfilled: (() => void) | null = null,
		onmessage: ((data: SignalRData | null) => void) | null = null,
		onrejected: ((reason: any) => void) | null = (reason: any) => {
			console.error(reason.toString())
		},
	): void {
		this._connection = new HubConnectionBuilder().withUrl(this._endpoint).build()
		this._connection.on('ReceiveMessage', this.receiveMessage)
		this._connection.start().then(onfulfilled).catch(onrejected)
		this._onmessage = onmessage
	}

	private receiveMessage(json: string): void {
		const messageData = JSON.parse(json) as SignalRData
		this?._onmessage(messageData)
	}

	public async joinGroup(group: string): Promise<void> {
		this._group = group
		const data: SignalRData = this.toData('JoinGroup', group)
		await this.invoke(data)
	}

	public async leaveGroup(): Promise<void> {
		this._group = null
		const data: SignalRData = this.toData('LeaveGroup')
		await this.invoke(data)
	}

	public async sendToGroup(data: string): Promise<void> {
		const messageData: SignalRData = this.toData('SendMessageToGroup')
		messageData.data = data
		await this.invoke(messageData)
	}

	public async invoke(data: SignalRData) {
		await this._connection.invoke(data.action, data.json)
	}

	private toData(action: SignalRAction, data: string | null = null): SignalRData {
		return new SignalRData(action, data)
	}
}

export class SignalRData {
	public action: string
	public data: string

	constructor(action: SignalRAction, data: string) {
		this.action = action
		this.data = data
	}

	public get json(): string {
		return JSON.stringify({
			Action: this.action,
			Data: this.data,
		})
	}

	public get jsonObject(): object {
		return JSON.parse(this.json)
	}
}

export type SignalRAction = 'JoinGroup' | 'LeaveGroup' | 'SendMessageToGroup'
