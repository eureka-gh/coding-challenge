import { Component } from '@angular/core';

import { loans } from '../../dummy.loans';
import { LoanSelectionService } from 'src/app/controller/loan-selection';
import { LoanDefinition } from 'src/app/model/loan-definition';

@Component({
  selector: 'app-loan-list',
  templateUrl: './loan-list.component.html',
  styleUrls: ['./loan-list.component.css']
})

export class LoanListComponent {
  loans = loans; // TODO: replaced by httpclient

  constructor(
      private loanSelection: LoanSelectionService
  ) {}

  update(item: LoanDefinition) {
      item.selected = !item.selected;
      if (item.selected) {
          this.loanSelection.Add(item);
      } else {
          this.loanSelection.Remove(item);
      }
  }
}
