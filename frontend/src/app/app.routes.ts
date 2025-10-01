import { Routes } from '@angular/router';
import { DebtListComponent } from './features/debts/debt-list/debt-list.component';
import { DebtFormComponent } from './features/debts/debt-form/debt-form.component';

export const routes: Routes = [
  { path: 'debts', component: DebtListComponent },
  { path: 'debts/new', component: DebtFormComponent },
  { path: '', redirectTo: '/debts', pathMatch: 'full' }
];