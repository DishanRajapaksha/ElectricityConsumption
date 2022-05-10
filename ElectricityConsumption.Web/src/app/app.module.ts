import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ClarityModule } from '@clr/angular';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { GridComponent } from './components/grid/grid.component';
import { NavigationComponent } from './components/navigation/navigation.component';
import { HomeComponent } from './views/home/home.component';
import { ConsumptionGridComponent } from './containers/consumption-grid/consumption-grid.component';
import { HttpClient, HttpClientModule } from "@angular/common/http";

@NgModule({
  declarations: [
    AppComponent,
    GridComponent,
    NavigationComponent,
    HomeComponent,
    ConsumptionGridComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ClarityModule,
    BrowserAnimationsModule,
    HttpClientModule
  ],
  providers: [
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
