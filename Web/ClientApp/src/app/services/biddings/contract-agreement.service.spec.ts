import { TestBed } from '@angular/core/testing';

import { ContractAgreementService } from './contract-agreement.service';

describe('ContractAgreementService', () => {
  let service: ContractAgreementService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ContractAgreementService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
