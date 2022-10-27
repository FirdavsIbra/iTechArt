import { Component } from '@angular/core';

import { UnitsEnum } from '../../../../../shared/enums/units.enum';

@Component({
  selector: 'app-police-page',
  templateUrl: './police-page.component.html',
  styleUrls: ['./police-page.component.scss'],
})
export class PolicePageComponent {
  public unit: UnitsEnum = UnitsEnum.police;
}
