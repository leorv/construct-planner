using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Bidding
{
    public class Level
    {
        public long LevelId { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public double Total { get; set; }

        public long SpreadsheetId { get; set; }
        public virtual Spreadsheet Spreadsheet { get; set; }
        public virtual ICollection<SpreadsheetItem> SpreadsheetItems { get; set; }

    }
}
