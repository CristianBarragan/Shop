import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ProductApi } from '../dto/productApi';
import { ProductApiService } from '../services/productApi.service';
import { CategoryApiService } from '../services/categoryApi.service';
import { DropdownComponent } from '../ui/dropdownComponent'

@Component({
  selector: 'my-products',
  templateUrl: 'productsApi.component.html'
})
export class ProductsApiComponent implements OnInit {
  products: ProductApi[];
  selectedProduct: ProductApi;
  dropdownValues: DropdownComponent;
  addingProduct = false;
  error: any;

  constructor(
    private router: Router,
    private productApiService: ProductApiService) { 
        
    }

    getProducts(): void {
    this.productApiService
        .getProducts()
        .subscribe(response => {
            this.products = response;
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

    close(savedProduct: ProductApi): void {
        this.addingProduct = false;
        if (savedProduct) { this.getProducts(); }
    }

    deleteProduct(product: ProductApi, event: any): void {
        event.stopPropagation();
        this.productApiService
          .deleteProduct(product)
          .subscribe((data) => {
            if(data.Ok)
            {
                this.products = this.products.filter(p => p !== product);
                if (this.selectedProduct === product) { this.selectedProduct = null; }  
            }
          },
          error => console.log(error),
          () => {
            console.log('ProductApiService:Delete completed');
          });
    }

    onSelect(product: ProductApi): void {
        this.selectedProduct = product;
        this.addingProduct = false;
    }

    gotoDetail(): void {
	    this.router.navigate(['/detail', this.selectedProduct.productId]);
    }

    ngOnInit(): void {
        this.getProducts();
    }
}
