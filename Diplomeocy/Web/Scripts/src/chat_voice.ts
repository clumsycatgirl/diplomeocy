import * as signalR from '@microsoft/signalr'

const xhr = new XMLHttpRequest()
let config: any
xhr.onreadystatechange = function ($evt) {
	if (xhr.readyState == 4 && xhr.status == 200) {
		let res = JSON.parse(xhr.responseText)
		console.log('Loaded ICE Servers from xirsys')
		console.table(res.v.iceServers)
		config = res.v.iceServers

		start()
	}
}
xhr.open('PUT', 'https://global.xirsys.net/_turn/Diplomeocy', true)
xhr.setRequestHeader(
	'Authorization',
	'Basic ' + btoa('ivysmnope:30e84c06-1773-11ef-a8d0-0242ac130002'),
)
xhr.setRequestHeader('Content-Type', 'application/json')
xhr.send(JSON.stringify({ format: 'urls' }))

const start = async () => {
	const configuration: RTCConfiguration = {
		iceServers: [
			{ urls: 'stun:stun.l.google.com:19302' }, // Google's STUN server
			...config.urls.map((url: any) => ({
				urls: url,
				username: config.username,
				credential: config.credential,
			})),
		],
		iceCandidatePoolSize: 10,
		// iceServers: [
		// 	{ urls: ['stun:fr-turn5.xirsys.com'] },
		// 	{
		// 		username:
		// 			'6BcenxCVkFaNeMTng_0BjA0jof0jFpMkyw-C0C3mVaGHrUmLfZP3H0RCH9KOMYJaAAAAAGZMnWtpdnlzbW5vcGU=',
		// 		credential: '95cb39e4-1773-11ef-b949-0242ac120004',
		// 		urls: [
		// 			'turn:fr-turn5.xirsys.com:80?transport=udp',
		// 			'turn:fr-turn5.xirsys.com:3478?transport=udp',
		// 			'turn:fr-turn5.xirsys.com:80?transport=tcp',
		// 			'turns:fr-turn5.xirsys.com:443?transport=tcp',
		// 		],
		// 	},
		// ],
	}

	const connection = new signalR.HubConnectionBuilder()
		.withUrl('/chat/text')
		.build()

	let localStream: MediaStream

	const setupLocalStream = async () => {
		try {
			localStream = await navigator.mediaDevices.getUserMedia({
				audio: true,
			})
		} catch (err) {
			console.error(`Microphone permission rejected ${err}`)
		}
	}

	const peerConnection = new RTCPeerConnection(configuration)

	connection.on('ReceiveVoiceSignal', async (signal: string) => {
		console.log(`SignalR received '${signal}'`)

		let parsedSignal: any
		try {
			parsedSignal = JSON.parse(signal)
			console.table(parsedSignal)
		} catch (err) {
			console.error(`Failed to parse signal '${signal}'`)
			return
		}

		if (parsedSignal.candidate) {
			handleICECandidate(parsedSignal)
		} else if (parsedSignal.type === 'offer') {
			await handleOffer(parsedSignal)
		} else if (parsedSignal.type === 'answer') {
			await handleAnswer(parsedSignal)
		} else {
			console.warn(`Unknown signal type ${parsedSignal.type}`)
		}
	})

	const sendVoiceSignal = (signal: string) => {
		connection
			.invoke('SendVoiceSignal', signal)
			.catch((err) => console.log(`SignalR sendVoiceSignal error ${err}`))
	}

	const createAndSendOffer = async () => {
		localStream
			.getTracks()
			.forEach((track) => peerConnection.addTrack(track, localStream))

		const offer = await peerConnection.createOffer()
		await peerConnection.setLocalDescription(offer)

		console.log(
			'WebRTC PeerConnection senders: ',
			peerConnection.getSenders(),
		)

		sendVoiceSignal(JSON.stringify(offer))
	}

	let iceCandidateQueue: RTCIceCandidateInit[] = []
	const handleOffer = async (offer: RTCSessionDescriptionInit) => {
		try {
			await peerConnection.setRemoteDescription(offer)

			const answer = await peerConnection.createAnswer()
			await peerConnection.setLocalDescription(answer)

			sendVoiceSignal(JSON.stringify(answer))

			while (iceCandidateQueue.length) {
				const candidate = iceCandidateQueue.shift()
				if (candidate) {
					await peerConnection.addIceCandidate(candidate)
				}
			}
		} catch (err) {
			console.error('Failed to handle offer:', err)
		}
	}

	const handleAnswer = async (answer: RTCSessionDescriptionInit) => {
		try {
			const sessionDescription = new RTCSessionDescription(answer)

			if (peerConnection.connectionState === 'closed') {
				console.warn(
					'Peer connection is closed. Cannot set remote description.',
				)
				return
			}

			if (
				peerConnection.signalingState !== 'have-remote-offer' &&
				peerConnection.signalingState !== 'have-local-offer'
			) {
				console.warn(
					'Invalid signaling state for setting remote description:',
					peerConnection.signalingState,
				)
				return
			}

			await peerConnection.setRemoteDescription(sessionDescription)

			while (iceCandidateQueue.length) {
				const candidate = iceCandidateQueue.shift()
				if (candidate) {
					await peerConnection.addIceCandidate(candidate)
				}
			}
		} catch (err) {
			console.error('Failed to handle answer:', err)
		}
	}

	let iceCandidateNumber = 0
	const handleICECandidate = async (candidateData: any) => {
		console.log(
			iceCandidateNumber + ' Received ICE Candidate from SignalR',
			candidateData,
		)
		if (candidateData.candidate) {
			const candidate = new RTCIceCandidate(candidateData)
			console.log('Adding ICE Candidate ', candidate)
			try {
				await peerConnection.addIceCandidate(candidate)
			} catch (err) {
				console.error(
					iceCandidateNumber + ' Failed to handle ICE candidate:',
					err,
				)
			}
		}
		iceCandidateNumber++
	}

	const remoteStream = new MediaStream()
	const remoteAudio = new Audio()
	remoteAudio.srcObject = remoteStream
	peerConnection.ontrack = (event) => {
		event.streams[0].getTracks().forEach((track) => {
			remoteStream.addTrack(track)
		})
	}
	$('body').append(remoteAudio)
	remoteAudio.play()

	peerConnection.onicecandidate = (event) => {
		console.log('WebRTC received ICECandidate', event.candidate)
		sendVoiceSignal(JSON.stringify(event.candidate))
	}
	peerConnection.oniceconnectionstatechange = () => {
		console.log(
			'ICE connection state changed:',
			peerConnection.iceConnectionState,
		)
	}
	peerConnection.onicecandidateerror = (event) => {
		console.error('ICE candidate error:', event)
	}
	peerConnection.onsignalingstatechange = (event) => {
		console.log('WebRTC signaling state changed: ', event)
	}

	try {
		await connection.start()
		console.log('SignalR connection started')
	} catch (err) {
		console.error(`SignalR connection error ${err}`)
	}

	await setupLocalStream()

	$('#startCall').on('click', createAndSendOffer)
}
