import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { FibResult } from '../models/fib-result.model';
import { FibRequest } from '../models/fib-request.model';

@Injectable({
  providedIn: 'root'
})
export class FibResultService {

  private url = "http://localhost:5000/api/FibMathCalculator";

  private httpOptions = {
    headers: new HttpHeaders({
      "Content-Type": "application/json"
    })
  };

  constructor(private http: HttpClient) { }

  public getAll(): Observable<FibResult[]> {
    return this.http.get<FibResult[]>(this.url, this.httpOptions).pipe(
      catchError(this.handleError)
    );
  }

  public add(model: FibRequest): Observable<FibResult>
  {
    return this.http.post<FibResult>(this.url, model, this.httpOptions).pipe(
      catchError(this.handleError)
    )
  }

  handleError(err: HttpErrorResponse) {

    let errorMessage = `Unknown error with status ${err.status}`;

    if (!err.ok) {
      errorMessage = err.error.errors.NumberToCalculate.join(', ');
    }

    return throwError(errorMessage);
  }
}
