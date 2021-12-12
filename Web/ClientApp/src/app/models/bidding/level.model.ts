import { SpreadsheetItem } from './spreadsheetitem.model';
export class Level {
    public levelId: number = 0;
    public name: string = '';
    public title: string = '';
    public total: number = 0;
    public spreadsheetId: number = 0;
    public spreadsheetItems: SpreadsheetItem[] = [];

  constructor(
    // public levelId: number,
    // public name: string,
    // public title: string,
    // public spreadsheet: number,
    // public spreadsheetItems: SpreadsheetItem[] = [],
  ) {

  }

}
