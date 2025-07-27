using Netflix_n_Chill.Data.ValueObject;
using Netflix_n_Chill.Models;
using System.Security.Cryptography;
using System.Text;

namespace Netflix_n_Chill.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context)
        {
            _context = context;
        }
        public Users ValidateCredentials(UsersVO user)
        {
            var pw = ComputeHash(user.Password, SHA256.Create());
            return _context.Users.FirstOrDefault(u => u.Username == user.Username && u.Password == pw);
        }
        //SHA256CryptoServiceProvider is deprecated, create one instead
        private object ComputeHash(string input, SHA256 algorithm)
        {
            Byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            Byte[] hashedBytes = algorithm.ComputeHash(inputBytes);
            return BitConverter.ToString(hashedBytes, 0);
        }
        public Users RefreshUserInfo(Users user)
        {
            //what's the big deal of this overengineering? 
            //if some search in our db is an null
            //it already means it doesn't exist, so we are searching for it twice
            //if (!Exists(user)) return null;

            var result = _context.Users.SingleOrDefault(x => x.Id == user.Id);

            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(user);
                    _context.SaveChanges();
                }
                catch
                {
                    throw;
                }
            }
            return result;
        }
        public bool Exists(Users user)
        {

            if (_context.Users.Any(u => u.Id == user.Id))
            {
                return true;
            }
            return false;
        }

    }
}
