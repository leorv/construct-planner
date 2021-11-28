import { Level } from './../../models/bidding/level.model';
import { Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'

import { Observable } from 'rxjs';
import { Spreadsheet } from 'src/app/models/bidding/spreadsheet.model';


@Injectable({
    providedIn: 'root'
})
export class LevelService {
    private baseUrl: string;
    private apiUrl: string = 'api/level/';
    private apiCall: string = '';
    private _level: Level = new Level();

    constructor(
        private http: HttpClient,
        @Inject('BASE_URL') baseUrl: string
    ) {
        this.baseUrl = baseUrl;
    }

    // GET: {id}
    public getLevelById(id: number): Observable<Level> {
        return this.http.get<Level>(this.baseUrl.concat(this.apiUrl, id.toString()));
    }
    // POST: Create
    public createLevel(level: Level): Observable<Level> {
        console.log(level);
        
        return this.http.post<Level>(this.baseUrl.concat(this.apiUrl), level);
    }
    // POST: get all levels of a spreadsheet.
    public findLevels(spreadsheet: Spreadsheet): Observable<Level[]> {
        return this.http.post<Level[]>(this.baseUrl.concat(this.apiUrl).concat("GetAll"), spreadsheet.spreadsheetId);
    }
    // PUT: Update
    public updateLevel(id: number, level: Level): Observable<Level> {
        return this.http.put<Level>(this.baseUrl.concat(this.apiUrl, id.toString()), level);
        // return this.http.put<Spreadsheet>(this.baseUrl.concat(this.apiUrl, id.toString()), spreadsheet);
    }
    // DELETE
    public removeLevel(id: number): Observable<Level> {
        return this.http.delete<Level>(this.baseUrl.concat(this.apiUrl, id.toString()));
    }

    public sessionClear() {
        // Implementar
    }


}
