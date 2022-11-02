import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { APIS } from '../constants/APIS';

import { environment } from '../../../environments/environment';
import { IGrocery } from "../interfaces/grocery.interface";

@Injectable({
  providedIn: 'root',
})
export class GroceryService {
  private urls = APIS.grocery;

  public constructor(private http: HttpClient) { }

  public getGrocery(): Observable<IGrocery[]> {
    return this.http.get<IGrocery[]>(`${environment.apiUrl}${this.urls.export}`);
  }
}
