import { Component, OnInit } from "@angular/core";

import { UnitsEnum } from '../../../../../shared/enums/units.enum';
import { IStudents } from '../../../../../shared/interfaces/students.interface';
import { StudentsService } from '../../../../../shared/services/students.service';

@Component({
  selector: 'app-students-page',
  templateUrl: './students-page.component.html',
  styleUrls: ['./students-page.component.scss'],
})
export class StudentsPageComponent implements OnInit{
  public unit: UnitsEnum = UnitsEnum.students;
  public data: IStudents[] | undefined;

  public columns = [
    'Id',
    'First Name',
    'Last Name',
    'Gender',
    'Email',
    'Date of Birth',
    'University',
  ];

  public props = [
    'id',
    'firstName',
    'lastName',
    'gender',
    'email',
    'dateOfBirth',
    'university',
  ];

  public constructor(private _StudentsService: StudentsService) {}

  public ngOnInit(): void {
    this._StudentsService.getStudents().subscribe((data: IStudents[]) => {
      this.data = data;
    });
  }
}
