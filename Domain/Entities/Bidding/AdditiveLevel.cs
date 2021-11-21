using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Bidding
{
    public class AdditiveLevel
    {
        public long AdditiveLevelId { get; set; }
        public string Name { get; set; }

        public long AdditiveSpreadsheetId { get; set; }
        public virtual AdditiveSpreadsheet AdditiveSpreadsheet { get; set; }
        public virtual ICollection<AdditiveSpreadsheetItem> AdditiveSpreadsheetItems { get; set; }

    }
}
