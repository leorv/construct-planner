import { Router } from '@angular/router';
import { UserService } from './../../../../services/user/user.service';
import { User } from './../../../../models/user.model';
import { ContractService } from './../../../../services/biddings/contract.service';
import { Component, OnInit } from '@angular/core';
import { Contract } from 'src/app/models/bidding/contract.model';

@Component({
    selector: 'app-contract-create',
    templateUrl: './contract-create.component.html',
    styleUrls: ['./contract-create.component.css']
})
export class ContractCreateComponent implements OnInit {

    contract: Contract = new Contract();
    usersCanContracted: User[] = [];


    constructor(
        private contractService: ContractService,
        private userService: UserService,
        private router: Router
    ) { }

    ngOnInit(): void {
        this.loadCanContractedUsers();
    }

    loadCanContractedUsers() {
        this.userService.getAllUsers().subscribe(
            users => {
                this.usersCanContracted = users;
            },
            err => {
                console.log('Erro ao buscar todos os usuários.', err)
            }
        )

    }

    createContract() {
        // if (localStorage.getItem("AuthenticatedUser").valueOf("userId") != null) {
        //     this.contract.userId = parseInt(localStorage.getItem("AuthenticatedUser").valueOf("userId"));
        // }
        if (this.userService.user != null) {
            this.contract.userId = this.userService.user.userId;
            console.log('inserimos o id para o contract.userId');
        }

        this.contractService.createContract(this.contract).subscribe(
            contract => {
                this.contract = new Contract();
                console.log('Contrato inserido com sucesso.');
                this.router.navigate(['/contracts']);
            },
            err => {
                console.log('Ocorreu um erro ao cadastrar o contrato.', err);
            }   
        )
    }
}
