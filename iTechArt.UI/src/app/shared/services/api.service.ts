import { Injectable } from '@angular/core';

import { UnitsEnum } from '../enums/units.enum';
import { APIS } from '../constants/APIS';
import { ExtensionsEnum } from '../enums/extensions.enum';

@Injectable({
  providedIn: 'root',
})
export class ApiService {
  public defineApiForUnitImport(
    unit: UnitsEnum | undefined,
    extension: ExtensionsEnum | string | undefined
  ): string | undefined {

    console.log(extension) //delete

    switch (unit) {
      case UnitsEnum.airport:
        return APIS.airport.import;
      case UnitsEnum.grocery:
        return APIS.grocery.import;
      case UnitsEnum.police:
        return APIS.police.import;
      case UnitsEnum.pupils:
        return APIS.pupils.import;
      case UnitsEnum.medStaff:
        return APIS.medStaff.import;
      case UnitsEnum.students:
        return APIS.students.import;
      default:
        return undefined;
    }
  }
}
