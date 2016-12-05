import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';

import { Product } from '../dto/product';
import { ProductService } from '../services/product.service';

@Component({
  selector: 'my-product-detail',
  templateUrl: 'product-detail.component.html'
})
export class ProductDetailComponent implements OnInit {
  @Input() product: Product;
  @Output() close = new EventEmitter();
  error: any;
  navigated = false; // true if navigated here

  constructor(
    private productService: ProductService,
    private route: ActivatedRoute) {
  }

  ngOnInit(): void {
    this.route.params.forEach((params: Params) => {
      if (params['id'] !== undefined) {
        let id = +params['id'];
        this.navigated = true;
        this.product = this.findProduct(id);
        
      } else {
        this.navigated = false;
        this.product = new Product();
      }
    });
  }

  findProduct (id: number): Product {
     let product = new Product();
     this.productService.getProducts()
        .subscribe((data : Product[]) => {
            product = data.find(product => product.id === id);
        },
        (error : any) => console.log(error),
        () => {
            product = null;
            console.log('ProductApiService:GetProducts completed');
        }
        );   
     return product;
  }

  save(): void {
    this.productService
        .save(this.product)
        .subscribe((res : any) => {
            this.product = res;
            this.goBack(this.product);
        },
        (error : any) => console.log(error),
        () => {
            console.log('ProductService:save completed');
        }
        );
  }

  goBack(savedProduct: Product = null): void {
    this.close.emit(savedProduct);
    if (this.navigated) { window.history.back(); }
  }
}
