import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoanListComponent } from './view/loan-list/loan-list.component';

const routes: Routes = [
  {path: '', component: LoanListComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
