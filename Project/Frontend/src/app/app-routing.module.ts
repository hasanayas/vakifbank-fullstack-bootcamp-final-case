import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductsComponent } from './products/products.component';
import { BasketPageComponent } from './basket/basket-page/basket-page.component';
import { UserListComponent } from './user-list/user-list.component';
import { AdminDashboardComponent } from "./admin/admin-dashboard/admin-dashboard.component";
import { LoginComponent } from "./login/login.component";
import { DistributorOrdersComponent  } from "./distributor/distributor-orders/distributor-orders.component";


export const routes: Routes = [
  
  { path: 'products', component: ProductsComponent },
  { path: 'distributororders', component: DistributorOrdersComponent  },
  { path: 'basket', component: BasketPageComponent },
  { path: 'user-list', component: UserListComponent },
  { path: '', component: LoginComponent},  //Default hali

  {path:"Adminpage/:userId", component:AdminDashboardComponent},
  {path:"Distributor/:userId", component:ProductsComponent},
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
