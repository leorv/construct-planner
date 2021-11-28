import { SourceItem } from './../../../models/bidding/pricereference/sourceitem.model';
import { Source } from './../../../models/bidding/pricereference/source.model';
import { HttpHeaders } from '@angular/common/http';
import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class FileUploadService {
    baseUrl: string = '';

  constructor(
      private httpClient: HttpClient,
      @Inject('BASE_URL') baseUrl: string
  ) {
      this.baseUrl = baseUrl;
   }

   postSourceItem(sourceItem: SourceItem): Observable<SourceItem> {
    const endpoint = this.baseUrl.concat('api/UploadSource');
    // const headers = new HttpHeaders().set('content-type', 'application/json');

    return this.httpClient.post<SourceItem>(endpoint, sourceItem);
}
}
