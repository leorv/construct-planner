using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Bidding
{
    public class Additive
    {
        public long AdditiveId {  get; set; }
        public string Name {  get; set; }
        public int Number { get; set; }
        public int Year { get; set; }
        public string Description {  get; set; } // Que fica em cima, apresentando o doc.
        public string Justification { get; set; }
        public decimal TotalValue { get; set; }
        public DateTime Date { get; set; }
        public bool Closed { get; set; }

        public long UserId { get; set; }
        public virtual User User { get; set; }
        public long ContractId { get; set; }
        public virtual Contract Contract { get; set; }
        public virtual ICollection<Clause> Clauses {  get; set; }
        public long SpreadsheetId { get; set; }
        public virtual Spreadsheet Spreadsheet {  get; set; }
        //public virtual ICollection<AdditiveUser> AdditiveUsers { get; set; }
        public virtual ICollection<AdditiveAgreement> AdditiveAgreements { get; set; }

    }

    /* Como será o funcionamento:
     * 
     * Há o contrato inicial, após isso é feito um aditivo com adições e supressões.
     * 
     * Assim, todo item referente supressão é descontado do contrato.
     * Novas quantidades são adicionadas aos itens existentes no contrato.
     * E novos itens também são adicionados no contrato.
     * Isso gera um novo contrato, R01, considerando o aditivo feito.
     * 
     * Um método deverá calcular a porcentagem que a parcela de soma do aditivo representa.
     * Outro método irá calcular a porcentagem que todo o aditivo representa sobre o contrato,
     * isto é, somar as adições e supressões, depois dividir este valor pelo valor do contrato inicial.
     * 
     * No preenchimento do aditivo, é mostrado todos os itens do contrato, podendo
     * o usuário adicionar ou suprimir os itens, criar novos itens, etc.
     * 
     */
}
