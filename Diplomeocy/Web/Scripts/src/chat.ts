import { HubConnectionBuilder } from '@microsoft/signalr'
import { MessageData } from './message_data'

import chatData from './chat_data'

const sendButton = document.getElementById('send-button') as HTMLButtonElement
sendButton.disabled = true

const joinGroupButton = document.getElementById(
	'join-group',
) as HTMLButtonElement
joinGroupButton.disabled = true

chatData.connect(() => {
	sendButton.disabled = false
	joinGroupButton.disabled = false

	chatData.user = 'meow !!! rember to change thsi'
	userInput.value = chatData.user
	chatData.joinGroup('all')
})

const userInput = document.getElementById('user-input') as HTMLInputElement
const messageInput = document.getElementById(
	'message-input',
) as HTMLInputElement

sendButton.onclick = (_: Event) => {
	const user: string = userInput.value
	const message: string = messageInput.value

	chatData.user = user
	chatData.sendMessageToGroup(message)
	messageInput.value = ''
}

const joinGroupInput = document.getElementById(
	'join-group-input',
) as HTMLInputElement
joinGroupButton.onclick = async (_: Event) => {
	if (joinGroupInput.value === '') return

	const newGroup = joinGroupInput.value

	await chatData.leaveGroup(chatData.group)
	await chatData.joinGroup(newGroup)
}
