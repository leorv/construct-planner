import { Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'

import { Contract } from 'src/app/models/bidding/contract.model';
import { Observable } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class ContractService {

    private baseUrl: string;
    private apiUrl: string = 'api/contract/';
    private apiCall: string = '';
    private _contract!: Contract;

    constructor(
        private http: HttpClient,
        @Inject('BASE_URL') baseUrl: string
    ) {
        this.baseUrl = baseUrl;
    }
    // GET: All
    public getContracts(): Observable<Contract[]> {
        return this.http.get<Contract[]>(this.baseUrl.concat(this.apiUrl));
    }
    // GET: {id}
    public getContractById(id: number): Observable<Contract> {
        return this.http.get<Contract>(this.baseUrl.concat(this.apiUrl, id.toString()));
    }
    // POST: Create
    public createContract(contract: Contract): Observable<Contract> {
        return this.http.post<Contract>(this.baseUrl.concat(this.apiUrl), contract);
    }
    // PUT: Update
    public updateContract(id: number, contract: Contract): Observable<Contract> {
        return this.http.put<Contract>(this.baseUrl.concat(this.apiUrl).concat(id.toString()), contract);
    }
    // DELETE
    public removeContract(id: number) : Observable<Contract> {
        return this.http.delete<Contract>(this.baseUrl.concat(this.apiUrl).concat(id.toString()));
    }

    public sessionClear() {
        // Implementar
    }
}
