/******/ (() => { // webpackBootstrap
/******/ 	"use strict";
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
/************************************************************************/
var __webpack_exports__ = {};
/* unused harmony export MessageData */
class MessageData {
    constructor(action, group, sender, message = null) {
        this.action = action;
        this.group = group;
        this.sender = sender;
        this.message = message;
    }
    get Action() {
        return this.action;
    }
    set Action(value) {
        this.action = value;
    }
    get Group() {
        return this.group;
    }
    set Group(value) {
        this.group = value;
    }
    get Sender() {
        return this.sender;
    }
    set Sender(value) {
        this.sender = value;
    }
    get Message() {
        return this.message;
    }
    set Message(value) {
        this.message = value;
    }
    get json() {
        return JSON.stringify({
            Action: this.action,
            Group: this.group,
            Sender: this.sender,
            Message: this.message,
        });
    }
    get jsonObject() {
        return JSON.parse(this.json);
    }
}

/******/ })()
;