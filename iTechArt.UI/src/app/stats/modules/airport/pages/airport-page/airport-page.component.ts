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
  public props = [
    'id',
    'name',
    'builtDate',
    'capacity',
    'address',
    'city',
    'passengersPerYear',
    'flightsPerYear',
    'averageTicketPrice',
  ];
  public columns = [
    'Id',
    'Name',
    'Built Date',
    'Capacity',
    'Address',
    'City',
    'Passengers Per Year',
    'Flights Per Year',
    'Average Ticket Price',
  ];

  public constructor(private statsService: StatsService) {}

  public ngOnInit(): void {
    this.statsService.getAllStatsByUnit(this.unit).subscribe({
      next: (data: UnitsTypes) => this.data = data,
      error: () => alert("Couldn't load data."),
    });
  }
}
