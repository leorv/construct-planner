import { HttpClient } from '@angular/common/http';
import { Inject } from '@angular/core';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Clause } from 'src/app/models/bidding/clause.model';

@Injectable({
    providedIn: 'root'
})
export class ClauseService {

    private baseUrl: string;
    private apiUrl: string = 'api/clause/';

    constructor(
        private http: HttpClient,
        @Inject('BASE_URL') baseUrl: string
    ) {
        this.baseUrl = baseUrl;
    }
    


    // GET: {id}
    public getClauseById(id: number): Observable<Clause> {
        return this.http.get<Clause>(this.baseUrl.concat(this.apiUrl, id.toString()));
    }
    // POST: Create
    public createClause(clause: Clause): Observable<Clause> {
        console.log(clause);
        console.log("chamando método http post para criar a cláusula.");
        return this.http.post<Clause>(this.baseUrl.concat(this.apiUrl), clause);
    }
    // POST: All clauses of a user.
    public findClauses(id: number): Observable<Clause[]> {
        return this.http.post<Clause[]>(this.baseUrl.concat(this.apiUrl).concat("GetAll"), id);
    }
    // PUT: Update
    public updateClause(id: number, clause: Clause): Observable<Clause> {
        return this.http.put<Clause>(this.baseUrl.concat(this.apiUrl).concat(id.toString()), clause);
    }
    // DELETE
    public removeClause(id: number): Observable<Clause> {
        return this.http.delete<Clause>(this.baseUrl.concat(this.apiUrl, id.toString()));
    }



}
