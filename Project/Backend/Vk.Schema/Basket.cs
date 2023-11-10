namespace Vk.Schema;

public class BasketRequest
{
    public int UserId { get; set; }
    public int ProductId { get; set; }
    public int BasketQuantity { get; set; }
    public double BasketPrice { get; set; }
    public bool BasketStatus { get; set; }
}

public class BasketUpdatedRequest
{
    public int UserId { get; set; }
    public int ProductId { get; set; }
    public int OrderId { get; set; }
    public int BasketQuantity { get; set; }
    public double BasketPrice { get; set; }
    public bool BasketStatus { get; set; }
}



public class BasketResponse
{
    public int Id { get; set; }

    public int UserId { get; set; }
    public int ProductId { get; set; }
    public int OrderId { get; set; }
    public int BasketQuantity { get; set; }
    public double BasketPrice { get; set; }
    public bool BasketStatus { get; set; }
}