import { Contract } from "./bidding/contract.model";

export class User {
  constructor(
    public userId: number,
    public name: string,
    public lastname: string,
    public email: string,
    public photo: string,
    public contracts: Contract[] = [],
    public contractsagreements: ContractAgreement[] = [],
    public additives: Additive[] = [],

  ) {

  }
}