import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminUpdateStockComponent } from './admin-update-stock.component';

describe('AdminUpdateStockComponent', () => {
  let component: AdminUpdateStockComponent;
  let fixture: ComponentFixture<AdminUpdateStockComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AdminUpdateStockComponent]
    });
    fixture = TestBed.createComponent(AdminUpdateStockComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
