import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RecipesRoutingModule } from './recipes-routing.module';
import { StandardRecipeComponent } from './standard-recipe/standard-recipe.component';
import { MatListModule } from '@angular/material/list';

@NgModule({
  imports: [CommonModule, MatListModule, RecipesRoutingModule],
  declarations: [StandardRecipeComponent]
})
export class RecipesModule { }
