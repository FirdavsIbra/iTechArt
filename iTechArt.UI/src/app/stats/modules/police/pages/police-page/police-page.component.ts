import { Component, OnInit } from "@angular/core";

import { UnitsEnum } from '../../../../../shared/enums/units.enum';
import { IPolice } from "../../interfaces/police.interface";
import { PoliceService } from "../../police.service";


@Component({
  selector: 'app-police-page',
  templateUrl: './police-page.component.html',
  styleUrls: ['./police-page.component.scss'],
})
export class PolicePageComponent implements OnInit{
  public unit: UnitsEnum = UnitsEnum.police;
  public data: IPolice[] | undefined;

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
    'heightInCM'
  ];

  public constructor(private _PoliceService: PoliceService) {}

  public ngOnInit(): void {
    this._PoliceService.getPolice()
      .subscribe((data: IPolice[]) => {
        this.data = data;
      });
  }
}


