import { HostListener, Component, Directive } from '@angular/core';
import { ScannedInventoryItem } from '../Models';
import { InventoryService } from '../inventory.service';
import { Observable } from 'rxjs';
import { map, startWith } from 'rxjs/operators';
import { FormControl, FormsModule, ReactiveFormsModule } from '@angular/forms';
import * as items from "../../assets/items.json";

interface options {
  Title: string,
  Barcode?: string | null
}


@Component({
  selector: 'app-add-inventory-item',
  templateUrl: './add-inventory-item.component.html',
  styleUrl: './add-inventory-item.component.css'
})
export class AddInventoryItemComponent {


  myControl = new FormControl('');
  options: options[] = items.items;
  filteredOptions!: Observable<options[]>;
  pickedItem: string = '';

  constructor(private inventoryS: InventoryService) {

  }

  ngOnInit() {
    this.filteredOptions = this.myControl.valueChanges.pipe(
      startWith(''),
      map(value => this._filter(value || '')),
    );
  }



  private _filter(value: string): options[] {
    const filterValue = value.toLowerCase().trim();
    if (filterValue == '') {
      return [{ "Title": "Type to start searching...", "Barcode": null }]
    }

    let searchValue = filterValue.split(" ")

    let validpicks: options[] = [];

    for (let i = 0; i < searchValue.length; i++) {
      if (i == 0) {
        validpicks = this.options.filter(option => option.Title.toLowerCase().includes(searchValue[i]))
      }
      else {
        validpicks = validpicks.filter(option => option.Title.toLowerCase().includes(searchValue[i]))
      }
    }

    return validpicks
    // return this.options.filter(option => option.name.toLowerCase().includes(filterValue))
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
    this.addInventoryItem();
  }

  addInventoryItem() {
    console.log(this.myControl);
    console.log(this.item)

    if (this.item.barcodeScan != null && this.item.barcodeScan != undefined && this.item.barcodeScan != '') {
      console.log("Add Item ran" + this.item.barcodeScan.toString());

      this.inventoryS.addInventoryItem((result: any) => {
        this.currentItems = result.responseObject
      }, this.item.barcodeScan)
      this.item.barcodeScan = '';
      this.currentItems.forEach(item => {
        let int = parseInt(item.quantity)
        this.total = this.total + int;
      });
    }
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
