import { Installment } from './installment.model';

export interface Debt {
  id: number;
  titleNumber: string;
  debtorName: string;
  debtorCpf: string;
  interestPercent: number;
  finePercent: number;
  installments: Installment[];
}
