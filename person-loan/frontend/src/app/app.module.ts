import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoanListComponent } from './view/loan-list/loan-list.component';
import { LoanSummaryComponent } from './view/loan-summary/loan-summary.component';

@NgModule({
  declarations: [
    AppComponent,
    LoanListComponent,
    LoanSummaryComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
