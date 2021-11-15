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

    public getContracts() : Observable<Contract[]>{        
        return this.http.get<Contract[]>(this.baseUrl.concat(this.apiUrl));
    }

    public getContractById(id: number) : Observable<Contract>{
        return this.http.get<Contract>(this.baseUrl
            .concat(this.apiUrl,id.toString()));
    }

    public sessionClear() {
        // Implementar
    }
}
