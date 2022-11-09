import { Component, OnInit } from '@angular/core';

import { UnitsEnum } from '../../../../../shared/enums/units.enum';
import { UnitsTypes } from '../../../../shared/types/units-types';
import { StatsService } from '../../../../stats.service';

@Component({
  selector: 'app-med-staff-page',
  templateUrl: './med-staff-page.component.html',
  styleUrls: ['./med-staff-page.component.scss'],
})
export class MedStaffPageComponent implements OnInit {
  public unit: UnitsEnum = UnitsEnum.medStaff;
  public data: UnitsTypes | undefined;

  public columns = [
    { field: 'id', header: 'Id', width: 57 },
    { field: 'firstName', header: 'First Name', width: 117 },
    { field: 'lastName', header: 'Last Name', width: 117 },
    { field: 'gender', header: 'Gender', width: 69 },
    { field: 'email', header: 'Email', width: 267 },
    { field: 'phoneNumber', header: 'Phone Number', width: 181 },
    { field: 'dateOfBirth', header: 'Date of Birth', width: 163 },
    { field: 'address', header: 'Address', width: 250 },
    { field: 'salary', header: 'Salary', width: 81 },
    { field: 'hospitalName', header: 'Hospital Name', width: 121 },
    { field: 'postalCode', header: 'Postal Code', width: 179 },
    { field: 'shift', header: 'Shift', width: 50 },
  ];

  public constructor(private statsService: StatsService) {}

  public ngOnInit(): void {
    this.statsService.getAllStatsByUnit(this.unit).subscribe({
      next: (data: UnitsTypes) => (this.data = data),
      error: () => alert("Couldn't load data."),
    });
  }
}
