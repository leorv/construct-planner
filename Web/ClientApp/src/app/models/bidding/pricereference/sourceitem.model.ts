export class SourceItem {
  constructor(
    public sourceItemId: number,
    public code: string,
    public description: string,
    public unit: string,
    public manpower: number,
    public material: number,
    public totalUnitValue: number,
    public sourceId: number
  ) {

  }
}
