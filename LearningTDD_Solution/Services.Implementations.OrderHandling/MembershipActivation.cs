using Services.Interfaces.OrderHandling;
using Services.Interfaces.OrderHandling.MembershipMgmt;
using System;

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
