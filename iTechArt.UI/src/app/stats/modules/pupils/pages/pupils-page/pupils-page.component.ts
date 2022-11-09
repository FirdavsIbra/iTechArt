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
    { field: 'id', header: 'Id', width: 41 },
    { field: 'firstName', header: 'First Name', width: 101 },
    { field: 'lastName', header: 'Last Name', width: 125 },
    { field: 'dateOfBirth', header: 'Date of Birth', width: 78 },
    { field: 'phoneNumber', header: 'Phone Number', width: 95 },
    { field: 'address', header: 'Address', width: 164  },
    { field: 'city', header: 'City', width: 169 },
    { field: 'schoolName', header: 'School Name', width: 402  },
    { field: 'grade', header: 'Grade', width: 61 },
    { field: 'courseLanguage', header: 'Course', width:108 },
    { field: 'shift', header: 'Shift', width: 50 },
  ];


  public constructor(private statsService: StatsService) {}

  public ngOnInit(): void {
    this.statsService.getAllStatsByUnit(this.unit).subscribe({
      next: (data: UnitsTypes) => this.data = data,
      error: () => alert("Couldn't load data."),
    });
  }
}
