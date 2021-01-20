using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace todo
{
   public class MyDbContex: DbContext 
    {

        public MyDbContex() : base("DbConnectionString")
        {

        }
        public DbSet<Case> Cases { get; set; }
    }
}
