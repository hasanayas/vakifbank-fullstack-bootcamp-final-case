import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from  '../../env/environment';
import { UserService } from '../../user.service'

@Component({
  selector: 'app-distributor-orders',
  templateUrl: './distributor-orders.component.html',
  styleUrls: ['./distributor-orders.component.css']
})
export class DistributorOrdersComponent {

 // Değişkenler
 waitingOrders: any[] = [];
 completedOrders: any[] = [];
 loggedInUserId!: number;

 constructor(private http: HttpClient,private userService: UserService) { }

 ngOnInit(): void {
  const loggedInUser = this.userService.getLoggedInUser();
  if (loggedInUser) {
    this.loggedInUserId = loggedInUser.Id;
  }

   this.GetOrders();
 }

 GetOrders() {

  let Id = this.loggedInUserId;
    Id = Number(Id);


   this.http.get(`${environment.url}Orders`).subscribe((data: any) => {
    const allOrders = data.response as any[];
    this.waitingOrders = allOrders.filter((order: any) => order.orderStatus === 'Waiting' && order.userId === Id); //Default olarak 2 vermektedir
    this.completedOrders = allOrders.filter((order: any) => order.orderStatus === 'Completed' && order.userId === Id);
  });
}




 //Sil - Kullanıcı Kendi siparişini iptal etmesi için
 deleteOrder(order: any) {
  this.http.delete(`${environment.url}Orders/${order.id}`).subscribe(() => {
    this.GetOrders(); // Siparişi sildikten sonra verileri yeniden yükle
  });
}


 //Tarihe göre filtreleme 
 filterOrders(event: Event) {

  let Id = this.loggedInUserId;
  Id = Number(Id);

  const target = event.target as HTMLSelectElement;
  const days = target.value;
  if (days) {
    const currentDate = new Date();
    const filterDate = new Date(currentDate.getTime() - (parseInt(days) * 24 * 60 * 60 * 1000));

    this.http.get(`${environment.url}Orders`).subscribe((data: any) => {
      const allOrders = data.response as any[];
      this.waitingOrders = allOrders.filter((order: any) => order.orderStatus === 'Waiting' && order.userId === Id && new Date(order.insertDate) >= filterDate); //Bug fix 
      this.completedOrders = allOrders.filter((order: any) => order.orderStatus === 'Completed' && order.userId === Id && new Date(order.insertDate) >= filterDate);  //Bug fix 
    });
  }
}



}
