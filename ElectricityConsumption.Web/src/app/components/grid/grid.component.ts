import { Component, Input, OnInit } from '@angular/core';
import { ConsumptionReadResponse } from "../../models/consumption-read-response";

@Component({
  selector: 'app-grid',
  templateUrl: './grid.component.html',
  styleUrls: ['./grid.component.css']
})
export class GridComponent implements OnInit {

  @Input()
  consumption: ConsumptionReadResponse = new ConsumptionReadResponse();

  constructor() { }

  ngOnInit(): void {
  }

}
