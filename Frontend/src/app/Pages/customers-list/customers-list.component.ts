import { Component } from '@angular/core';
import { Customer } from '../../models/customer.model';
import { CustomerService } from '../../services/customer.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-customers-list',
  imports: [CommonModule],
  templateUrl: './customers-list.component.html',
  styleUrl: './customers-list.component.css',
})
export class CustomersListComponent {
    customers: Customer[] = []; // Lista de órdenes inicializada vacía
  
    constructor(private customerService: CustomerService) {}
  
    ngOnInit() {
      this.loadCustomers();
    }
  
    loadCustomers() {
      this.customerService.getCustomers().subscribe((data) => {
        this.customers = data; // Actualiza la lista con los datos del backend
      });
    }

    
  newCustomer(){
    alert('New Customer!')
  }
}
