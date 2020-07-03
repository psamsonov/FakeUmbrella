import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { AppComponent } from './app.component';
import { CustomersComponent } from './customers/customers.component';
import { HttpClientModule } from '@angular/common/http';
import { TopCustomersComponent } from './topcustomers/topcustomers.component';


const routes: Routes = [
  { path: 'customers', component: CustomersComponent },
  
  { path: 'topcustomers', component: TopCustomersComponent }
];

@NgModule({
  declarations: [
    AppComponent,
    CustomersComponent,
    TopCustomersComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
