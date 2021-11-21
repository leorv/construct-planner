import { DataTransferService } from './../../../services/data-transfer.service';
import { ContractService } from './../../../services/biddings/contract.service';
import { ClauseService } from './../../../services/biddings/clause.service';
import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Clause } from 'src/app/models/bidding/clause.model';
import { Contract } from 'src/app/models/bidding/contract.model';

@Component({
    selector: 'app-clause',
    templateUrl: './clause.component.html',
    styleUrls: ['./clause.component.css']
})
export class ClauseComponent implements OnInit {

    clauses: Clause[] = [];
    clause: Clause = new Clause();
    contract: Contract = new Contract();
    idToRemove: number = 0;
    spinnerActive: boolean = false;

    constructor(
        private route: ActivatedRoute,
        private dataTransferService: DataTransferService,
        // private contractService: ContractService,
        private clauseService: ClauseService
    ) { }

    ngOnInit(): void {
        this.dataTransferService.objects.subscribe(
            result => {
                console.log(result);
                this.contract = result;
                this.getClauses(this.contract.contractId);
                this.sorterClauses();
            },
            err => {
                console.log("Ocorreu um erro ao relacionar o contrato destas cláusulas.", err);
            }
        )        
    }

    getClauses(id: number) {
        this.clauseService.findClauses(id).subscribe(
            clauses => {
                this.clauses = clauses;
            },
            err => {
                alert("erro ao carregar as cláusulas.");
                console.log("Erro ao buscar as cláusulas.");
            }
        )
    }
    // getContract(id: number) {
    //     this.contractService.getContractById(id).subscribe(
    //         contract => {
    //             this.contract = contract;
    //         },
    //         err => {
    //             alert("Erro ao vincular o contrato com as cláusulas.");
    //             console.log("Erro ao buscar o contrato.");
    //         }
    //     )
    // }
    sorterClauses() {

        this.clauses = this.clauses.sort((n1, n2) => {
            if (n1.number > n2.number) {
                return 1;
            }
            if (n1.number < n2.number) {
                return -1;
            }
            return 0;
        });
    }
    createClause() {
        console.log("inserindo id do contrato na cláusula.");
        this.clause.contractId = this.contract.contractId;
        console.log("chamando o clause service.");
        this.clauseService.createClause(this.clause).subscribe(
            clause => {
                this.clauses.push(clause);
                this.sorterClauses();
            },
            err => {
                console.log("Erro: ", err);
                return alert("ocorreu um erro ao inserir a cláusula.");
            }
        );
    }
    editClause() {

    }
    deleteId(id: number) {
        this.idToRemove = id;
    }

    clauseDelete() {
        this.clauseService.removeClause(this.idToRemove).subscribe(
            result => {
                var _index = this.clauses.findIndex(clause => clause.clauseId == this.idToRemove);
                this.clauses.splice(_index, 1);
                console.log("deletado com sucesso.");
            },
            err => {
                alert("Ocorreu um erro ao deletar.");
                console.log("Ocorreu um erro ao deletar.", err);
            }
        )

    }

}
