import * as signalR from '@microsoft/signalr'

const connection = new signalR.HubConnectionBuilder()
	.withUrl('/chat/voice')
	.build()

connection.on('Receive', (data: string) => {
	console.log(data)
	const bytesString = atob(data)
	const bytes = new Uint8Array(bytesString.length)
	for (let i = 0; i < bytesString.length; i++) {
		bytes[i] = bytesString.charCodeAt(i)
	}

	const audioElement = new Audio()

	const blob = new Blob([bytes], { type: 'audio/wav' })
	const url = URL.createObjectURL(blob)
	audioElement.src = url

	audioElement
		.play()
		.then(() => {
			console.log('Audio playback started successfully.')
		})
		.catch((error) => {
			console.error('Error playing audio:', error)
		})
	return
})

export const startVoiceChat = async () => {
	try {
		await connection.start()
		console.log('SignalR connected')
	} catch (error) {
		console.error(error)
	}
}

export const stopVoiceChat = () => {
	connection.stop()
}

const audioElement = document.getElementById('audioElement') as HTMLAudioElement

let mediaRecorder: MediaRecorder
let mediaStream: MediaStream
let audioChunks: Blob[] = []

const handleDataAvailable = async (event: BlobEvent) => {
	console.log('handleDataAvailable')
	if (event.data.size > 0) {
		audioChunks.push(event.data)

		const arrayBuffer = await event.data.arrayBuffer()
		const bytes = new Uint8Array(arrayBuffer)
		const base64String = btoa(String.fromCharCode(...bytes))

		await connection.invoke('Send', base64String)
	}
}

const startMediaRecorder = () => {
	if (mediaStream) {
		mediaRecorder = new MediaRecorder(mediaStream)
		mediaRecorder.ondataavailable = handleDataAvailable
		mediaRecorder.start()
		console.log('MediaRecorder started')
	}
}

const stopMediaRecorder = () => {
	if (mediaRecorder && mediaRecorder.state !== 'inactive') {
		mediaRecorder.stop()
		console.log('MediaRecorder stopped')
	}
}

$('#startCall').on('click', startMediaRecorder)
$('#endCall').on('click', stopMediaRecorder)

navigator.mediaDevices
	.getUserMedia({ audio: true })
	.then((stream) => {
		// audioElement.srcObject = stream
		mediaStream = stream
	})
	.catch((error) => {
		console.error('Error accessing microphone:', error)
	})

$(() => {
	setTimeout(() => {
		startVoiceChat()
		startMediaRecorder()
	}, 2500)
})
