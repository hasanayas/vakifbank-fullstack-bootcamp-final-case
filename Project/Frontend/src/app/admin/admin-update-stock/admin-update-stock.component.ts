import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../env/environment';

@Component({
  selector: 'app-admin-update-stock',
  templateUrl: './admin-update-stock.component.html',
  styleUrls: ['./admin-update-stock.component.css']
})
export class AdminUpdateStockComponent implements OnInit {

  selectedProduct: any;
  products: any[] = [];
  newStock: number = 0;

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.GetProducts();
  }

  GetProducts() {
   this.http.get<any>(`${environment.url}Products`).subscribe(data => {
      this.products = data.response;
    });
  }

  selectProduct(product: any) {
    this.selectedProduct = product;
    this.newStock = product.productQuantity;
  }

  PutStock() {
    if (this.selectedProduct) {
      const { ProductName, ProductImage, ProductInformation } = this.selectedProduct;
      const updatedProduct = {
        ...this.selectedProduct,
        productQuantity: this.newStock,
        ProductName,
        ProductImage,
        ProductInformation
      };

      if (this.newStock >= 1) {
        this.http.put<any>(`${environment.url}Products/${this.selectedProduct.id}`, updatedProduct)
          .subscribe(data => {
            this.selectedProduct.productQuantity = this.newStock;
            this.GetProducts(); // Güncelleme işlemi tamamlandıktan sonra verileri tekrar yükle
          });
      } else {
        alert('Stok adedi 1 den küçük olamaz.');
      }
    }
  }
}
