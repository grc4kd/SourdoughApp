import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HydrationComponent } from './hydration/hydration.component';
import { StandardRecipeComponent } from './standard-recipe/standard-recipe.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

@NgModule({
  declarations: [AppComponent, HydrationComponent],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    StandardRecipeComponent,
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
