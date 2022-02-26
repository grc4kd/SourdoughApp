import { Component, OnInit } from '@angular/core';
import { Hydration } from '../hydration';

@Component({
  selector: 'app-hydration',
  templateUrl: './hydration.component.html',
  styleUrls: ['./hydration.component.css']
})
export class HydrationComponent implements OnInit {
  hydration: Hydration = {
    starter: 289.0,
    starterHydration: 1.0,
    water: 260.261905,
    flour: 450.738095
  }  

  constructor() { }

  ngOnInit(): void {
  }

}
