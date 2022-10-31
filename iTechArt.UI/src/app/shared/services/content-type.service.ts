import { Injectable } from '@angular/core';

import { CONTENT_TYPES } from '../constants/file-extensions';

@Injectable({
  providedIn: 'root',
})
export class ContentTypeService {
  public getFileExtension(filename: string | undefined): string | undefined {
    return filename!.split('.').pop();
  }

  public getContentType(fileName: string | undefined): string {
    let fileExtension = this.getFileExtension(fileName);

    function defineContentType(fileExtension: string | undefined): string {
      return CONTENT_TYPES[fileExtension!];
    }

    return defineContentType(fileExtension);
  }
}
