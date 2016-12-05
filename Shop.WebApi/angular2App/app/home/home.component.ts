import { Component, OnInit } from '@angular/core';

@Component({
    selector: 'homecomponent',
    template: require('./home.component.html')
})

export class HomeComponent implements OnInit {

    public message: string;

    constructor() {
        this.message = "home.component";
    }

    ngOnInit() {
        console.log("ngOnInit HomeComponent");
    }
}
