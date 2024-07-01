import { HostListener, Component, Directive } from '@angular/core';
import { ScannedInventoryItem } from '../Models';
import { InventoryService } from '../inventory.service';

@Component({
  selector: 'app-add-inventory-item',
  templateUrl: './add-inventory-item.component.html',
  styleUrl: './add-inventory-item.component.css'
})
export class AddInventoryItemComponent {

  constructor(private inventoryS: InventoryService) {

  }

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

  items: ScannedInventoryItem[] = [];

  currentItems: ScannedInventoryItem[] = [];

  total: number = 0;

  buttonSubmit() {
    let barcodeScan: String = this.item.barcodeScan.toString();
    console.log(`The button was pressed. Item Barcode: ${barcodeScan}`)
    this.item.barcodeScan = '';
  }


  @HostListener('document:keydown.enter', ['$event'])
  eventListener(event: any) {
    this.addInventoryItem(this.item);
  }

  addInventoryItem(item: ScannedInventoryItem) {
    if (item.barcodeScan != null && item.barcodeScan != undefined && item.barcodeScan != '') {
      console.log("Add Item ran" + item.barcodeScan.toString());

      this.inventoryS.addInventoryItem((result: any) => {
        // let newItem: ScannedInventoryItem = {
        //   barcodeScan: result.responseObject.barcodeScan,
        //   category: '',
        //   subCategory: '',
        //   title: result.responseObject.title,
        //   description: result.responseObject.description,
        //   quantity: result.responseObject.quantity,
        //   whatNotType: '',
        //   price: '',
        //   shippingProfile: '',
        //   gradable: '',
        //   offerable: '',
        //   hazmat: '',
        //   imageURL1: '',
        //   imageURL2: '',
        //   imageURL3: '',
        //   imageURL4: '',
        //   imageURL5: '',
        //   imageURL6: '',
        //   imageURL7: '',
        //   imageURL8: ''
        // }

        //this.currentItems.push(newItem)

        this.currentItems = result.responseObject


      }, item.barcodeScan)
      this.item.barcodeScan = '';
      this.currentItems.forEach(item => {
        let int = parseInt(item.quantity)
        this.total = this.total + int;
      });
    }
  }



  createCSV() {

    this.inventoryS.createCSVFile((result: any) => {
      console.log(result);
      this.currentItems = [];
    });

  }

  getCurrentList() {
    this.inventoryS.getInventoryItems((result: any) => {
      this.currentItems = result;
      this.currentItems.forEach(item => {
        let int = parseInt(item.quantity)
        this.total = this.total + int;
      });
    })
  }

}
