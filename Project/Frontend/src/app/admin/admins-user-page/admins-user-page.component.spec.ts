import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminsUserPageComponent } from './admins-user-page.component';

describe('AdminsUserPageComponent', () => {
  let component: AdminsUserPageComponent;
  let fixture: ComponentFixture<AdminsUserPageComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AdminsUserPageComponent]
    });
    fixture = TestBed.createComponent(AdminsUserPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
