import { DataTransferService } from './../../../services/data-transfer.service';
import { Router } from '@angular/router';
import { User } from 'src/app/models/user.model';
import { UserService } from 'src/app/services/user/user.service';
import { ContractService } from './../../../services/biddings/contract.service';
import { Component, Input, OnInit } from '@angular/core';
import { Contract } from 'src/app/models/bidding/contract.model';
import { ActivatedRoute, Params } from '@angular/router';
import { Observable } from 'rxjs';

@Component({
    selector: 'app-contract-details',
    templateUrl: './contracts-details.component.html',
    styleUrls: ['./contracts-details.component.css']
})
export class ContractsDetailsComponent implements OnInit {

    contract: Contract = new Contract();
    ownerUser: User = new User();
    contractedUser: User = new User();

    constructor(
        private contractService: ContractService,
        private userService: UserService,
        private route: ActivatedRoute,
        private router: Router,
        private dataTransferService: DataTransferService
    ) { }

    ngOnInit(): void {
        // this.contract = this.contractService.getContractById(1);
        console.clear();
        const par = this.route.snapshot.paramMap.get('id');
        console.log(par);
        if (par != null) {
            this.getContract(parseInt(par));
        }        
    }
    shareData(data: any){
        this.dataTransferService.sendAnything(data); // Para mandar algo para outro componente.
    }


    getContract(id: number){
        console.log('contract id:');
        console.log(id);
        this.contractService.getContractById(id).subscribe(
            contract_json => {
                this.contract = contract_json;
                this.getOwnerUser(this.contract.userId);
                this.getContractedUser(this.contract.contractedUserId);
            },
            err => {
                console.log(err.error);
            }
        );
    }
    getOwnerUser(id: number){
        console.log('contract owner:');
        console.log(id);
        this.userService.getUserById(id).subscribe(
            user_json => {
                this.ownerUser = user_json;
            },
            err => {
                console.log(err.error);
            }
        );
    }
    getContractedUser(id: number){
        console.log('contracted User id:');
        console.log(id);
        this.userService.getUserById(id).subscribe(
            user_json => {
                this.contractedUser = user_json;
            },
            err => {
                console.log(err.error);
            }
        );
    }

    goToClauses(contractId: number){
        this.router.navigate(['clauses', this.contract.contractId.toString()]);        
    }




}