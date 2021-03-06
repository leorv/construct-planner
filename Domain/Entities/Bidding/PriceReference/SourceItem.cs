using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Bidding.PriceReference
{
    public class SourceItem
    {
        public long SourceItemId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string Unit { get; set; }
        public decimal ManPower { get; set; }
        public decimal Material { get; set; }
        public decimal TotalUnitValue {  get; set; }
        // Relações
        public long SourceId { get; set; }
        public virtual Source Source { get; set; }
        public virtual ICollection<Input> Inputs { get; set; }
    }
}
