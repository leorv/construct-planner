using Domain.Entities.Bidding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Common
{
    public class Address
    {
        // TODO: Implementar o Address no contexto, repositório e unit of work.
        public int AddressId {  get; set; }
        public string PostalCode { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Complement { get; set; }
        public string District { get; set; }
        public string City {  get; set; }
        public string State {  get; set; }
        public string Country {  get; set; }
        // Relações
        public long SpreadsheetId { get; set; }
        public virtual Spreadsheet Spreadsheet {  get; set; }
    }
}
