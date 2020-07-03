import { Component, OnInit } from '@angular/core';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';

import {Customer} from '../customer';


@Injectable()
@Component({
  selector: 'app-customers',
  templateUrl: './customers.component.html',
  styleUrls: ['./customers.component.css']
})
export class CustomersComponent implements OnInit {

  client: HttpClient = null;
  url: string = '/api/customer';
  customers: Customer[] = null;
  error = null;

  constructor(private http: HttpClient) {
    this.client = http;

  }

  ngOnInit(): void {
    this.client.get(this.url).subscribe(
      (data: Customer[]) =>
      {
        this.customers = data;
      },
      (error) =>
      {
        this.error = error.message;
      }
    );
  }

}
