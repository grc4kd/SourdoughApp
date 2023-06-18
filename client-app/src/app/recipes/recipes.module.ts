import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RecipesRoutingModule } from './recipes-routing.module';
import { StandardRecipeComponent } from './standard-recipe/standard-recipe.component';

@NgModule({
  declarations: [StandardRecipeComponent],
  imports: [CommonModule, RecipesRoutingModule],
  exports: [],
})
export class RecipesModule {}
