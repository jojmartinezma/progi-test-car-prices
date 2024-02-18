import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, catchError, map, of } from 'rxjs';
import { VehicleResponse } from '../models/vehicleResponse';
import { VehicleRequest } from '../models/vehicleRequest';

@Injectable({
  providedIn: 'root'
})
export class VehicleServiceService {

  private _baseUrl: string = 'https://localhost:7065/api/RatesCalculation';
  private _apiOptions;

  constructor(
    private _http$: HttpClient
    ) {
      this._apiOptions = { headers: new HttpHeaders(), params: new HttpParams()};
      this._apiOptions.headers = new HttpHeaders(
          {
              'Content-Type': 'application/json',
          });
      this._apiOptions.params = new HttpParams();
    }

    // method to call api
    public calculatePrice(req: VehicleRequest): Observable<VehicleResponse | null> {
      // configure body
      const body = JSON.stringify(req);

      // call api
      return this._http$.post<VehicleResponse>(this._baseUrl, body, this._apiOptions).pipe(
        map((res: VehicleResponse) => {
          return res;
        }),
        catchError(_ => of(null))
      );

    }
}
