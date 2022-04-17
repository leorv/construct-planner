import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { ContractService } from './../../services/biddings/contract.service';
import { UserService } from './../../services/user/user.service';

import { Contract } from './../../models/bidding/contract.model';


@Component({
    selector: 'app-contract',
    templateUrl: './contracts.component.html',
    styleUrls: ['./contracts.component.css']
})

export class ContractsComponent implements OnInit {

    title = 'Contratos';
    // public contracts: Contract[] = [];
    // contractedUser: User[] = [];
    // private detailsUrl: string = '/contract-details/';
    contracts: Contract[] = [];
    // contractUsers: ContractUser[] = [];
    // contratedUsers: User[] = [];
    idToRemove: number = 0;


    constructor(
        private router: Router,
        private contractService: ContractService,
        private userService: UserService
    ) {
    }

    ngOnInit(): void {
        this.getAllContracts();        
    }

    getAllContracts(){
        this.contractService.findContracts(this.userService.user).subscribe(
            (data) => {
                console.log('Contratos recarregados.');
                this.contracts = data;
            },
            (error) => {
                console.log(error);
            }
        )
    }

    // CRUD
    contractCreate() {
        this.router.navigate(['contract-create']);
    }
    contractDetails(id: number) {
        this.router.navigate(['contract-details', id.toString()]);
    }
    deleteId(id: number){
        this.idToRemove = id;
    }
    contractDelete(){
        this.contractService.removeContract(this.idToRemove).subscribe(
            result => {
                var _index = this.contracts.findIndex(contract => contract.contractId == this.idToRemove);
                this.contracts.splice(_index,1);
                console.log("deletado com sucesso.");
            },
            err => {
                console.log("Ocorreu um erro ao deletar.", err);
            }
        )  
    } 
}