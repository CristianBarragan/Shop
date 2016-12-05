import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';
import { ProductApi } from '../dto/productApi';
import { CategoryApi} from '../dto/categoryApi';
import { ProductApiService } from '../services/productApi.service';
import { CategoryApiService} from '../services/categoryApi.service';
import { DropdownComponent} from '../ui/DropdownComponent';
//import { DropdownValue} from '../ui/DropdownValue';

@Component({
  selector: 'my-productApi-detail',
  templateUrl: 'productApi-detail.component.html'
})
export class ProductApiDetailComponent implements OnInit {
  @Input() product: ProductApi;
  @Output() close = new EventEmitter();
  error: any;
  navigated = false; // true if navigated here
  //dropdownComponent : DropdownComponent;
  categories: CategoryApi[]; 

  constructor(
    private productService: ProductApiService,
    private categoryService: CategoryApiService,
    private route: ActivatedRoute) {
    //this.dropdownComponent.values = this.getCategoriesDropdownValues();
  }

  ngOnInit(): void {
    this.route.params.forEach((params: Params) => {
      if (params['productId'] !== undefined) {
        let id = +params['productId'];
        this.navigated = true;
        this.productService.getProduct(id)
        .subscribe(
            (data) => {this.product = data;
            //(err) => {this.error = err};        
        },
        error => console.log(error),
        () => {
            console.log('ProductApiService:GetProducts completed');
        }
        );
      } else {
        this.navigated = false;
        this.product = new ProductApi();
      }
    });
  }

   /*private getCategoriesDropdownValues () : DropdownValue[] { 
      this.categoryService.getCategories()
      .subscribe(
        (data) => {this.categories = data;
        //(err) => {this.error = err};        
        },
        error => console.log(error),
        () => {
          console.log('ProductApiService:GetProducts completed');
        }
      );
    
      var items: DropdownValue[];
      for(var i = 1; i <=this.categories.length ; i++){
        items.push(new DropdownValue(this.categories[i].categoryId, this.categories[i].name));
      }
      return items;
    }*/

  save(): void {
    if(this.product.productId !== undefined)
    {
        this.productService
        .updateProduct(this.product.productId, this.product)
        .subscribe(
            (data) => {this.goBack(this.product);
            //(err) => {this.error = err};
        },
        error => console.log(error),
        () => {
            console.log('ProductApiService:GetProducts completed');
        }
        );
    }
    else
    {
        this.productService
        .addProduct(this.product)
        .subscribe(
            (data) => {this.goBack(this.product);
            //(err) => {this.error = err};
        },
        error => console.log(error),
        () => {
            console.log('ProductApiService:GetProducts completed');
        }
        );
    }
  }

  goBack(savedProduct: ProductApi = null): void {
    this.close.emit(savedProduct);
    if (this.navigated) { window.history.back(); }
  }
}
