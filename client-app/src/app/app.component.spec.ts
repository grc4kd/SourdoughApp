import { ComponentFixture, TestBed } from '@angular/core/testing';
import { AppComponent } from './app.component';
import { HarnessLoader } from '@angular/cdk/testing';
import { TestbedHarnessEnvironment } from '@angular/cdk/testing/testbed';
import { MatButtonToggleHarness } from '@angular/material/button-toggle/testing';
import { AppModule } from './app.module';
import { Router } from '@angular/router';

let fixture: ComponentFixture<AppComponent>;
let loader: HarnessLoader;

describe('AppComponent', () => {
  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AppModule],
      declarations: [
        AppComponent
      ],
    }).compileComponents();
    fixture = TestBed.createComponent(AppComponent);
    loader = TestbedHarnessEnvironment.loader(fixture);
  });

  it('should create the app', () => {
    const fixture = TestBed.createComponent(AppComponent);
    const app = fixture.componentInstance;
    expect(app).toBeTruthy();
  });

  it(`should have as title 'client-app'`, () => {
    const fixture = TestBed.createComponent(AppComponent);
    const app = fixture.componentInstance;
    expect(app.title).toEqual('BREADCO');
  });

  it('should render title', async () => {
    const fixture = TestBed.createComponent(AppComponent);
    fixture.detectChanges();
    const compiled = fixture.nativeElement as HTMLElement;
    const appTitleText = compiled.querySelector('.app-header')?.textContent;
    expect(appTitleText).toContain('BREADCO');
  });

  it('should route to RecipesModule when clicking on the recipes button', async () => {
    const recipeButton = await loader.getHarness(
      MatButtonToggleHarness.with({text: 'Recipes'}));
    
    await recipeButton.toggle();

    expect(TestBed.inject(Router).url)
      .withContext('should nav to RecipesModule')
      .toEqual('/recipes');
  });
});
