import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UnitHeaderComponent } from './unit-header.component';

describe('UnitHeaderComponent', () => {
  let component: UnitHeaderComponent;
  let fixture: ComponentFixture<UnitHeaderComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UnitHeaderComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(UnitHeaderComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
