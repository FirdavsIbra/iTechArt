import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { DashboardPageComponent } from "./shared/pages/dashboard-page/dashboard-page.component";
import { AirportPageComponent } from "./stats/modules/airport/pages/airport-page/airport-page.component";
import { PolicePageComponent } from "./stats/modules/police/pages/police-page/police-page.component";
import { PupilsPageComponent } from "./stats/modules/pupils/pages/pupils-page/pupils-page.component";
import { MedStaffPageComponent } from "./stats/modules/medStaff/pages/med-staff-page/med-staff-page.component";
import { StudentsPageComponent } from "./stats/modules/students/pages/students-page/students-page.component";
import { GroceryPageComponent } from "./stats/modules/grocery/pages/grocery-page/grocery-page.component";

const routes: Routes = [
  {path: '', component: DashboardPageComponent },
  {path: 'med-staff', component: MedStaffPageComponent},
  {path: 'police', component: PolicePageComponent },
  {path: 'students', component: StudentsPageComponent},
  {path: 'pupils', component: PupilsPageComponent },
  {path: 'grocery', component: GroceryPageComponent},
  {path: 'airport', component: AirportPageComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
