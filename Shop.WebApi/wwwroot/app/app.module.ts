import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { HttpModule } from '@angular/http';

import { Configuration } from './app.constants';
import { AppRoutingModule, routedComponents } from './app.routes';

import { AppComponent } from './app.component';

//import { InMemoryWebApiModule } from 'angular-in-memory-web-api';
//import { InMemoryProductService } from './data/in-memory-product.service';

//import { ProductService } from './services/product.service';
import { ProductApiService} from './services/productApi.service'
import { CategoryApiService} from './services/categoryApi.service'
//import { DropdownComponent} from './ui/DropdownComponent';

@NgModule({
    imports: [
        BrowserModule,
        FormsModule,
        AppRoutingModule,
        HttpModule
        //InMemoryWebApiModule.forRoot(InMemoryProductService, { delay: 600 })
    ],
    declarations: [
        AppComponent,
        routedComponents
        //DropdownComponent
    ],
    providers: [
        //ProductService,
        ProductApiService,
        CategoryApiService,
        Configuration
    ],
    bootstrap: [AppComponent],
})

export class AppModule { }