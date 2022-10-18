import { UnitTypeInterface } from '../interfaces/unit-type.interface';
import { UnitEnum } from '../enums/unit.enum';

export const UNITS: Record<UnitEnum, UnitTypeInterface> = {
  police: {
    title: 'Police',
    number: Math.floor(Math.random() * 1000),
    icon: '../../assets/police.png',
    path: 'police',
  },
  students: {
    title: 'Students',
    number: Math.floor(Math.random() * 1000),
    icon: '../../assets/students.png',
    path: 'students',
  },
  pupils: {
    title: 'Pupils',
    number: Math.floor(Math.random() * 1000),
    icon: '../../assets/pupils.png',
    path: 'pupils',
  },
  airport: {
    title: 'Airport',
    number: Math.floor(Math.random() * 1000),
    icon: '../../assets/airport.png',
    path: 'airport',
  },
  medStaff: {
    title: 'MedStaff',
    number: Math.floor(Math.random() * 1000),
    icon: '../../assets/med.png',
    path: 'med-staff',
  },
  grocery: {
    title: 'Grocery',
    number: Math.floor(Math.random() * 1000),
    icon: '../../assets/grocery.png',
    path: 'grocery',
  },
};
