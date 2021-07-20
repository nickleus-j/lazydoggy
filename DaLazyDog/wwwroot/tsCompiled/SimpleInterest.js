"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var SimpleInterest = (function () {
    function SimpleInterest(p, i, y) {
        this.Principal = p;
        this.AnnualInterestRate = i;
        this.Years = y;
    }
    SimpleInterest.prototype.MonthsCount = function () {
        return this.Years * 12;
    };
    SimpleInterest.prototype.GetAmountAccured = function () {
        return this.Principal * (1 + (this.AnnualInterestRate / 100) * this.Years);
    };
    SimpleInterest.prototype.GetMonthlyPayment = function () {
        return this.GetAmountAccured() / this.MonthsCount();
    };
    SimpleInterest.prototype.GetMonthlyPrincipal = function () {
        return this.Principal / this.MonthsCount();
    };
    SimpleInterest.prototype.MonthlyInterest = function () { return this.GetMonthlyPayment() - this.GetMonthlyPrincipal(); };
    return SimpleInterest;
}());
exports.SimpleInterest = SimpleInterest;
function arere() {
    console.log("----");
    var c = new SimpleInterest(100000, 5, 1);
    console.log(c.GetAmountAccured());
}
//# sourceMappingURL=SimpleInterest.js.map