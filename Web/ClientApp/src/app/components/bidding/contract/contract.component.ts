import { Router } from '@angular/router';
import { ContractService } from './../../../services/biddings/contract.service';
import { Contract } from './../../../models/bidding/contract.model';
import { Component, OnInit } from '@angular/core';

@Component({
    selector: 'app-contract',
    templateUrl: './contract.component.html',
    styleUrls: ['./contract.component.css']
})

export class ContractComponent implements OnInit {

    title = 'Contratos';
    // public contracts: Contract[] = [];
    
    // private detailsUrl: string = '/contract-details/';
    public contracts: Contract[] = [];
    

    constructor(
        private router: Router,
        private contractService: ContractService,        
    ) {
    }

    ngOnInit(): void {
        this.contractService.getContracts().subscribe(
            (data) => {
                console.log(data);
                this.contracts = data;

            },
            (error) => {
                console.log(error);
            }
        )
    }

    contractDetails(id: number) {
        this.router.navigate(['contract-details',id.toString()]);
    }
}
