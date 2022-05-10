import { MeterReading } from "./meter-reading";

export class ConsumptionReadResponse {
  usage: MeterReading[] = [];
  pageIndex: number = 0;
  pageSize: number= 0;
  pageTotal: number= 0;
  total: number= 0;
}
