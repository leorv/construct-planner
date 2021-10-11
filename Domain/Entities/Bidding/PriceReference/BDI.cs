using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Bidding.PriceReference
{
    public class BDI
    {
        public long BDIId { get; set; }
        public int Number { get; set; }
        public string Name {  get; set; }
        // Administração Central:
        public double PersonnelAdministration { get; set; }
        public double GeneralExpenses { get; set; }
        // Riscos e imprevistos.
        public double Risks { get; set; }
        // Seguro
        public double Insurance { get; set; }
        // Garantias (ônus exigido no edital)
        public double Warranty { get; set; }
        public double FinantialExpenses { get; set; }
        public double Profit { get; set; }
        // Tributos, talvez no futuro, implementar classe, interface ou serviço
        // para mexer melhor com isso. Por enquanto será apenas estas variáveis.
        public double PIS { get; set; }
        public double Cofins { get; set; }
        public double CPRB { get; set; } // Contribuição Previdenciária sobre Receita Bruta
        public double ISS { get; set; } // Ou ISSQN.
        public double BDIValue { get; set; }

        public long ContractId { get; set; }
        public virtual Contract Contract { get; set; }

    }
}
