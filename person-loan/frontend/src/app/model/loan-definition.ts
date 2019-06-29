
export class LoanDefinition {
    id: string;
    balance = 0;
    constructor(id: string, banlance: number) {
        this.id = id;
        this.balance = banlance;
    }

    /*
    get Balance() { return this.balance; }
    set Balance(val: number) {this.balance = val; }
    */
}
