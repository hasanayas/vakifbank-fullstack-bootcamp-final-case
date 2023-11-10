import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { UserService } from '../user.service';
import { environment } from '../env/environment';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit {
  productRows: any[][] = [];
  products: any[] = [];
  filteredProducts: any[] = [];
  karmarji = 1;
  searchTerm = '';
  ProfitMargin!: number;

  constructor(private http: HttpClient, private router: Router, private userService: UserService) {}

  // Sayfa yüklendiğinde çalışacak olan fonksiyon
  ngOnInit(): void {

    // Kâr marjını güncelle
    const loggedInUser = this.userService.getLoggedInUser();
    this.karmarji *= 1 + Number(loggedInUser.UserProfitMargin) / 100;

    // Ürünleri yükle 
    this.GetProducts();
  }

  // Ürünleri API'den yükleyen fonksiyon
  GetProducts() {
    this.http.get(`${environment.url}Products`).subscribe((data: any) => {
      this.products = data.response;
      this.arrangeProducts();
    });
  }

  // Ürünleri satır halinde düzenleyen fonksiyon
  arrangeProducts() {
    let currentRow: any[] = [];
    for (let i = 0; i < this.products.length; i++) {
      currentRow.push(this.products[i]);
      if (currentRow.length === 3 || i === this.products.length - 1) {
        this.productRows.push(currentRow);
        currentRow = [];
      }
    }
  }

  // Sepet sayfasına yönlendirme yapan fonksiyon
  goToBasket() {
    this.router.navigate(['basket']);
  }

  // Ürünleri arama işlemini gerçekleştiren fonksiyon
  searchProducts() {
    this.filteredProducts = this.products.filter(product => {
      return product.productName.toLowerCase().includes(this.searchTerm.toLowerCase());
    });
  }
}
