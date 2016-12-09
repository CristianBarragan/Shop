import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';
import { ProductApi } from '../dto/productApi';
import { CategoryApi} from '../dto/categoryApi';
import { ProductApiService } from '../services/productApi.service';
import { CategoryApiService} from '../services/categoryApi.service';

@Component({
  selector: 'my-productApi-detail',
  templateUrl: 'productApi-detail.component.html'
})
export class ProductApiDetailComponent implements OnInit {
  @Input() product: ProductApi;
  @Output() close = new EventEmitter();
  error: any;
  navigated = false; // true if navigated here
  categories: CategoryApi[]; 
  selectedCategory:CategoryApi;

  constructor(
    private productService: ProductApiService,
    private categoryService: CategoryApiService,
    private route: ActivatedRoute) {
    this.getCategoriesDropdownValues();
  }

  ngOnInit(): void {
    this.route.params.forEach((params: Params) => {
      if (params['productId'] !== undefined) {
        let id = +params['productId'];
        this.navigated = true;
        this.productService.getProduct(id)
        .subscribe(
            (data) => {
                    this.product = data;
                    this.selectedCategory = this.categories.find(item => item.categoryId === this.product.categoryId);
            },
            (err) => console.error("Error ocurred : ", err)
         );       
      } else {
        this.navigated = false;
        this.product = new ProductApi();
      }
    });
  }

   getCategoriesDropdownValues () : void { 
      this.categoryService.getCategories()
      .subscribe(response => {
        this.categories = response;  
      },
      (error : any) => console.log(error),
        () => {
            console.log('ProductApiService:GetProducts completed');
        }
      );
    }

  save(): void {
    if(this.product.productId !== undefined)
    {
        this.product.categoryId = this.selectedCategory.categoryId;
        this.productService
        .updateProduct(this.product.productId, this.product)
        .subscribe(
            (data) => {
                    this.goBack(this.product);},
            (err) => console.error("Error ocurred : ", err)
        );
    }
    else
    {
        this.productService
        .addProduct(this.product)
        .subscribe(
            (data) => this.goBack(this.product),
            (err) => console.error("Error ocurred : ", err)
        );
    }
  }

  goBack(savedProduct: ProductApi = null): void {
    this.close.emit(savedProduct);
    if (this.navigated) { window.history.back(); }
  }
}
