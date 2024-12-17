
export interface Order {
  id:number;
  customerName: string;
  customerAddress: string; // O number si el ID es numérico
  status: string;   // O number si el ID es numérico
  totalCost: number;
}