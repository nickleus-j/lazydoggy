import { Translate } from "./Translate";
class LetterMaker {
    Translator: Translate;
    constructor(item: string) { this.Translator = new Translate(); }
    makeLetter(templateText: string, oldText: string, replacement: string,ddlData:object): string {
        let content: string;
        content = this.formatTextForGeneratedLetters(templateText.replace(oldText, replacement));
        return this.makeDdlFromData(content, ddlData);
    }
    makeDdlFromData(oldText: string, ddlData: object): string {
        let result: string = oldText;
        let maker = this;
        Object.keys(ddlData).forEach(function (key) {
            result = result.replace(new RegExp(`(\s|)+([\|]+${key})`), maker.createSelectTagFromArray(ddlData[key]));
        });
        let defaultArr: string[] = [this.Translator.translate("thanks"), this.Translator.translate("sincerly")];
        return this.replaceSubStringMatchingregEx(new RegExp("(\s|)+([\|]+[a-zA-Z]*)"), result, maker.createSelectTagFromArray(defaultArr));
    }
    createSelectTagFromArray(arr:  unknown[]): string {
        let result: string = "<select class='form-control'>";
        for (var ctr = 0; ctr < arr.length; ctr++) {
            result = result.concat(`<option>${arr[ctr]}</option>`)
        }
        return result.concat("</select>");
    }
    replaceSubStringMatchingregEx(regex: RegExp, text: string,replacement:string="") :string{
        let replacedText: string = text;
        while (regex.test(replacedText)) {
            replacedText = replacedText.replace(regex, replacement);
        }
        return replacedText;
    }
    replaceSubstringInsrances(oldText: string, substringToReplace: string, replacement: string=""): string {
        if (oldText.indexOf(substringToReplace) >= 0) {
            return this.replaceSubstringInsrances(oldText.replace(substringToReplace, replacement), substringToReplace, replacement);
        }
        return oldText;
    }
    
    formatTextForGeneratedLetters(oldText: string): string {
        let text: string;
        let regex = new RegExp("(\s|)+(\`+[a-zA-Z]*)");
        
        text = this.replaceSubstringInsrances(
                this.replaceSubstringInsrances(
                    this.replaceSubStringMatchingregEx(regex, oldText, "<input class='form-control'/> "),
                " ~", "")
            , "~", "");
        return this.replaceSubstringInsrances(text, "<br/>");
    }
}