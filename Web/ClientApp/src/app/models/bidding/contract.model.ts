import { User } from "../user.model";

export class Contract {
    public contractId: number = 0;
    public name: string = '';
    public object: string = '';
    public number: number = 0;
    public year: number = 0;
    public description: string = '';
    public totalValue: number = 0;
    public date: Date = new Date();
    public closed: boolean = false;
    public contractedUserId: number = 0;
    public userId: number = 0;
    public users: User[] = [];

  constructor(
    // public contractId: number,
    // public name: string,
    // public object: string,
    // public number: number,
    // public year: number,
    // public description: string,
    // public totalValue: number,
    // public date: Date,
    // public closed: boolean,
    // public contractedUserId: number,
    // public userId: number,
    // public users: User[] = [],
  )
  {

  }

}
