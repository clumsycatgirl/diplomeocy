import * as RecordRTC from 'recordrtc'
import * as SignalR from '@microsoft/signalr'

let recorder: RecordRTC
let connection: SignalR.HubConnection
const audioChunks: Blob[] = []

const base64ToAudio = (base64String: string, mimeType: string) => {
	const byteCharacters = atob(base64String)
	const byteArrays: Uint8Array[] = []

	for (let offset = 0; offset < byteCharacters.length; offset += 512) {
		const slice = byteCharacters.slice(offset, offset + 512)
		const byteNumbers = new Array(slice.length)

		for (let i = 0; i < slice.length; i++) {
			byteNumbers[i] = slice.charCodeAt(i)
		}

		const byteArray = new Uint8Array(byteNumbers)
		byteArrays.push(byteArray)
	}

	return new Blob(byteArrays, { type: mimeType })
}

const onDataAvailable = (blob: Blob) => {
	if (connection && connection.invoke) {
		const reader = new FileReader()
		reader.onload = () => {
			const base64String = (reader.result as string).split(',')[1]
			connection.invoke('SendVoiceSignal', base64String)
		}
		reader.readAsDataURL(blob)
	}
}

const onConnectionStart = () => {
	console.log('SignalR connection started')
	recorder.startRecording()
	console.log('RecordRTC recorder started')
}

const receiveVoiceSignal = (base64Audio: string) => {
	const audioBlob: Blob = base64ToAudio(base64Audio, 'audio/wav')
	audioChunks.push(audioBlob)

	const audioUrl = URL.createObjectURL(
		new Blob(audioChunks, { type: 'audio/wav' }),
	)

	const audio = new Audio()
	audio.src = audioUrl

	audio
		.play()
		.then(() => {
			console.log('Audio playback started')
		})
		.catch((error) => {
			console.error('Error during audio playback:', error)
		})
}

$(async () => {
	try {
		const stream = await navigator.mediaDevices.getUserMedia({
			audio: true,
		})
		recorder = new RecordRTC(stream, {
			type: 'audio',
			mimeType: 'audio/wav',
			timeSlice: 250, // every 250ms
			ondataavailable: onDataAvailable,
		})

		connection = new SignalR.HubConnectionBuilder()
			.withUrl('/chat/text')
			.build()

		connection.on('ReceiveVoiceSignal', receiveVoiceSignal)

		connection
			.start()
			.then(onConnectionStart)
			.catch((error) => {
				console.error('SignalR connection error:', error)
			})
	} catch (error) {
		console.error('Error accessing media devices:', error)
	}
})

if (false) {
	navigator.mediaDevices
		.getUserMedia({ audio: true })
		.then((stream: MediaStream) => {
			const mediaRecorder = new MediaRecorder(stream, {
				mimeType: 'audio/ogg; codecs=opus;',
			})

			mediaRecorder.onstart = () => console.log('Started media recorder')

			mediaRecorder.ondataavailable = async (event: BlobEvent) => {
				console.log('on-data-available')
				// const arrayBuffer = await event.data.arrayBuffer()
				// console.log('format=' + new Uint8Array(arrayBuffer, 0, 4))
				// console.log(arrayBuffer)
				// socket.send(arrayBuffer)

				// const arrayBuffer = await event.data.arrayBuffer()
				// const bytes = new Uint8Array(arrayBuffer)
				// const base64String = btoa(String.fromCharCode(...bytes))

				// const bytesString = atob(base64String)
				// const backBytes = new Uint8Array(bytesString.length)
				// for (let i = 0; i < bytesString.length; i++) {
				// bytes[i] = bytesString.charCodeAt(i)
				// }

				// const audioElement = new Audio()

				// const blob = new Blob([backBytes], {
				// type: 'audio/ogg; codecs=opus;',
				// })
				// const url = URL.createObjectURL(blob)
				// audioElement.srcObject = stream

				// audioElement
				// .play()
				// .then(() => console.log('started playing'))
				// .catch(console.error)
				const blob = new Blob([event.data])
				const url = URL.createObjectURL(blob)
				const audio = new Audio(url)
				audio.play()
			}
			mediaRecorder.onerror = console.error

			mediaRecorder.onstop = () => console.log('Stopped media recorder')

			mediaRecorder.start(2000)
		})
		.catch((error: any) => {
			console.error('Error accessing audio devices.', error)
		})

	const url = `wss://${window.location.hostname}:${window.location.port}/ws`
	const socket = new WebSocket(url)

	socket.binaryType = 'arraybuffer'

	socket.onopen = () =>
		console.log(`Started WebSocket connection on '${url}'`)

	const audioContext = new AudioContext()
	socket.onmessage = async (event: MessageEvent<ArrayBuffer>) => {
		console.log(`received-length:${event.data.byteLength}`)
		console.log(event.data)

		return
		try {
			const blob = new Blob([event.data], { type: 'audio/ogg' })
			const url = URL.createObjectURL(blob)

			const audio = new Audio(url)
			const source = audioContext.createMediaElementSource(audio)
			source.connect(audioContext.destination)
			audio.play()
		} catch (err) {
			console.error('Error playing audio:', err)
		}
	}

	socket.onerror = console.error

	const sendSignalingMessage = (message: any, json: boolean = true) => {
		if (json) message = JSON.stringify(message)
		console.log(`sent-length:${message.length}`)
		socket.send(message)
	}
}

if (false) {
	// const toggleMic = () => {
	// 	if (!canRecord) return
	// 	console.log('toggle')
	// 	isRecording = !isRecording
	// 	if (isRecording) {
	// 		recorder.start()
	// 	} else {
	// 		recorder.stop()
	// 	}
	// }
	// const audioElement = new Audio()
	// let canRecord = false
	// let isRecording = false
	// let recorder: MediaRecorder = null
	// let chunks: Blob[] = []
	// const setupAudio = () => {
	// 	if (navigator.mediaDevices && navigator.mediaDevices.getUserMedia)
	// 		navigator.mediaDevices
	// 			.getUserMedia({ audio: true })
	// 			.then(setupStream)
	// 			.catch(console.error)
	// }
	// const setupStream = (stream: MediaStream) => {
	// 	recorder = new MediaRecorder(stream, {
	// 		mimeType: 'audio/ogg; codecs=opus;',
	// 	})
	// 	recorder.ondataavailable = ({ data }) => {
	// 		chunks.push(data)
	// 	}
	// 	recorder.onstop = (event) => {
	// 		const blob = new Blob(chunks, { type: 'audio/ogg; codecs=opus;' })
	// 		chunks = []
	// 		const audioUrl = URL.createObjectURL(blob)
	// 		audioElement.src = audioUrl
	// 	}
	// 	canRecord = true
	// }
	// $('#startCall').on('click', toggleMic)
	// $('#endCall').on('click', () => {
	// 	console.log('started playing')
	// 	audioElement.play()
	// })
	// setupAudio()
}
