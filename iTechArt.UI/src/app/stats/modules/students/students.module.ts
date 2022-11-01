import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { StudentsPageComponent } from './pages/students-page/students-page.component';
import { SharedModule } from '../../../shared/shared.module';
import { SharedStatsModule } from "../../shared/shared-stats.module";

@NgModule({
  declarations: [StudentsPageComponent],
    imports: [CommonModule, SharedModule, SharedStatsModule]
})
export class StudentsModule {}
