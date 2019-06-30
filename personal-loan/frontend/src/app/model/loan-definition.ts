
export class LoanDefinition {
    id: string;
    balance = 0;
    selected = false;
    constructor(id: string, banlance: number) {
        this.id = id;
        this.balance = banlance;
    }
}
