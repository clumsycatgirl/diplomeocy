export type ResultError = {
	field: string
	errors: string[]
}

export type ErrorResult = {
	success: false
	errors: ResultError[]
}

export type NotFoundResult = {
	success: false
	what: string
}

export type RedirectResult = {
	success: true
	destination: string
}

type Result = { success: boolean } & (ErrorResult | NotFoundResult | RedirectResult)
export default Result

export const isErrorResult = (result: Result): result is ErrorResult => result.success === false && 'errors' in result
export const isNotFoundResult = (result: Result): result is NotFoundResult => result.success === false && 'what' in result
export const isRedirectResult = (result: Result): result is RedirectResult => result.success === true && 'destination' in result

declare global {
	interface Promise<T> {
		toResult(): Promise<Result>
	}
}

Promise.prototype.toResult = async function (this: Promise<Response>): Promise<Result> {
	try {
		const response = await this

		if (!response.ok) {
			const errorData = await response.json()
			return {
				success: false,
				errors: [
					{
						field: 'general',
						errors: [errorData?.message || 'Unknown error'],
					},
				],
			}
		}

		const resultData: Result = await response.json()

		return resultData
	} catch (error) {
		return {
			success: false,
			errors: [
				{
					field: 'general',
					errors: [error instanceof Error ? error.message : 'Unknown error'],
				},
			],
		}
	}
}

export const ResultRequest = (endpoint: string, body: object, method: string = 'POST') => {
	const formBody = Object.keys(body)
		.map((key) => encodeURIComponent(key) + '=' + encodeURIComponent(body[key as keyof typeof body] as string))
		.join('&')

	return fetch(endpoint, {
		method: method.toUpperCase(),
		body: formBody,
		headers: {
			'Content-Type': 'application/x-www-form-urlencoded',
		},
	}).toResult()
}
