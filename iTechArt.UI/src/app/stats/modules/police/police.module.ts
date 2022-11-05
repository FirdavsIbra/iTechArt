import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PolicePageComponent } from './pages/police-page/police-page.component';
import { SharedModule } from "../../../shared/shared.module";
import { SharedStatsModule } from "../../shared/shared-stats.module";

@NgModule({
  declarations: [PolicePageComponent],
  imports: [CommonModule, SharedModule, SharedStatsModule]
})
export class PoliceModule {}
