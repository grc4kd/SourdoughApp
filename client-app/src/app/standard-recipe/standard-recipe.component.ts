import { Component } from '@angular/core';
import { ThemePalette } from '@angular/material/core';
import { MatButtonModule } from '@angular/material/button';
import { NgFor } from '@angular/common';
import { MatTabsModule } from '@angular/material/tabs';

/**
 * @title Basic use of the tab nav bar
 */
@Component({
  selector: 'app-standard-recipe-component',
  templateUrl: 'standard-recipe.component.html',
  styleUrls: ['standard-recipe.component.css'],
  standalone: true,
  imports: [MatTabsModule, NgFor, MatButtonModule],
})
export class StandardRecipeComponent {
  links = ['First', 'Second', 'Third'];
  activeLink = this.links[0];
  background: ThemePalette = undefined;

  toggleBackground() {
    this.background = this.background ? undefined : 'primary';
  }

  addLink() {
    this.links.push(`Link ${this.links.length + 1}`);
  }
}
