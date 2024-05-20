import * as signalR from '@microsoft/signalr'

const connection = new signalR.HubConnectionBuilder()
	.withUrl('/chat/text')
	.build()

connection
	.start()
	.then(() => console.log('SignalR connection started'))
	.catch((err) => console.error(`SignalR connection error ${err}`))

connection.on('ReceiveVoiceSignal', (signal: string) => {
	console.log(`SignalR received '${signal}'`)

	let parsedSignal: RTCSessionDescriptionInit
	try {
		parsedSignal = JSON.parse(signal)
		console.table(parsedSignal)
	} catch (err) {
		console.error(`Failed to parse signal '${signal}'`)
		return
	}

	if (parsedSignal.type === 'offer') {
		handleOffer(parsedSignal)
	} else if (parsedSignal.type === 'answer') {
		handleAnswer(parsedSignal)
	} else {
		console.warn(`Unknown signal type ${parsedSignal.type}`)
	}
})

const sendVoiceSignal = (signal: string) => {
	connection
		.invoke('SendVoiceSignal', signal)
		.catch((err) => console.log(`SignalR sendVoiceSignal error ${err}`))
}

let localStream: MediaStream
let localAudioElement: HTMLAudioElement

const setupLocalStream = async () => {
	try {
		localStream = await navigator.mediaDevices.getUserMedia({ audio: true })
		// localAudioElement.srcObject = localStream
	} catch (err) {
		console.error(`Microphone permission rejected ${err}`)
	}
}

const createAndSendOffer = async () => {
	const peerConnection = new RTCPeerConnection()

	localStream
		.getTracks()
		.forEach((track) => peerConnection.addTrack(track, localStream))

	const offer = await peerConnection.createOffer()
	await peerConnection.setLocalDescription(offer)

	sendVoiceSignal(JSON.stringify(offer))
}

const handleOffer = async (offer: RTCSessionDescriptionInit) => {
	const peerConnection = new RTCPeerConnection()

	localStream
		.getTracks()
		.forEach((track) => peerConnection.addTrack(track, localStream))

	await peerConnection.setRemoteDescription(offer)

	const answer = await peerConnection.createAnswer()
	await peerConnection.setLocalDescription(answer)

	sendVoiceSignal(JSON.stringify(answer))
}

const handleAnswer = async (answer: RTCSessionDescriptionInit) => {
	try {
		const peerConnection = new RTCPeerConnection()
		const sessionDescription = new RTCSessionDescription(answer)

		if (peerConnection.connectionState === 'closed') {
			console.warn(
				'Peer connection is closed. Cannot set remote description.',
			)
			return
		}

		if (
			peerConnection.signalingState !== 'have-local-offer' &&
			peerConnection.signalingState !== 'have-remote-offer'
		) {
			console.warn(
				'Invalid signaling state for setting remote description:',
				peerConnection.signalingState,
			)
			return
		}

		await peerConnection.setRemoteDescription(sessionDescription)
	} catch (err) {
		console.error('Failed to set remote description:', err)
		console.table(answer)
	}
}

$(setupLocalStream)
$('#startCall').on('click', createAndSendOffer)
