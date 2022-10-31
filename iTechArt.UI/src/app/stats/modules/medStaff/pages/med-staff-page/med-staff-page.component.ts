import { Component, OnInit } from "@angular/core";

import { UnitsEnum } from '../../../../../shared/enums/units.enum';
import { ImedStaff } from "../../../../../shared/interfaces/medStaff.interface";
import { MedStaffService } from "../../../../../shared/services/medStaff.service";

@Component({
  selector: 'app-med-staff-page',
  templateUrl: './med-staff-page.component.html',
  styleUrls: ['./med-staff-page.component.scss'],
})
export class MedStaffPageComponent implements OnInit{
  public unit: UnitsEnum = UnitsEnum.medStaff;
  public data: ImedStaff[] | undefined;

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

  public constructor(private _medStaffService: MedStaffService) {}

  public ngOnInit(): void {
    this._medStaffService.getMedStaff()
      .subscribe((data: ImedStaff[]) => {
        this.data = data;
      });
  }
}
