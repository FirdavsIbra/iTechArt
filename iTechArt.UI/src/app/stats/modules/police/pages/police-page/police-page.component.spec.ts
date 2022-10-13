import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PolicePageComponent } from './police-page.component';

describe('PolicePageComponent', () => {
  let component: PolicePageComponent;
  let fixture: ComponentFixture<PolicePageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [PolicePageComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(PolicePageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
