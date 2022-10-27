import { Component } from '@angular/core';

import { UnitsEnum } from '../../../../../shared/enums/units.enum';

@Component({
  selector: 'app-med-staff-page',
  templateUrl: './med-staff-page.component.html',
  styleUrls: ['./med-staff-page.component.scss'],
})
export class MedStaffPageComponent {
  public unit: UnitsEnum = UnitsEnum.medStaff;
}
