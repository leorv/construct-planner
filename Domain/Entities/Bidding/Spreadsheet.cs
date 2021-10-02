using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Bidding
{
    public class Spreadsheet
    {
        public long Id { get; set; }
        public string Name {  get; set; }
        public string Title {  get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public DateTime Date { get; set; }

    }
}
