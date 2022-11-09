import { Injectable } from '@angular/core';

import { UnitsEnum } from '../enums/units.enum';
import { APIS } from '../apis/constants/apis';
import { ExtensionsEnum } from '../enums/extensions.enum';
import { environment } from '../../../environments/environment';
import { ApisImportEnum } from '../apis/enums/apis-import.enum';
import { ApisExportEnum } from "../apis/enums/apis-export.enum";

@Injectable({
  providedIn: 'root',
})
export class ApiService {
  public url = environment.apiUrl;
  public unitPath: string | undefined;

  public defineUnitPath(unit: UnitsEnum | undefined): void {
    switch (unit) {
      case UnitsEnum.airport:
        this.unitPath = APIS.airport.path;
        break;
      case UnitsEnum.grocery:
        this.unitPath = APIS.grocery.path;
        break;
      case UnitsEnum.police:
        this.unitPath = APIS.police.path;
        break;
      case UnitsEnum.pupils:
        this.unitPath = APIS.pupils.path;
        break;
      case UnitsEnum.medStaff:
        this.unitPath = APIS.medStaff.path;
        break;
      case UnitsEnum.students:
        this.unitPath = APIS.students.path;
        break;
      default:
        break;
    }
  }

  public defineImportApiForCurrentUnit(
    unit: UnitsEnum | undefined,
    extension: string | undefined
  ): string {
    let currentImportApi: ApisImportEnum | undefined;

    this.defineUnitPath(unit);

    switch (extension) {
      case ExtensionsEnum.xml:
        currentImportApi = ApisImportEnum.xml;
        break;
      case ExtensionsEnum.xls:
        currentImportApi = ApisImportEnum.xls;
        break;
      case ExtensionsEnum.xlsx:
        currentImportApi = ApisImportEnum.xlsx;
        break;
      case ExtensionsEnum.csv:
        currentImportApi = ApisImportEnum.csv;
        break;
      default:
        return '';
    }

    return `${this.url}${this.unitPath}${currentImportApi}`;
  }

  public defineExportApiForCurrentUnit(unit: UnitsEnum | undefined): string {
    this.defineUnitPath(unit);

    return `${this.url}${this.unitPath}${ApisExportEnum.getAll}`;
  }
}
