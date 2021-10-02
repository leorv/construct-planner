using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Bidding
{
    public class SpreadsheetItem
    {
        public long Id { get; set; }
        public string Source { get; set; }
        public string Code { get; set; }
        public string Description {  get; set; }
        public double amount { get; set; }
        public string Unit { get; set; }
        public decimal ManPower { get; set; }
        public decimal Material { get; set; }


        // TODO: Relações da planilha e seus itens
    }
}
