import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GroceryPageComponent } from './grocery-page.component';

describe('GroceryPageComponent', () => {
  let component: GroceryPageComponent;
  let fixture: ComponentFixture<GroceryPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [GroceryPageComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(GroceryPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
