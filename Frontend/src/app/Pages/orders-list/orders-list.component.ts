import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { OrderService } from '../../services/order.service';
import { Order } from '../../models/order.model';
import { NewOrderComponent } from './new-order/new-order.component';

@Component({
  selector: 'app-orders-list',
  imports: [CommonModule, NewOrderComponent],
  templateUrl: './orders-list.component.html',
  styleUrl: './orders-list.component.css',
})
export class OrdersListComponent implements OnInit {
  orders: Order[] = []; // Lista de órdenes inicializada vacía
  
  showNewOrderForm = false; // Controla la visibilidad del componente

  constructor(private orderService: OrderService) {}

  ngOnInit() {
    this.loadOrders();
  }

  loadOrders() {
    this.orderService.getOrders().subscribe((data) => {
      this.orders = data; // Actualiza la lista con los datos del backend
    });
  }

  newOrder(){
    
  }
}

