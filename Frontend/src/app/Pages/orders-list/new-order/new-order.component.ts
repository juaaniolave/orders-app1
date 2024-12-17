import { Component } from '@angular/core';
import { ProductService } from '../../../services/product.service';
import { CustomerService } from '../../../services/customer.service';
import { Product } from '../../../models/product.model';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { NewOrderService } from '../../../services/new-order.service';
import { Router } from '@angular/router';
import { NewOrder } from '../../../models/newOrder.model';
import { SelectProductsComponent } from '../../products-list/select-products/select-products.component';

@Component({
  selector: 'app-new-order',
  standalone: true,
  imports: [CommonModule, FormsModule,SelectProductsComponent],
  templateUrl: './new-order.component.html',
  styleUrls: ['./new-order.component.css'],
})
export class NewOrderComponent {
  orderDate: string;
  products: Product[] = [];
  totalCost: number = 0;
  quantities: number[] = [];
  status: { value: string; label: string }[] = [];
  customers: { value: string; label: string }[] = [];
  selectedCustomer: string = '';
  selectedStatus: string = '';
  comment: string = '';
  showProductModal = false; // Estado del modal

  openProductModal() {
    this.showProductModal = true;
  }

  addSelectedProducts(selectedProducts: Product[]) {
    this.products.push(...selectedProducts);
    this.showProductModal = false;
  }
  constructor(
    private productService: ProductService,
    private newOrderService: NewOrderService,
    private customerService: CustomerService,
    public router: Router
  ) {
    this.orderDate = this.getCurrentDate();
  }

  ngOnInit() {
    this.loadStatus();
    this.loadCustomers();
  }

  loadProducts() {
    this.productService.getProducts().subscribe((data) => {
      this.products = data;
      this.quantities = Array(this.products.length).fill(0);
    });
  }
  getCurrentDate(): string {
    const today = new Date();
    const year = today.getFullYear();
    const month = String(today.getMonth() + 1).padStart(2, '0');
    const day = String(today.getDate()).padStart(2, '0');
    return `${year}-${month}-${day}`;
  }

  updateTotalCost() {
    this.totalCost = this.products.reduce((sum, product, index) => {
      return sum + (this.quantities[index] || 0) * product.cost;
    }, 0);
  }

  loadStatus() {
    this.newOrderService.getStatus().subscribe((data) => {
      this.status = [{ value: '', label: 'Select Status' }, ...data];
    });
  }

  loadCustomers() {
    this.customerService.getCustomersNames().subscribe((data) => {
      this.customers = [{ value: '', label: 'Select Customer' }, ...data];
    });
  }

  // Método de validación para el botón Save
  isSaveDisabled(): boolean {
    return !this.selectedCustomer || !this.selectedStatus;
  }

  saveOrder() {
    const orderData: NewOrder = {
      orderDate: this.orderDate,
      customerId: this.selectedCustomer,
      statusId: this.selectedStatus,
      comment: this.comment,
      product: this.products.map((product, index) => ({
        id: product.id,
        quantity: this.quantities[index] || 0,
      })),
    };

    this.newOrderService.createOrder(orderData).subscribe({
      next: () => {
        this.router.navigate(['/orders']);
      },
      error: (err) => {
        console.error('Error creating order:', err);
        alert('Failed to create order. Please try again.');
      },
    });
  }
}
