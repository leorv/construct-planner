export class Address {
  constructor(
    public addressId: number,
    public postalCode: string,
    public street: string,
    public number: string,
    public complement: string,
    public district: string,
    public city: string,
    public state: string,
    public country: string,
    public spreadsheetId: number,
  ) {

  }
  
}
