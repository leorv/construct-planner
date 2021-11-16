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

  constructor(
      private contractService: ContractService
  ) { }

  ngOnInit(): void {
  }

  createContract(){
      this.contractService.createContract(this.contract).subscribe(
          contract => {
              this.contract = new Contract();
          },
          err => {
              console.log('Ocorreu um erro ao cadastrar o contrato.', err);
          }
      )
  }
}
