using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Bidding.PriceReference
{
    public class Source
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public string SourceFamily { get; set; }
        public string EncumberType { get; set; }
        // Relações
        public ICollection<Input> Inputs { get; set; }
        public ICollection<SourceItem> SourceItems { get; set; }


    }
}
