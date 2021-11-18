import { TestBed } from '@angular/core/testing';

import { BdiService } from './bdi.service';

describe('BdiService', () => {
  let service: BdiService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(BdiService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
