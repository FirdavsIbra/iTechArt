import { Component, OnInit } from '@angular/core';

import { UnitsEnum } from '../../../../../shared/enums/units.enum';
import { UnitsTypes } from '../../../../shared/types/units-types';
import { StatsService } from '../../../../stats.service';

@Component({
  selector: 'app-pupils-page',
  templateUrl: './pupils-page.component.html',
  styleUrls: ['./pupils-page.component.scss'],
})
export class PupilsPageComponent implements OnInit {
  public unit: UnitsEnum = UnitsEnum.pupils;
  public data: UnitsTypes | undefined;

  public columns = [
    { field: 'id', header: 'Id', width: 450 },
    { field: 'firstName', header: 'First Name', width: 200 },
    { field: 'lastName', header: 'Last Name', width: 100 },
    { field: 'dateOfBirth', header: 'Date of Birth', width: 100 },
    { field: 'phoneNumber', header: 'Phone Number' },
    { field: 'address', header: 'Address' },
    { field: 'city', header: 'City' },
    { field: 'schoolName', header: 'School Name' },
    { field: 'grade', header: 'Grade' },
    { field: 'course', header: 'Course' },
    { field: 'shift', header: 'Shift' },
  ];


  public constructor(private statsService: StatsService) {}

  public ngOnInit(): void {
    this.statsService.getAllStatsByUnit(this.unit).subscribe({
      next: (data: UnitsTypes) => this.data = data,
      error: () => alert("Couldn't load data."),
    });
  }
}
