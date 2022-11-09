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
    { field: 'id', header: 'Id', width: 450 },
    { field: 'firstName', header: 'First Name', width: 200 },
    { field: 'lastName', header: 'Last Name', width: 100 },
    { field: 'gender', header: 'Gender', width: 100 },
    { field: 'email', header: 'Email', width:100 },
    { field: 'dateOfBirth', header: 'Date of Birth', width:100 },
    { field: 'salary', header: 'Salary', width: 100 },
    { field: 'departmentRetail', header: 'Department Retail', width:100 },
    { field: 'jobTitle', header: 'Job Title', width:100 }
  ];

  public constructor(private statsService: StatsService) {}

  public ngOnInit(): void {
    this.statsService.getAllStatsByUnit(this.unit).subscribe({
      next: (data: UnitsTypes) => this.data = data,
      error: () => alert("Couldn't load data."),
    });
  }
}
