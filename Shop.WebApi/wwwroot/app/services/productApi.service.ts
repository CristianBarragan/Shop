import { Injectable } from '@angular/core';
import { Headers, Http, Response } from '@angular/http';
import 'rxjs/add/operator/toPromise';
import 'rxjs/Rx';
import { Observable } from 'rxjs/Observable';
import { Configuration } from '../app.constants';
import { ProductApi } from '../dto/ProductApi';

@Injectable()
export class ProductApiService {

  private actionUrl: string;
  private headers: Headers;

  constructor(private _http: Http, private _configuration: Configuration) {
    this.actionUrl = `${_configuration.Server}api/Product/`; 
    this.headers = new Headers();
    this.headers.append('Content-Type', 'application/json');
    this.headers.append('Accept', 'application/json');   
  }

    public getProducts = (): Observable<ProductApi[]> => {
        return this._http.get(this.actionUrl)
        .map(res => res.json());
    }

    public getProduct = (id: number): Observable<ProductApi> => {
        return this._http.get(this.actionUrl + id).map(res => res.json());
    }

    public addProduct = (itemName: ProductApi): Observable<any> => {
        return this._http
            .post(this.actionUrl, JSON.stringify(itemName), { headers: this.headers })
            .map(res => res.json());
    }

    public updateProduct = (id: number, itemToUpdate: ProductApi): Observable<any> => {
        return this._http
            .put(this.actionUrl + id, JSON.stringify(itemToUpdate), { headers: this.headers });
    }

    public deleteProduct = (product: ProductApi): Observable<any> => {
        return this._http.delete(this.actionUrl + product.productId);
    }

}
