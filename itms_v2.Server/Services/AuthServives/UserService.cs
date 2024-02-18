using itms_v2.Server.Models;


namespace itms_v2.Server.Services
{
    public class UserService: IUserService
    {
        private readonly DatabaseContext _context;

        public UserService( DatabaseContext context)
        {
            _context = context;

        }
        public User Create(User user)
        { 
            _context.Users.Add(user);
            user.Id = _context.SaveChanges();
            return user;
        }

        public User GetByEmail(string email)
        {
            return _context.Users.FirstOrDefault(u => u.Email == email)!;
        }
        public User GetById(int id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id)!;
        }
        public string GetMyName()
        {
            return "";
        }
    }
}
