namespace Vk.Schema;

public class AddressRequest
{
    public int UserId { get; set; }
    public string AddressLine1 { get; set; }
    public string AddressLine2 { get; set; }
    public string City { get; set; }
    public string County { get; set; }
    public int PostalCode { get; set; }
}

public class AddressUpdatedRequest
{
    public int UserId { get; set; }
    public string AddressLine1 { get; set; }
    public string AddressLine2 { get; set; }
    public string City { get; set; }
    public string County { get; set; }
    public int PostalCode { get; set; }
}



public class AddressResponse
{
    public int UserId { get; set; }
    public string AddressLine1 { get; set; }
    public string AddressLine2 { get; set; }
    public string City { get; set; }
    public string County { get; set; }
    public int PostalCode { get; set; }
}