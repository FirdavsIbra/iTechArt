import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';

import { HeaderComponent } from './components/header/header.component';
import { DashboardPageComponent } from './pages/dashboard-page/dashboard-page.component';

@NgModule({
  declarations: [
    DashboardPageComponent,
    HeaderComponent
  ],
  exports: [HeaderComponent],
  imports: [CommonModule, RouterLink, ReactiveFormsModule],
})
export class SharedModule {}
