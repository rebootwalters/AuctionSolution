using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class UserDAL
    {
        #region direct Mappings
         public int UserID { get; set; }
        public string EMailAddress { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Hash { get; set; }
        public int RoleID { get; set; }
        #endregion

        #region indirect mappings
        public string RoleName { get; set; }
        #endregion
    }
}
