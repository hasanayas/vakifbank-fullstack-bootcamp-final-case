import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';



import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { ProductCardComponent } from './product-card/product-card.component';
import { ProductsComponent } from './products/products.component';
import { BasketPageComponent } from './basket/basket-page/basket-page.component';
import { BasketCardComponent } from './basket/basket-card/basket-card.component';
import { PaymentComponent } from './payment/payment.component';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { UserListComponent } from './user-list/user-list.component';
import { AdminDashboardComponent } from './admin/admin-dashboard/admin-dashboard.component';
import { AdminSidebarComponent } from './admin/admin-sidebar/admin-sidebar.component';
import { AdminOrdersComponent } from './admin/admin-orders/admin-orders.component';
import { RouterModule } from '@angular/router';
import { routes } from './app-routing.module';
import { DistributorOrdersComponent } from './distributor/distributor-orders/distributor-orders.component';
import { CommonModule } from '@angular/common';
import { AdminReportComponent } from './admin/admin-report/admin-report.component';
import { AdminUpdateStockComponent } from './admin/admin-update-stock/admin-update-stock.component'; 
import { AdminPageComponent } from './admin/admin-page/admin-page.component';
import { AdminsUserPageComponent } from './admin/admins-user-page/admins-user-page.component'; 

@NgModule({
  declarations: [
    // HttpClientModule,
    AppComponent,
    LoginComponent,
    AdminSidebarComponent,
    ProductCardComponent,
    ProductsComponent,
    BasketPageComponent,
    BasketCardComponent,
    PaymentComponent,
    UserListComponent,
    AdminDashboardComponent,
    AdminSidebarComponent,
    AdminOrdersComponent,
    DistributorOrdersComponent,
    AdminReportComponent,
    AdminUpdateStockComponent,
    AdminPageComponent,
    AdminsUserPageComponent,
    


  ],
  imports: [
    CommonModule, //Date için gerekli
    FormsModule,
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    RouterModule.forRoot(routes)
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
