import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { AddInventoryItemComponent } from './add-inventory-item/add-inventory-item.component';

const routes: Routes = [
  { path: "", component: AppComponent },
  { path: "AddItem", component: AddInventoryItemComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
