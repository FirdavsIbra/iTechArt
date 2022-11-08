import { Component, OnInit } from '@angular/core';

import { UnitsEnum } from '../../../../../shared/enums/units.enum';
import { UnitsTypes } from '../../../../shared/types/units-types';
import { StatsService } from '../../../../stats.service';

@Component({
  selector: 'app-grocery-page',
  templateUrl: './grocery-page.component.html',
  styleUrls: ['./grocery-page.component.scss'],
})
export class GroceryPageComponent implements OnInit {
  public unit: UnitsEnum = UnitsEnum.grocery;
  public data: UnitsTypes | undefined;
  public columns = [
    'Id',
    'First Name',
    'Last Name',
    'Gender',
    'Email',
    'Date of Birth',
    'Salary',
    'Department Retail',
    'Job Title',
  ];
  public props = [
    'id',
    'firstName',
    'lastName',
    'gender',
    'email',
    'dateOfBirth',
    'salary',
    'departmentRetail',
    'jobTitle',
  ];

  public constructor(private statsService: StatsService) {}

  public ngOnInit(): void {
    this.statsService.getAllStatsByUnit(this.unit).subscribe({
      next: (data: UnitsTypes) => this.data = data,
      error: () => alert("Couldn't load data."),
    });
  }
}
