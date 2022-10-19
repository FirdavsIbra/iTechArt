import { UnitTypeInterface } from '../interfaces/unit-type.interface';
import { UnitsEnum } from '../enums/units.enum';

export const UNITS: Record<UnitsEnum, UnitTypeInterface> = {
  police: {
    title: 'Police',
    icon: '../../assets/police.png',
    path: 'police',
  },
  students: {
    title: 'Students',
    icon: '../../assets/students.png',
    path: 'students',
  },
  pupils: {
    title: 'Pupils',
    icon: '../../assets/pupils.png',
    path: 'pupils',
  },
  airport: {
    title: 'Airport',
    icon: '../../assets/airport.png',
    path: 'airport',
  },
  medStaff: {
    title: 'MedStaff',
    icon: '../../assets/med.png',
    path: 'med-staff',
  },
  grocery: {
    title: 'Grocery',
    icon: '../../assets/grocery.png',
    path: 'grocery',
  },
};
