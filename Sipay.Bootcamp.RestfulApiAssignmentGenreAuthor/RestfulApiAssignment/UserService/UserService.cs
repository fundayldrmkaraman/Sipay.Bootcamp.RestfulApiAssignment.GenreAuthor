using Assignment1;

namespace RestfulApiAssignment.Users
{
    public class UserService : IUserService
    {
        public bool Authenticate(string username, string password)
        {
            return username == Startup.FakeUsername && password == Startup.FakePassword;
        }

        public bool ValidateToken(string token)
        {
            throw new NotImplementedException();
        }
    }
}
