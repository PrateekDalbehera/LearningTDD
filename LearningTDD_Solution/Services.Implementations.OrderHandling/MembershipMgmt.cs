using Services.Interfaces.OrderHandling;
using Services.Interfaces.OrderHandling.MembershipMgmt;
using System;

namespace Services.Implementations.OrderHandling
{
    public abstract class MembershipMgmt : IMembershipMgmt
    {
        private readonly IMembershipOrderType _member;

        IOrderType IOrder.orderType { get; set; }

        public MembershipMgmt(IMembershipOrderType member)
        {
            _member = member;
        }

        public virtual string Handle()
        {
            ActivateMemberShip(_member.MemberID);
            NotifyMember(_member.Email);

            return "ActivateMemberShip, NotifyMember";
        }

        protected void ActivateMemberShip(int memberId)
        {
            Console.WriteLine($"MembershipMgmt: ActivateMemberShip. For Member with Id: {memberId}");
        }

        protected void NotifyMember(string emailId)
        {
            Console.WriteLine($"MembershipMgmt: NotifyMember. With Email Id: {emailId}");
        }
    }
}
