import { Level } from "./level.model";

export class Spreadsheet {
    public spreadsheetId: number = 0;
    public name: string = '';
    public title: string = '';
    public description: string = '';
    public author: string = '';
    public date: Date = new Date();
    public encumberType: string = '';
    public contractId: number = 0;
    public additiveId: number = 0;
    public levels: Level[] = [];
  constructor(
    // public spreadsheetId: number,
    // public name: string,
    // public title: string,
    // public description: string,
    // public author: string,
    // public date: Date,
    // public encumberType: string,
    // public contractId: number,
    // public additiveId: number,
  ) {

  }
}
