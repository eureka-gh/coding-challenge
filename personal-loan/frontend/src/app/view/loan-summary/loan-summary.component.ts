import { Component, OnInit} from '@angular/core';
import { LoanProviderService } from 'src/app/controller/loan-provider.service';

@Component({
  selector: 'app-loan-summary',
  templateUrl: './loan-summary.component.html',
  styleUrls: ['./loan-summary.component.css']
})

export class LoanSummaryComponent implements OnInit {
    constructor(
        private loanProvider: LoanProviderService
    ) {}

    ngOnInit() {
      this.loanProvider.Load();
    }

    ShowSummaryAmount() {
        return this.loanProvider.Sum();
    }

    IsLoanSelected() {
        return this.loanProvider.Count() > 0;
    }

    CanApplyNewLoan() {
        return this.loanProvider.loans.length < 3;
    }
}
