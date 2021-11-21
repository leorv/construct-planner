using Repository.Interfaces.Bidding;
using Repository.Context;
using System;
using System.Threading.Tasks;
using Repository.Repositories.Bidding;
using Repository.Repositories.Bidding.PriceReference;
using Repository.Interfaces.Common;
using Repository.Repositories.Common;
using Repository.Interfaces.Bidding.PriceReference;
using Repository.Interfaces;

namespace Repository.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ConstructContext context;

        // Bidding
        private IAdditiveAgreementRepository additiveAgreementRepository = null;
        public IAdditiveAgreementRepository AdditiveAgreementRepository
        {
            get
            {
                if (additiveAgreementRepository == null)
                {
                    additiveAgreementRepository = new AdditiveAgreementsRepository(context);
                }
                return additiveAgreementRepository;
            }
        }
        //private IAdditiveParticipantRepository additiveParticipantRepository = null;
        //public IAdditiveParticipantRepository AdditiveParticipantRepository
        //{
        //    get
        //    {
        //        if (additiveParticipantRepository == null)
        //        {
        //            additiveParticipantRepository = new AdditiveParticipantRepository(context);
        //        }
        //       return additiveParticipantRepository;
        //    }
        //}
        private IAdditiveClauseRepository additiveClauseRepository = null;
        public IAdditiveClauseRepository AdditiveClauseRepository
        {
            get
            {
                if (additiveClauseRepository == null)
                {
                    additiveClauseRepository = new AdditiveClauseRepository(context);
                }
                return additiveClauseRepository;
            }
        }
        private IAdditiveLevelRepository additiveLevelRepository = null;
        public IAdditiveLevelRepository AdditiveLevelRepository
        {
            get
            {
                if (additiveLevelRepository == null)
                {
                    additiveLevelRepository = new AdditiveLevelRepository(context);
                }
                return additiveLevelRepository;
            }
        }
        private IAdditiveRepository additiveRepository = null;
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
        private IAdditiveSpreadsheetItemRepository additiveSpreadsheetItemRepository = null;
        public IAdditiveSpreadsheetItemRepository AdditiveSpreadsheetItemRepository
        {
            get
            {
                if (additiveSpreadsheetItemRepository == null)
                {
                    additiveSpreadsheetItemRepository = new AdditiveSpreadsheetItemRepository(context);
                }
                return additiveSpreadsheetItemRepository;
            }
        }
        private IAdditiveSpreadsheetRepository additiveSpreadsheetRepository = null;
        public IAdditiveSpreadsheetRepository AdditiveSpreadsheetRepository
        {
            get
            {
                if (additiveSpreadsheetRepository == null)
                {
                    additiveSpreadsheetRepository = new AdditiveSpreadsheetRepository(context);
                }
                return additiveSpreadsheetRepository;
            }
        }


        //private IClauseAgreementRepository clauseAgreementRepository = null;
        //public IClauseAgreementRepository ClauseAgreementRepository
        //{
        //    get
        //    {
        //        if (clauseAgreementRepository == null)
        //        {
        //            clauseAgreementRepository = new ClauseAgreementRepository(context);
        //        }
        //        return clauseAgreementRepository;
        //    }
        //}
        private IClauseRepository clauseRepository = null;
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
        private IContractAgreementRepository contractAgreementRepository = null;
        public IContractAgreementRepository ContractAgreementRepository
        {
            get
            {
                if (contractAgreementRepository == null)
                {
                    contractAgreementRepository = new ContractAgreementRepository(context);
                }
                return contractAgreementRepository;
            }
        }
        private IContractUserRepository contractUserRepository = null;
        public IContractUserRepository ContractUserRepository
        {
            get
            {
                if (contractUserRepository == null)
                {
                    contractUserRepository = new ContractUserRepository(context);
                }
                return contractUserRepository;
            }
        }
        private IContractRepository contractRepository = null;
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
        private ILevelRepository levelRepository = null;
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
        private ISpreadsheetItemRepository spreadsheetItemRepository = null;
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
        private ISpreadsheetRepository spreadsheetRepository = null;
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
        // PriceReference
        private IBDIRepository bdiRepository = null;
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
        private IInputRepository inputRepository = null;
        public IInputRepository InputRepository
        {
            get
            {
                if (inputRepository == null)
                {
                    inputRepository = new InputRepository(context);
                }
                return inputRepository;
            }
        }
        private ISourceItemRepository sourceItemRepository = null;
        public ISourceItemRepository SourceItemRepository
        {
            get
            {
                if (sourceItemRepository == null)
                {
                    sourceItemRepository = new SourceItemRepository(context);
                }
                return sourceItemRepository;

            }
        }
        private ISourceRepository sourceRepository = null;
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
        //Common
        private IAddressRepository addressRepository = null;
        public IAddressRepository AddressRepository
        {
            get
            {
                if (addressRepository == null)
                {
                    addressRepository = new AddressRepository(context);
                }
                return addressRepository;
            }
        }
        // USer
        private IUserRepository userRepository = null;
        public IUserRepository UserRepository
        {
            get
            {
                if (userRepository == null)
                {
                    userRepository = new UserRepository(context);
                }
                return userRepository;
            }
        }


        // ============= MÉTODOS =============
        public UnitOfWork(ConstructContext context)
        {
            this.context = context;
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await context.SaveChangesAsync() > 0;
        }
        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }
    }
}
