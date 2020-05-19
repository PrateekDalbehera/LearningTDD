using Services.Interfaces.OrderHandling.MembershipMgmt;

namespace Services.Implementations.OrderHandling
{
    public class MembershipOrderType : IMembershipOrderType
    {
        public int OrderID { get; set; }
        public int MemberID { get; set; }
        public string Email { get; set; }
        public string Subscription { get; set; }
    }
}
