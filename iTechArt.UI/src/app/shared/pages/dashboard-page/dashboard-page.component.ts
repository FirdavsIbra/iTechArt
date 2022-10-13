import { Component } from '@angular/core';

import { UNITS } from "../../constants/units";

@Component({
  selector: 'app-dashboard-page',
  templateUrl: './dashboard-page.component.html',
  styleUrls: ['./dashboard-page.component.scss'],
})
export class DashboardPageComponent {
  public units: typeof UNITS = UNITS //refactor
}
