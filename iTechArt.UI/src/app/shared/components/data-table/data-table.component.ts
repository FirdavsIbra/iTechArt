import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-data-table',
  templateUrl: './data-table.component.html',
  styleUrls: ['./data-table.component.scss']
})
export class DataTableComponent {
  @Input() public data: any[] | undefined;
  @Input() public columns: string[] | undefined;
  @Input() public props: string[] | undefined;
}
