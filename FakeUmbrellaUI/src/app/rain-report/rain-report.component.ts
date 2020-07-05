import { Component, OnInit, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Customer } from '../customer';

@Injectable()
@Component({
  selector: 'app-rain-report',
  templateUrl: './rain-report.component.html',
  styleUrls: ['./rain-report.component.css']
})
export class RainReportComponent implements OnInit {

  client: HttpClient = null;
  url: string = '/api/customer/rain';
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
