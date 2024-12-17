import { Component, EventEmitter, Output, Input, OnChanges, SimpleChanges } from '@angular/core';
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
export class SelectProductsComponent implements OnChanges {
  products: Product[] = []; // Lista completa de productos
  filteredProducts: Product[] = []; // Productos filtrados (excluye los ya seleccionados)
  selectedProducts: Set<Product> = new Set(); // Conjunto de productos seleccionados

  @Input() alreadySelectedProducts: Product[] = []; // Productos seleccionados previamente
  @Output() productsSelected = new EventEmitter<Product[]>(); // Emitir productos seleccionados

  constructor(private productService: ProductService) {
    this.loadProducts();
  }

  // Detectar cambios en las entradas del componente
  ngOnChanges(changes: SimpleChanges): void {
    if (changes['alreadySelectedProducts'] && this.products.length > 0) {
      this.filterProducts();
    }
  }

  // Cargar todos los productos
  loadProducts() {
    this.productService.getProducts().subscribe((data) => {
      this.products = data;
      this.filterProducts();
    });
  }

  // Filtrar los productos excluyendo los ya seleccionados
  filterProducts() {
    const alreadySelectedIds = this.alreadySelectedProducts.map(p => p.id);
    this.filteredProducts = this.products.filter(
      product => !alreadySelectedIds.includes(product.id)
    );
  }

  // Método para alternar la selección de un producto
  toggleProductSelection(product: Product) {
    if (this.isProductSelected(product)) {
      this.selectedProducts.delete(product);
    } else {
      this.selectedProducts.add(product);
    }
  }

  // Verificar si un producto está seleccionado
  isProductSelected(product: Product): boolean {
    return Array.from(this.selectedProducts).some(p => p.id === product.id);
  }

  // Confirmar selección y emitir productos seleccionados al componente padre
  confirmSelection() {
    this.productsSelected.emit(Array.from(this.selectedProducts));
  }
}
