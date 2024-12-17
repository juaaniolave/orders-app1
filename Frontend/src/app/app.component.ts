import { Component } from '@angular/core';
import { MenuComponent } from './menu/menu.component';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [MenuComponent, RouterModule], 
  templateUrl: './app.component.html',
  styleUrls: ['../styles.css'],
})

export class AppComponent {}
