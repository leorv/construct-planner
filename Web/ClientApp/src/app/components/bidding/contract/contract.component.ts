import { ContractUser } from './../../../models/bidding/contractuser.model';
import { UserService } from './../../../services/user/user.service';
import { User } from './../../../models/user.model';
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
        this.contractService.getContracts().subscribe(
            (data) => {
                console.log('Contratos recarregados.');
                this.contracts = data;
                // this.getContractsAndUsers(this.contracts);
                // this.getContratedUsers(this.contracts);
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
