import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { APIS } from '../../../shared/constants/APIS';

import { environment } from '../../../../environments/environment';
import { IStudents } from "./interfaces/students.interface";

@Injectable({
  providedIn: 'root',
})
export class StudentsService {
  private urls = APIS.students;

  public constructor(private http: HttpClient) { }

  public getStudents(): Observable<IStudents[]> {
    return this.http.get<IStudents[]>(`${environment.apiUrl}${this.urls.export}`);
  }
}
