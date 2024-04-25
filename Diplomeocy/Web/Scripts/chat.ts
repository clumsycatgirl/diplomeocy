/// <reference types="@microsoft/signalr" />

const connection: signalR.HubConnection = new signalR.HubConnectionBuilder()
	.withUrl("/chathub")
	.build();

const sendButton: HTMLButtonElement = document.getElementById(
	"send-button"
) as HTMLButtonElement;
sendButton.disabled = true;

const messageList: HTMLElement = document.getElementById("messages-list");
connection.on("ReceiveMessage", (user: string, message: string) => {
	const li: HTMLLIElement = document.createElement("li");
	li.textContent = `${user}: ${message}`;

	messageList.appendChild(li);
});

connection
	.start()
	.then(() => {
		sendButton.disabled = false;
	})
	.catch((reason: any) => {
		console.error(reason.toString());
	});

const userInput: HTMLInputElement = document.getElementById(
	"user-input"
) as HTMLInputElement;
const messageInput: HTMLInputElement = document.getElementById(
	"message-input"
) as HTMLInputElement;
sendButton.onclick = (event: Event) => {
	const user: string = userInput.value;
	const message: string = messageInput.value;

	connection.invoke("SendMessage", user, message).catch((reason: any) => {
		console.error(reason.toString());
	});

	event.preventDefault();
};
