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
export let CategoryApiService = class CategoryApiService {
    constructor(_http, _configuration) {
        this._http = _http;
        this._configuration = _configuration;
        this.getCategories = () => {
            return this._http.get(this.actionUrl)
                .map(res => res.json());
        };
        this.getCategory = (id) => {
            return this._http.get(this.actionUrl + id).map(res => res.json());
        };
        this.addCategory = (itemName) => {
            return this._http
                .post(this.actionUrl, JSON.stringify(itemName), { headers: this.headers })
                .map(res => res.json());
        };
        this.updateCategory = (id, itemToUpdate) => {
            return this._http
                .put(this.actionUrl + id, JSON.stringify(itemToUpdate), { headers: this.headers });
        };
        this.deleteCategory = (category) => {
            return this._http.delete(this.actionUrl + category.categoryId);
        };
        this.actionUrl = `${_configuration.Server}api/Category/`;
        this.headers = new Headers();
        this.headers.append('Content-Type', 'application/json');
        this.headers.append('Accept', 'application/json');
    }
};
CategoryApiService = __decorate([
    Injectable(), 
    __metadata('design:paramtypes', [Http, Configuration])
], CategoryApiService);
//# sourceMappingURL=categoryApi.service.js.map