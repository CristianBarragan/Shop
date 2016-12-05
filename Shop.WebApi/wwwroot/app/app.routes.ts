import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
//import { ProductsComponent } from './product/products.component';
//import { ProductDetailComponent } from './product/product-detail.component';
import { ProductsApiComponent } from './productApi/productsApi.component';
import { ProductApiDetailComponent } from './productApi/productApi-detail.component'

const routes: Routes = [
    { path: '', redirectTo: '/home', pathMatch: 'full'},
    { path: 'home', component: HomeComponent },
    //{ path: 'products', component: ProductsComponent},
    //{ path: 'detail/:id', component: ProductDetailComponent},
    { path: 'productsApi', component: ProductsApiComponent},
    { path: 'detail/:productId', component: ProductApiDetailComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }

export const routedComponents = [
            HomeComponent,
            //ProductsComponent, 
            //ProductDetailComponent,
            ProductsApiComponent,
            ProductApiDetailComponent
        ];

//RouterModule.forRoot(appRoutes);