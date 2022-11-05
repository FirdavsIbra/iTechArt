import { Component, OnInit } from '@angular/core';

import { UnitsEnum } from '../../../../../shared/enums/units.enum';
import { AirportService } from '../../airport.service';
import { IAirport } from '../../interfaces/airport.interface';

@Component({
  selector: 'app-airport-page',
  templateUrl: './airport-page.component.html',
  styleUrls: ['./airport-page.component.scss'],
})
export class AirportPageComponent implements OnInit {
  public unit: UnitsEnum = UnitsEnum.airport;
  public data: IAirport[] | undefined;
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

  public constructor(private _airportService: AirportService) {}

  public ngOnInit(): void {
    this._airportService.getAirports().subscribe({
      next: (data: IAirport[]) => this.data = data,
      error: () => alert("Couldn't load data."),
    });
  }
}
