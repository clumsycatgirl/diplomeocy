var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
export const isErrorResult = (result) => result.success === false && 'errors' in result;
export const isNotFoundResult = (result) => result.success === false && 'what' in result;
export const isRedirectResult = (result) => result.success === true && 'destination' in result;
Promise.prototype.toResult = function () {
    return __awaiter(this, void 0, void 0, function* () {
        try {
            const response = yield this;
            if (!response.ok) {
                const errorData = yield response.json();
                return {
                    success: false,
                    errors: [
                        {
                            field: 'general',
                            errors: [(errorData === null || errorData === void 0 ? void 0 : errorData.message) || 'Unknown error'],
                        },
                    ],
                };
            }
            const resultData = yield response.json();
            return resultData;
        }
        catch (error) {
            return {
                success: false,
                errors: [
                    {
                        field: 'general',
                        errors: [error instanceof Error ? error.message : 'Unknown error'],
                    },
                ],
            };
        }
    });
};
export const ResultRequest = (endpoint, body, method = 'POST') => {
    const formBody = Object.keys(body)
        .map((key) => encodeURIComponent(key) + '=' + encodeURIComponent(body[key]))
        .join('&');
    return fetch(endpoint, {
        method: method.toUpperCase(),
        body: formBody,
        headers: {
            'Content-Type': 'application/x-www-form-urlencoded',
        },
    }).toResult();
};
