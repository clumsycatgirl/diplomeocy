/// <reference types="@microsoft/signalr" />
var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
const connection = new signalR.HubConnectionBuilder()
    .withUrl('/chathub')
    .build();
class MessageData {
    constructor(action = 'JoinGroup', group = '', sender = '', message = null) {
        this.action = action;
        this.group = group;
        this.sender = sender;
        this.message = message;
    }
    get Action() {
        return this.action;
    }
    set Action(value) {
        this.action = value;
    }
    get Group() {
        return this.group;
    }
    set Group(value) {
        this.group = value;
    }
    get Sender() {
        return this.sender;
    }
    set Sender(value) {
        this.sender = value;
    }
    get Message() {
        return this.message;
    }
    set Message(value) {
        this.message = value;
    }
}
const sendButton = document.getElementById('send-button');
sendButton.disabled = true;
const joinGroupButton = document.getElementById('join-group');
joinGroupButton.disabled = true;
const messageList = document.getElementById('messages-list');
connection.on('ReceiveMessage', (user, message) => {
    const li = document.createElement('li');
    li.textContent = `${user}: ${message}`;
    messageList.appendChild(li);
});
let group;
connection
    .start()
    .then(() => {
    sendButton.disabled = false;
    joinGroupButton.disabled = false;
    group = 'all';
    const data = new MessageData();
    data.Action = 'JoinGroup';
    connection.invoke('JoinGroup', JSON.stringify(data));
})
    .catch((reason) => {
    console.error(reason.toString());
});
const userInput = document.getElementById('user-input');
const messageInput = document.getElementById('message-input');
sendButton.onclick = (event) => {
    const user = userInput.value;
    const message = messageInput.value;
    const data = '';
    connection
        .invoke('SendMessageToGroup', JSON.stringify(data))
        .catch((reason) => {
        console.log(reason.toString());
    });
    event.preventDefault();
};
const joinGroupInput = document.getElementById('join-group-input');
joinGroupButton.onclick = (_) => __awaiter(this, void 0, void 0, function* () {
    if (joinGroupInput.value === '')
        return;
    yield connection.invoke('LeaveGroup', JSON.stringify({ Group: group }));
    group = joinGroupInput.value;
    yield connection.invoke('JoinGroup', JSON.stringify({ Group: group }));
});
//# sourceMappingURL=chat.js.map