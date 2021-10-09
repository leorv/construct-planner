namespace Domain.Entities.Bidding
{
    public class AdditiveParticipant
    {
        public long UserId { get; set; }
        public virtual User User { get; set; }
        public long AdditiveId { get; set; }
        public virtual Additive Additive { get; set; }
    }
}