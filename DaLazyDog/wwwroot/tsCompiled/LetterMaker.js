var LetterMaker = (function () {
    function LetterMaker(item) {
    }
    LetterMaker.prototype.makeLetter = function (templateText, oldText, replacement, ddlData) {
        var content;
        content = this.formatTextForGeneratedLetters(templateText.replace(oldText, replacement));
        return this.makeDdlFromData(content, ddlData);
    };
    LetterMaker.prototype.makeDdlFromData = function (oldText, ddlData) {
        var result = oldText;
        var maker = this;
        Object.keys(ddlData).forEach(function (key) {
            result = result.replace(new RegExp("(s|)+([|]+" + key + ")"), maker.createSelectTagFromArray(ddlData[key]));
        });
        var defaultArr = ["Thanks", "Sincerly"];
        return this.replaceSubStringMatchingregEx(new RegExp("(\s|)+([\|]+[a-zA-Z]*)"), result, maker.createSelectTagFromArray(defaultArr));
    };
    LetterMaker.prototype.createSelectTagFromArray = function (arr) {
        var result = "<select class='form-control'>";
        for (var ctr = 0; ctr < arr.length; ctr++) {
            result = result.concat("<option>" + arr[ctr] + "</option>");
        }
        return result.concat("</select>");
    };
    LetterMaker.prototype.replaceSubStringMatchingregEx = function (regex, text, replacement) {
        if (replacement === void 0) { replacement = ""; }
        var replacedText = text;
        while (regex.test(replacedText)) {
            replacedText = replacedText.replace(regex, replacement);
        }
        return replacedText;
    };
    LetterMaker.prototype.replaceSubstringInsrances = function (oldText, substringToReplace, replacement) {
        if (replacement === void 0) { replacement = ""; }
        if (oldText.indexOf(substringToReplace) >= 0) {
            return this.replaceSubstringInsrances(oldText.replace(substringToReplace, replacement), substringToReplace, replacement);
        }
        return oldText;
    };
    LetterMaker.prototype.formatTextForGeneratedLetters = function (oldText) {
        var text;
        var regex = new RegExp("(\s|)+(\`+[a-zA-Z]*)");
        text = this.replaceSubstringInsrances(this.replaceSubstringInsrances(this.replaceSubStringMatchingregEx(regex, oldText, "<input class='form-control'/> "), " ~", ""), "~", "");
        return this.replaceSubstringInsrances(text, "<br/>");
    };
    return LetterMaker;
}());
//# sourceMappingURL=LetterMaker.js.map