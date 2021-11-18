import { TestBed } from '@angular/core/testing';

import { SpreadsheetItemService } from './spreadsheet-item.service';

describe('SpreadsheetItemService', () => {
  let service: SpreadsheetItemService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SpreadsheetItemService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
