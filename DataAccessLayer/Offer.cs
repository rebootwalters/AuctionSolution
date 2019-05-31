﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class OfferDAL
    {

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
