import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../env/environment';

@Component({
  selector: 'app-admin-report',
  templateUrl: './admin-report.component.html',
  styleUrls: ['./admin-report.component.css']
})
export class AdminReportComponent implements OnInit {
  totalCompletedOrdersOneDay: number = 0;
  totalCompletedOrdersSevenDays: number = 0;
  totalCompletedOrdersThirtyDays: number = 0;

  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.getReport();
  }

  getReport() {
    const apiUrl = `${environment.url}Orders`;
    this.http.get(apiUrl).subscribe((response: any) => {
      const orders = response.response;
      const currentDate = new Date();
  
      this.totalCompletedOrdersOneDay = this.calculateCompletedOrders(orders, this.getDateFilter(currentDate, 1), 'Completed');
      this.totalCompletedOrdersSevenDays = this.calculateCompletedOrders(orders, this.getDateFilter(currentDate, 6), 'Completed');
      this.totalCompletedOrdersThirtyDays = this.calculateCompletedOrders(orders, this.getDateFilter(currentDate, 23), 'Completed');
    });
  }

  calculateCompletedOrders(orders: any[], filterDate: Date, status: string): number {
    return orders
      .filter((order: any) => new Date(order.insertDate) >= filterDate && order.orderStatus === status)
      .length;
  }

  getDateFilter(currentDate: Date, daysAgo: number): Date {
    return new Date(currentDate.setDate(currentDate.getDate() - daysAgo));
  }
}
