import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HydrationComponent } from './hydration/hydration.component';
import { StandardRecipeComponent } from './standard-recipe/standard-recipe.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { IngredientsTableComponent } from './ingredients-table/ingredients-table.component';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSortModule } from '@angular/material/sort';

@NgModule({
  declarations: [AppComponent, HydrationComponent, IngredientsTableComponent],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    StandardRecipeComponent,
    MatTableModule,
    MatPaginatorModule,
    MatSortModule,
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
