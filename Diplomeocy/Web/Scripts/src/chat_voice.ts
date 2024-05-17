import * as signalR from '@microsoft/signalr'

let localStream: MediaStream = null
let peerConnection: RTCPeerConnection = null
const configuration: RTCConfiguration = {
	iceServers: [{ urls: 'stun:stun.l.google.com:19302' }],
}
let audioContext: AudioContext = null

const connection: signalR.HubConnection = new signalR.HubConnectionBuilder()
	.withUrl('/textchat')
	.build()

$('#startCall').on('click', async () => {
	console.log('starting call')
	try {
		localStream = await navigator.mediaDevices.getUserMedia({ audio: true })
		console.log('Microphone access granted')

		peerConnection = new RTCPeerConnection(configuration)

		localStream
			.getTracks()
			.forEach((track) => peerConnection.addTrack(track, localStream))

		peerConnection.onicecandidate = (event) => {
			if (event.candidate)
				connection.invoke(
					'SendVoiceSignal',
					JSON.stringify({ candidate: event.candidate }),
				)
		}

		peerConnection.ontrack = (event) => {
			const remoteAudio = $('#remoteAudio').get(0) as HTMLAudioElement
			remoteAudio.srcObject = event.streams[0]
		}

		const offer = await peerConnection.createOffer()
		await peerConnection.setLocalDescription(offer)
		connection.invoke(
			'SendVoiceSignal',
			JSON.stringify({ offer: peerConnection.localDescription }),
		)
	} catch (error) {
		console.error(error)
	}
})

$('#endCall').on('click', async () => {
	if (!peerConnection) return

	peerConnection.close()
	peerConnection = null
	localStream.getTracks().forEach((track) => track.stop())
})

connection.on('ReceiveVoiceSignal', async (signal: string) => {
	const message = JSON.parse(signal)
	// console.log(message)

	if (message.answer) {
		await peerConnection.setRemoteDescription(
			new RTCSessionDescription(message.answer),
		)
		return
	}

	if (message.candidate) {
		await peerConnection.addIceCandidate(
			new RTCIceCandidate(message.candidate),
		)
		return
	}

	if (message.offer) {
		if (!!peerConnection) return

		peerConnection = new RTCPeerConnection(configuration)

		peerConnection.onicecandidate = (event) => {
			if (!event.candidate) return

			connection.invoke(
				'SendVoiceSignal',
				JSON.stringify({ candidate: event.candidate }),
			)
		}

		peerConnection.ontrack = (event) => {
			// const remoteAudio = $('#remoteAudio').get(0) as HTMLAudioElement
			// remoteAudio.srcObject = event.streams[0]
			// console.log(event.streams[0])
			// remoteAudio.play()
			audioContext = new AudioContext()

			const gainNode = audioContext.createGain()
			gainNode.connect(audioContext.destination)

			const microphoneStream =
				audioContext.createMediaStreamSource(localStream)
			microphoneStream.connect(audioContext.destination)
		}

		localStream.getTracks().forEach((track) => {
			peerConnection.addTrack(track, localStream)
		})

		return
	}
})

connection.start().catch(console.error)

if (false)
	// echo test
	$(async function () {
		const audioContext = new AudioContext()

		console.log('audio is starting up ...')

		if (!navigator.getUserMedia)
			navigator.getUserMedia =
				navigator.getUserMedia ||
				navigator.webkitGetUserMedia ||
				navigator.mozGetUserMedia ||
				navigator.msGetUserMedia

		if (!navigator.getUserMedia) {
			alert('getUserMedia not supported in this browser.')
			return
		}

		localStream = await navigator.mediaDevices.getUserMedia({
			audio: true,
		})

		const gainNode = audioContext.createGain()
		gainNode.connect(audioContext.destination)

		const microphoneStream =
			audioContext.createMediaStreamSource(localStream)
		microphoneStream.connect(audioContext.destination)
	})
