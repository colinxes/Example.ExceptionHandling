using Example.ExceptionHandling.Database;
using Example.ExceptionHandling.Models;

namespace Example.ExceptionHandling.Repositories
{
    public class UserRepository
    {
        public User? GetByUsername(string pUsername)
        {
            return UserTable.Instance.Data.SingleOrDefault(pUser => pUser.Username == pUsername);
        }
        
        public bool ExistsWithId(Guid pId)
        {
            return UserTable.Instance.Data.Any(pUser => pUser.Id == pId);
        }
        
        public bool ExistsWithUsername(string pUsername)
        {
            return UserTable.Instance.Data.Any(pUser => pUser.Username == pUsername);
        }
        
        public void CreateUser(User pUser)
        {
            // Simulate some db action that might get an timeout.
            Random random = Random.Shared;
            long randomNumber =  random.NextInt64(0, 2);

            if (randomNumber == 0)
                throw new TimeoutException("The database could not be reached out.");

            UserTable.Instance.Data.Add(pUser);
        }
    }
}