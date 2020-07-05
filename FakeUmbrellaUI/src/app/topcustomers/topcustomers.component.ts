import { Component, OnInit } from '@angular/core';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';
import { Chart } from 'chart.js'

import {Customer} from '../customer';

@Injectable()
@Component({
  selector: 'app-topcustomers',
  templateUrl: './topcustomers.component.html',
  styleUrls: ['./topcustomers.component.css']
})
export class TopCustomersComponent implements OnInit {

  xAxis: string[];
  yAxis: number[];
  xAxisColor: string[];
  yAxisMax: number = 0;
  client: HttpClient = null;
  url: string = '/api/customer/top';
  customers: Customer[] = null;
  error = null;
  chart: Chart = null;

  constructor(private http: HttpClient) {
    this.client = http;

  }

  ngOnInit(): void {
    this.client.get(this.url).subscribe(
      (data: Customer[]) =>
      {
        this.customers = data;
        this.xAxis = data.map(x => x.customerName);
        this.yAxis = data.map(x => x.numberOfEmployees);
        this.xAxisColor = data.map(x => x.willRain? 'green' : 'red')

        this.chart = new Chart('canvas', {
          type: 'bar',
          data: {
            labels: this.xAxis,
            datasets: [
              {
                data: this.yAxis,
                backgroundColor : this.xAxisColor
              }
            ]
          } ,
          options: {
              legend: {
                display: false
              },
              scales: {
                  yAxes: [{
                      ticks: {
                          suggestedMin: 0,
                          suggestedMax: this.yAxisMax
                      }
                  }]
              }
          }
        }
      );


        
      },
      (error) =>
      {
        this.error = error.message;
      }
    );
  }


}
