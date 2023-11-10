import { Component } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';
import { UserService } from '../user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {

  loginObj: any = {
    "userEmail": "",
    "userPassword": ""
  };

  constructor(private http: HttpClient, private router: Router, private userService: UserService) { }

  onLogin() {
    const baseUrl = 'https://localhost:44346/';

    // JSON verileri dizeye çevir
    const body = JSON.stringify(this.loginObj);

    // Headers oluştur ve JSON içeriğini ayarla
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });

    this.http.post(baseUrl + 'finalCase/Tokens', body, { headers: headers }).subscribe((res: any) => {

      if (res.success) {

        localStorage.setItem('loginToken', res.response.token);
        const tokenPayload = JSON.parse(atob(res.response.token.split('.')[1]));

        // Kullanıcı bilgilerini userService'e ayarla
        this.userService.setLoggedInUser(tokenPayload);

        const userRole = tokenPayload.UserRole;
        const userId = parseInt(tokenPayload.Id);

        if (userRole === 'Admin') {
          this.router.navigateByUrl(`/Adminpage/${userId}`);
        } else if (userRole === 'Dealer') {
          this.router.navigateByUrl(`/Distributor/${userId}`);
        }
      } else {
      }
    });
  }
}
