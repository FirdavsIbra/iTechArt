import { Component } from '@angular/core';

import { UnitsEnum } from "../../../../../shared/enums/units.enum";

@Component({
  selector: 'app-airport-page',
  templateUrl: './airport-page.component.html',
  styleUrls: ['./airport-page.component.scss'],
})
export class AirportPageComponent {
  public unit: UnitsEnum = UnitsEnum.airport
}
