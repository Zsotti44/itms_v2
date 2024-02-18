using itms_v2.Server.Models;
using System.Text.Json.Serialization;

namespace itms_v2.Server.Services
{
    public interface IUserService
    {
        string GetMyName();
        User Create(User user);
        User GetByEmail(string email);
        User GetById(int id);
         //[JsonIgnore] public string Password { get; set; }

    }
}
