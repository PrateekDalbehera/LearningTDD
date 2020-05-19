namespace Services.Interfaces.OrderHandling.MembershipMgmt
{
    public interface IMembershipOrderType : IOrderType
    {
        int MemberID { get; set; }
        string Email { get; set; }
        string Subscription { get; set; }
    }
}
