import { Component, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-basket-card',
  templateUrl: './basket-card.component.html',
  styleUrls: ['./basket-card.component.css']
})
export class BasketCardComponent {
  @Input() productName: string = 'Ürün Adı';
  @Input() quantity: number = 0;
  @Input() totalPrice: number = 0;
  @Input() productId: number = 0;
  @Output() delete: EventEmitter<number> = new EventEmitter<number>();


  deleteItem() {
    this.delete.emit(this.productId); 
  }
  
}