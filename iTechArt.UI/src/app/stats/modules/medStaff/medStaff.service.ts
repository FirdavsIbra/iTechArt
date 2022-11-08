import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { APIS } from '../../../shared/apis/constants/apis';

import { environment } from '../../../../environments/environment';
import { IMedStaff } from "./interfaces/medStaff.interface";

@Injectable({
  providedIn: 'root',
})
export class MedStaffService {
  private urls = APIS.medStaff;

  public constructor(private http: HttpClient) { }

  public getMedStaff(): Observable<IMedStaff[]> {
    return this.http.get<IMedStaff[]>(`${environment.apiUrl}${this.urls.export}`);
  }
}
