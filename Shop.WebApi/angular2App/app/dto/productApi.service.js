var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Injectable } from '@angular/core';
import { Headers, Http } from '@angular/http';
import 'rxjs/add/operator/toPromise';
import 'rxjs/Rx';
import { Configuration } from '../app.constants';
export let ProductApiService = class ProductApiService {
    constructor(_http, _configuration) {
        this._http = _http;
        this._configuration = _configuration;
        this.getProducts = () => {
            return this._http.get(this.actionUrl)
                .map(res => res.json());
        };
        this.getProduct = (id) => {
            return this._http.get(this.actionUrl + id).map(res => res.json());
        };
        this.addProduct = (itemName) => {
            return this._http
                .post(this.actionUrl, JSON.stringify(itemName), { headers: this.headers })
                .map(res => res.json());
        };
        this.updateProduct = (id, itemToUpdate) => {
            return this._http
                .put(this.actionUrl + id, JSON.stringify(itemToUpdate), { headers: this.headers })
                .map(res => res.json());
        };
        this.deleteProduct = (product) => {
            return this._http.delete(this.actionUrl + product.productId)
                .map(res => res.json());
        };
        this.actionUrl = `${_configuration.Server}api/Product/`;
        this.headers = new Headers();
        this.headers.append('Content-Type', 'application/json');
        this.headers.append('Accept', 'application/json');
    }
};
ProductApiService = __decorate([
    Injectable(), 
    __metadata('design:paramtypes', [Http, Configuration])
], ProductApiService);
//# sourceMappingURL=productApi.service.js.map