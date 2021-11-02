export class Input {
  constructor(
    public inputId: number,
    public code: string,
    public description: string,
    public unit: string,
    public type: string,
    public price: number,
    public amount: number,
    public sourceId: number,
    public sourceItemId: number
  ) {

  }
}
