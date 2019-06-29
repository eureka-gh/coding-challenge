import { Component } from '@angular/core';
import { LoanSelectionService } from 'src/app/controller/loan-selection';

@Component({
  selector: 'app-loan-summary',
  templateUrl: './loan-summary.component.html',
  styleUrls: ['./loan-summary.component.css']
})

export class LoanSummaryComponent {
    constructor(
        private loanSelection: LoanSelectionService
    ) {}

    ShowSummaryAmount() {
        return this.loanSelection.Sum();
    }
}
