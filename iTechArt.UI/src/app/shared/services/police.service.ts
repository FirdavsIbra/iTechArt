import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { APIS } from '../constants/APIS';

import { environment } from '../../../environments/environment';
import { IPolice } from "../interfaces/police.interface";

@Injectable({
  providedIn: 'root',
})
export class PoliceService {
  private urls = APIS.police;

  public constructor(private http: HttpClient) { }

  public getPolice(): Observable<IPolice[]> {
    return this.http.get<IPolice[]>(`${environment.apiUrl}${this.urls.export}`);
  }
}
