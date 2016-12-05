import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { DropdownValue } from './DropdownValue';

@Component({
  selector: 'dropdown',
  template: `
    <ul>
      <li *ngFor="values" (click)="selectItem(value.value)">{{value.label}}</li>
    </ul>
  `
})
export class DropdownComponent {
  @Input()
  values: DropdownValue[];

  @Output()
  select = new EventEmitter();

  constructor() {
    this.select = new EventEmitter();
  }

  selectItem(value: number) {
    this.select.emit(value);
  }
}