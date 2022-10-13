import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { HeaderComponent } from './components/header/header.component';
import { DashboardPageComponent } from './pages/dashboard-page/dashboard-page.component';
import { RouterLink } from "@angular/router";

@NgModule({
  declarations: [DashboardPageComponent, HeaderComponent],
  exports: [HeaderComponent],
  imports: [CommonModule, RouterLink]
})
export class SharedModule {}
