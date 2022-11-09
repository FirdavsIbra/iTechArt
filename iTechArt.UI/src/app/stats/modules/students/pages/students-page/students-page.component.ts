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
    { field: 'id', header: 'Id', width: 57 },
    { field: 'firstName', header: 'First Name', width: 217 },
    { field: 'lastName', header: 'Last Name', width: 124 },
    { field: 'gender', header: 'Gender', width: 117 },
    { field: 'email', header: 'Email', width: 267 },
    { field: 'dateOfBirth', header: 'Date of Birth', width: 107 },
    { field: 'university', header: 'University', width: 615 },
  ];

  public constructor(private statsService: StatsService) {}

  public ngOnInit(): void {
    this.statsService.getAllStatsByUnit(this.unit).subscribe({
      next: (data: UnitsTypes) => (this.data = data),
      error: () => alert("Couldn't load data."),
    });
  }
}
