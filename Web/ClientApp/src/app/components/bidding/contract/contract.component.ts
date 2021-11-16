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


    // getContractsAndUsers(contracts: Contract[]) {
    //     for (var n = 0; n <= contracts.length; n++) {
    //         this.userService.getUserById(contracts[n].contractedUserId).subscribe(
    //             user => {
    //                 this.contractUsers.push(new ContractUser(user.userId, contracts[n].contractId));
    //             },
    //             err => {
    //                 console.log(err.error);
    //             }
    //         );
    //     }
    // }

    // getContratedUsers(contracts: Contract[]) {
    //     for (var n = 0; n <= contracts.length; n++) {
    //         this.userService.getUserById(contracts[n].contractedUserId).subscribe(
    //             user => {
    //                 this.contratedUsers.push(user);
    //             },
    //             err => {
    //                 console.log(err.error);
    //             }
    //         );
    //     }
    // }

    // getUserName(user: User): string {
    //     return user.name;
    // }

    contractDetails(id: number) {
        this.router.navigate(['contract-details', id.toString()]);
    }
    contractCreate() {
        this.router.navigate(['contract-create']);
    }

}
