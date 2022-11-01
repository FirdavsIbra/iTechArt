import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { APIS } from '../../../shared/constants/APIS';

import { environment } from '../../../../environments/environment';
import { IPupil } from "./interfaces/pupil.interface";

@Injectable({
  providedIn: 'root',
})
export class PupilsService {
  private urls = APIS.pupils;

  public constructor(private http: HttpClient) { }

  public getPupils(): Observable<IPupil[]> {
    return this.http.get<IPupil[]>(`${environment.apiUrl}${this.urls.export}`);
  }
}
