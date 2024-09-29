import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AddInventoryItemComponent } from './add-inventory-item/add-inventory-item.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { MatSlideToggleModule } from '@angular/material/slide-toggle'
import { MatAutocomplete, MatAutocompleteModule, MatOption } from '@angular/material/autocomplete'
import { AsyncPipe } from '@angular/common';
import { MatInput } from '@angular/material/input';
import { NavigationComponent } from './navigation/navigation.component';
import { HomeComponent } from './home/home.component'
import { LowerCaseUrlSerializer } from './util/UrlSerializer';
import { UrlSerializer } from '@angular/router';
import { UpdateMetaDataComponent } from './update-meta-data/update-meta-data.component';
import { CreateSquareCsvComponent } from './create-square-csv/create-square-csv.component';

@NgModule({
  declarations: [
    AppComponent,
    AddInventoryItemComponent,
    NavigationComponent,
    HomeComponent,
    UpdateMetaDataComponent,
    CreateSquareCsvComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    MatSlideToggleModule,
    MatAutocompleteModule,
    AsyncPipe,
    MatInput,
  ],
  providers: [
    provideAnimationsAsync(),
    {
      provide: UrlSerializer,
      useClass: LowerCaseUrlSerializer
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
