import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-admin-page',
  templateUrl: './admin-page.component.html',
  styleUrls: ['./admin-page.component.css']
})
export class AdminPageComponent implements OnInit {

  @Input() selectedPage: string = '';


  constructor() { }

  ngOnInit(): void {
  }

}
