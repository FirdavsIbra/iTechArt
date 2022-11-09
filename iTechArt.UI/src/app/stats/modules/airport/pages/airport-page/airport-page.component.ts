import { Component, OnInit } from '@angular/core';

import { UnitsEnum } from '../../../../../shared/enums/units.enum';
import { StatsService } from '../../../../stats.service';
import { UnitsTypes } from '../../../../shared/types/units-types';

@Component({
  selector: 'app-airport-page',
  templateUrl: './airport-page.component.html',
  styleUrls: ['./airport-page.component.scss'],
})
export class AirportPageComponent implements OnInit {
  public unit: UnitsEnum = UnitsEnum.airport;
  public data: UnitsTypes | undefined;

  public columns = [
    { field: 'id', header: 'Id', width: 58 },
    { field: 'airportName', header: 'Name', width: 217 },
    { field: 'builtDate', header: 'Built Date', width: 117 },
    { field: 'capacity', header: 'Capacity', width: 117 },
    { field: 'address', header: 'Address', width: 122 },
    { field: 'city', header: 'City', width: 153 },
    { field: 'passengersPerYear', header: 'Passengers per Year', width: 117 },
    { field: 'flightsPerYear', header: 'Flights per Year', width: 117 },
    { field: 'averageTicketPrice', header: 'Average Ticket Price', width: 117 },
  ];

  public constructor(private statsService: StatsService) {}

  public ngOnInit(): void {
    this.statsService.getAllStatsByUnit(this.unit).subscribe({
      next: (data: UnitsTypes) => (this.data = data),
      error: () => alert("Couldn't load data."),
    });
  }
}
