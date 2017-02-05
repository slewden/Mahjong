import { NgModule }      from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule }   from '@angular/forms';

import { AppComponent }  from './app.component';
import { UiPartieBegin } from './ui.partieBegin';

@NgModule({
  imports: [
    BrowserModule,
    FormsModule
  ],
  declarations: [
    AppComponent,
    UiPartieBegin
  ],
  bootstrap:    [ AppComponent ]
})
export class AppModule { }
