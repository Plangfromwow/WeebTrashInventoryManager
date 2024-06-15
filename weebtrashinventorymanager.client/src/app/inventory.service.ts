import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ScannedInventoryItem } from './Models';


@Injectable({
  providedIn: 'root'
})
export class InventoryService {

  constructor(private http: HttpClient) { }

  //Gets
  getInventoryItems(cb: any) {
    this.http.get("/inventory").subscribe(cb);
  }

  getInventoryItemFromScan(cb: any, id: string) {
    this.http.get<ScannedInventoryItem>(`/inventory/${id}`).subscribe(cb);
  }

  //Sets 
  addInventoryItem(cb: any, newItem: ScannedInventoryItem) {
    this.http.post<ScannedInventoryItem>("/inventory", newItem).subscribe(cb);
  }






}
