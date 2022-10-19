import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { StudentsPageComponent } from './pages/students-page/students-page.component';
import { SharedModule } from "../../../shared/shared.module";

@NgModule({
  declarations: [StudentsPageComponent],
    imports: [CommonModule, SharedModule]
})
export class StudentsModule {}
