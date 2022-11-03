import { Component, OnInit } from "@angular/core";

import { UnitsEnum } from "../../../../../shared/enums/units.enum";
import { IGrocery } from "../../interfaces/grocery.interface";
import { GroceryService } from "../../grocery.service";

@Component({
  selector: 'app-grocery-page',
  templateUrl: './grocery-page.component.html',
  styleUrls: ['./grocery-page.component.scss'],
})
export class GroceryPageComponent implements OnInit{
  public unit: UnitsEnum = UnitsEnum.grocery
  public data: IGrocery[] | undefined;

  public columns = [
    'Id',
    'First Name',
    'Last Name',
    'Gender',
    'Email',
    'Date of Birth',
    'Salary',
    'Department Retail',
    'Job Title'
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
    'jobTitle'
  ];

  public constructor(private _GroceryService: GroceryService) {}

  public ngOnInit(): void {
    this._GroceryService.getGrocery().subscribe((data: IGrocery[]) => {
      this.data = data;
    });
  }
}



