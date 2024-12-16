import { Component } from '@angular/core';
import { MenuComponent } from './menu/menu.component';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [MenuComponent, RouterModule], 
  template: `
<div class="content">
<app-menu></app-menu> 
  <router-outlet></router-outlet> 
</div>
  `,
})
export class AppComponent {}
