/*
 * ATTENTION: The "eval" devtool has been used (maybe by default in mode: "development").
 * This devtool is neither made for production nor for readable output files.
 * It uses "eval()" calls to create a separate source file in the browser devtools.
 * If you are trying to read the output file, select a different devtool (https://webpack.js.org/configuration/devtool/)
 * or disable the default devtool with "devtool: false".
 * If you are looking for production-ready output files, see mode: "production" (https://webpack.js.org/configuration/mode/).
 */
/******/ (() => { // webpackBootstrap
/******/ 	"use strict";
/******/ 	var __webpack_modules__ = ({

/***/ "./src/header.ts":
/*!***********************!*\
  !*** ./src/header.ts ***!
  \***********************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

eval("__webpack_require__.r(__webpack_exports__);\n/* harmony import */ var _results__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ./results */ \"./src/results.ts\");\nvar __awaiter = (undefined && undefined.__awaiter) || function (thisArg, _arguments, P, generator) {\n    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }\n    return new (P || (P = Promise))(function (resolve, reject) {\n        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }\n        function rejected(value) { try { step(generator[\"throw\"](value)); } catch (e) { reject(e); } }\n        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }\n        step((generator = generator.apply(thisArg, _arguments || [])).next());\n    });\n};\n\nwindow.Diplomeocy.Header.setup = () => {\n    const joinLink = $('#join-link');\n    const inputContainer = $('#join-input-container');\n    const input = $('#join-input');\n    const submitButton = $('#join-submit-button');\n    joinLink.on('mouseenter', () => {\n        inputContainer.removeClass('translate-x-[100%] hidden');\n        joinLink.addClass('translate-x-[200%]');\n    });\n    const hideInput = () => {\n        if (!input.is(':focus') && !inputContainer.is(':hover')) {\n            inputContainer.addClass('translate-x-[100%]');\n            joinLink.removeClass('translate-x-[200%]');\n            input.val('');\n        }\n    };\n    inputContainer.on('mouseleave', hideInput);\n    input.on('blur', hideInput);\n    input.on('mouseleave', hideInput);\n    input.on('keypress', (e) => {\n        if (e.which === 13) {\n            submitButton.trigger('click');\n        }\n        if (!/[0-9]/.test(e.key)) {\n            e.preventDefault();\n        }\n    });\n    console.log(submitButton);\n    submitButton.on('click', () => __awaiter(void 0, void 0, void 0, function* () {\n        const tableId = input.val();\n        console.log(tableId);\n        const result = yield (0,_results__WEBPACK_IMPORTED_MODULE_0__.ResultRequest)(`/Table/Join/${tableId}`, {});\n        if ((0,_results__WEBPACK_IMPORTED_MODULE_0__.isRedirectResult)(result)) {\n            window.location.href = result.destination;\n            return;\n        }\n        // not gonna handle errors for this I just don't feel like it\n        // TODO: show a message of some sort idk idc i want to kms\n    }));\n};\nwindow.Diplomeocy.Tables.Sidebar = {\n    setup: function () {\n        const tabButtons = document.querySelectorAll('[data-hs-tab]');\n        const tabPanels = document.querySelectorAll('[role=\"tabpanel\"]');\n        tabButtons.forEach((button) => {\n            button.addEventListener('click', function () {\n                const targetTab = document.querySelector(this.getAttribute('data-hs-tab'));\n                tabPanels.forEach((panel) => {\n                    panel.classList.add('hidden');\n                    panel.classList.remove('block');\n                });\n                targetTab.classList.remove('hidden');\n                targetTab.classList.add('block');\n                tabButtons.forEach((btn) => btn.classList.remove('active'));\n                this.classList.add('active');\n            });\n        });\n        if (tabButtons.length > 0) {\n            ;\n            tabButtons[0].click();\n        }\n    },\n};\n\n\n//# sourceURL=webpack://myapp-client-bundle/./src/header.ts?");

/***/ }),

/***/ "./src/results.ts":
/*!************************!*\
  !*** ./src/results.ts ***!
  \************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

eval("__webpack_require__.r(__webpack_exports__);\n/* harmony export */ __webpack_require__.d(__webpack_exports__, {\n/* harmony export */   ResultRequest: () => (/* binding */ ResultRequest),\n/* harmony export */   isErrorResult: () => (/* binding */ isErrorResult),\n/* harmony export */   isNotFoundResult: () => (/* binding */ isNotFoundResult),\n/* harmony export */   isRedirectResult: () => (/* binding */ isRedirectResult)\n/* harmony export */ });\nvar __awaiter = (undefined && undefined.__awaiter) || function (thisArg, _arguments, P, generator) {\n    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }\n    return new (P || (P = Promise))(function (resolve, reject) {\n        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }\n        function rejected(value) { try { step(generator[\"throw\"](value)); } catch (e) { reject(e); } }\n        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }\n        step((generator = generator.apply(thisArg, _arguments || [])).next());\n    });\n};\nconst isErrorResult = (result) => result.success === false && 'errors' in result;\nconst isNotFoundResult = (result) => result.success === false && 'what' in result;\nconst isRedirectResult = (result) => result.success === true && 'destination' in result;\nPromise.prototype.toResult = function () {\n    return __awaiter(this, void 0, void 0, function* () {\n        try {\n            const response = yield this;\n            if (!response.ok) {\n                const errorData = yield response.json();\n                return {\n                    success: false,\n                    errors: [\n                        {\n                            field: 'general',\n                            errors: [(errorData === null || errorData === void 0 ? void 0 : errorData.message) || 'Unknown error'],\n                        },\n                    ],\n                };\n            }\n            const resultData = yield response.json();\n            return resultData;\n        }\n        catch (error) {\n            return {\n                success: false,\n                errors: [\n                    {\n                        field: 'general',\n                        errors: [error instanceof Error ? error.message : 'Unknown error'],\n                    },\n                ],\n            };\n        }\n    });\n};\nconst ResultRequest = (endpoint, body, method = 'POST') => {\n    const formBody = Object.keys(body)\n        .map((key) => encodeURIComponent(key) + '=' + encodeURIComponent(body[key]))\n        .join('&');\n    return fetch(endpoint, {\n        method: method.toUpperCase(),\n        body: formBody,\n        headers: {\n            'Content-Type': 'application/x-www-form-urlencoded',\n        },\n    }).toResult();\n};\n\n\n//# sourceURL=webpack://myapp-client-bundle/./src/results.ts?");

/***/ })

/******/ 	});
/************************************************************************/
/******/ 	// The module cache
/******/ 	var __webpack_module_cache__ = {};
/******/ 	
/******/ 	// The require function
/******/ 	function __webpack_require__(moduleId) {
/******/ 		// Check if module is in cache
/******/ 		var cachedModule = __webpack_module_cache__[moduleId];
/******/ 		if (cachedModule !== undefined) {
/******/ 			return cachedModule.exports;
/******/ 		}
/******/ 		// Create a new module (and put it into the cache)
/******/ 		var module = __webpack_module_cache__[moduleId] = {
/******/ 			// no module.id needed
/******/ 			// no module.loaded needed
/******/ 			exports: {}
/******/ 		};
/******/ 	
/******/ 		// Execute the module function
/******/ 		__webpack_modules__[moduleId](module, module.exports, __webpack_require__);
/******/ 	
/******/ 		// Return the exports of the module
/******/ 		return module.exports;
/******/ 	}
/******/ 	
/************************************************************************/
/******/ 	/* webpack/runtime/define property getters */
/******/ 	(() => {
/******/ 		// define getter functions for harmony exports
/******/ 		__webpack_require__.d = (exports, definition) => {
/******/ 			for(var key in definition) {
/******/ 				if(__webpack_require__.o(definition, key) && !__webpack_require__.o(exports, key)) {
/******/ 					Object.defineProperty(exports, key, { enumerable: true, get: definition[key] });
/******/ 				}
/******/ 			}
/******/ 		};
/******/ 	})();
/******/ 	
/******/ 	/* webpack/runtime/hasOwnProperty shorthand */
/******/ 	(() => {
/******/ 		__webpack_require__.o = (obj, prop) => (Object.prototype.hasOwnProperty.call(obj, prop))
/******/ 	})();
/******/ 	
/******/ 	/* webpack/runtime/make namespace object */
/******/ 	(() => {
/******/ 		// define __esModule on exports
/******/ 		__webpack_require__.r = (exports) => {
/******/ 			if(typeof Symbol !== 'undefined' && Symbol.toStringTag) {
/******/ 				Object.defineProperty(exports, Symbol.toStringTag, { value: 'Module' });
/******/ 			}
/******/ 			Object.defineProperty(exports, '__esModule', { value: true });
/******/ 		};
/******/ 	})();
/******/ 	
/************************************************************************/
/******/ 	
/******/ 	// startup
/******/ 	// Load entry module and return exports
/******/ 	// This entry module can't be inlined because the eval devtool is used.
/******/ 	var __webpack_exports__ = __webpack_require__("./src/header.ts");
/******/ 	
/******/ })()
;