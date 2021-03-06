using Domain.Entities.Bidding;
using Domain.Entities.Bidding.PriceReference;
using Domain.Entities.Common;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Config.Bidding;
using Repository.Config.Bidding.PriceReference;
using Repository.Config.Common;
using Repository.Config;

namespace Repository.Context
{
    public class ConstructContext : DbContext
    {
        // Bidding
        public DbSet<AdditiveAgreement> AdditiveAgreements { get; set; }
        //public DbSet<AdditiveUser> AdditiveParticipants { get; set; }
        public DbSet<AdditiveClause> AdditiveClauses {get; set;}
        public DbSet<Additive> Additives { get; set; }
        //public DbSet<ClauseAgreement> ClauseAgreements { get; set; }
        public DbSet<AdditiveLevel> AdditiveLevels {get; set;}
        public DbSet<AdditiveSpreadsheet> AdditiveSpreadsheets {get; set;}
        public DbSet<AdditiveSpreadsheetItem> AdditiveSpreadsheetItems {get; set;}
        public DbSet<Clause> Clauses { get; set; }
        public DbSet<ContractAgreement> ContractAgreements { get; set; }
        public DbSet<ContractUser> ContractUsers { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Level> Levels { get; set; }
        public DbSet<SpreadsheetItem> SpreadsheetItems { get; set; }
        public DbSet<Spreadsheet> Spreadsheets { get; set; }
        // PriceReference
        public DbSet<BDI> BDIs { get; set; }
        public DbSet<Input> Inputs { get; set; }
        public DbSet<SourceItem> SourceItems { get; set; }
        public DbSet<Source> Sources { get; set; }
        // Common
        public DbSet<Address> Addresses { get; set; }
        // User
        public DbSet<User> Users { get; set; }


        public ConstructContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Bidding
            modelBuilder.ApplyConfiguration(new AdditiveAgreementConfiguration());
            modelBuilder.ApplyConfiguration(new AdditiveClauseConfiguration());
            modelBuilder.ApplyConfiguration(new AdditiveConfiguration());
            modelBuilder.ApplyConfiguration(new AdditiveLevelConfiguration());
            modelBuilder.ApplyConfiguration(new AdditiveSpreadsheetConfiguration());
            modelBuilder.ApplyConfiguration(new AdditiveSpreadsheetItemConfiguration());
            modelBuilder.ApplyConfiguration(new ClauseConfiguration());
            modelBuilder.ApplyConfiguration(new ContractAgreementConfiguration());
            modelBuilder.ApplyConfiguration(new ContractConfiguration());
            modelBuilder.ApplyConfiguration(new ContractUserConfiguration());
            modelBuilder.ApplyConfiguration(new LevelConfiguration());
            modelBuilder.ApplyConfiguration(new SpreadsheetConfiguration());
            modelBuilder.ApplyConfiguration(new SpreadsheetItemConfiguration());
            // PriceReference
            modelBuilder.ApplyConfiguration(new BDIConfiguration());
            modelBuilder.ApplyConfiguration(new InputConfiguration());
            modelBuilder.ApplyConfiguration(new SourceConfiguration());
            modelBuilder.ApplyConfiguration(new SourceItemConfiguration());
            // Common
            modelBuilder.ApplyConfiguration(new AddressConfiguration());
            // User
            modelBuilder.ApplyConfiguration(new UserConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
