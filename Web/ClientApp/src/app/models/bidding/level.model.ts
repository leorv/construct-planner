import { SpreadsheetItem } from './spreadsheetitem.model';
export class Level {
    public levelId: number = 0;
    public name: string = '';
    public title: string = '';
    public spreadsheetId: number = 0;
    public spreadsheetItems: SpreadsheetItem[] = [];

    constructor() {
    }
}
