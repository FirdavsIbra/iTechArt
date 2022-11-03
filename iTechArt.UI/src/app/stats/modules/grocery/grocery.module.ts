import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { GroceryPageComponent } from './pages/grocery-page/grocery-page.component';
import { SharedModule } from "../../../shared/shared.module";
import { SharedStatsModule } from "../../shared/shared-stats.module";

@NgModule({
  declarations: [GroceryPageComponent],
    imports: [CommonModule, SharedModule, SharedStatsModule]
})
export class GroceryModule {}
