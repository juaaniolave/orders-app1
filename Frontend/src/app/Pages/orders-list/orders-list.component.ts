import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { OrderService } from '../../services/order.service';
import { Order } from '../../models/order.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-orders-list',
  imports: [CommonModule],
  templateUrl: './orders-list.component.html',
  styleUrl: './orders-list.component.css',
})
export class OrdersListComponent implements OnInit {
  orders: Order[] = [];
  newOrderRoute: string = 'new-order';
  
  constructor(private orderService: OrderService, private router: Router) {}

  
  ngOnInit() {
    this.loadOrders();
  }

  loadOrders() {
    this.orderService.getOrders().subscribe((data) => {
      this.orders = data; // Actualiza la lista con los datos del backend
    });
  }


  newOrder(){
    this.router.navigate([this.newOrderRoute])
  }
}

