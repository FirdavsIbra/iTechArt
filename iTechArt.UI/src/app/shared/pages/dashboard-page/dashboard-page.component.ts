import { Component, OnInit } from '@angular/core';

import { UNITS } from '../../constants/units';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../../environments/environment';
import { UnitCountDashboardInterface } from "../../interfaces/unit-count-dashboard.interface";

@Component({
  selector: 'app-dashboard-page',
  templateUrl: './dashboard-page.component.html',
  styleUrls: ['./dashboard-page.component.scss'],
})
export class DashboardPageComponent implements OnInit {
  public units: typeof UNITS = UNITS;
  public url = environment.apiUrl;
  public unitCountsInfo : UnitCountDashboardInterface | undefined;

  public constructor(private http: HttpClient) {}

  public ngOnInit(): void {
    this.getUnitCountsInfo();
  }

  public getUnitCountsInfo(): void {
    this.http
      .get<any>( 'https://itechart-app.herokuapp.com/api/dashboard/total-amounts')
      .subscribe((data) => {
        this.unitCountsInfo = data;
        console.log('TOTALS-AMOUNTS received: ', data);
      });
  }
  // public getAirport(): void {
  //   this.http
  //     .get<any>(`${this.url}${this.apis.airport.export}`)
  //     .subscribe((data) => {
  //       this.unitCountsInfo.airportCount = data;
  //     });
  //
  //   console.log(this.unitCountsInfo.airportCount);
  // }
  //
  // public getPolice(): void {
  //   this.http
  //     .get<any>(`${this.url}${this.apis.police.export}`)
  //     .subscribe((data) => {
  //       this.unitCountsInfo.policeCount = data;
  //     });
  //
  //   console.log(this.unitCountsInfo.policeCount);
  // }
  //
  // public getMedStaff(): void {
  //   this.http
  //     .get<any>(`${this.url}${this.apis.medStaff.export}`)
  //     .subscribe((data) => {
  //       this.unitCountsInfo.medStaffCount = data;
  //     });
  //
  //   console.log(this.unitCountsInfo.medStaffCount);
  // }
  //
  // public getGrocery(): void {
  //   this.http
  //     .get<any>(`${this.url}${this.apis.grocery.export}`)
  //     .subscribe((data) => {
  //       this.unitCountsInfo.groceryCount = data;
  //     });
  //
  //   console.log(this.unitCountsInfo.groceryCount);
  // }
  //
  // public getStudents(): void {
  //   this.http
  //     .get<any>(`${this.url}${this.apis.students.export}`)
  //     .subscribe((data) => {
  //       this.unitCountsInfo.studentsCount = data;
  //     });
  //
  //   console.log(this.unitCountsInfo.studentsCount);
  // }
  //
  // public getPupils(): void {
  //   this.http
  //     .get<any>(`${this.url}${this.apis.pupils.export}`)
  //     .subscribe((data) => {
  //       this.unitCountsInfo.pupilsCount = data;
  //     });
  //
  //   console.log(this.unitCountsInfo.pupilsCount);
  // }
}
