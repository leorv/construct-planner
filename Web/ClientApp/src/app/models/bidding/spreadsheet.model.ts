export class SpreadSheet {
  constructor(
    public spreadsheetId: number,
    public name: string,
    public title: string,
    public description: string,
    public author: string,
    public date: Date,
    public encumberType: string,
    public contractId: number,
    public additiveId: number,
  ) {

  }
}
