import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormBuilder, FormGroup, FormArray, Validators } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';
import { DebtService } from '../debt.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-debt-form',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatCardModule,
    MatToolbarModule,
    MatIconModule
  ],
  templateUrl: './debt-form.component.html',
  styleUrls: ['./debt-form.component.scss']
})
export class DebtFormComponent {
  private fb = inject(FormBuilder);
  private debtService = inject(DebtService);
  private router = inject(Router);

  debtForm: FormGroup = this.fb.group({
    titleNumber: ['', Validators.required],
    debtorName: ['', Validators.required],
    debtorCpf: ['', Validators.required],
    interestPercent: ['', [Validators.required, Validators.min(0)]],
    finePercent: ['', [Validators.required, Validators.min(0)]],
    installments: this.fb.array([])
  });

  get installments(): FormArray {
    return this.debtForm.get('installments') as FormArray;
  }

  addInstallment() {
    const installmentForm = this.fb.group({
      installmentNumber: ['', Validators.required],
      dueDate: ['', Validators.required],
      amount: ['', [Validators.required, Validators.min(0)]]
    });
    this.installments.push(installmentForm);
  }

  removeInstallment(index: number) {
    this.installments.removeAt(index);
  }

  onSubmit() {
    if (this.debtForm.valid) {
      this.debtService.addDebt(this.debtForm.value).subscribe(() => {
        this.router.navigate(['/debts']);
      });
    }
  }
}