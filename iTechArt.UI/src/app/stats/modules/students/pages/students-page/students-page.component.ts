import { Component } from '@angular/core';

import { UnitsEnum } from '../../../../../shared/enums/units.enum';

@Component({
  selector: 'app-students-page',
  templateUrl: './students-page.component.html',
  styleUrls: ['./students-page.component.scss'],
})
export class StudentsPageComponent {
  public unit: UnitsEnum = UnitsEnum.students;
}
