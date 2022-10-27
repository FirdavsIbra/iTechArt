import { Component } from '@angular/core';

import { UNITS } from '../../constants/units';
import { UnitsEnum } from '../../enums/units.enum';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss'],
})
export class HeaderComponent {
  public units: typeof UNITS = UNITS;
  public unitsTitles: typeof UnitsEnum = UnitsEnum;
}
