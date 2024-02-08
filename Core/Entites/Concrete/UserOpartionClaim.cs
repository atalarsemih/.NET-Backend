namespace Core.Entites.Concrete
{
    public class UserOpartionClaim : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }
    }

}
