var ExcuseLetter = (function () {
    function ExcuseLetter(ExcuseTitle, LetterTemplateContent) {
        this.ExcuseTitle = ExcuseTitle;
        this.LetterTemplateContent = LetterTemplateContent;
    }
    ExcuseLetter.prototype.getTitleContent = function () {
        return "Excuse: ".concat(this.ExcuseTitle, "\n Letter Template ", this.LetterTemplateContent);
    };
    return ExcuseLetter;
}());
//# sourceMappingURL=ExcuseLetter.js.map