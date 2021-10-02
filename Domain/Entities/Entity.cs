using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public abstract class Entity
    {
        private List<string> messageValidation;

        protected List<string> MessageValidation { get {
                return messageValidation ??= new List<string>(); // Usei atribuição composta.
            }  }
        protected bool IsValid
        {
            get { return !MessageValidation.Any(); }
            /* Leia-se:
             * Caso não houver nenhuma mensagem de validação,
             * é considerado válido. True.
             * De outra forma, se houver alguma mensagem de validação,
             * indica False.
            */
        }

        public abstract void Validate();
        protected void ClearValidateMessages()
        {
            MessageValidation.Clear();
        }
        protected void AddValidationMessage(string msg)
        {
            MessageValidation.Add(msg);
        }
    }
}
