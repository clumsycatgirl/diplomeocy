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

/***/ "./src/message_data.ts":
/*!*****************************!*\
  !*** ./src/message_data.ts ***!
  \*****************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

eval("__webpack_require__.r(__webpack_exports__);\n/* harmony export */ __webpack_require__.d(__webpack_exports__, {\n/* harmony export */   MessageData: () => (/* binding */ MessageData)\n/* harmony export */ });\nclass MessageData {\r\n    constructor(action, group, sender, message = null) {\r\n        this.action = action;\r\n        this.group = group;\r\n        this.sender = sender;\r\n        this.message = message;\r\n    }\r\n    get Action() {\r\n        return this.action;\r\n    }\r\n    set Action(value) {\r\n        this.action = value;\r\n    }\r\n    get Group() {\r\n        return this.group;\r\n    }\r\n    set Group(value) {\r\n        this.group = value;\r\n    }\r\n    get Sender() {\r\n        return this.sender;\r\n    }\r\n    set Sender(value) {\r\n        this.sender = value;\r\n    }\r\n    get Message() {\r\n        return this.message;\r\n    }\r\n    set Message(value) {\r\n        this.message = value;\r\n    }\r\n    get json() {\r\n        return JSON.stringify({\r\n            Action: this.action,\r\n            Group: this.group,\r\n            Sender: this.sender,\r\n            Message: this.message,\r\n        });\r\n    }\r\n    get jsonObject() {\r\n        return JSON.parse(this.json);\r\n    }\r\n}\r\n\n\n//# sourceURL=webpack://myapp-client-bundle/./src/message_data.ts?");

/***/ })

/******/ 	});
/************************************************************************/
/******/ 	// The require scope
/******/ 	var __webpack_require__ = {};
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
/******/ 	var __webpack_exports__ = {};
/******/ 	__webpack_modules__["./src/message_data.ts"](0, __webpack_exports__, __webpack_require__);
/******/ 	
/******/ })()
;