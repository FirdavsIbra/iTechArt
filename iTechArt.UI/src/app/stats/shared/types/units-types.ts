import { IAirport } from '../../modules/airport/interfaces/airport.interface';
import { IMedStaff } from '../../modules/medStaff/interfaces/medStaff.interface';
import { IGrocery } from '../../modules/grocery/interfaces/grocery.interface';
import { IPupil } from '../../modules/pupils/interfaces/pupil.interface';
import { IPolice } from '../../modules/police/interfaces/police.interface';
import { IStudents } from '../../modules/students/interfaces/students.interface';

export type UnitsTypes =
  | IAirport[]
  | IGrocery[]
  | IMedStaff[]
  | IPolice[]
  | IPupil[]
  | IStudents[];
