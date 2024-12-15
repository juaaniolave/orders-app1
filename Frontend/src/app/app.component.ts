import { Component } from '@angular/core';
import { MenuComponent } from './menu/menu.component';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [MenuComponent, RouterModule], 
  template: `
<app-menu></app-menu> 
<div class="content">
  <router-outlet></router-outlet> 
</div>
  `,
})
export class AppComponent {}
