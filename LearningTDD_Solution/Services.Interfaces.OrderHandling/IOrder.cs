namespace Services.Interfaces.OrderHandling
{
    public interface IOrder
    {
        IOrderType orderType { get; set; }
        string Handle();
    }
}
