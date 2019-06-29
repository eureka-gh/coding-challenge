import { Component } from '@angular/core';

import { loans } from '../../dummy.loans';

@Component({
  selector: 'app-loan-list',
  templateUrl: './loan-list.component.html',
  styleUrls: ['./loan-list.component.css']
})

export class LoanListComponent {
  loans = loans;
}
