namespace Blog.Gateways.Web.Contracts
{
    public interface ILoginModelContract
    {
        string Username { get; }

        string Password { get; }

        string ReturnUrl { get; set;}
    }
}
