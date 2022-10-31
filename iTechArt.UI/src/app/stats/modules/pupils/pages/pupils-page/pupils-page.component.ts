import { Component, OnInit } from '@angular/core';

import { UnitsEnum } from '../../../../../shared/enums/units.enum';
import { PupilsService } from "../../../../../shared/services/pupils.service";
import { IPupil } from "../../../../../shared/interfaces/pupil.interface";

@Component({
  selector: 'app-pupils-page',
  templateUrl: './pupils-page.component.html',
  styleUrls: ['./pupils-page.component.scss'],
})
export class PupilsPageComponent implements OnInit {
  public unit: UnitsEnum = UnitsEnum.pupils;
  public data: IPupil[] | undefined;

  public columns = [
    'Id',
    'First Name',
    'Last Name',
    'Date of Birth',
    'Gender',
    'Phone Number',
    'Address',
    'City',
    'School Name',
    'Grade',
    'Course Language',
    'Shift',
  ];

  public props = [
    'id',
    'firstName',
    'lastName',
    'dateOfBirth',
    'gender',
    'phoneNumber',
    'address',
    'city',
    'schoolName',
    'grade',
    'courseLanguage',
    'shift',
  ];

  public constructor(private _pupilsService: PupilsService) {}

  public ngOnInit(): void {
    this._pupilsService.getPupils()
      .subscribe((data: IPupil[]) => {
        this.data = data;
      });
  }
}
