import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ClausesCreateComponent } from './clauses-create.component';

describe('ClausesCreateComponent', () => {
  let component: ClausesCreateComponent;
  let fixture: ComponentFixture<ClausesCreateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ClausesCreateComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ClausesCreateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
