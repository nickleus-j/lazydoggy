export class SimpleInterest {
    constructor(p: number, i: number, y: number) {
        this.Principal = p;
        this.AnnualInterestRate = i;
        this.Years = y;
    }
    Principal: number;
    AnnualInterestRate: number;
    Years: number;
    public MonthsCount() {
        return this.Years * 12;
    }
    public GetAmountAccured() {
        return this.Principal * (1 + (this.AnnualInterestRate / 100) * this.Years);
    }
    public GetMonthlyPayment() {
        return this.GetAmountAccured() / this.MonthsCount();
    }
    public GetMonthlyPrincipal() {
        return this.Principal / this.MonthsCount();
    }
    public MonthlyInterest() { return this.GetMonthlyPayment() - this.GetMonthlyPrincipal(); }
}
function arere() {
    console.log("----");
    let c = new SimpleInterest(100000, 5, 1);
    console.log(c.GetAmountAccured());
}