"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var Translate_1 = require("./Translate");
var ExcuseLetter = (function () {
    function ExcuseLetter(ExcuseTitle, LetterTemplateContent) {
        this.ExcuseTitle = ExcuseTitle;
        this.LetterTemplateContent = LetterTemplateContent;
    }
    ExcuseLetter.prototype.getTitleContent = function () {
        var t = new Translate_1.Translate();
        return t.translate("excusecolon").concat(this.ExcuseTitle, "\n", t.translate("letterTemplate"), " ", this.LetterTemplateContent);
    };
    return ExcuseLetter;
}());
//# sourceMappingURL=ExcuseLetter.js.map