using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class CategoryDAL
    {
        #region Direct Mapping
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        #endregion direct mapping

        public override string ToString()
        {
            return $"CategoryID: {CategoryID,10} Category: {CategoryName}";
        }
    }
}
