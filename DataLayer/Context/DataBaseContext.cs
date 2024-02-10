using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Context
{
    public class DataBaseContext:DbContext
    {
        public DataBaseContext()
            : base("name=DataBaseContext")
        {
        }


        public DbSet<User> Users { get; set; }




    }
}
