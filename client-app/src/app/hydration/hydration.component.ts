import { Component, OnInit } from '@angular/core';
import { Hydration } from './hydration';
import { HydrationMock } from './hydration.mock';

@Component({
  selector: 'app-hydration',
  templateUrl: './hydration.component.html',
  styleUrls: ['./hydration.component.css']
})

export class HydrationComponent implements OnInit {
  hydration: Hydration;

  constructor() {
    this.hydration = HydrationMock.MockObject;
  }

  ngOnInit(): void {

  }
}
