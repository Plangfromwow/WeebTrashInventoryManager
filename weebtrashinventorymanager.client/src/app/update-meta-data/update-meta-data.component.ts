import { Component, HostListener } from '@angular/core';
import { ScannedInventoryItem } from '../Models';

@Component({
  selector: 'app-update-meta-data',
  templateUrl: './update-meta-data.component.html',
  styleUrl: './update-meta-data.component.css'
})
export class UpdateMetaDataComponent {
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

  @HostListener('document:keydown.enter', ['$event'])
  eventListener(event: any) {
    this.addOrUpdateMetaDataItem();
  }

  addOrUpdateMetaDataItem() {
    console.log("This would add an item to the thing: " + this.item.barcodeScan);
  }

}
