// src/app/orders-list/orders-list.component.ts
import { Component, OnInit } from '@angular/core';
import { Order } from '../models/order.model';
import { OrderService } from '../services/order.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-orders-list',
  templateUrl: './orders-list.component.html',
  styleUrls: ['./orders-list.component.css'],
  imports: [CommonModule]
})
export class OrdersListComponent implements OnInit {
  orders: Order[] = [];

  constructor(private orderService: OrderService) {}

  ngOnInit() {
    this.loadOrders();
  }

  loadOrders() {
    this.orderService.getOrders().subscribe((data) => {
      this.orders = data;
    });
  }

  newOrder() {
    // Acción para agregar una nueva orden
    alert('Redirect to New Order page!');
  }
}