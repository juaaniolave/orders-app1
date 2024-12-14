// src/app/services/order.service.ts
import { Injectable } from '@angular/core';
import { Order } from '../models/order.model';
import { Observable, of } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class OrderService {
  private orders: Order[] = [
    { orderNumber: 1256789, customerName: 'John Smith', customerAddress: '5th Ave, New York', totalCost: 150, status: 'New' },
    { orderNumber: 1256789, customerName: 'John Smith', customerAddress: '5th Ave, New York', totalCost: 150, status: 'New' },
  ];

  getOrders(): Observable<Order[]> {
    return of(this.orders); // Simulación de datos
  }
}