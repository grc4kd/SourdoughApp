import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HydrationComponent } from './hydration/hydration.component';
import { StandardRecipeComponentComponent } from './standard-recipe/standard-recipe.component';

@NgModule({
  declarations: [
    AppComponent,
    HydrationComponent,
    StandardRecipeComponentComponent,
  ],
  imports: [BrowserModule, AppRoutingModule],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
