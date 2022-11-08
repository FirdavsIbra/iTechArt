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
    'Id',
    'First Name',
    'Last Name',
    'Date of Birth',
    'Gender',
    'Phone Number',
    'Address',
    'City',
    'School Name',
    'Grade',
    'Course Language',
    'Shift',
  ];
  public props = [
    'id',
    'firstName',
    'lastName',
    'dateOfBirth',
    'gender',
    'phoneNumber',
    'address',
    'city',
    'schoolName',
    'grade',
    'courseLanguage',
    'shift',
  ];

  public constructor(private statsService: StatsService) {}

  public ngOnInit(): void {
    this.statsService.getAllStatsByUnit(this.unit).subscribe({
      next: (data: UnitsTypes) => this.data = data,
      error: () => alert("Couldn't load data."),
    });
  }
}
