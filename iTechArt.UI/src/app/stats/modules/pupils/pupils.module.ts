import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PupilsPageComponent } from './pages/pupils-page/pupils-page.component';
import { SharedModule } from "../../../shared/shared.module";
import { SharedStatsModule } from "../../shared/shared-stats.module";

@NgModule({
  declarations: [PupilsPageComponent],
    imports: [CommonModule, SharedModule, SharedStatsModule]
})
export class PupilsModule {}
