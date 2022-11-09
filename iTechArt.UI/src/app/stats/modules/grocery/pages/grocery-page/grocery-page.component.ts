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
    { field: 'id', header: 'Id', width: 58 },
    { field: 'firstName', header: 'First Name', width: 217 },
    { field: 'lastName', header: 'Last Name', width: 117 },
    { field: 'gender', header: 'Gender', width: 117 },
    { field: 'email', header: 'Email', width: 229 },
    { field: 'birthday', header: 'Date of Birth', width: 117 },
    { field: 'salary', header: 'Salary', width: 117 },
    { field: 'departmentRetail', header: 'Department Retail', width: 117 },
    { field: 'jobTitle', header: 'Job Title', width: 121 },
  ];

  public constructor(private statsService: StatsService) {}

  public ngOnInit(): void {
    this.statsService.getAllStatsByUnit(this.unit).subscribe({
      next: (data: UnitsTypes) => (this.data = data),
      error: () => alert("Couldn't load data."),
    });
  }
}
