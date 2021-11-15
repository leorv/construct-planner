import { User } from "../user.model";

export class Contract {

  constructor(
    public contractId: number,
    public name: string,
    public object: string,
    public number: number,
    public year: number,
    public description: string,
    public totalValue: number,
    public date: Date,
    public closed: boolean,
    public userId: number,
    public users: User[] = [],
  )
  {

  }

}
