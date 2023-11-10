import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { formatDate } from '@angular/common';
import { UserService } from '../../user.service';
import { environment } from  '../../env/environment';

@Component({
  selector: 'app-basket-page',
  templateUrl: './basket-page.component.html',
  styleUrls: ['./basket-page.component.css']
})
export class BasketPageComponent implements OnInit {
  selectedPaymentMethod = 'Credit Card';
  products: any[] = [];
  loggedInUserId!: number;

  constructor(private http: HttpClient, private userService: UserService) { }

  ngOnInit() {
    // Kullanıcı oturumunda ise, kullanıcı kimliğini al
    const loggedInUser = this.userService.getLoggedInUser();
    if (loggedInUser) {
      this.loggedInUserId = loggedInUser.Id;
    }
    // Sepet verilerini yükle
    this.GetBaskets();
  }

  // Sepet verilerini yükler
  GetBaskets() {
    // Kullanıcı kimliğini al
    let Id = this.loggedInUserId;
    Id = Number(Id);
    
    // Sepet verilerini API'den yükle ve filtrele
    this.http.get(`${environment.url}Baskets?userId=${this.loggedInUserId}`).subscribe((data: any) => {
      this.products = data.response.filter((item: any) => item.userId === Id && item.basketStatus === true);
      // Ürün adını id'sine göre getir
      this.products.forEach(product => {
        this.getProductNameById(product.productId, product);
      });
    });
  }

  // Ürün adını id'sine göre getirir
  getProductNameById(productId: number, product: any) {
    this.http.get(`${environment.url}Products/${productId}`).subscribe((data: any) => {
      if (product) {
        product.productName = data.response.productName;
      }
    });
  }

  // Sepetteki toplam fiyatı getirir
  getTotalPrice(): number {
    return this.products.reduce((acc, curr) => acc + curr.basketPrice, 0);
  }

  // Ödeme yapar
  makePayment() {
    let Id = this.loggedInUserId;
    Id = Number(Id);

    // Sipariş verilerini oluştur
    const orderData = {
      userId: Id,
      orderStatus: 'Waiting',
      orderPaymentMethod: this.selectedPaymentMethod,
      orderAmount: this.getTotalPrice(),
      insertDate: formatDate(new Date(), 'yyyy-MM-dd HH:mm:ss.SSSSSSS', 'en-US')
    };

    // Ödeme yapma işlemlerini gerçekleştir
    this.http.post(`${environment.url}Orders`, orderData).subscribe(
      (response) => {
        alert('Payment completed successfully. Order created.');
        // Ödeme sonrası sepet durumunu güncelle ve ürün stoğunu düşür
        this.products.forEach(product => {
          this.updateBasketStatus(product.id);
          this.updateProductStock(product.productId, product.basketQuantity);
        });
      },
      (error) => {
        alert('An error occurred during payment');
      }
    );
  }

  // Ürün stoğunu günceller
  updateProductStock(productId: number, quantity: number) {
    this.http.get(`${environment.url}Products/${productId}`).subscribe((data: any) => {

      const product = data.response;
      if (product) {
        product.productQuantity -= quantity;
        // Güncellenen stok bilgisini API'ye gönder
        this.http.put(`${environment.url}Products/${productId}`, product).subscribe();
      }
    });
  }

  // Sepet durumunu günceller
  updateBasketStatus(basketId: number) {
    const updatedBasket = {
      basketStatus: false
    };

    this.http.put(`${environment.url}Baskets/${basketId}`, updatedBasket).subscribe(
      (response) => {
        this.products = this.products.filter(product => product.id !== basketId);
      }
    );
  }

  // Ürünü sepetten kaldırır
  removeItem(productId: number) {
    this.http.delete(`${environment.url}Baskets/${productId}`).subscribe((response) => {
      this.products = this.products.filter(product => product.productId !== productId);
      this.GetBaskets();
    });
  }
}
