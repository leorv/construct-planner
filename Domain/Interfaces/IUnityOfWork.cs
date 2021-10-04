using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUnityOfWork : IDisposable
    {
        IAdditiveRepository Additives {  get; }
        IBDIRepository BDIs {  get; }
        IClauseRepository Clauses {  get; }
        IContractRepository Contracts {  get; }
        IInputRepository Inputs {  get; }
        ILevelRepository Levels {  get; }
        ISourceItemRepository SourceItems {  get; }
        ISourceRepository Sources {  get; }
        ISpreadsheetItemRepository SpreadsheetItems {  get; }
        ISpreadsheetRepository Spreadsheets {  get; }




        // Macoratti ensina com o int Commit();
        // Método para salvar as informações.
        void Commit();
    }
}
