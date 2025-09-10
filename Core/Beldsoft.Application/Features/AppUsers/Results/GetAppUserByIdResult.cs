namespace Beldsoft.Application.Features.AppUsers.Results
{
    public class GetAppUserByIdResult
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? PhoneNumber { get; set; }

    }
}
