import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Customer } from '../customer';
import { Validators } from '@angular/forms';
import { CustomersComponent } from '../customers/customers.component';
import { Router } from '@angular/router';


@Injectable()
@Component({
  selector: 'app-reactive-customer',
  templateUrl: './add-customer.component.html'
})
export class AddCustomerComponent {
  customerControl = new FormControl('');

  client: HttpClient = null;
  url: string = '/api/customer';
  customer: Customer = new Customer();
  error = null;


  constructor(private http: HttpClient, private router: Router) {
    this.client = http;

  }

  onSubmit(): void {


    this.client.post(this.url, this.customer).subscribe(
      (data) =>
      {
        this.router.navigate(['/customers'])
      },
      (error) =>
      {
        this.error = error.message;
      }
    );
  }


}