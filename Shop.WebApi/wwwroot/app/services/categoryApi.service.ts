import { Injectable } from '@angular/core';
import { Headers, Http, Response } from '@angular/http';
import 'rxjs/add/operator/toPromise';
import 'rxjs/Rx';
import { Observable } from 'rxjs/Observable';
import { Configuration } from '../app.constants';
import { CategoryApi } from '../dto/CategoryApi';

@Injectable()
export class CategoryApiService {

  private actionUrl: string;
  private headers: Headers;

  constructor(private _http: Http, private _configuration: Configuration) {
    this.actionUrl = `${_configuration.Server}api/Category/`; 
    this.headers = new Headers();
    this.headers.append('Content-Type', 'application/json');
    this.headers.append('Accept', 'application/json');   
  }

    public getCategories = (): Observable<CategoryApi[]> => {
        return this._http.get(this.actionUrl)
        .map(res => res.json());
    }

    public getCategory = (id: number): Observable<CategoryApi> => {
        return this._http.get(this.actionUrl + id).map(res => res.json());
    }

    public addCategory = (itemName: CategoryApi): Observable<any> => {
        return this._http
            .post(this.actionUrl, JSON.stringify(itemName), { headers: this.headers })
            .map(res => res.json());
    }

    public updateCategory = (id: number, itemToUpdate: CategoryApi): Observable<any> => {
        return this._http
            .put(this.actionUrl + id, JSON.stringify(itemToUpdate), { headers: this.headers });
    }

    public deleteCategory = (category: CategoryApi): Observable<any> => {
        return this._http.delete(this.actionUrl + category.categoryId);
    }

}
