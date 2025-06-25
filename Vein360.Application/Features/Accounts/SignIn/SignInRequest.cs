namespace Vein360.Application.Features.Accounts.SignIn
{
    public record SignInRequest(string username, string password, RoleType role) : IRequest<AuthenticationResponseDto>
    {
    }
}
