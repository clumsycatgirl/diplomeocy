import { HubConnection, HubConnectionBuilder } from '@microsoft/signalr'
import { MessageData, MessageDataAction } from './message_data'

export const chatUrl: string = '/textchat'

export class ChatData {
	public user: string
	public group: string
	public connection: HubConnection

	constructor() {}

	public connect(
		onfulfilled: (() => void) | null = null,
		onrejected: ((reason: any) => void) | null = (reason: any) => {
			console.error(reason.toString())
		},
	): void {
		this.connection = new HubConnectionBuilder().withUrl(chatUrl).build()

		this.connection.on('ReceiveMessage', this.receiveMessage)

		this.connection.start().then(onfulfilled).catch(onrejected)
	}

	private receiveMessage(json: string): void {
		const messageData = JSON.parse(json) as MessageData

		const li = document.createElement('li')
		li.textContent = `${messageData.Sender}: ${messageData.Message}`

		$(`#messages-list`).append(li)
	}

	public async joinGroup(group: string): Promise<void> {
		this.group = group
		const messageData = this.messageData('JoinGroup')
		await this.invoke(messageData)
	}

	public async leaveGroup(group: string): Promise<void> {
		this.group = group
		const messageData = this.messageData('LeaveGroup')
		await this.invoke(messageData)
		this.group = null
	}

	public async sendMessageToGroup(message: string): Promise<void> {
		const messageData = this.messageData('SendMessageToGroup')
		messageData.message = message
		await this.invoke(messageData)
	}

	private messageData(action: MessageDataAction): MessageData {
		return new MessageData(action, this.group, this.user)
	}

	public async invoke(data: MessageData): Promise<void> {
		await this.connection.invoke(data.action, data.json)
	}
}

const chatData: ChatData = new ChatData()
export default chatData
