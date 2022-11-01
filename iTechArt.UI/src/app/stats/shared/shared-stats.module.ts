import { NgModule } from '@angular/core';
import { NgForOf, NgIf } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';

import { DataTableComponent } from './components/data-table/data-table.component';
import { UnitHeaderComponent } from './components/unit-header/unit-header.component';
import { ExcelExportComponent } from './components/excel-export/excel-export.component';

@NgModule({
  declarations: [ExcelExportComponent, UnitHeaderComponent, DataTableComponent],
  exports: [ExcelExportComponent, UnitHeaderComponent, DataTableComponent],
  imports: [NgForOf, ReactiveFormsModule, NgIf],
})
export class SharedStatsModule {}
