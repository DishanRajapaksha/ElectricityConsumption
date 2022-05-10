import { Injectable } from '@angular/core';
import { environment } from "../../environments/environment";
import { HttpClient } from "@angular/common/http";
import { ConsumptionReadResponse } from "../models/consumption-read-response";
import { ConsumptionReadRequest } from "../models/consumption-read-request";

@Injectable({
  providedIn: 'root'
})
export class DataService {

  url: string = environment.apiUrl;

  constructor(private readonly http: HttpClient) { }

  public getConsumptionData(request: ConsumptionReadRequest){
    return this.http.get<ConsumptionReadResponse>(`${this.url}/ElectricityConsumption?pageIndex=${request.pageIndex}&pageSize=${request.pageSize}`);
  }

}
