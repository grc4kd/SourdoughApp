import { Component } from '@angular/core';
import { environment } from './../environments/environment';
import { _isTestEnvironment } from '@angular/cdk/platform';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'BREADCO';

  constructor() {
    if (!environment.production && !_isTestEnvironment()) {
      console.warn("Current environment is not production.");
    }
  }
}
