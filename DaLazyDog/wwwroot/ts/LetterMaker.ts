class LetterMaker {
    constructor(item:string) { }
    makeLetter(templateText: string, oldText: string,replacement:string): string {
        let content: string;
        content = templateText.replace(oldText, replacement);
        return this.removeTildeAndBr(content);
    }//`Excuse
    removeTildeAndBr(oldText: string): string {
        let text:string = oldText;
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
    }
}