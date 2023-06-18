import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { StandardRecipeComponent } from './standard-recipe/standard-recipe.component';

const routes: Routes = [
  {
    path: '',
    component: StandardRecipeComponent,
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class RecipesRoutingModule {}
