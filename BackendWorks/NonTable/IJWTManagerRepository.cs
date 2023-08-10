using BackendWorks.Models;

namespace BackendWorks.NonTable
{
    public interface IJWTManagerRepository
    {
        Tokens Authenticate(User users, UserContext _userContext);
    }
}
