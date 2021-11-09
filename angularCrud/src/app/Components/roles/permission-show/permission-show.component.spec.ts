import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PermissionShowComponent } from './permission-show.component';

describe('PermissionShowComponent', () => {
  let component: PermissionShowComponent;
  let fixture: ComponentFixture<PermissionShowComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PermissionShowComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PermissionShowComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
