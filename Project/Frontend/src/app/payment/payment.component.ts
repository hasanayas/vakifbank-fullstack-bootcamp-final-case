import { Component, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-payment',
  templateUrl: './payment.component.html',
  styleUrls: ['./payment.component.css']
})
export class PaymentComponent {
  totalPrice: number;
  
  @Input() selectedPaymentMethod: string;
  @Output() selectedPaymentMethodChange = new EventEmitter<string>(); // New output event

  expiryDate: string;
  cvv: string;
  creditCardNumber: string;
  bankName: string;
  accountNumber: string;
  iban: string;

  constructor() {
    this.totalPrice = 0;
    this.selectedPaymentMethod = 'creditCard';
    this.creditCardNumber = '';
    this.expiryDate = '';
    this.cvv = '';
    this.bankName = '';
    this.accountNumber = '';
    this.iban = '';
  }

  //Seçilen ödeme yöntemi
  onPaymentMethodChange(event: Event) {
    this.selectedPaymentMethod = (event.target as HTMLSelectElement).value;
    this.selectedPaymentMethodChange.emit(this.selectedPaymentMethod); // Emit the selected payment method
  }


   // Kredi kartı numarasını 4'ü 4'e bölmek için bir işlev 
   formatCreditCardNumber() {
    // Boşlukları kaldırarak sadece rakamları alır.
    this.creditCardNumber = this.creditCardNumber.replace(/\s/g, '');
    // 4'ü 4'e bloklar halinde numarayı düzenler.
    this.creditCardNumber = this.creditCardNumber.match(/.{1,4}/g)?.join(' ') || '';
  }

  formatExpiryDate(event: Event) {
    const inputElement = event.target as HTMLInputElement;
    let inputValue = inputElement.value.replace(/\D/g, ''); // Remove non-numeric characters
  
    if (inputValue.length > 2) {
      inputValue = inputValue.slice(0, 2) + '/' + inputValue.slice(2);
    }
  
    inputElement.value = inputValue;
  }
  

  completePayment() {
    const message = " Ödeme işleminiz başarıyla alınmıştır. Şirket tarafında onay beklenmektedir ";
    alert(message);
  }
  


}