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
    'Id',
    'First Name',
    'Last Name',
    'Gender',
    'Email',
    'Phone Number',
    'Date of Birth',
    'Address',
    'Salary',
    'Hospital Name',
    'Postal Code',
    'Shift',
  ];
  public props = [
    'id',
    'firstName',
    'lastName',
    'gender',
    'email',
    'phoneNumber',
    'dateOfBirth',
    'address',
    'salary',
    'hospitalName',
    'postalCode',
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
