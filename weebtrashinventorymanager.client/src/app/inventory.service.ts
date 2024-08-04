import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { JsonResponseObject, ScannedInventoryItem } from './Models';


@Injectable({
  providedIn: 'root'
})
export class InventoryService {

  constructor(private http: HttpClient) { }

  //Gets
  getInventoryItems(cb: any) {
    this.http.get("/inventory/AllItems").subscribe(cb);
  }

  createCSVFile(cb: any) {
    this.http.get<JsonResponseObject>(`/inventory/CreateWhatNotCSV/`).subscribe(cb);
  }

  //Sets 
  addInventoryItem(cb: any, newItem: string) {
    this.http.get<JsonResponseObject>(`/inventory/addItem?id=${newItem}`).subscribe(cb);
  }

  // Get autocomplete data 
  getAutoCompleteData(cb: any) {
    this.http.get("/inventory/AllDataShort").subscribe(cb);
  }

}
