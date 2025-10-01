import { Component, OnInit, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatTableModule } from '@angular/material/table';
import { MatCardModule } from '@angular/material/card';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { RouterModule } from '@angular/router';
import { DebtService } from '../debt.service';
import { DebtListItem } from '../models/debt-list-item.model';
import { Observable, of } from 'rxjs';
import { MatIconModule } from '@angular/material/icon';

// Force a change

@Component({
  selector: 'app-debt-list',
  standalone: true,
  imports: [
    CommonModule,
    RouterModule,
    MatTableModule,
    MatCardModule,
    MatToolbarModule,
    MatButtonModule,
    MatIconModule
  ],
  templateUrl: './debt-list.component.html',
  styleUrls: ['./debt-list.component.scss']
})
export class DebtListComponent implements OnInit {
  private debtService = inject(DebtService);

  debts$: Observable<DebtListItem[]> = of([]);
  displayedColumns: string[] = ['titleNumber', 'debtorName', 'installmentsCount', 'originalAmount', 'daysOverdue', 'updatedAmount'];

  ngOnInit() {
    this.debts$ = this.debtService.getDebts();
  }
}