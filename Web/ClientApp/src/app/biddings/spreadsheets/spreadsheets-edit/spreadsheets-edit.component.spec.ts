import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SpreadsheetsEditComponent } from './spreadsheets-edit.component';

describe('SpreadsheetsEditComponent', () => {
  let component: SpreadsheetsEditComponent;
  let fixture: ComponentFixture<SpreadsheetsEditComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SpreadsheetsEditComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SpreadsheetsEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
