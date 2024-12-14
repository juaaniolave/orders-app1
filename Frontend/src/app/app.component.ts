import { Component } from '@angular/core';
import { OrdersListComponent } from './orders-list/orders-list.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [OrdersListComponent],
  template: `
    <app-orders-list></app-orders-list>
  `,
})
export class AppComponent {}