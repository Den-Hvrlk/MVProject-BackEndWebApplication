namespace MVProject.Application.DTOs
{
    public record LoginUserResponse(string AccessToken, string RefreshToken, string Message, string UserName);
}
