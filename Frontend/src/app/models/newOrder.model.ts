import {OrderProduct} from './OrderProduct'

export interface NewOrder {
  orderDate: string;
  customerId: string; // O number si el ID es numérico
  statusId: string;   // O number si el ID es numérico
  comment: string;
  product: OrderProduct[];
}