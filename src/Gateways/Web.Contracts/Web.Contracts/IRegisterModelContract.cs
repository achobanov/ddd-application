namespace Blog.Gateways.Web.Contracts
{
    public interface IRegisterModelContract : ILoginModelContract
    {
        string ConfirmPassword { get; }
    }
}
