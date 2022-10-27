import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MedStaffPageComponent } from "./pages/med-staff-page/med-staff-page.component";
import { SharedModule } from "../../../shared/shared.module";

@NgModule({
  declarations: [MedStaffPageComponent],
    imports: [CommonModule, SharedModule]
})
export class MedStaffModule {}
