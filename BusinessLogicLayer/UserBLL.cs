using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
 public   class UserBLL
    {
        public UserBLL()
        {

        }
        public UserBLL(UserDAL dal)
        {
            this.Hash = dal.Hash;
            this.EMailAddress = dal.EMailAddress;
            this.Name = dal.Name;
            this.Password = dal.Password;
            this.RoleID = dal.RoleID;
            this.RoleName = dal.RoleName;
            this.UserID = dal.RoleID;
        }

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
