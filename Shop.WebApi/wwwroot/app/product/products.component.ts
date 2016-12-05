import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { Product } from '../dto/product';
import { ProductService } from '../services/product.service';

@Component({
  selector: 'my-products',
  templateUrl: 'products.component.html'
})
export class ProductsComponent implements OnInit {
  products: Product[];
  selectedProduct: Product;
  addingProduct = false;
  error: any;

  constructor(
    private router: Router,
    private productService: ProductService) { }

  getProducts(): void {
    this.productService
      .getProducts()
        .subscribe((data : any) => {
            this.products = data;
        },
        (error : any) => console.log(error),
        () => {
            console.log('ProductApiService:GetProducts completed');
        }
        );
  }

  addProduct(): void {
    this.addingProduct = true;
    this.selectedProduct = null;
  }

  close(savedProduct: Product): void {
    this.addingProduct = false;
    if (savedProduct) { this.getProducts(); }
  }

  deleteProduct(product: Product, event: any): void {
    event.stopPropagation();
    this.productService
      .delete(product)
      .subscribe((response : any) => {
            this.products = this.products.filter(p => p !== product);
            if (this.selectedProduct === product) { this.selectedProduct = null; }  
          },
          (error : any) => console.log(error),
          () => {
            console.log('ProductApiService:Delete completed');
          });
  }

  onSelect(product: Product): void {
    this.selectedProduct = product;
    this.addingProduct = false;
  }

  gotoDetail(): void {
    this.router.navigate(['/detail', this.selectedProduct.id]);
  }

  ngOnInit(): void {
    this.getProducts();
  }
}
