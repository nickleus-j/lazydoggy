var LetterMaker = (function () {
    function LetterMaker(item) {
    }
    LetterMaker.prototype.makeLetter = function (templateText, oldText, replacement) {
        var content;
        content = templateText.replace(oldText, replacement);
        return this.removeTildeAndBr(content);
    };
    LetterMaker.prototype.removeTildeAndBr = function (oldText) {
        var text = oldText;
        while (text.indexOf(' ~') >= 0) {
            text = text.replace(" ~", "");
        }
        while (text.indexOf('~') >= 0) {
            text = text.replace("~", "");
        }
        while (text.indexOf('<br/>') >= 0) {
            text = text.replace("<br/>", "");
        }
        return text;
    };
    return LetterMaker;
}());
//# sourceMappingURL=LetterMaker.js.map