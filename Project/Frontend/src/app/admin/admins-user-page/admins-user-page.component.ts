import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../env/environment';

@Component({
  selector: 'app-admins-user-page',
  templateUrl: './admins-user-page.component.html',
  styleUrls: ['./admins-user-page.component.css'],
})
export class AdminsUserPageComponent {

  users: any[] = [];
  userNumber!: number;
  userName!: string;
  userEmail!: string;
  userPassword!: string;
  userRole: string = 'Dealer';
  userBalance!: number;
  userProfitMargin!: number;
  

  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.GetUsers();
  }

  PostUser() {
    const data = {
      userNumber: this.userNumber,
      userName: this.userName,
      userEmail: this.userEmail,
      userPassword: this.userPassword,
      userRole: 'Dealer',
      userBalance: this.userBalance,
      userProfitMargin: this.userProfitMargin,
    };
  
    // Kullanıcı ekleme
    this.http.post(`${environment.url}Users`, data).subscribe(
      (response) => {
        alert('User created');
        // Kullanıcı oluşturulduktan sonra mail gönderme işlemini yap
        this.sendMail(this.userName, this.userPassword);
        this.GetUsers();
      },
      (error) => {
        alert('An error occurred while creating the user');
      }
    );
  }
  

  //Kullanıcıları getirme
  GetUsers() {
    this.http.get<any>(`${environment.url}Users`).subscribe(
      (response) => {
        this.users = response.response.filter((user: any) => user.userRole === 'Dealer');
      }
    );
  }
  
//Kullanıcıyı silme
deleteUser(id: number) {
  const confirmed = confirm("Are you sure you want to delete the user?");
  if (confirmed) {
    this.http.delete(`${environment.url}Users/${id}`).subscribe(
      (response) => {
        alert('User deleted');
        this.GetUsers();
      },
      (error) => {
        alert('An error occurred while deleting the user');
      }
    );
  }
}

//Mail Gönderme 
sendMail(userName: string, password: string) {
  const data = {
    email: this.userEmail,
    description: `Your registration has been successfully completed. Username: ${userName}, Your password: ${password}`

  };

  // http servisi ile post işlemini gerçekleştiriyoruz
  this.http.post(`${environment.url}Mails`, data).subscribe(
    (response) => {
      alert('Email sent successfully.');
    },
    (error) => {
      alert('An error occurred while sending the email.');
    }
  );
}

  
}
