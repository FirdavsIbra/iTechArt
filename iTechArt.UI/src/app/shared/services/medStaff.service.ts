import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { APIS } from '../constants/APIS';

import { environment } from '../../../environments/environment';
import { ImedStaff } from "../interfaces/medStaff.interface";

@Injectable({
  providedIn: 'root',
})
export class MedStaffService {
  private urls = APIS.medStaff;

  public constructor(private http: HttpClient) { }

  public getMedStaff(): Observable<ImedStaff[]> {
    return this.http.get<ImedStaff[]>(`${environment.apiUrl}${this.urls.export}`);
  }
}
