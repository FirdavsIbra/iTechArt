import { Component, Input } from '@angular/core';

import { UnitsEnum } from '../../../../shared/enums/units.enum';

@Component({
  selector: 'app-unit-header',
  templateUrl: './unit-header.component.html',
  styleUrls: ['./unit-header.component.scss'],
})
export class UnitHeaderComponent {
  @Input() public unit: UnitsEnum | undefined;
}
