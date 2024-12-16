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
    showNewOrderForm = false; // Controla la visibilidad del componente
    
    constructor(private customerService: CustomerService) {}
  
    ngOnInit() {
      this.loadCustomers();
    }
  
    loadCustomers() {
      this.customerService.getCustomers().subscribe((data) => {
        this.customers = data; // Actualiza la lista con los datos del backend
      });
    }


    

    // Función que muestra el formulario de nueva orden
    newOrder() {
      this.showNewOrderForm = !this.showNewOrderForm;
    }
  newCustomer(){
    alert('New Customer!')
  }
}
