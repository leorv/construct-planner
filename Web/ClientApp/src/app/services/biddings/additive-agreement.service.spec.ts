import { TestBed } from '@angular/core/testing';

import { AdditiveAgreementService } from './additive-agreement.service';

describe('AdditiveAgreementService', () => {
  let service: AdditiveAgreementService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AdditiveAgreementService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
