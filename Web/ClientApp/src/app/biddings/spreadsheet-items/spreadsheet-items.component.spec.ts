import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SpreadsheetItemsComponent } from './spreadsheet-items.component';

describe('SpreadsheetItemsComponent', () => {
  let component: SpreadsheetItemsComponent;
  let fixture: ComponentFixture<SpreadsheetItemsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SpreadsheetItemsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SpreadsheetItemsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
