import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';

import { HeaderComponent } from './components/header/header.component';
import { DashboardPageComponent } from './pages/dashboard-page/dashboard-page.component';
import { ExcelExportComponent } from './components/excel-export/excel-export.component';

@NgModule({
  declarations: [DashboardPageComponent, HeaderComponent, ExcelExportComponent],
  exports: [HeaderComponent, ExcelExportComponent],
  imports: [CommonModule, RouterLink],
})
export class SharedModule {}
