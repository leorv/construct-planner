import { User } from "../user.model";

export class Contract {

  constructor(
    public contractId: Number,
    public name: string,
    public object: string,
    public number: number,
    public year: number,
    public description: string,
    public totalvalue: number,
    public date: Date,
    public closed: boolean,
    public userid: number,
    public users: User[] = [],
  )
  {

  }

}
