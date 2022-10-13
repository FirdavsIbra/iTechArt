import { Component } from '@angular/core';

import { UNITS } from "../../constants/units";

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent {
  public units = UNITS
}
