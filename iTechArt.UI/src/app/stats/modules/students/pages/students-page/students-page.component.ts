import { Component, OnInit } from '@angular/core';

import { UnitsEnum } from '../../../../../shared/enums/units.enum';
import { UnitsTypes } from '../../../../shared/types/units-types';
import { StatsService } from '../../../../stats.service';

@Component({
  selector: 'app-students-page',
  templateUrl: './students-page.component.html',
  styleUrls: ['./students-page.component.scss'],
})
export class StudentsPageComponent implements OnInit {
  public unit: UnitsEnum = UnitsEnum.students;
  public data: UnitsTypes | undefined;
  public columns = [
    'Id',
    'First Name',
    'Last Name',
    'Gender',
    'Email',
    'Date of Birth',
    'University',
  ];
  public props = [
    'id',
    'firstName',
    'lastName',
    'gender',
    'email',
    'dateOfBirth',
    'university',
  ];

  public constructor(private statsService: StatsService) {}

  public ngOnInit(): void {
    this.statsService.getAllStatsByUnit(this.unit).subscribe({
      next: (data: UnitsTypes) => this.data = data,
      error: () => alert("Couldn't load data."),
    });
  }
}
