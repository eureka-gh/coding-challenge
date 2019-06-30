import { Injectable } from '@angular/core';

import { LoanDefinition } from '../model/loan-definition';
// import { DummyLoans } from '../dummy.loans';
import { ApiClient } from './api-client.service';

@Injectable({
  providedIn: 'root'
})

export class LoanProviderService {
  private selectedLoans = new Map();
  private sum = 0;
  loans: LoanDefinition[] = [];

  constructor(private apiClient: ApiClient) {}

  AddSelection(item: LoanDefinition) {
    this.selectedLoans.set(item.id, item.balance);
    this.sum += item.balance;
  }

  RemoveSelection(item: LoanDefinition) {
    this.selectedLoans.delete(item.id);
    this.sum -= item.balance;
  }

  Sum() {
    return this.sum;
  }

  Count() {
    return this.selectedLoans.size;
  }

  Load() {
    // assuem the login user has userId == '1'
    this.apiClient.getUserLoans('1').subscribe(
      loans => this.loans = loans
      );
  }
}
