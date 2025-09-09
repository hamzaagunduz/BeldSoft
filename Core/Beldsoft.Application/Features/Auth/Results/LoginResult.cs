namespace Beldsoft.Application.Features.Auth.Results
{
    public class LoginResult
    {
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
        public int? UserId { get; set; }
        public string UserName { get; set; }
        public string Role { get; set; }

    }
}
