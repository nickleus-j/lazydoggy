import { Translate } from "./Translate";
class ExcuseLetter{
    ExcuseTitle:string;
    LetterTemplateContent:string;
    constructor(ExcuseTitle: string, LetterTemplateContent: string) {  
        this.ExcuseTitle = ExcuseTitle;  
        this.LetterTemplateContent = LetterTemplateContent; 
    }
    getTitleContent(): String{
        let t = new Translate();
        return t.translate("excusecolon").concat(this.ExcuseTitle, "\n", t.translate("letterTemplate"), " ", this.LetterTemplateContent);
    }
}