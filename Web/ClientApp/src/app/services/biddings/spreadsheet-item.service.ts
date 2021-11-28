import { Level } from './../../models/bidding/level.model';
import { SpreadsheetItem } from './../../models/bidding/spreadsheetitem.model';
import { Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'

import { Observable } from 'rxjs';


@Injectable({
    providedIn: 'root'
})
export class SpreadsheetItemService {
    private baseUrl: string;
    private apiUrl: string = 'api/spreadsheetItem/';
    private apiCall: string = '';
    private _spreadsheetItem: SpreadsheetItem = new SpreadsheetItem();

    constructor(
        private http: HttpClient,
        @Inject('BASE_URL') baseUrl: string
    ) {
        this.baseUrl = baseUrl;
    }

    // GET: {id}
    public getSpreadsheetItemById(id: number): Observable<SpreadsheetItem> {
        return this.http.get<SpreadsheetItem>(this.baseUrl.concat(this.apiUrl, id.toString()));
    }
    // POST: Create
    public createSpreadsheetItem(spreadsheetItem: SpreadsheetItem): Observable<SpreadsheetItem> {
        return this.http.post<SpreadsheetItem>(this.baseUrl.concat(this.apiUrl), spreadsheetItem);
    }
    // POST: get all spreadsheetItems of a level.
    public findSpreadsheetItems(level: Level): Observable<SpreadsheetItem[]> {
        return this.http.post<SpreadsheetItem[]>(this.baseUrl.concat(this.apiUrl).concat("GetAll"), level.levelId);
    }
    // PUT: Update
    public updateSpreadsheetItem(id: number, spreadsheetItem: SpreadsheetItem): Observable<SpreadsheetItem> {
        return this.http.put<SpreadsheetItem>(this.baseUrl.concat(this.apiUrl).concat(id.toString()), spreadsheetItem);
    }
    // DELETE
    public removeSpreadsheetItem(id: number): Observable<SpreadsheetItem> {
        return this.http.delete<SpreadsheetItem>(this.baseUrl.concat(this.apiUrl, id.toString()));
    }

    public sessionClear() {
        // Implementar
    }
}
