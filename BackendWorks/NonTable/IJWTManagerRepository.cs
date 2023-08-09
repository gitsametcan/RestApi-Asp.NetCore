using BackendWorks.Models;

namespace BackendWorks.NonTable
{
    public interface IJWTManagerRepository
    {
        Tokens Authenticate(Users users, UserContext _userContext);
    }
}
