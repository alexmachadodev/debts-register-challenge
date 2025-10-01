import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Debt } from './models/debt.model';
import { DebtListItem } from './models/debt-list-item.model';

@Injectable({
  providedIn: 'root'
})
export class DebtService {
  private http = inject(HttpClient);
  private apiUrl = 'http://localhost:8080/api/debts';

  getDebts(): Observable<DebtListItem[]> {
    return this.http.get<DebtListItem[]>(this.apiUrl);
  }

  addDebt(debt: Debt): Observable<Debt> {
    return this.http.post<Debt>(this.apiUrl, debt);
  }
}