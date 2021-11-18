import { TestBed } from '@angular/core/testing';

import { SourceItemService } from './source-item.service';

describe('SourceItemService', () => {
  let service: SourceItemService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SourceItemService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
