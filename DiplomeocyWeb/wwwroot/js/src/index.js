var _a, _b;
import HSCollapse from '@preline/collapse';
export var Diplomeocy;
(function (Diplomeocy) {
    function meow() {
        console.log('meow');
    }
    Diplomeocy.meow = meow;
    function updateTheme(theme) {
        document.documentElement.className = theme.toLowerCase();
    }
    Diplomeocy.updateTheme = updateTheme;
    function reloadHtmx() {
        var _a;
        console.log('htmx: reloading document.body');
        (_a = window.htmx) === null || _a === void 0 ? void 0 : _a.process(document.body);
    }
    Diplomeocy.reloadHtmx = reloadHtmx;
    function reloadCollapse() {
        HSCollapse.autoInit();
    }
    Diplomeocy.reloadCollapse = reloadCollapse;
    let Auth;
    (function (Auth) {
    })(Auth = Diplomeocy.Auth || (Diplomeocy.Auth = {}));
    let Header;
    (function (Header) {
    })(Header = Diplomeocy.Header || (Diplomeocy.Header = {}));
    let Tables;
    (function (Tables) {
        let Sidebar;
        (function (Sidebar) {
        })(Sidebar = Tables.Sidebar || (Tables.Sidebar = {}));
    })(Tables = Diplomeocy.Tables || (Diplomeocy.Tables = {}));
    let Game;
    (function (Game) {
    })(Game = Diplomeocy.Game || (Diplomeocy.Game = {}));
})(Diplomeocy || (Diplomeocy = {}));
window.Diplomeocy = window.Diplomeocy || Diplomeocy;
(_b = (_a = window.Diplomeocy).meow) === null || _b === void 0 ? void 0 : _b.call(_a);
export const onLoad = (callback) => {
    document.addEventListener('DOMContentLoaded', callback);
};
