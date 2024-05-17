import * as signalR from '@microsoft/signalr'

let localStream: MediaStream = null
let peerConnection: RTCPeerConnection = null
const configuration: RTCConfiguration = {
	iceServers: [{ urls: 'stun:stun.l.google.com:19302' }],
}

const connection = new signalR.HubConnectionBuilder()
	.withUrl('/textchat')
	.build()

connection.start().catch(console.error)

connection.on('ReceiveVoiceSignal', async (signal: string) => {
	const message = JSON.parse(signal)

	if (message.offer) {
		const peerConnection = new RTCPeerConnection(configuration)

		peerConnection.onicecandidate = async (event) => {
			if (event.candidate) {
				await connection.invoke(
					'SendVoiceSignal',
					JSON.stringify({ candidate: event.candidate }),
				)
			}
		}

		peerConnection.ontrack = (event) => {
			const remoteAudio = document.getElementById(
				'remoteAudio',
			) as HTMLAudioElement
			if (!remoteAudio.srcObject) {
				remoteAudio.srcObject = event.streams[0]
			}
		}

		await peerConnection.setRemoteDescription(
			new RTCSessionDescription(message.offer),
		)

		const answer = await peerConnection.createAnswer()
		await peerConnection.setLocalDescription(answer)
		await connection.invoke(
			'SendVoiceSignal',
			JSON.stringify({ answer: peerConnection.localDescription }),
		)
	} else if (message.answer) {
		await peerConnection.setRemoteDescription(
			new RTCSessionDescription(message.answer),
		)
	} else if (message.candidate) {
		await peerConnection.addIceCandidate(
			new RTCIceCandidate(message.candidate),
		)
	}
})

// Simplified call start function
$('#startCall').on('click', async () => {
	try {
		const localStream = await navigator.mediaDevices.getUserMedia({
			audio: true,
		})
		const peerConnection = new RTCPeerConnection(configuration)

		localStream.getTracks().forEach((track) => {
			peerConnection.addTrack(track, localStream)
		})

		const offer = await peerConnection.createOffer()
		await peerConnection.setLocalDescription(offer)
		await connection.invoke(
			'SendVoiceSignal',
			JSON.stringify({ offer: peerConnection.localDescription }),
		)
	} catch (error) {
		console.error(error)
	}
})
