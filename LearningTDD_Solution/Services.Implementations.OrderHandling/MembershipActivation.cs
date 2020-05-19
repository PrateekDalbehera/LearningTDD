using Services.Interfaces.OrderHandling.MembershipMgmt;

namespace Services.Implementations.OrderHandling
{
    public class MembershipActivation : MembershipMgmt
    {
        private readonly IMembershipOrderType _member;

        public MembershipActivation(IMembershipOrderType member) : base(member)
        {
            _member = member;
        }
    }
}
