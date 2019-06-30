
export class LoanDefinition {
    id: string;
    balance = 0;
    interest = 0;
    earlyRepaymentFee = 0;
    payoutOrCarryover = 0;
    selected = false;
    constructor(id: string, banlance: number) {
        this.id = id;
        this.balance = banlance;
    }
}
