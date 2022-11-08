import { Component, OnInit } from '@angular/core';

import { UnitsEnum } from '../../../../../shared/enums/units.enum';
import { UnitsTypes } from '../../../../shared/types/units-types';
import { StatsService } from '../../../../stats.service';

@Component({
  selector: 'app-police-page',
  templateUrl: './police-page.component.html',
  styleUrls: ['./police-page.component.scss'],
})
export class PolicePageComponent implements OnInit {
  public unit: UnitsEnum = UnitsEnum.police;
  public data: UnitsTypes | undefined;
  public columns = [
    'Id',
    'First Name',
    'Last Name',
    'Gender',
    'Email',
    'Address',
    'Job Title',
    'Weight In Kg',
    'Height In Cm',
  ];
  public props = [
    'id',
    'firstName',
    'lastName',
    'gender',
    'email',
    'address',
    'weightInKg',
    'heightInCM',
  ];

  public constructor(private statsService: StatsService) {}

  public ngOnInit(): void {
    this.statsService.getAllStatsByUnit(this.unit).subscribe({
      next: (data: UnitsTypes) => this.data = data,
      error: () => alert("Couldn't load data."),
    });
  }
}
