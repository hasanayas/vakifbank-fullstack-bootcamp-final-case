using Vk.Base;

namespace Vk.Schema;


public class UserRequest 
{
    //public int Id { get; set; }
    public int UserNumber { get; set; }
    public string UserName { get; set; }
    public string UserEmail { get; set; }
    public string UserPassword { get; set; }
    public string UserRole { get; set; }
    public double UserBalance { get; set; }
    public int UserProfitMargin { get; set; }
}

public class UserUpdatedRequest
{
    public int UserNumber { get; set; }
    public string UserName { get; set; }
    public string UserEmail { get; set; }
    public string UserPassword { get; set; }
    public string UserRole { get; set; }
    public double UserBalance { get; set; }
    public int UserProfitMargin { get; set; }
}


public class UserResponse : BaseModel
{
    public int Id { get; set; }
    public int UserNumber { get; set; }
    public string UserName { get; set; }
    public string UserEmail { get; set; }
    public string UserPassword { get; set; }
    public int UserPasswordRetryCount { get; set; }
    public string UserRole { get; set; }
    public double UserBalance { get; set; }
    public int UserProfitMargin { get; set; }

    public virtual List<AddressResponse> Addresses { get; set; }
    public virtual List<OrderResponse> Orders { get; set; }
}
