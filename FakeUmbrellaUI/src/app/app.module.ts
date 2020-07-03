import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { AppComponent } from './app.component';
import { CustomersComponent } from './customers/customers.component';
import { HttpClientModule } from '@angular/common/http';
import { TopCustomersComponent } from './topcustomers/topcustomers.component';
import { AddCustomerComponent } from './add-customer/add-customer.component';
import { FormsModule } from '@angular/forms';



const routes: Routes = [
  { path: 'customers', component: CustomersComponent },
  { path: 'topcustomers', component: TopCustomersComponent },
  { path: 'add-customer', component: AddCustomerComponent }
];

@NgModule({
  declarations: [
    AppComponent,
    CustomersComponent,
    TopCustomersComponent,
    AddCustomerComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    RouterModule.forRoot(routes),
    FormsModule
  ],
  exports: [RouterModule],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
