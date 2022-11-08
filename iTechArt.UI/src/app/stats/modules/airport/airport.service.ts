import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { IAirport } from './interfaces/airport.interface';
import { environment } from '../../../../environments/environment';
import { ApiService } from '../../../shared/services/api.service';
import { UnitsEnum } from '../../../shared/enums/units.enum';

@Injectable({
  providedIn: 'root',
})
export class AirportService {
  public url = environment.apiUrl;
  private api: string | undefined;

  public constructor(
    private http: HttpClient,
    private apiService: ApiService
  ) {}

  public getAirports(unit: UnitsEnum): Observable<IAirport[]> {
    this.api = this.apiService.defineExportApiForCurrentUnit(unit);
    return this.http.get<IAirport[]>(`${this.api}`);
  }
}
