import { Injectable } from "@angular/core";
import { Additive } from "./bidding/additive.model";
import { Contract } from "./bidding/contract.model";
import { ContractAgreement } from "./bidding/contractagreement.model";

export class User {
    public userId: number =0;
    public name: string = '';
    public lastname: string = '';
    public email: string = '';
    public password: string = '';
    public photo: string = '';
    public contracts: Contract[] = [];
    public contractsagreements: ContractAgreement[] = [];
    public additives: Additive[] = [];
  constructor(
    // public userId: number,
    // public name: string,
    // public lastname: string,
    // public email: string,
    // public password: string,
    // public photo: string,
    // public contracts: Contract[] = [] ,
    // public contractsagreements: ContractAgreement[] = [],
    // public additives: Additive[] = [],
  ) {
  }  
}