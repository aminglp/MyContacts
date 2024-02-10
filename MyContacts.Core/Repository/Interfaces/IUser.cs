using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyContacts.Core.Repository.Interfaces
{
    public interface IUser
    {
        IEnumerable<User> GetAllUser();

        User GetUserByUserId(int userid);

        void AddUSer(User user);

        void Delete(int userId);

        void UpdateUser(User user);

        void Dispose();
    }
}
