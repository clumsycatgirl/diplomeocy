import { Diplomeocy } from '..'
import { SignalR, SignalRBuilder } from '../singlar'

Diplomeocy.Chat.setup = () => {
	const chat: SignalR = SignalRBuilder.chat()
}
