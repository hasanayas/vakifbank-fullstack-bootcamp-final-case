import { Component, Input } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { UserService } from '../user.service';
import { environment } from '../env/environment';

@Component({
  selector: 'app-product-card',
  templateUrl: './product-card.component.html',
  styleUrls: ['./product-card.component.css']
})
export class ProductCardComponent {

  @Input() productName!: string;
  @Input() productInfo!: string;
  @Input() stockQuantity!: number;
  @Input() price!: number;
  @Input() productId!: number;
  quantity = 0;

  constructor(private http: HttpClient, private userService: UserService) { }

  decreaseQuantity() {
    if (this.quantity > 0) this.quantity--;
  }

  increaseQuantity() {
    if (this.quantity < this.stockQuantity) this.quantity++;
  }

  addToBasket() {
    const loggedInUser = this.userService.getLoggedInUser();
    if (!loggedInUser) return;

    const userId = loggedInUser.Id;
    const basketRequest = {
      UserId: userId,
      ProductId: this.productId,
      orderId: 0,
      BasketQuantity: this.quantity,
      BasketPrice: this.quantity * this.price,
      BasketStatus: true,
    };

    this.http.post(`${environment.url}Baskets`, basketRequest).subscribe((data: any) => {});
  }
}
