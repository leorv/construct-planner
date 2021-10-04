using Domain.Interfaces;
using Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class UnityOfWork : IUnityOfWork
    {
        private readonly ConstructContext context;

        public IAdditiveRepository Additives { get; set; }
        public IBDIRepository BDIs { get; set; }
        public IClauseRepository Clauses { get; set; }
        public IContractRepository Contracts { get; set; }
        public IInputRepository Inputs { get; set; }
        public ILevelRepository Levels { get; set; }
        public ISourceItemRepository SourceItems { get; set; }
        public ISourceRepository Sources { get; set; }
        public ISpreadsheetItemRepository SpreadsheetItems { get; set; }
        public ISpreadsheetRepository Spreadsheets { get; set; }

        public UnityOfWork(ConstructContext context)
        {
            this.context = context;

            // Acho que o que tem aqui abaixo não está legal, mas bora assim...
            Additives = new AdditiveRepository(context);
            BDIs = new BDIRepository(context);
            Clauses = new ClauseRepository(context);
            Contracts = new ContractRepository(context);
            Inputs = new InputRepository(context);
            Levels = new LevelRepository(context);
            SourceItems = new SourceItemRepository(context);
            Sources = new SourceRepository(context);
            SpreadsheetItems = new SpreadsheetItemRepository(context);
            Spreadsheets = new SpreadsheetRepository(context);
        }

        public void Commit()
        {
            return context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
