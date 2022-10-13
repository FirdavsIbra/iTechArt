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
    icon: '../../assets/students.png'
  },
  pupils: {
    title: "Pupils",
    number: 456454756,
    icon: '../../assets/pupils.png'
  },
  airport: {
    title: "Airport",
    number: 456454756,
    icon: '../../assets/airport.png'
  },
  medStaff: {
    title: "MedStaff",
    number: 456454756,
    icon: '../../assets/medstaff.png'
  },
  grocery: {
    title: "Grocery",
    number: 456454756,
    icon: '../../assets/grocery.png'
  },
}
