var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ProductApiService } from '../services/productApi.service';
export let ProductsApiComponent = class ProductsApiComponent {
    constructor(router, productApiService) {
        this.router = router;
        this.productApiService = productApiService;
        this.addingProduct = false;
    }
    getProducts() {
        this.productApiService
            .getProducts()
            .subscribe(response => {
            this.products = response;
        }, (error) => console.log(error), () => {
            console.log('ProductApiService:GetProducts completed');
        });
    }
    addProduct() {
        this.addingProduct = true;
        this.selectedProduct = null;
    }
    close(savedProduct) {
        this.addingProduct = false;
        if (savedProduct) {
            this.getProducts();
        }
    }
    deleteProduct(product, event) {
        event.stopPropagation();
        this.productApiService
            .deleteProduct(product)
            .subscribe((data) => {
            if (data.Ok) {
                this.products = this.products.filter(p => p !== product);
                if (this.selectedProduct === product) {
                    this.selectedProduct = null;
                }
            }
        }, error => console.log(error), () => {
            console.log('ProductApiService:Delete completed');
        });
    }
    onSelect(product) {
        this.selectedProduct = product;
        this.addingProduct = false;
    }
    gotoDetail() {
        this.router.navigate(['/detail', this.selectedProduct.productId]);
    }
    ngOnInit() {
        this.getProducts();
    }
};
ProductsApiComponent = __decorate([
    Component({
        selector: 'my-products',
        templateUrl: 'productsApi.component.html'
    }), 
    __metadata('design:paramtypes', [Router, ProductApiService])
], ProductsApiComponent);
//# sourceMappingURL=productsApi.component.js.map