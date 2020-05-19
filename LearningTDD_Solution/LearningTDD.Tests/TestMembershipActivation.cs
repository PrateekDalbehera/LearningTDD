using Services.Implementations.OrderHandling;
using Services.Interfaces.OrderHandling;
using Services.Interfaces.OrderHandling.MembershipMgmt;
using Xunit;

namespace LearningTDD.Tests
{
    public class TestMembershipActivation
    {
        [Fact]
        public void PassingTest()
        {
            // Arrange
            string expected = "ActivateMemberShip, NotifyMember", actual;
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
            string expected = "UpgradeAccount, NotifyMember", actual;
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
