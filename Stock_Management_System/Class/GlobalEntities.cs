using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock_Management_System.Class
{
    public partial class GlobalEntities : DbContext
    {
       public GlobalEntities(string conStr) : base(conStr)
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
