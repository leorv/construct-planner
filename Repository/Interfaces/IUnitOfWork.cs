using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Interfaces.Bidding;
using Repository.Interfaces.Bidding.PriceReference;
using Repository.Interfaces.Common;

namespace Repository.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        // Bidding
        IAdditiveAgreementRepository AdditiveAgreementRepository { get; }
        IAdditiveParticipantRepository AdditiveParticipantRepository { get; }
        IAdditiveRepository AdditiveRepository { get; }
        IClauseAgreementRepository ClauseAgreementRepository { get; }
        IClauseRepository ClauseRepository { get; }
        IContractAgreementRepository ContractAgreementRepository { get; }
        IContractParticipantRepository ContractParticipantRepository { get; }
        IContractRepository ContractRepository { get; }
        ILevelRepository LevelRepository { get; }
        ISpreadsheetItemRepository SpreadsheetItemRepository { get; }
        ISpreadsheetRepository SpreadsheetRepository { get; }
        // PriceReference
        IBDIRepository BDIRepository { get; }
        IInputRepository InputRepository { get; }
        ISourceItemRepository SourceItemRepository { get; }
        ISourceRepository SourceRepository { get; }
        // Common
        IAddressRepository AddressRepository { get; }




        // Macoratti ensina com o int Commit();
        // Método para salvar as informações.
        Task<bool> SaveAsync();
    }
}
