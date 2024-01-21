namespace ShopOnline.API.Entites;

public class UserAddress
{
    public int Id { get; set; }
    public string AppUserId { get; set; }
    public string AddressLine { get; set; }
    public int CityId { get; set; }
    public int PostalCode { get; set; }

    public City City{ get; set; }
    public AppUser AppUser { get; set; }
}
