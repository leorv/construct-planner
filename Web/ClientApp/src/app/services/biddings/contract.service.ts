import { HttpHeaders } from '@angular/common/http';
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
        // console.log('Inserindo contrato...');
        // const headers = new HttpHeaders().set('content-type', 'application/json');
        
        // var body = {
        //     name: contract.name,
        //     object: contract.object,
        //     number: contract.number,
        //     year: contract.year,
        //     description: contract.description,
        //     date: contract.date,
        //     closed: contract.closed,
        //     contractedUserId: contract.contractedUserId,
        //     userId: contract.userId
        // }
        // Na API: [Bind("Name, Object, Number, Year, Description, Date, Closed, ContractedUserId, UserId")]
        return this.http.post<Contract>(this.baseUrl.concat(this.apiUrl), contract);
        // return this.http.post<Contract>(this.baseUrl.concat(this.apiUrl), body, { headers });
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
