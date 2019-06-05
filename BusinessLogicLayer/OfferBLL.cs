using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
 public   class OfferBLL
    {
        public OfferBLL()
        {

        }
        public OfferBLL(OfferDAL dal)
        {
            this.OfferID = dal.OfferID;
            this.BuyerEmailAddress = this.BuyerEmailAddress;
            this.BuyerID = this.BuyerID;
            this.BuyerName = this.BuyerName;
            this.Comments = this.Comments;
            this.ExpireDate = this.ExpireDate;
            this.OfferPrice = dal.OfferPrice;
            this.OfferState = dal.OfferState;
            this.ProductID = dal.ProductID;
            this.ProductName = dal.ProductName;
            
        }

        #region direct mappings
        public int OfferID { get; set; }
        public int ProductID { get; set; }
        public int BuyerID { get; set; }
        public decimal OfferPrice { get; set; }
        public int OfferState { get; set; }
        public DateTime ExpireDate { get; set; }
        public string Comments { get; set; }

        #endregion direct mappings

        #region indirect mapping
        public string ProductName { get; set; }
        public string BuyerName { get; set; }
        public string BuyerEmailAddress { get; set; }

        #endregion indirect mappings

    }
}
