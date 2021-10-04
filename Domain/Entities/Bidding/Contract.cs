using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Bidding
{
    public class Contract : Entity
    {
        public long Id { get; set; }
        public string Name {  get; set; } // Para controle do usuário.
        public string Object { get; set; }
        public int Number { get; set; }
        public int Year { get; set; }
        public string Description {  get; set; } // A ser exibido na parte de cima do contrato. Aquele resumo.
        public decimal TotalValue { get; set; }
        public DateTime Date { get; set; }
        public string Comments { get; set; }

        public virtual ICollection<Clause> Clauses { get; set; }
        public virtual ICollection<Additive> Additives { get; set; }
        public virtual ICollection<Spreadsheet> Spreadsheets { get; set; }

        public override void Validate()
        {
            ClearValidateMessages();
            
            if (!Clauses.Any())
            {
                MessageValidation.Add("Aviso: Não há cláusulas no contrato.");
            }
            if (Number <= 0)
            {
                MessageValidation.Add("Verifique a numeração do contrato.");
            }


            //throw new NotImplementedException();
        }
    }
}
