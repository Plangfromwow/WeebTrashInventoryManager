import { Component } from '@angular/core';
import { ScannedInventoryItem, WhatNotItem } from '../Models';
import { InventoryService } from '../inventory.service';

@Component({
  selector: 'app-add-inventory-item',
  templateUrl: './add-inventory-item.component.html',
  styleUrl: './add-inventory-item.component.css'
})


export class AddInventoryItemComponent {

  constructor(private inventory: InventoryService) { }

  item: ScannedInventoryItem =
    {
      barcodeScan: '',
      category: '',
      subCategory: '',
      title: '',
      description: '',
      quantity: '',
      whatNotType: '',
      price: '',
      shippingProfile: '',
      gradable: '',
      offerable: '',
      hazmat: '',
      imageURL1: '',
      imageURL2: '',
      imageURL3: '',
      imageURL4: '',
      imageURL5: '',
      imageURL6: '',
      imageURL7: '',
      imageURL8: ''
    };

  buttonSubmit() {
    let barcodeScan: String = this.item.barcodeScan.toString();
    console.log(`The button was pressed. Item Barcode: ${barcodeScan}`)
  }

  addInventoryItem(item: ScannedInventoryItem) {

  }




}
