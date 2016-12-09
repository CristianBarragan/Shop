var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ProductApi } from '../dto/productApi';
import { ProductApiService } from '../services/productApi.service';
import { CategoryApiService } from '../services/categoryApi.service';
export let ProductApiDetailComponent = class ProductApiDetailComponent {
    constructor(productService, categoryService, route) {
        this.productService = productService;
        this.categoryService = categoryService;
        this.route = route;
        this.close = new EventEmitter();
        this.navigated = false;
        this.getCategoriesDropdownValues();
    }
    ngOnInit() {
        this.route.params.forEach((params) => {
            if (params['productId'] !== undefined) {
                let id = +params['productId'];
                this.navigated = true;
                this.productService.getProduct(id)
                    .subscribe((data) => {
                    this.product = data;
                    this.selectedCategory = this.categories.find(item => item.categoryId === this.product.categoryId);
                }, (err) => console.error("Error ocurred : ", err));
            }
            else {
                this.navigated = false;
                this.product = new ProductApi();
            }
        });
    }
    getCategoriesDropdownValues() {
        this.categoryService.getCategories()
            .subscribe(response => {
            this.categories = response;
        }, (error) => console.log(error), () => {
            console.log('ProductApiService:GetProducts completed');
        });
    }
    save() {
        if (this.product.productId !== undefined) {
            this.product.categoryId = this.selectedCategory.categoryId;
            this.productService
                .updateProduct(this.product.productId, this.product)
                .subscribe((data) => {
                this.goBack(this.product);
            }, (err) => console.error("Error ocurred : ", err));
        }
        else {
            this.productService
                .addProduct(this.product)
                .subscribe((data) => this.goBack(this.product), (err) => console.error("Error ocurred : ", err));
        }
    }
    goBack(savedProduct = null) {
        this.close.emit(savedProduct);
        if (this.navigated) {
            window.history.back();
        }
    }
};
__decorate([
    Input(), 
    __metadata('design:type', ProductApi)
], ProductApiDetailComponent.prototype, "product", void 0);
__decorate([
    Output(), 
    __metadata('design:type', Object)
], ProductApiDetailComponent.prototype, "close", void 0);
ProductApiDetailComponent = __decorate([
    Component({
        selector: 'my-productApi-detail',
        templateUrl: 'productApi-detail.component.html'
    }), 
    __metadata('design:paramtypes', [ProductApiService, CategoryApiService, ActivatedRoute])
], ProductApiDetailComponent);
//# sourceMappingURL=productApi-detail.component.js.map