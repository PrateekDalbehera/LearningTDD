﻿using Services.Implementations.OrderHandling;
using Services.Interfaces.OrderHandling;
using Services.Interfaces.OrderHandling.MembershipMgmt;
using Xunit;

namespace LearningTDD.Tests
{
    public class TestMembershipActivation
    {
        private const string PASSINGTESTEXPECTED = "ActivateMemberShip, NotifyMember";
        private const string FAILINGTESTEXPECTED = "UpgradeAccount, NotifyMember";

        [Fact]
        public void PassingTest()
        {
            // Arrange
            string expected = PASSINGTESTEXPECTED, actual;
            IMembershipOrderType orderType = new MembershipOrderType();
            orderType.OrderID = 1;
            orderType.MemberID = 101;
            orderType.Email = "test@example.com";

            IOrder order = new MembershipActivation(orderType);

            // Act
            var orderManagement = new OrderManagementApp(order);
            actual = orderManagement.Handle();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void FailingTest()
        {
            // Arrange
            string expected = FAILINGTESTEXPECTED, actual;
            IMembershipOrderType orderType = new MembershipOrderType();
            orderType.OrderID = 1;
            orderType.MemberID = 101;
            orderType.Email = "test@example.com";

            IOrder order = new MembershipActivation(orderType);

            // Act
            var orderManagement = new OrderManagementApp(order);
            actual = orderManagement.Handle();

            // Assert
            Assert.NotEqual(expected, actual);
        }
    }
}
