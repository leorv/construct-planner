export class SpreadSheetItem {
  constructor(
    public spreadsheetitemId: number,
    public source: string,
    public code: string,
    public description: string,
    public amount: number,
    public unit: string,
    public manpower: number,
    public material: number,
    public levelId: number
  ) {

  }
}
