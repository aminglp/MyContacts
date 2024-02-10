using DataLayer.Context;
using DataLayer.Entities;
using MyContacts.Core.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyContacts.Core.Repository.Services
{
    public class UserService : IUser
    {
        private DataBaseContext _context;
        public UserService()
        {
            _context=new DataBaseContext();
        }


        public void AddUSer(User user)
        {
            try
            {
                _context.Users.Add(user);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                MessageBox.Show("error"+e.Message);
            }
            finally 
            {
                Dispose();
            }

        }

        public void Delete(int userId)
        {
            try
            {
                 User user = GetUserByUserId(userId);
                _context.Entry(user).State = EntityState.Deleted;
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                MessageBox.Show("error" + e.Message);
            }


        }

        public IEnumerable<User> GetAllUser()
        {
            using(DataBaseContext _context = new DataBaseContext())
            {
                return _context.Users.ToList();
            }
            

        }

        public User GetUserByUserId(int userid)
        {
          return  _context.Users.SingleOrDefault(p => p.UserId == userid);
        }

        public void UpdateUser( User user)
        {
            #region firsttry
            //User _user = GetUserByUserId(userId);
            //_user.Name = user.Name;
            //_user.Family = user.Family;
            //_user.Address = user.Address;
            //_user.Age = user.Age;
            //_user.Mobile = user.Mobile;
            #endregion
            _context.Entry(user).State = EntityState.Modified;
            _context.SaveChanges();

        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
