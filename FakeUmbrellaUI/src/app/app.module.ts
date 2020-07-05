import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { AppComponent } from './app.component';
import { CustomersComponent } from './customers/customers.component';
import { HttpClientModule } from '@angular/common/http';
import { TopCustomersComponent } from './topcustomers/topcustomers.component';
import { AddCustomerComponent } from './add-customer/add-customer.component';
import { EditCustomerComponent } from './edit-customer/edit-customer.component';
import { FormsModule } from '@angular/forms';
import { RainReportComponent } from './rain-report/rain-report.component';



const routes: Routes = [
  { path: 'customers', component: CustomersComponent },
  { path: 'topcustomers', component: TopCustomersComponent },
  { path: 'add-customer', component: AddCustomerComponent },
  { path: 'edit-customer/:id', component: EditCustomerComponent },
  { path: 'rain-report', component: RainReportComponent }

];

@NgModule({
  declarations: [
    AppComponent,
    CustomersComponent,
    TopCustomersComponent,
    AddCustomerComponent,
    EditCustomerComponent,
    RainReportComponent
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
