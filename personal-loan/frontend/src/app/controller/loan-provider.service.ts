import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { LoanDefinition } from '../model/loan-definition';
import { DummyLoans } from '../dummy.loans';

@Injectable({
  providedIn: 'root'
})

export class LoanProviderService {
  private data = DummyLoans;
  private selectedLoans = new Map();
  private sum = 0;
  loans: LoanDefinition[] = [];

  constructor(private apiClient: HttpClient) {}

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
    //let data = this.apiClient.get('/assert/dummy.db.json');
    this.data.forEach(item => { this.loans.push(
      {
        id: item.id,
        balance: Number(item.balance),
        selected: false
      });
    } );
  }
}
