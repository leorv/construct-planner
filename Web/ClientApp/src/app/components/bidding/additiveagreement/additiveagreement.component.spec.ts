import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdditiveagreementComponent } from './additiveagreement.component';

describe('AdditiveagreementComponent', () => {
  let component: AdditiveagreementComponent;
  let fixture: ComponentFixture<AdditiveagreementComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AdditiveagreementComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AdditiveagreementComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
