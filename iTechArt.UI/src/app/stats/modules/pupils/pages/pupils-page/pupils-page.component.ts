import { Component } from '@angular/core';

import { UnitsEnum } from '../../../../../shared/enums/units.enum';

@Component({
  selector: 'app-pupils-page',
  templateUrl: './pupils-page.component.html',
  styleUrls: ['./pupils-page.component.scss'],
})
export class PupilsPageComponent {
  public unit: UnitsEnum = UnitsEnum.pupils;
}
