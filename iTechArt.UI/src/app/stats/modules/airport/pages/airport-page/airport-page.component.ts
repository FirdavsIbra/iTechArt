import { Component, OnInit } from '@angular/core';

import { UnitsEnum } from '../../../../../shared/enums/units.enum';
import { StatsService } from "../../../../stats.service";
import { UnitsTypes } from "../../../../shared/types/units-types";

@Component({
  selector: 'app-airport-page',
  templateUrl: './airport-page.component.html',
  styleUrls: ['./airport-page.component.scss'],
})
export class AirportPageComponent implements OnInit {
  public unit: UnitsEnum = UnitsEnum.airport;
  public data: UnitsTypes | undefined;

  public columns = [
    { field: 'id', header: 'Id', width: 450 },
    { field: 'name', header: 'Name', width: 200 },
    { field: 'builtDate', header: 'Built Date', width: 100 },
    { field: 'capacity', header: 'Capacity', width: 100 },
    { field: 'address', header: 'Address', width: 100 },
    { field: 'city', header: 'City', width: 100 },
    { field: 'passengersPerYear', header: 'Passangers per Year', width: 100 },
    { field: 'flightsPerYear', header: 'Flights per Year', width: 100 },
    { field: 'averageTicketPrice', header: 'Average Ticket Price', width: 100 },

  ];

  public constructor(private statsService: StatsService) {}

  public ngOnInit(): void {
    this.statsService.getAllStatsByUnit(this.unit).subscribe({
      next: (data: UnitsTypes) => this.data = data,
      error: () => alert("Couldn't load data."),
    });
  }
}
