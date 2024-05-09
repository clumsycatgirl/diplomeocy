export type MessageDataAction =
	| 'JoinGroup'
	| 'LeaveGroup'
	| 'SendMessageToGroup'

export class MessageData {
	constructor(
		public action: MessageDataAction,
		public group: string,
		public sender: string,
		public message: string | null = null,
	) {}

	public get Action(): MessageDataAction {
		return this.action
	}
	public set Action(value: MessageDataAction) {
		this.action = value
	}

	public get Group(): string {
		return this.group
	}
	public set Group(value: string) {
		this.group = value
	}

	public get Sender(): string {
		return this.sender
	}
	public set Sender(value: string) {
		this.sender = value
	}

	public get Message(): string {
		return this.message
	}
	public set Message(value: string) {
		this.message = value
	}

	public get json(): string {
		return JSON.stringify({
			Action: this.action,
			Group: this.group,
			Sender: this.sender,
			Message: this.message,
		})
	}

	public get jsonObject(): object {
		return JSON.parse(this.json)
	}
}
