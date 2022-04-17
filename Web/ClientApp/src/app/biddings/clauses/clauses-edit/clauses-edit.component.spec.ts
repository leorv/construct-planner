import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ClausesEditComponent } from './clauses-edit.component';

describe('ClausesEditComponent', () => {
  let component: ClausesEditComponent;
  let fixture: ComponentFixture<ClausesEditComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ClausesEditComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ClausesEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
