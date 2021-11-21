using Domain.Entities.Bidding.PriceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Bidding
{
    public class AdditiveSpreadsheetItem
    {
        public long AdditiveSpreadsheetItemId { get; set; }
        public string Source { get; set; }
        public string Code { get; set; }
        public string Description {  get; set; }
        public double Amount { get; set; }
        public string Unit { get; set; }
        public decimal ManPower { get; set; }
        public decimal Material { get; set; }
        // Relações
        public long AdditiveLevelId { get; set; }
        public virtual AdditiveLevel AdditiveLevel { get; set; }
        
    }
}
