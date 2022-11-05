import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AirportModule } from './modules/airport/airport.module';
import { GroceryModule } from './modules/grocery/grocery.module';
import { MedStaffModule } from './modules/medStaff/med-staff.module';
import { PoliceModule } from './modules/police/police.module';
import { PupilsModule } from './modules/pupils/pupils.module';
import { StudentsModule } from './modules/students/students.module';
import { SharedStatsModule } from './shared/shared-stats.module';

@NgModule({
  imports: [
    CommonModule,
    AirportModule,
    GroceryModule,
    MedStaffModule,
    PoliceModule,
    PupilsModule,
    StudentsModule,
    SharedStatsModule,
  ],
})
export class StatsModule {}
