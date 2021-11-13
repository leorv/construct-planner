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
    public contracts: any;

    constructor(
        private contractService: ContractService
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




}
