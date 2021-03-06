﻿using Services.Interfaces.OrderHandling.MembershipMgmt;
using System;

namespace Services.Implementations.OrderHandling
{
    public class MembershipUpgradation : MembershipMgmt
    {
        private readonly IMembershipOrderType _member;

        public MembershipUpgradation(IMembershipOrderType member) : base(member)
        {
            _member = member;
        }

        public override string Handle()
        {
            UpgradeAccount(_member.MemberID);
            NotifyMember(_member.Email);

            return "UpgradeAccount, NotifyMember";
        }

        private void UpgradeAccount(int memberId)
        {
            Console.WriteLine($"MembershipUpgradation: UpgradeAccount. For Member with Id: {memberId}");
        }
    }
}
