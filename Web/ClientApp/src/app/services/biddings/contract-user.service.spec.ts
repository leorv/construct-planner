import { TestBed } from '@angular/core/testing';

import { ContractUserService } from './contract-user.service';

describe('ContractUserService', () => {
  let service: ContractUserService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ContractUserService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
