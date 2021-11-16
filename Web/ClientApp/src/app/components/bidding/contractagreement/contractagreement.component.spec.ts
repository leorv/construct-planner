import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ContractagreementComponent } from './contractagreement.component';

describe('ContractagreementComponent', () => {
  let component: ContractagreementComponent;
  let fixture: ComponentFixture<ContractagreementComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ContractagreementComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ContractagreementComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
