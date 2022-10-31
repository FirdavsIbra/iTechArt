import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';

import { HeaderComponent } from './components/header/header.component';
import { DashboardPageComponent } from './pages/dashboard-page/dashboard-page.component';
import { ExcelExportComponent } from './components/excel-export/excel-export.component';
import { UnitHeaderComponent } from './components/unit-header/unit-header.component';
import { DataTableComponent } from './components/data-table/data-table.component';

@NgModule({
  declarations: [
    DashboardPageComponent,
    HeaderComponent,
    ExcelExportComponent,
    UnitHeaderComponent,
    DataTableComponent,
  ],
  exports: [HeaderComponent, ExcelExportComponent, UnitHeaderComponent, DataTableComponent],
  imports: [CommonModule, RouterLink, ReactiveFormsModule],
})
export class SharedModule {}
