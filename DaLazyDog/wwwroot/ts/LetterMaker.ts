class LetterMaker {
    constructor(item: string) { }
    makeLetter(templateText: string, oldText: string, replacement: string): string {
        let content: string;
        content = templateText.replace(oldText, replacement);
        return this.removeTildeAndBr(content);
    }
    removeTildeAndBr(oldText: string): string {
        let text: string = oldText;
        let regex = new RegExp("(\s|)+(\`+[a-zA-Z]*)");
        while (regex.test(text)) {
            text = text.replace(regex, "<input class='form-control'/> ");
        }
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