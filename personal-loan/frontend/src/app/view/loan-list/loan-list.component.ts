import { Component} from '@angular/core';

import { LoanDefinition } from '../../model/loan-definition';
import { LoanProviderService } from 'src/app/controller/loan-provider.service';

@Component({
  selector: 'app-loan-list',
  templateUrl: './loan-list.component.html',
  styleUrls: ['./loan-list.component.css']
})

export class LoanListComponent {

  constructor(
    private loanProvider: LoanProviderService,
  ) {}


  OnSelect(item: LoanDefinition) {
    item.selected = !item.selected;
    if (item.selected) {
        this.loanProvider.AddSelection(item);
    } else {
        this.loanProvider.RemoveSelection(item);
    }
  }

  AllLoans() {
      return this.loanProvider.loans;
  }
}
