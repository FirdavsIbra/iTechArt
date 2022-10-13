import { Component } from '@angular/core';

import { UNITS } from '../../constants/units';
import { UnitEnum } from '../../enums/unit.enum';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss'],
})
export class HeaderComponent {
  public units = UNITS;
  public unitsTitles = UnitEnum;
}
