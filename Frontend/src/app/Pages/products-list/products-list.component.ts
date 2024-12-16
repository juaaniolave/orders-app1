import { Component } from '@angular/core';
import { Product } from '../../models/product.model';
import { ProductService } from '../../services/product.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-products-list',
  imports: [CommonModule],
  templateUrl: './products-list.component.html',
  styleUrl: './products-list.component.css',
})
export class ProductsListComponent {
    products: Product[] = []; // Lista de órdenes inicializada vacía
  
    constructor(private productService: ProductService) {}
  
    ngOnInit() {
      this.loadProducts();
    }
  
    loadProducts() {
      this.productService.getProducts().subscribe((data) => {
        this.products = data; // Actualiza la lista con los datos del backend
      });
    }

  newProduct(){
    alert('New Product!')
  }
}
