import { Component, OnInit } from '@angular/core';

import { UNITS } from '../../constants/units';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../../environments/environment';

@Component({
  selector: 'app-dashboard-page',
  templateUrl: './dashboard-page.component.html',
  styleUrls: ['./dashboard-page.component.scss'],
})
export class DashboardPageComponent implements OnInit {
  public units: typeof UNITS = UNITS;
  public url = environment.apiUrl;

  public count = {
    policeCount: '',
    medStaffCount: '',
    groceryCount: '',
    pupilsCount: '',
    studentsCount: '',
    airportCount: '',
  }; //delete

  public apis = { //to consts
    police: {
      import: 'api/police/import',
      export: 'api/police/export',
    },
    medStaff: {
      import: 'api/medStaff/import',
      export: 'api/medStaff/export',
    },
    grocery: {
      import: 'api/grocery/import',
      export: 'api/grocery/export',
    },
    pupils: {
      import: 'api/pupils/import',
      export: 'api/pupils/export',
    },
    students: {
      import: 'api/student/import',
      export: 'api/student/export',
    },
    airport: {
      import: 'api/airport/import',
      export: 'api/airport/export',
    }, //add dashboard
  };

  public constructor(private http: HttpClient) {}

  public ngOnInit(): void {
    this.getAirport();
    this.getPolice();
    this.getPupils();
    this.getGrocery();
    this.getMedStaff();
    this.getStudents();//delete all, add 1 get yours
  }

  public getAirport(): void {
    this.http
      .get<any>(`${this.url}${this.apis.airport.export}`)
      .subscribe((data) => {
        this.count.airportCount = data;
      });

    console.log(this.count.airportCount);
  }

  public getPolice(): void {
    this.http
      .get<any>(`${this.url}${this.apis.police.export}`)
      .subscribe((data) => {
        this.count.policeCount = data;
      });

    console.log(this.count.policeCount);
  }

  public getMedStaff(): void {
    this.http
      .get<any>(`${this.url}${this.apis.medStaff.export}`)
      .subscribe((data) => {
        this.count.medStaffCount = data;
      });

    console.log(this.count.medStaffCount);
  }

  public getGrocery(): void {
    this.http
      .get<any>(`${this.url}${this.apis.grocery.export}`)
      .subscribe((data) => {
        this.count.groceryCount = data;
      });

    console.log(this.count.groceryCount);
  }

  public getStudents(): void {
    this.http
      .get<any>(`${this.url}${this.apis.students.export}`)
      .subscribe((data) => {
        this.count.studentsCount = data;
      });

    console.log(this.count.studentsCount);
  }

  public getPupils(): void {
    this.http
      .get<any>(`${this.url}${this.apis.pupils.export}`)
      .subscribe((data) => {
        this.count.pupilsCount = data;
      });

    console.log(this.count.pupilsCount);
  }
}
