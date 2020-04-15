class ExcuseLetter{
    ExcuseTitle:string;
    LetterTemplateContent:string;
    constructor(ExcuseTitle: string, LetterTemplateContent: string) {  
        this.ExcuseTitle = ExcuseTitle;  
        this.LetterTemplateContent = LetterTemplateContent; 
    }
    getTitleContent():String{
        return "Excuse: ".concat(this.ExcuseTitle,"\n Letter Template ",this.LetterTemplateContent);
    }
}