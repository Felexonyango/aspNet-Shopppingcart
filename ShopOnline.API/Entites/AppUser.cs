namespace ShopOnline.API.Entites;

public class AppUser: IdentityUser
{
    public ICollection<UserAddress> Address { get; set; }
}
