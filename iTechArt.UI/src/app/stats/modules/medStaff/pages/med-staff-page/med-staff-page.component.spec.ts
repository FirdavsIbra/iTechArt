import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MedStaffPageComponent } from './med-staff-page.component';

describe('MedStaffPageComponent', () => {
  let component: MedStaffPageComponent;
  let fixture: ComponentFixture<MedStaffPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [MedStaffPageComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(MedStaffPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
