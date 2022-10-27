import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PupilsPageComponent } from './pupils-page.component';

describe('PupilsPageComponent', () => {
  let component: PupilsPageComponent;
  let fixture: ComponentFixture<PupilsPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [PupilsPageComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(PupilsPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
