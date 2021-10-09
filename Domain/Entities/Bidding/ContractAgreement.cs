namespace Domain.Entities.Bidding
{
    public class ContractAgreement
    {
        public long UserId { get; set; }
        public User User { get; set; }
        public long ContractId { get; set; }
        public Contract Contract {  get; set; }
    }
}