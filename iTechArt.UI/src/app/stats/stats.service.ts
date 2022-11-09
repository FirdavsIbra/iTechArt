import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { ApiService } from '../shared/services/api.service';
import { UnitsEnum } from '../shared/enums/units.enum';
import { UnitsTypes } from "./shared/types/units-types";

@Injectable({
  providedIn: 'root',
})
export class StatsService {
  private api: string | undefined;

  public constructor(
    private http: HttpClient,
    private apiService: ApiService
  ) {}

  public getAllStatsByUnit(unit: UnitsEnum): Observable<UnitsTypes> {
    this.api = this.apiService.defineExportApiForCurrentUnit(unit);

    console.log(this.api)

    return this.http.get<UnitsTypes>(`${this.api}`);
  }
}
