using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ProductDAL
    {
        #region DirectMappings
        public int ProductID { get; set; }
        public int CategoryID { get; set; }
        public int SellerID { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set;}
        public decimal ReservePrice { get; set; }

        public int WinningOfferID { get; set; }

        public string Comments { get; set; }
        #endregion

        #region indirect Mappings
        public string SellerName { get; set; }
        public string SellerEMailAddress { get; set; }
        public string CategoryName { get; set; }
        #endregion
    }
}
