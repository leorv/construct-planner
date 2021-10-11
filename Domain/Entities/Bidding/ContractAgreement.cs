namespace Domain.Entities.Bidding
{
    public class ContractAgreement
    {
        public long UserId { get; set; }
        public virtual User User { get; set; }
        public long ContractId { get; set; }
        public virtual Contract Contract {  get; set; }
        public bool IsAgree { get; set; }
    }
}