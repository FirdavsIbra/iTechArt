import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { UNITS } from '../../constants/units';
import { environment } from '../../../../environments/environment';
import { UnitCountDashboardInterface } from '../../interfaces/unit-count-dashboard.interface';
import { APIS } from '../../apis/constants/apis';

@Component({
  selector: 'app-dashboard-page',
  templateUrl: './dashboard-page.component.html',
  styleUrls: ['./dashboard-page.component.scss'],
})
export class DashboardPageComponent implements OnInit {
  public units: typeof UNITS = UNITS;
  public url = environment.apiUrl;
  public unitCountsInfo: UnitCountDashboardInterface | undefined;

  public constructor(private http: HttpClient) {}

  public ngOnInit(): void {
    this.getUnitCountsInfo();
  }

  public getUnitCountsInfo(): void {
    this.http
      .get<UnitCountDashboardInterface>(
        `${this.url}${APIS.dashboard.totalAmounts}`
      )
      .subscribe((data: UnitCountDashboardInterface) => {
        this.unitCountsInfo = data;
      });
  }
}
