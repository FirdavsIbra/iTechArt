import { Component, Input, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';

import { UnitsEnum } from '../../enums/units.enum';
import { environment } from '../../../../environments/environment';
import { ApiService } from '../../services/api.service';
import { ContentTypeService } from '../../services/content-type.service';
import { ExtensionsEnum } from '../../enums/extensions.enum';

@Component({
  selector: 'app-excel-export',
  templateUrl: './excel-export.component.html',
  styleUrls: ['./excel-export.component.scss'],
})
export class ExcelExportComponent implements OnInit {
  @Input() public unit: UnitsEnum | undefined;

  public url = environment.apiUrl;
  public api: string | undefined;
  public fileName: string | undefined;
  public isFormValid = false;
  public isFormButtonDisabled = false;

  public exportForm = new FormGroup({
    file: new FormControl('', [Validators.required]),
    fileSource: new FormControl('', [Validators.required]),
  });

  public constructor(
    private http: HttpClient,
    private apiService: ApiService,
    private contentTypeService: ContentTypeService
  ) {}

  public ngOnInit(): void {
    this.api = this.apiService.defineApiForUnitImport(this.unit);
  }

  public onFileChange(event: any): void {
    this.isFormButtonDisabled = false;
    if (event.target.files.length > 0) {
      const file = event.target.files[0];
      this.fileName = file.name;
      const fileExtension = this.contentTypeService.getFileExtension(
        this.fileName
      );
      if (
        fileExtension === ExtensionsEnum.csv ||
        fileExtension === ExtensionsEnum.xls ||
        fileExtension === ExtensionsEnum.xml ||
        fileExtension === ExtensionsEnum.xlsx
      ) {
        this.exportForm.patchValue({
          fileSource: file,
        });
        this.isFormValid = true;
      } else {
        this.isFormValid = false;
      }
    }
  }

  public submit(): void {
    this.isFormButtonDisabled = true;
    const file = this.exportForm.get('fileSource')!.value;
    // const fileContentType = this.contentTypeService.getContentType(
    //   this.fileName
    // );
    const formData = new FormData();
    formData.append('file', file!);

    //const headers = new HttpHeaders().set('content-type', fileContentType!);

    // this.http.post(`${this.url}${this.api}`, formData).subscribe(() => {
    //   alert('Uploaded Successfully.');
    //   this.isFormButtonDisabled = false;
    // });

    this.http.post<any>(`${this.url}${this.api}`, formData).subscribe({
      next: (data: string) => {
        alert('Uploaded Successfully.');
        console.log(data)
        this.isFormButtonDisabled = false;
      },
      error: (error: string) => {
        alert(`There was an error! ${error}`);
        console.log(error);
        this.isFormButtonDisabled = false;
      }
    })
  }
}
