import { UnitTypeInterface } from "../interfaces/unit-type.interface";
import { UnitEnum } from "../enums/unit.enum";

export const UNITS: Record<UnitEnum, UnitTypeInterface> = {
  police: {
    title: "Police",
    number: 456454756,
    icon: '../../assets/police.png',
    path: 'police'
  },
  students: {
    title: "Students",
    number: 456454756,
    icon: '../../assets/students.png',
    path: 'students'
  },
  pupils: {
    title: "Pupils",
    number: 456454756,
    icon: '../../assets/pupils.png',
    path: 'pupils'
  },
  airport: {
    title: "Airport",
    number: 456454756,
    icon: '../../assets/airport.png',
    path: 'airport'
  },
  medStaff: {
    title: "MedStaff",
    number: 456454756,
    icon: '../../assets/medstaff.png',
    path: 'med-staff'
  },
  grocery: {
    title: "Grocery",
    number: 456454756,
    icon: '../../assets/grocery.png',
    path: 'grocery'
  },
}
