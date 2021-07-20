"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var SimpleInterest_1 = require("./SimpleInterest");
var SimpleInterestCompo = (function () {
    function SimpleInterestCompo(principalId, interestId, yearsid, AmountAccuredId) {
        this.principalDomId = principalId;
        this.interestDomId = interestId;
        this.yearsDomID = yearsid;
        this.AmountAccuredDom = document.getElementById(AmountAccuredId);
        this.PrincipalBox = document.getElementById(principalId);
        this.InterestBox = document.getElementById(interestId);
        this.YearsBox = document.getElementById(yearsid);
    }
    SimpleInterestCompo.prototype.showAccuredResult = function () {
        this.model = new SimpleInterest_1.SimpleInterest(parseFloat(this.PrincipalBox.nodeValue), parseFloat(this.InterestBox.nodeValue), parseFloat(this.YearsBox.nodeValue));
        this.AmountAccuredDom.textContent = "Amount To Pay: " + this.model.GetAmountAccured();
    };
    return SimpleInterestCompo;
}());
window.onload = function () {
    var obj = new SimpleInterest_1.SimpleInterest(250000, 5, 2);
    console.log(obj.GetAmountAccured());
};
var saC = new SimpleInterest_1.SimpleInterest(250000, 5, 2);
//# sourceMappingURL=SimpleInterestCompo.js.map