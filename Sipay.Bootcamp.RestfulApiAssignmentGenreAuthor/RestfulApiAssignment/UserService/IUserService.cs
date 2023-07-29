namespace RestfulApiAssignment.Users
{
    public interface IUserService
    {
        bool Authenticate(string username, string password);
        bool ValidateToken(string token);
    }
}
