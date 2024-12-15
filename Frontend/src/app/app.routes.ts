import { Routes } from '@angular/router';
import { OrdersListComponent } from './orders-list/orders-list.component';
import { ProductsListComponent } from './products-list/products-list.component';
import { CustomersListComponent } from './customers-list/customers-list.component';

export const routes: Routes = [
  { path: 'orders', component: OrdersListComponent },
  { path: 'products', component: ProductsListComponent },
  { path: 'customers', component: CustomersListComponent },
  { path: '', redirectTo: 'index', pathMatch: 'full' } // Redirige por defecto
];