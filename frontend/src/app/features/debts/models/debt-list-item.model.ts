export interface DebtListItem {
  id: string;
  titleNumber: string;
  debtorName: string;
  installmentCount: number;
  originalValue: number;
  daysInArrears: number;
  updatedValue: number;
}
