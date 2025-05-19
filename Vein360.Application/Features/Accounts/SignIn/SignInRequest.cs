namespace Vein360.Application.Features.Accounts.SignIn
{
    public record SignInRequest(string email, string password, RoleType role) : IRequest<string>
    {
    }
}
