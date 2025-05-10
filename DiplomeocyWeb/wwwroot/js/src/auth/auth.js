var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
import { isErrorResult, isNotFoundResult, isRedirectResult, ResultRequest } from '../results';
const handleResult = (result) => {
    $('.is-invalid').removeClass('is-invalid');
    $('.text-danger').text('');
    if (isErrorResult(result)) {
        result.errors.forEach((error) => {
            $(`#${error.field.toLowerCase()}`).addClass('is-invalid');
            $(`#${error.field.toLowerCase()}`).siblings('.text-danger').text(error.errors.join(', '));
        });
    }
    if (isNotFoundResult(result)) {
        $(`#username`).addClass('is-invalid').siblings('.text-danger').text(result.what);
    }
    if (isRedirectResult(result)) {
        window.location.href = result.destination;
    }
};
window.Diplomeocy.Auth = {
    pfpOnChange() {
        const $element = $('#profile-picture');
        const $image = $('#profile-picture-preview');
        $image.attr('src', $element.val());
    },
    login() {
        return __awaiter(this, void 0, void 0, function* () {
            const result = yield ResultRequest('/Auth/Login', {
                username: $('#username').val(),
                password: $('#password').val(),
                __RequestVerificationToken: $('#antiforgery-token').val(),
            });
            handleResult(result);
        });
    },
    register() {
        return __awaiter(this, void 0, void 0, function* () {
            const result = yield ResultRequest('/Auth/Register', {
                username: $('#username').val(),
                password: $('#password').val(),
                passwordconfirmation: $('#passwordconfirmation').val(),
                picturepath: $('#profile-picture').val(),
            });
            handleResult(result);
        });
    },
};
