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
    { field: 'id', header: 'Company', width: 450 },
    { field: 'firstName', header: 'First Name', width: 200 },
    { field: 'lastName', header: 'Last Name', width: 100 },
    { field: 'gender', header: 'Gender', width: 100 },
    { field: 'email', header: 'Email' },
    { field: 'dateOfBirth', header: 'Date of Birth' },
    { field: 'university', header: 'University' },
  ];

  public constructor(private statsService: StatsService) {}

  public ngOnInit(): void {
    this.statsService.getAllStatsByUnit(this.unit).subscribe({
      next: (data: UnitsTypes) => this.data = data,
      error: () => alert("Couldn't load data."),
    });
  }
}
