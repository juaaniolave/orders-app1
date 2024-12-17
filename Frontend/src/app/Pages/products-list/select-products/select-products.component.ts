import { Component, EventEmitter, Output } from '@angular/core';
import { ProductService } from '../../../services/product.service';
import { Product } from '../../../models/product.model';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-select-products',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './select-products.component.html',
  styleUrls: ['./select-products.component.css']
})
export class SelectProductsComponent {
  products: Product[] = []; // Lista de productos cargados
  selectedProducts: Product[] = []; // Productos seleccionados

  @Output() productsSelected = new EventEmitter<Product[]>(); // Emitir productos seleccionados al componente padre

  constructor(private productService: ProductService) {
    this.loadProducts();
  }

  loadProducts() {
    this.productService.getProducts().subscribe((data) => {
      this.products = data;
    });
  }

  toggleProductSelection(product: Product) {
    const index = this.selectedProducts.findIndex(p => p.id === product.id);
    if (index === -1) {
      this.selectedProducts.push(product);
    } else {
      this.selectedProducts.splice(index, 1);
    }
  }

  confirmSelection() {
    this.productsSelected.emit(this.selectedProducts);
  }
}
