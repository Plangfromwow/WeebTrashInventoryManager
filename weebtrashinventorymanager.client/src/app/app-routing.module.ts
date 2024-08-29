import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { AddInventoryItemComponent } from './add-inventory-item/add-inventory-item.component';
import { HomeComponent } from './home/home.component';
import { UpdateMetaDataComponent } from './update-meta-data/update-meta-data.component';

const routes: Routes = [
  { path: "", component: HomeComponent },
  { path: "whatnotcsv", component: AddInventoryItemComponent },
  { path: "updatemetadata", component: UpdateMetaDataComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
