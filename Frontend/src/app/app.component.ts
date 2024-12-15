import { Component } from '@angular/core';
import { OrdersListComponent } from './orders-list/orders-list.component';
import { MenuComponent } from './menu/menu.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [OrdersListComponent, MenuComponent], // Importa MenuComponent aquí
  template: `
    <app-menu></app-menu> 
  `,
})
export class AppComponent {}
