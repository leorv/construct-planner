import { Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'

import { Contract } from 'src/app/models/bidding/contract.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ContractService {

    private baseUrl: string;
    private _contract!: Contract;
    
    constructor(
        private http: HttpClient,
        @Inject('BASE_URL') baseUrl: string
    ) {
        this.baseUrl = baseUrl;
    }

    public getContracts() {        
        return this.http.get(this.baseUrl.concat('api/contract'));
    }        

    public sessionClear() {
        // Implementar
    }
}
