import { SimpleInterest } from "./SimpleInterest";

class SimpleInterestCompo {
    constructor(principalId: string, interestId: string, yearsid: string, AmountAccuredId: string) {
        this.principalDomId = principalId;
        this.interestDomId = interestId;
        this.yearsDomID = yearsid;
        this.AmountAccuredDom = document.getElementById(AmountAccuredId);
        this.PrincipalBox = document.getElementById(principalId);
        this.InterestBox = document.getElementById(interestId);
        this.YearsBox = document.getElementById(yearsid);
    }
    model: SimpleInterest;
    principalDomId: string;
    interestDomId: string;
    yearsDomID: string;
    AmountAccuredDom: HTMLElement;
    PrincipalBox: HTMLElement;
    InterestBox: HTMLElement;
    YearsBox: HTMLElement;
    ResultBtnDom: HTMLElement;
    public showAccuredResult() {
        this.model = new SimpleInterest(parseFloat(this.PrincipalBox.nodeValue), parseFloat(this.InterestBox.nodeValue), parseFloat(this.YearsBox.nodeValue))
        this.AmountAccuredDom.textContent = "Amount To Pay: " + this.model.GetAmountAccured();
    }
}
window.onload = () => {
    var obj = new SimpleInterest(250000, 5, 2);
    console.log(obj.GetAmountAccured());
};  
const saC = new SimpleInterest(250000, 5, 2);