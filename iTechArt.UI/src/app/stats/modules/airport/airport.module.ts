import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AirportPageComponent } from './pages/airport-page/airport-page.component';
import { SharedModule } from '../../../shared/shared.module';
import { SharedStatsModule } from "../../shared/shared-stats.module";

@NgModule({
  declarations: [AirportPageComponent],
  imports: [CommonModule, SharedModule, SharedStatsModule]
})
export class AirportModule {}
