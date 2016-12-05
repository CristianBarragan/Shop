import { Injectable } from '@angular/core';
import { Headers, Http, Response } from '@angular/http';
import 'rxjs/add/operator/toPromise';
import 'rxjs/Rx';
import { Observable } from 'rxjs/Observable';
import { Configuration } from '../app.constants';
import { Product } from '../dto/product';

@Injectable()
export class ProductService {

  private productsUrl: string;
  private headers: Headers;

  constructor(private http: Http) { 
    this.productsUrl = 'app/products/';
    this.headers = new Headers();
    this.headers.append('Content-Type', 'application/json');
    this.headers.append('Accept', 'application/json');
  }

  public getProducts = (): Observable<Product[]> => {
    return this.http
      .get(this.productsUrl)
      .map(res => res.json().data as Product[]);
  }

  public save = (product: Product): Observable<Product> => {
    if (product.id) {
      return this.put(product);
    }
    return this.post(product);
  }

  public delete = (product: Product): Observable<Response> => {
    return this.http.delete(this.productsUrl + product.id);
  }

  // Add new Product
  private post = (product: Product): Observable<Product> => {
    var toAdd = JSON.stringify({ Product: product });
        return this.http.post(this.productsUrl, toAdd, { headers: this.headers }).map(res => res.json());
  }

  // Update existing Product
  private put = (product: Product): Observable<any> => {
    return this.http
            .put(this.productsUrl + product.id, JSON.stringify(product), { headers: this.headers })
            .map(res => res.json());
  }
}
