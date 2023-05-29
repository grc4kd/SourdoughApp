import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StandardRecipeComponent } from './standard-recipe.component';

describe('StandardRecipeComponent', () => {
  let component: StandardRecipeComponent;
  let fixture: ComponentFixture<StandardRecipeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [StandardRecipeComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(StandardRecipeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
