using Services.Implementations.OrderHandling;
using Services.Interfaces.OrderHandling;
using Services.Interfaces.OrderHandling.MembershipMgmt;
using Xunit;

namespace LearningTDD.Tests
{
    public class TestMembershipUpgradation
    {
        private const string PASSINGTESTEXPECTED = "UpgradeAccount, NotifyMember";
        private const string FAILINGTESTEXPECTED = "ActivateMemberShip, NotifyMember";
        [Fact]
        public void PassingTest()
        {
            // Arrange
            string expected = PASSINGTESTEXPECTED, actual;
            IMembershipOrderType orderType = new MembershipOrderType();
            orderType.OrderID = 1;
            orderType.MemberID = 101;
            orderType.Email = "test@example.com";

            IOrder order = new MembershipUpgradation(orderType);

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

            IOrder order = new MembershipUpgradation(orderType);

            // Act
            var orderManagement = new OrderManagementApp(order);
            actual = orderManagement.Handle();

            // Assert
            Assert.NotEqual(expected, actual);
        }
    }
}
