import { Routes } from '@angular/router';
import { OrdersListComponent } from './Pages/orders-list/orders-list.component';
import { ProductsListComponent } from './Pages/products-list/products-list.component';
import { CustomersListComponent } from './Pages/customers-list/customers-list.component';
import { NewOrderComponent } from './Pages/orders-list/new-order/new-order.component';

export const routes: Routes = [
  { path: 'orders', component: OrdersListComponent },
  { path: 'products', component: ProductsListComponent },
  { path: 'customers', component: CustomersListComponent },
  { path: 'new-order', component: NewOrderComponent},
  { path: '', redirectTo: 'index', pathMatch: 'full' } // Redirige por defecto
];