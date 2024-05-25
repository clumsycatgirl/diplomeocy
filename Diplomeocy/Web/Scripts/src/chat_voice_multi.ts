import * as signalR from '@microsoft/signalr'

export class ChatRoom {
	private connection: signalR.HubConnection
	private peerConnection: RTCPeerConnection
	private localStream: MediaStream
	private remoteStream: MediaStream
	private remoteAudio: HTMLAudioElement
	private iceCandidateQueue: RTCIceCandidateInit[] = []
	private iceCandidateNumber = 0
	private config: any

	constructor(private chatRoomId: string) {
		this.remoteStream = new MediaStream()
		this.remoteAudio = new Audio()
		this.remoteAudio.srcObject = this.remoteStream
		document.body.append(this.remoteAudio)
		this.remoteAudio.play()
	}

	async start() {
		await this.fetchIceServers()
		await this.setupSignalR()
		await this.setupWebRTC()
		await this.setupLocalStream()
	}

	private async fetchIceServers() {
		return new Promise<void>((resolve, reject) => {
			const xhr = new XMLHttpRequest()
			xhr.onreadystatechange = () => {
				if (xhr.readyState == 4 && xhr.status == 200) {
					let res = JSON.parse(xhr.responseText)
					this.config = res.v.iceServers
					resolve()
				}
			}
			xhr.open('PUT', 'https://global.xirsys.net/_turn/Diplomeocy', true)
			xhr.setRequestHeader('Authorization', 'Basic ' + btoa('ivysmnope:30e84c06-1773-11ef-a8d0-0242ac130002'))
			xhr.setRequestHeader('Content-Type', 'application/json')
			xhr.send(JSON.stringify({ format: 'urls' }))
		})
	}

	private async setupSignalR() {
		this.connection = new signalR.HubConnectionBuilder().withUrl(`/chat/text`).build()

		this.connection.on('ReceiveVoiceSignal', async (signal: string) => {
			let parsedSignal: any
			try {
				parsedSignal = JSON.parse(signal)
			} catch (err) {
				return
			}

			if (parsedSignal.candidate) {
				await this.handleICECandidate(parsedSignal)
			} else if (parsedSignal.type === 'offer') {
				await this.handleOffer(parsedSignal)
			} else if (parsedSignal.type === 'answer') {
				await this.handleAnswer(parsedSignal)
			}
		})

		try {
			await this.connection.start()
		} catch (err) {}
	}

	private async setupWebRTC() {
		const configuration: RTCConfiguration = {
			iceServers: [
				{ urls: 'stun:stun.l.google.com:19302' },
				...this.config.urls.map((url: any) => ({
					urls: url,
					username: this.config.username,
					credential: this.config.credential,
				})),
			],
			iceCandidatePoolSize: 10,
		}

		this.peerConnection = new RTCPeerConnection(configuration)

		this.peerConnection.ontrack = (event) => {
			event.streams[0].getTracks().forEach((track) => {
				this.remoteStream.addTrack(track)
			})
		}

		this.peerConnection.onicecandidate = (event) => {
			this.sendVoiceSignal(JSON.stringify(event.candidate))
		}

		this.peerConnection.oniceconnectionstatechange = () => {}
		this.peerConnection.onicecandidateerror = (event) => {}
		this.peerConnection.onsignalingstatechange = (event) => {}
	}

	private async setupLocalStream() {
		try {
			this.localStream = await navigator.mediaDevices.getUserMedia({
				audio: true,
			})
		} catch (err) {}
	}

	private sendVoiceSignal(signal: string) {
		this.connection
			.invoke(
				'SendVoiceGroupSignal',
				`${(document.getElementById('group') as HTMLInputElement).value}-${(document.getElementById('join-group-input') as HTMLSelectElement).value}`,
				signal,
			)
			.catch((err) => {})
	}

	private async createAndSendOffer() {
		this.localStream.getTracks().forEach((track) => this.peerConnection.addTrack(track, this.localStream))

		const offer = await this.peerConnection.createOffer()
		await this.peerConnection.setLocalDescription(offer)

		this.sendVoiceSignal(JSON.stringify(offer))
	}

	private async handleOffer(offer: RTCSessionDescriptionInit) {
		try {
			await this.peerConnection.setRemoteDescription(offer)

			const answer = await this.peerConnection.createAnswer()
			await this.peerConnection.setLocalDescription(answer)

			this.sendVoiceSignal(JSON.stringify(answer))

			while (this.iceCandidateQueue.length) {
				const candidate = this.iceCandidateQueue.shift()
				if (candidate) {
					await this.peerConnection.addIceCandidate(candidate)
				}
			}
		} catch (err) {}
	}

	private async handleAnswer(answer: RTCSessionDescriptionInit) {
		try {
			const sessionDescription = new RTCSessionDescription(answer)

			if (this.peerConnection.connectionState === 'closed') {
				return
			}

			if (this.peerConnection.signalingState !== 'have-remote-offer' && this.peerConnection.signalingState !== 'have-local-offer') {
				return
			}

			await this.peerConnection.setRemoteDescription(sessionDescription)

			while (this.iceCandidateQueue.length) {
				const candidate = this.iceCandidateQueue.shift()
				if (candidate) {
					await this.peerConnection.addIceCandidate(candidate)
				}
			}
		} catch (err) {}
	}

	private async handleICECandidate(candidateData: any) {
		if (candidateData.candidate) {
			const candidate = new RTCIceCandidate(candidateData)
			try {
				await this.peerConnection.addIceCandidate(candidate)
			} catch (err) {}
		}
		this.iceCandidateNumber++
	}
}
