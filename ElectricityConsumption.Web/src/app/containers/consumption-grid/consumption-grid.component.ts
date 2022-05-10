import { Component, OnInit } from '@angular/core';
import { DataService } from "../../services/data.service";
import { ConsumptionReadRequest } from "../../models/consumption-read-request";
import { ConsumptionReadResponse } from "../../models/consumption-read-response";

@Component({
  selector: 'app-consumption-grid',
  templateUrl: './consumption-grid.component.html',
  styleUrls: ['./consumption-grid.component.css']
})
export class ConsumptionGridComponent implements OnInit {
  public consumption: ConsumptionReadResponse = new ConsumptionReadResponse();

  constructor(public readonly dataService: DataService) { }

  ngOnInit(): void {
    this.getConsumptionData({pageSize:20, pageIndex:1});
  }

  public getConsumptionData(request: ConsumptionReadRequest){
    this.dataService
      .getConsumptionData(request)
      .subscribe({
        error: (error) => {
          console.log(error);
        },
        next: (response) => {
          this.consumption = response;
        }
      });
  }
}
