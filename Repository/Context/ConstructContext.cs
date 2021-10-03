using Domain.Entities.Bidding;
using Domain.Entities.Bidding.PriceReference;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Context
{
    public class ConstructContext : DbContext
    {
        public DbSet<Additive> Additives {  get; set; }
        public DbSet<BDI> BDIs { get; set; }
        public DbSet<Clause> Clauses {  get; set; }
        public DbSet<Contract> Contracts {  get; set; }
        public DbSet<Input> Inputs { get; set; }
        public DbSet<Level> Levels { get; set; }
        public DbSet<SourceItem> SourceItems {  get; set; }
        public DbSet<Source> Sources {  get; set; }
        public DbSet<SpreadsheetItem> SpreadsheetItems {  get; set; }
        public DbSet<Spreadsheet> Spreadsheets {  get; set; }

        public ConstructContext(DbContextOptions options) : base(options)
        {
        }
    }
}
