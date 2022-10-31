import { TestBed } from '@angular/core/testing';

import { PupilsService } from './pupils.service';

describe('PupilsService', () => {
  let service: PupilsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PupilsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
