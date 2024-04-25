/// <reference types="@microsoft/signalr" />
const connection = new signalR.HubConnectionBuilder()
    .withUrl("/chathub")
    .build();
const sendButton = document.getElementById("send-button");
sendButton.disabled = true;
const messageList = document.getElementById("messages-list");
connection.on("ReceiveMessage", (user, message) => {
    const li = document.createElement("li");
    li.textContent = `${user}: ${message}`;
    messageList.appendChild(li);
});
connection
    .start()
    .then(() => {
    sendButton.disabled = false;
})
    .catch((reason) => {
    console.error(reason.toString());
});
const userInput = document.getElementById("user-input");
const messageInput = document.getElementById("message-input");
sendButton.onclick = (event) => {
    const user = userInput.value;
    const message = messageInput.value;
    connection.invoke("SendMessage", user, message).catch((reason) => {
        console.error(reason.toString());
    });
    event.preventDefault();
};
//# sourceMappingURL=chat.js.map