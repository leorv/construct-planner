import { Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'

import { AdditiveAgreement } from './../../models/bidding/additiveagreement.model';
import { Observable } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class AdditiveAgreementService {

    private baseUrl: string;
    private apiUrl: string = 'api/additiveAgreement/';
    private apiCall: string = '';
    private _additiveAgreement!: AdditiveAgreement;

    constructor(
        private http: HttpClient,
        @Inject('BASE_URL') baseUrl: string
    ) {
        this.baseUrl = baseUrl;
    }
    // GET: All
    public getAdditiveAgreements(): Observable<AdditiveAgreement[]> {
        return this.http.get<AdditiveAgreement[]>(this.baseUrl.concat(this.apiUrl));
    }
    // GET: {id}
    public getAdditiveAgreementById(id: number): Observable<AdditiveAgreement> {
        return this.http.get<AdditiveAgreement>(this.baseUrl.concat(this.apiUrl, id.toString()));
    }
    // POST: Create
    public createAdditiveAgreement(additiveAgreement: AdditiveAgreement): Observable<AdditiveAgreement> {        
        return this.http.post<AdditiveAgreement>(this.baseUrl.concat(this.apiUrl), additiveAgreement);
    }
    // PUT: Update
    public updateAdditiveAgreement(id: number, additiveAgreement: AdditiveAgreement): Observable<AdditiveAgreement> {
        return this.http.put<AdditiveAgreement>(this.baseUrl.concat(this.apiUrl).concat(id.toString()), additiveAgreement);
    }
    // DELETE
    public removeAdditiveAgreement(id: number) : Observable<AdditiveAgreement> {
        return this.http.delete<AdditiveAgreement>(this.baseUrl.concat(this.apiUrl).concat(id.toString()));
    }
    public sessionClear() {
        // Implementar
    }
}