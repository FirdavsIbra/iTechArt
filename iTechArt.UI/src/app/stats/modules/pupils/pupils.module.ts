import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PupilsPageComponent } from './pages/pupils-page/pupils-page.component';
import { SharedModule } from "../../../shared/shared.module";

@NgModule({
  declarations: [PupilsPageComponent],
    imports: [CommonModule, SharedModule]
})
export class PupilsModule {}
