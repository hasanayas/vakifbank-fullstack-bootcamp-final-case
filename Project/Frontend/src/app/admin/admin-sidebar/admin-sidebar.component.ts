import { Component, OnInit, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-admin-sidebar',
  templateUrl: './admin-sidebar.component.html',
  styleUrls: ['./admin-sidebar.component.css']
})
export class AdminSidebarComponent implements OnInit {
  selectedItem: string = 'Orders';


  @Output() pageChanged = new EventEmitter<string>();

  constructor() { }

  ngOnInit(): void {
  }

  changePage(page: string) {
    this.pageChanged.emit(page);
    this.selectedItem = page;
  }

}
