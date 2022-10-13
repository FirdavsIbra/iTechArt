import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AirportPageComponent } from './pages/airport-page/airport-page.component';
import { SharedModule } from "../../../shared/shared.module";

@NgModule({
  declarations: [AirportPageComponent],
  imports: [CommonModule, SharedModule]
})
export class AirportModule {}
