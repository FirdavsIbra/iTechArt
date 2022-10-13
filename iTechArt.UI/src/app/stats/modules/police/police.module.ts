import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PolicePageComponent } from './pages/police-page/police-page.component';
import { SharedModule } from "../../../shared/shared.module";

@NgModule({
  declarations: [PolicePageComponent],
    imports: [CommonModule, SharedModule]
})
export class PoliceModule {}
