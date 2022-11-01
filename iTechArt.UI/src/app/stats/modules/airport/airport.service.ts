import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IAirport } from './interfaces/airport.interface';
import { APIS } from '../../../shared/constants/APIS';

import { environment } from '../../../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class AirportService {
  private urls = APIS.airport;

  public constructor(private http: HttpClient) { }

  public getAirports(): Observable<IAirport[]> {
    return this.http.get<IAirport[]>(`${environment.apiUrl}${this.urls.export}`);
  }
}
