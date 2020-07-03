import { Component, Input } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Customer } from '../customer';
import { FormsModule } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';


@Injectable()
@Component({
  selector: 'app-reactive-customer',
  templateUrl: './edit-customer.component.html'
})
export class EditCustomerComponent {
  customerControl = new FormControl('');

  client: HttpClient = null;
  url: string = '/api/customer';
  id: string;

  customer: Customer;
  error = null;


  constructor(private http: HttpClient, private _ActivatedRoute:ActivatedRoute, private router: Router) {
    this.client = http;

    this._ActivatedRoute.paramMap.subscribe(params => { 
        var id = params.get('id'); 

        this.client.get(this.url + '/' + id).subscribe(
          (data: Customer) =>
          {
            this.customer = data;
          },
          (error) =>
          {
            this.error = error.message;
          }
        );
    });
     
  }

  onSubmit(): void {
    this.client.put(this.url + '/' + this.customer.id, this.customer).subscribe(
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