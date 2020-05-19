namespace Services.Interfaces.OrderHandling
{
    public interface IOrder
    {
        IOrderType orderType { get; set; }
        void Handle();
    }
}
