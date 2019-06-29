import { Injectable } from '@angular/core';
import { LoanDefinition } from '../model/loan-definition';

@Injectable({
  providedIn: 'root'
})
export class LoanSelectionService {
  private selectedLoans = new Map();
  private sum = 0;

  constructor() {}

  Add(item: LoanDefinition) {
      this.selectedLoans.set(item.id, item.balance);
      this.sum += item.balance;
  }

  Remove(item: LoanDefinition) {
      this.selectedLoans.delete(item.id);
      this.sum -= item.balance;
  }

  Sum() {
    return this.sum;
  }
}
