import { HostListener, Component, Directive } from '@angular/core';
import { ScannedInventoryItem } from '../Models';
import { InventoryService } from '../inventory.service';
import { Observable } from 'rxjs';
import { map, startWith } from 'rxjs/operators';
import { FormControl, FormsModule, ReactiveFormsModule } from '@angular/forms';
import * as items from "../../assets/items.json";

interface options {
  name: string,
  barcodeScan?: string | null
}


@Component({
  selector: 'app-add-inventory-item',
  templateUrl: './add-inventory-item.component.html',
  styleUrl: './add-inventory-item.component.css'
})
export class AddInventoryItemComponent {


  myControl = new FormControl('');
  options: options[] = [{ name: "No Data", barcodeScan: "" }];

  filteredOptions!: Observable<options[]>;
  pickedItem: string = '';

  constructor(private inventoryS: InventoryService) {

  }

  ngOnInit() {
    this.filteredOptions = this.myControl.valueChanges.pipe(
      startWith(''),
      map(value => this._filter(value || '')),
    );

    this.inventoryS.getAutoCompleteData((result: any) => {

      this.options = result.responseObject;
    })
  }



  private _filter(value: string): options[] {
    const filterValue = value.toLowerCase().trim();
    if (filterValue == '') {
      return [{ "name": "Type to start searching...", "barcodeScan": null }]
    }

    let searchValue = filterValue.split(" ")

    let validpicks: options[] = [];


    for (let i = 0; i < searchValue.length; i++) {

      if (i == 0) {
        validpicks = this.options.filter(option => option.name.toLowerCase().includes(searchValue[i]))
        this.item.barcodeScan = '';
      }
      else {
        this.item.barcodeScan = '';
        validpicks = validpicks.filter(option => option.name.toLowerCase().includes(searchValue[i]))
      }

      if (validpicks.length === 1) {
        this.item.barcodeScan = validpicks[0].barcodeScan ? validpicks[0].barcodeScan : "No Barcode Found";
      }
    }

    if (validpicks.length > 10) {
      validpicks = validpicks.slice(0, 10)
      return validpicks
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
    this.item.barcodeScan = '';
  }


  @HostListener('document:keydown.enter', ['$event'])
  eventListener(event: any) {
    this.addInventoryItem();
  }

  failResponse = false;

  addInventoryItem() {
    this.failResponse = false;
    if (this.item.barcodeScan != null && this.item.barcodeScan != undefined && this.item.barcodeScan != '') {

      this.inventoryS.addInventoryItem((result: any) => {
        if (result.statusCode === "404") {
          this.failResponse = true;
          return;
        }
        this.currentItems = result.responseObject.items
        this.total = result.responseObject.total
      }, this.item.barcodeScan)
      this.item.barcodeScan = '';
      this.myControl.setValue('')
      this.total = 0;

    }
  }


  getCurrentList() {
    this.inventoryS.getInventoryItems((result: any) => {
      this.total = result.responseObject.total
      this.currentItems = result.responseObject.items;
    })
  }

  createCSV() {
    this.inventoryS.createCSVFile((result: any) => {
      console.log(result);
      this.currentItems = [];
    });
  }

}
