import { HttpHeaders } from '@angular/common/http';
import { Spreadsheet } from './../../models/bidding/spreadsheet.model';
import { Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'

import { Observable } from 'rxjs';
import { Contract } from 'src/app/models/bidding/contract.model';


@Injectable({
    providedIn: 'root'
})
export class SpreadsheetService {
    private baseUrl: string;
    private apiUrl: string = 'api/spreadsheet/';
    private apiCall: string = '';
    private _spreadsheet: Spreadsheet = new Spreadsheet();

    constructor(
        private http: HttpClient,
        @Inject('BASE_URL') baseUrl: string
    ) {
        this.baseUrl = baseUrl;
    }

    // GET: {id}
    public getSpreadsheetById(id: number): Observable<Spreadsheet> {
        return this.http.get<Spreadsheet>(this.baseUrl.concat(this.apiUrl, id.toString()));
    }
    // POST: Create
    public createSpreadsheet(spreadsheet: Spreadsheet): Observable<Spreadsheet> {
        return this.http.post<Spreadsheet>(this.baseUrl.concat(this.apiUrl), spreadsheet);
    }
    // POST: get all spreadsheets of a contract.
    public findSpreadsheets(contract: Contract): Observable<Spreadsheet[]> {
        return this.http.post<Spreadsheet[]>(this.baseUrl.concat(this.apiUrl).concat("GetAll"), contract.contractId);
    }
    // PUT: Update
    public updateSpreadsheet(id: number, spreadsheet: Spreadsheet): Observable<Spreadsheet> {
        console.log("Dentro do método updateSpreadsheet().");
        console.log("Rota: " + this.baseUrl.concat(this.apiUrl, id.toString()));
        console.log("id: " + id.toString() + ":::: Objeto: ");
        console.log(spreadsheet);

        return this.http.put<Spreadsheet>(this.baseUrl.concat(this.apiUrl, id.toString()), spreadsheet);

        // const headers = new HttpHeaders().set('content-type', 'application/json');
        // var body = {
        //     name: spreadsheet.name,
        //     description: spreadsheet.description,
        //     date: spreadsheet.date,
        //     author: spreadsheet.author
        // }
        // return this.http.put<Spreadsheet>(this.baseUrl.concat(this.apiUrl, id.toString()), body, { headers });
    }
    // DELETE
    public removeSpreadsheet(id: number): Observable<Spreadsheet> {
        return this.http.delete<Spreadsheet>(this.baseUrl.concat(this.apiUrl, id.toString()));
    }

    public sessionClear() {
        // Implementar
    }


}
