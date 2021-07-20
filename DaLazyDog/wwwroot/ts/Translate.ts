export class Translate {
    static language: string ="en";
    translate(key): string {
        let xrhFile = new XMLHttpRequest();
        //load content data 
        xrhFile.open("GET", "./resources/" + Translate.language + ".json", false);
        xrhFile.onreadystatechange = function () {
            if (xrhFile.readyState === 4) {
                if (xrhFile.status === 200 || xrhFile.status == 0) {
                    let LngObject = JSON.parse(xrhFile.responseText);
                    return LngObject["key"];

                }
                return key;
            }
            return key;
        }
        xrhFile.send();
        return key;
    };
    say(): string {
        console.log("hello");
        return "hello";
    }
}