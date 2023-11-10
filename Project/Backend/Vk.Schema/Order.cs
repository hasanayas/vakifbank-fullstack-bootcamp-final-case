namespace Vk.Schema;

public class OrderRequest
{
    public int UserId { get; set; }
    public string OrderStatus { get; set; }
    public string OrderPaymentMethod { get; set; }
    public double OrderAmount { get; set; }

}

public class OrderUpdatedRequest
{
    public int UserId { get; set; }
    public string OrderStatus { get; set; }
    public string OrderPaymentMethod { get; set; }
    public double OrderAmount { get; set; }

}

public class OrderResponse
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string OrderStatus { get; set; }
    public string OrderPaymentMethod { get; set; }
    public double OrderAmount { get; set; }

    public DateTime InsertDate { get; set; }
}
