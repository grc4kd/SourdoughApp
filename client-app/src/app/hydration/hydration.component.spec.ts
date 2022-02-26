import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HydrationComponent } from './hydration.component';

describe('HydrationComponent', () => {
  let component: HydrationComponent;
  let fixture: ComponentFixture<HydrationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HydrationComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(HydrationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
