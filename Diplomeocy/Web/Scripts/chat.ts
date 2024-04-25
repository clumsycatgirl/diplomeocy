/// <reference types="@microsoft/signalr" />

const connection: signalR.HubConnection = new signalR.HubConnectionBuilder()
	.withUrl('/chathub')
	.build();

type MessageDataAction = 'JoinGroup' | 'LeaveGroup' | 'SendMessage';
class MessageData {
	constructor(
		private action: MessageDataAction = 'JoinGroup',
		private group: string = '',
		private sender: string = '',
		private message: string | null = null,
	) {}

	public get Action(): string {
		return this.action;
	}
	public set Action(value: MessageDataAction) {
		this.action = value;
	}

	public get Group(): string {
		return this.group;
	}

	public set Group(value: string) {
		this.group = value;
	}

	public get Sender(): string {
		return this.sender;
	}

	public set Sender(value: string) {
		this.sender = value;
	}

	public get Message(): string | null {
		return this.message;
	}

	public set Message(value: string | null) {
		this.message = value;
	}
}

const sendButton: HTMLButtonElement = document.getElementById(
	'send-button',
) as HTMLButtonElement;
sendButton.disabled = true;

const joinGroupButton: HTMLButtonElement = document.getElementById(
	'join-group',
) as HTMLButtonElement;
joinGroupButton.disabled = true;

const messageList: HTMLElement = document.getElementById('messages-list');
connection.on('ReceiveMessage', (user: string, message: string) => {
	const li: HTMLLIElement = document.createElement('li');
	li.textContent = `${user}: ${message}`;

	messageList.appendChild(li);
});

let group: string;
connection
	.start()
	.then(() => {
		sendButton.disabled = false;
		joinGroupButton.disabled = false;

		group = 'all';
		const data: MessageData = new MessageData();
		data.Action = 'JoinGroup';
		connection.invoke('JoinGroup', JSON.stringify(data));
	})
	.catch((reason: any) => {
		console.error(reason.toString());
	});

const userInput: HTMLInputElement = document.getElementById(
	'user-input',
) as HTMLInputElement;
const messageInput: HTMLInputElement = document.getElementById(
	'message-input',
) as HTMLInputElement;
sendButton.onclick = (event: Event) => {
	const user: string = userInput.value;
	const message: string = messageInput.value;

	const data = '';
	connection
		.invoke('SendMessageToGroup', JSON.stringify(data))
		.catch((reason) => {
			console.log(reason.toString());
		});

	event.preventDefault();
};

const joinGroupInput: HTMLInputElement = document.getElementById(
	'join-group-input',
) as HTMLInputElement;
joinGroupButton.onclick = async (_: Event) => {
	if (joinGroupInput.value === '') return;

	await connection.invoke('LeaveGroup', JSON.stringify({ Group: group }));

	group = joinGroupInput.value;
	await connection.invoke('JoinGroup', JSON.stringify({ Group: group }));
};
