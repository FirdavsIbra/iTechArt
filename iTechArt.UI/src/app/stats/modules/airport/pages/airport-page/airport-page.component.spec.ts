import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AirportPageComponent } from './airport-page.component';

describe('AirportPageComponent', () => {
  let component: AirportPageComponent;
  let fixture: ComponentFixture<AirportPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [AirportPageComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(AirportPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
