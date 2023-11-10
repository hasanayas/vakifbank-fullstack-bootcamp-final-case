 // user-list.component.ts

 import { Component, OnInit } from '@angular/core';
 import { HttpClient } from '@angular/common/http';
 
 @Component({
   selector: 'app-user-list',
   templateUrl: './user-list.component.html',
   styleUrls: ['./user-list.component.css']
 })
 
 export class UserListComponent implements OnInit {
   users: any[] = [];
   selectedUser: any;
   userId: number = 0; // Başlangıçta 0 olarak atanmış.
   userIdToDelete: number = 1;
 
   //New User
   newUserNumber: number = 0;
   newUserName: string = '';
   newUserEmail: string = '';
   newUserPassword: string = '';
   newUserPasswordRetryCount: number = 0;
   newUserRole: string = '';
   newUserBalance: number = 0;
   newUserProfitMargin: number = 0;
   newUserInsertData: Date = new Date();

   //Updata User 
  updateUserNumber: number = 0;
  updateUserName: string = '';
  updateUserEmail: string = '';
  updateUserPassword: string = '';
  updateUserRole: string = '';
  updateUserBalance: number = 0;
  updateUserProfitMargin: number = 0;
   
 
 
   constructor(private http: HttpClient) { }
 
   ngOnInit(): void {
     this.loadUsers();
   }
 
   loadUsers() {
     this.http.get('https://localhost:44346/finalCase/Users').subscribe((data: any) => {
       this.users = data.response;
     });
   }
 
   //IDye göre
   searchUser() {
     if (this.userId) {
       this.http.get(`https://localhost:44346/finalCase/Users/${this.userId}`).subscribe((data: any) => {
         this.selectedUser = data.response;
       });
     }
   }
 
 
   deleteUser() {
     if (this.userIdToDelete) {
       this.http.delete(`https://localhost:44346/finalCase/Users/${this.userIdToDelete}`).subscribe((data: any) => {
         this.loadUsers(); // Kullanıcılar yeniden yüklenir
       });
     }
   }
 
   
   //CREATE FONKSİYONU
   createUser() {
     const currentDate = new Date(); 
     const formattedDate = currentDate.toISOString();
   
     const newUser = {
       UserNumber: this.newUserNumber,
       UserName: this.newUserName,
       UserEmail: this.newUserEmail,
       UserPassword: this.newUserPassword,
       UserRole: this.newUserRole,
       UserBalance: this.newUserBalance,
       UserProfitMargin: this.newUserProfitMargin,
       InsertDate: formattedDate,
     };
   
     this.http.post('https://localhost:44346/finalCase/Users', newUser).subscribe((data: any) => {
       this.loadUsers();
       this.resetInputFields();
     });
   }
   


   //UpdateFonksiyonu

  updateUser() {
    const updatedUser = {
      UserNumber: this.updateUserNumber,
      UserName: this.updateUserName,
      UserEmail: this.updateUserEmail,
      UserPassword: this.updateUserPassword,
       UserRole: this.updateUserRole,
      UserBalance: this.updateUserBalance,
      UserProfitMargin: this.updateUserProfitMargin
    };

    this.http.put(`https://localhost:44346/finalCase/Users/${this.userId}`, updatedUser).subscribe((data: any) => {
      this.loadUsers();
      this.resetUpdateFields();
    });
  }

   
   
//Alanları eski haline getirir
   resetInputFields() {
    this.newUserNumber = 0;
    this.newUserName = '';
    this.newUserEmail = '';
    this.newUserPassword = '';
    this.newUserPasswordRetryCount = 0;
    this.newUserRole = '';
    this.newUserBalance = 0;
    this.newUserProfitMargin = 0;
    this.newUserInsertData = new Date();
  }

  //Tablodaki verileri inputları taşıyan fonksiyon
  transferUserData(user: any) {
    this.userId = user.id
    this.updateUserNumber = user.userNumber;
    this.updateUserName = user.userName;
    this.updateUserEmail = user.userEmail;
    this.updateUserRole = user.userRole;
    this.updateUserPassword = user.userPassword;
    this.updateUserBalance = user.userBalance;
    this.updateUserProfitMargin = user.userProfitMargin;
  }
  

//İnput alanlarını resetler
  resetUpdateFields() {
    this.updateUserNumber = 0;
    this.updateUserName = '';
    this.updateUserEmail = '';
    this.updateUserPassword = '';
    this.updateUserRole = '';
    this.updateUserBalance = 0;
    this.updateUserProfitMargin = 0;
  }

 
  //  logNewUserData() {
  //    const currentDate = new Date(); 
  //    const formattedDate = currentDate.toISOString(); 
 
  //    const newUser = {
  //      UserNumber: this.newUserNumber,
  //      UserName: this.newUserName,
  //      UserEmail: this.newUserEmail,
  //      UserPassword: this.newUserPassword,
  //      UserRole: this.newUserRole,
  //      UserBalance: this.newUserBalance,
  //      UserProfitMargin: this.newUserProfitMargin,
  //      InsertDate: formattedDate,
  //    };
 
  //    console.log("New User Data:", newUser);
  //  }
   
 }