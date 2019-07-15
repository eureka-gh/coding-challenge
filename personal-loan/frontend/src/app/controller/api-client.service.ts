import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';

import { LoanDefinition } from '../model/loan-definition';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({ providedIn: 'root' })

export class ApiClient {
    /*
     * local debug build
    private loanProviderUri = 'http://localhost:11202/api';
    */

    /*
     * cloud deployment
     */
    private loanProviderUri = 'https://webappdotnetframework.azurewebsites.net/api';

    constructor(private http: HttpClient) { }

    /** GET Loans from the server */
    getUserLoans(userId: string): Observable<LoanDefinition[]> {
        let path = '/user/' + userId + '/loan';
        return this.http.get<LoanDefinition[]>(this.loanProviderUri + path)
          .pipe(
              tap(_ => console.log('getUserLoans')),
              catchError(this.handleError<LoanDefinition[]>('getUserLoans', []))
          );
    }

    private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {

      console.error(error); // log to console instead

      // TODO: send the error to remote logging infrastructure
      alert(error.message);

      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }
}
