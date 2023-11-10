import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import * as XLSX from 'xlsx'; //Excel export almak için 
import { format } from 'date-fns'; // Date formatlamak için gerekli
import { environment } from '../../env/environment';

@Component({
  selector: 'app-admin-orders',
  templateUrl: './admin-orders.component.html',
  styleUrls: ['./admin-orders.component.css']
})
export class AdminOrdersComponent implements OnInit {
  // Değişkenler
  waitingOrders: any[] = [];
  processingOrders: any[] = [];
  completedOrders: any[] = [];

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.GetOrders();
  }

  //Siparişleri Getir

  GetOrders() {
    this.http.get(`${environment.url}Orders`).subscribe((data: any) => {
      this.waitingOrders = (data.response as any[]).filter((order: any) => order.orderStatus === 'Waiting');
      this.completedOrders = (data.response as any[]).filter((order: any) => order.orderStatus === 'Completed');

    });
  }

 
 //Güncelle - Durumu Günceller
 PutOrder(order: any) {
  const updatedOrder = {
    id: order.id,
    orderStatus: 'Completed',
    orderPaymentMethod: order.orderPaymentMethod,
    orderAmount: order.orderAmount
  };

  this.http.put(`${environment.url}Orders/${order.id}`, updatedOrder).subscribe((data: any) => {
    order.orderStatus = 'Completed'; // Sipariş durumunu güncelle
    this.GetOrders(); // Siparişi güncelledikten sonra verileri yeniden yükle
  });
}


  //Sil
  DeleteOrder(order: any) {
    this.http.delete(`${environment.url}Orders/${order.id}`).subscribe(() => {
      this.GetOrders(); // Siparişi sildikten sonra verileri yeniden yükle
    });
  }
  

   //Sipariş tarihlerini değiştirme
   formatOrderDate(dateString: string): string {
    const formattedDate = format(new Date(dateString), 'dd/MM/yyyy');
    return formattedDate;
  }
  

   // Excel dışa aktarma işlevi
   exportToExcel(data: any[], filename: string) {
    const formattedData = data.map(order => {
      return {
        id: order.id,
        userId: order.userId,
        orderPaymentMethod: order.orderPaymentMethod,
        orderAmount: order.orderAmount,
        orderStatus: order.orderStatus,
        insertDate: this.formatOrderDate(order.insertDate)
      };
    });
  
    const ws: XLSX.WorkSheet = XLSX.utils.json_to_sheet(formattedData);
    const wb: XLSX.WorkBook = XLSX.utils.book_new();
    XLSX.utils.book_append_sheet(wb, ws, 'Sheet1');
    XLSX.writeFile(wb, `${filename}.xlsx`);
  }

   // Bekleyen İşlemleri JSON'a dönüştürme işlevi
  exportToWaitingJson() {
    const jsonData = JSON.stringify(this.waitingOrders, null, 2);
    const blob = new Blob([jsonData], { type: 'application/json' });
    const url = window.URL.createObjectURL(blob);
    const a = document.createElement('a');
    a.href = url;
    a.download = 'waiting_orders.json';
    document.body.appendChild(a);
    a.click();
    document.body.removeChild(a);
    window.URL.revokeObjectURL(url);
  }

  // Tamamlanmış İşlemleri JSON'a dönüştürme işlevi
  exportToCompletedJson() {
    const jsonData = JSON.stringify(this.completedOrders, null, 2);
    const blob = new Blob([jsonData], { type: 'application/json' });
    const url = window.URL.createObjectURL(blob);
    const a = document.createElement('a');
    a.href = url;
    a.download = 'completed_orders.json';
    document.body.appendChild(a);
    a.click();
    document.body.removeChild(a);
    window.URL.revokeObjectURL(url);
  }
}