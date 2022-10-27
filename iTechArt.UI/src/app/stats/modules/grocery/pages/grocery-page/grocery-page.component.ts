import { Component } from '@angular/core';

import { UnitsEnum } from "../../../../../shared/enums/units.enum";

@Component({
  selector: 'app-grocery-page',
  templateUrl: './grocery-page.component.html',
  styleUrls: ['./grocery-page.component.scss'],
})
export class GroceryPageComponent {
  public unit: UnitsEnum = UnitsEnum.grocery
}

