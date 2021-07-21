"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.Translate = void 0;
var Translate = (function () {
    function Translate() {
    }
    Translate.prototype.translate = function (key) {
        var xrhFile = new XMLHttpRequest();
        xrhFile.open("GET", "./resources/" + Translate.language + ".json", false);
        xrhFile.onreadystatechange = function () {
            if (xrhFile.readyState === 4) {
                if (xrhFile.status === 200 || xrhFile.status == 0) {
                    var LngObject = JSON.parse(xrhFile.responseText);
                    return LngObject["key"];
                }
                return key;
            }
            return key;
        };
        xrhFile.send();
        return key;
    };
    ;
    Translate.prototype.say = function () {
        console.log("hello");
        return "hello";
    };
    Translate.language = "en";
    return Translate;
}());
exports.Translate = Translate;
//# sourceMappingURL=Translate.js.map