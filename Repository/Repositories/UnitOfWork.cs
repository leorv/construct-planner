using Domain.Interfaces;
using Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ConstructContext context;

        private IAdditiveRepository additiveRepository = null;
        private IBDIRepository bdiRepository = null;
        private IClauseRepository clauseRepository = null;
        private IContractRepository contractRepository = null;
        private IInputRepository inputRepository = null;
        private ILevelRepository levelRepository = null;
        private ISourceItemRepository sourceItemRepository = null;
        private ISourceRepository sourceRepository = null;
        private ISpreadsheetItemRepository spreadsheetItemRepository = null;
        private ISpreadsheetRepository spreadsheetRepository = null;


        public IAdditiveRepository AdditiveRepository 
        { 
            get 
            { 
                if (additiveRepository == null)
                {
                    additiveRepository = new AdditiveRepository(context);
                }
                return additiveRepository;
            }
        }
        public IBDIRepository BDIRepository
        {
            get
            {
                if (bdiRepository == null)
                {
                    bdiRepository = new BDIRepository(context);
                }
                return bdiRepository;
            }
        }
        public IClauseRepository ClauseRepository
        {
            get
            {
                if (clauseRepository == null)
                {
                    clauseRepository = new ClauseRepository(context);
                }
                return clauseRepository;
            }
        }
        public IContractRepository ContractRepository
        {
            get
            {
                if (contractRepository == null)
                {
                    contractRepository = new ContractRepository(context);
                }
                return contractRepository;
            }
        }
        public IInputRepository InputRepository
        {
            get
            {
                if(inputRepository == null)
                {
                    inputRepository = new InputRepository(context);
                }
                return inputRepository;
            }
        }
        public ILevelRepository LevelRepository
        {
            get
            {
                if (levelRepository == null)
                {
                    levelRepository = new LevelRepository(context);
                }
                return levelRepository;
            }
        }
        public ISourceItemRepository SourceItemRepository
        {
            get
            {
                if (sourceItemRepository == null)
                {
                    sourceItemRepository = new SourceItemRepository(context);
                }

            }
        }
        public ISourceRepository SourceRepository
        {
            get
            {
                if (sourceRepository == null)
                {
                    sourceRepository = new SourceRepository(context);
                }
                return sourceRepository;
            }
        }
        public ISpreadsheetItemRepository SpreadsheetItemRepository
        {
            get
            {
                if (spreadsheetItemRepository == null)
                {
                    spreadsheetItemRepository = new SpreadsheetItemRepository(context);
                }
                return spreadsheetItemRepository;
            }
        }
        public ISpreadsheetRepository SpreadsheetRepository
        {
            get
            {
                if (spreadsheetRepository == null)
                {
                    spreadsheetRepository = new SpreadsheetRepository(context);
                }
                return spreadsheetRepository;
            }
        }

        public UnitOfWork(ConstructContext context)
        {
            this.context = context;

            // Acho que o que tem aqui abaixo não está legal, mas bora assim...
            //AdditiveRepository = new AdditiveRepository(context);
            //BDIRepository = new BDIRepository(context);
            //ClauseRepository = new ClauseRepository(context);
            //ContractRepository = new ContractRepository(context);
            //InputRepository = new InputRepository(context);
            //LevelRepository = new LevelRepository(context);
            //SourceItemRepository = new SourceItemRepository(context);
            //SourceRepository = new SourceRepository(context);
            //SpreadsheetItemRepository = new SpreadsheetItemRepository(context);
            //SpreadsheetRepository = new SpreadsheetRepository(context);
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public async Task<bool> SaveAsync()
        {
            return await context.SaveChangesAsync() > 0;
        }
    }
}
