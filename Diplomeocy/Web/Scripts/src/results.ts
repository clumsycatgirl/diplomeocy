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

type Result = { success: boolean } & (
	| ErrorResult
	| NotFoundResult
	| RedirectResult
)
export default Result

export const isErrorResult = (result: Result): result is ErrorResult =>
	result.success === false && 'errors' in result

export const isNotFoundResult = (result: Result): result is NotFoundResult =>
	result.success === false && 'what' in result

export const isRedirectResult = (result: Result): result is RedirectResult =>
	result.success === true && 'destination' in result
