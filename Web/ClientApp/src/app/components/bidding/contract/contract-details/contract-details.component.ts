import { User } from 'src/app/models/user.model';
import { UserService } from 'src/app/services/user/user.service';
import { ContractService } from './../../../../services/biddings/contract.service';
import { Component, Input, OnInit } from '@angular/core';
import { Contract } from 'src/app/models/bidding/contract.model';
import { ActivatedRoute, Params } from '@angular/router';
import { Observable } from 'rxjs';

@Component({
    selector: 'app-contract-details',
    templateUrl: './contract-details.component.html',
    styleUrls: ['./contract-details.component.css']
})
export class ContractDetailsComponent implements OnInit {

    contract: Contract = new Contract(0, "", "", 0, 0, "", 0, new Date(), false, 0, []);
    ownerUser: User = new User(0, '', '', '', '', '', [], [], []);

    constructor(
        private contractService: ContractService,
        private userService: UserService,
        private route: ActivatedRoute
    ) { }

    ngOnInit(): void {
        // this.contract = this.contractService.getContractById(1);
        console.clear();
        const par = this.route.snapshot.paramMap.get('id');
        console.log(par);
        if (par != null) {
            this.contractService.getContractById(parseInt(par)).subscribe(
                contract_json => {
                    this.contract = contract_json;
                    this.userService.getUserById(this.contract.userId).subscribe(
                        user_json => {
                            this.ownerUser = user_json;
                        },
                        err => {
                            console.log(err.error);
                        }
                    );
                },
                err => {
                    console.log(err.error);
                }
            );
        }
        
    }




}