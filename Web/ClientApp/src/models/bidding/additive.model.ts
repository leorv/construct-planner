import { AdditiveAgreement } from "./additiveagreement.model";
import { Clause } from "./clause.model";

export class Additive {
  constructor(
    public additiveId: number,
    public name: string,
    public number: number,
    public year: number,
    public description: string,
    public justification: string,
    public totalValue: number,
    public date: Date,
    public closed: boolean,
    public userId: number,
    public contractId: number,
    public clauses: Clause[] = [],
    public agreements: AdditiveAgreement[] = [],
  ) {

  }
}
