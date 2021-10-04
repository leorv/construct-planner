using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces.Bidding;

namespace Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IAdditiveRepository AdditiveRepository {  get; }
        IBDIRepository BDIRepository {  get; }
        IClauseRepository ClauseRepository {  get; }
        IContractRepository ContractRepository {  get; }
        IInputRepository InputRepository {  get; }
        ILevelRepository LevelRepository {  get; }
        ISourceItemRepository SourceItemRepository {  get; }
        ISourceRepository SourceRepository {  get; }
        ISpreadsheetItemRepository SpreadsheetItemRepository {  get; }
        ISpreadsheetRepository SpreadsheetRepository {  get; }




        // Macoratti ensina com o int Commit();
        // Método para salvar as informações.
        Task<bool> SaveAsync();
    }
}
