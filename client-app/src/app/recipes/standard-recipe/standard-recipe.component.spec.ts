import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StandardRecipeComponent } from './standard-recipe.component';

describe('StandardRecipeComponent', () => {
  let component: StandardRecipeComponent;
  let fixture: ComponentFixture<StandardRecipeComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [StandardRecipeComponent]
    });
    fixture = TestBed.createComponent(StandardRecipeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
