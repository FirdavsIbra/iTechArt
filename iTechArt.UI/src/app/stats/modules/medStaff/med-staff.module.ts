import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MedStaffPageComponent } from "./pages/med-staff-page/med-staff-page.component";
import { SharedModule } from "../../../shared/shared.module";
import { SharedStatsModule } from "../../shared/shared-stats.module";

@NgModule({
  declarations: [MedStaffPageComponent],
    imports: [CommonModule, SharedModule, SharedStatsModule]
})
export class MedStaffModule {}
