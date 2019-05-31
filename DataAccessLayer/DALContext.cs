using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    class Mapper
    {
        public void assert(bool test, string message)
        {
            if (!test)
            {
                throw new Exception(message);
            }
        }
    }

    class CategoryMapper : Mapper
    {
        int CategoryIdOrdinal;
        int CategoryOrdinal;
       public CategoryMapper(SqlDataReader r)
        {
            CategoryIdOrdinal = r.GetOrdinal("CategoryID");
            assert(0 == CategoryIdOrdinal, "CategoryID is not column 0 as expected");
            CategoryOrdinal = r.GetOrdinal("Category");
            assert(1 == CategoryOrdinal, "Category is not column 1 as expected");
        }
        public CategoryDAL ToCategory(SqlDataReader r)
        {
            CategoryDAL rv = new CategoryDAL();
            rv.CategoryID = r.GetInt32(CategoryIdOrdinal);
            rv.CategoryName = r.GetString(CategoryOrdinal);

            return rv;
        }
    }

    class RoleMapper : Mapper
    {
        int RoleIdOrdinal;
        int RoleOrdinal;
        public RoleMapper(SqlDataReader r)
        {
            RoleIdOrdinal = r.GetOrdinal("RoleID");
            assert(0 == RoleIdOrdinal, "RoleID is not column 0 as expected");
            RoleOrdinal = r.GetOrdinal("Role");
            assert(1 == RoleOrdinal, "Role is not column 1 as expected");
        }
        public RoleDAL ToRole(SqlDataReader r)
        {
           RoleDAL rv = new RoleDAL();
            rv.RoleID = r.GetInt32(RoleIdOrdinal);
            rv.RoleName = r.GetString(RoleOrdinal);

            return rv;
        }
    }

    class UserMapper : Mapper
    {
        int UserIdOrdinal;
        int EmailAddressOrdinal;
        int NameOrdinal;
        int PasswordOrdinal;
        int HashOrdinal;
        int RoleIdOrdinal;

        int RoleNameOrdinal;
        public UserMapper(SqlDataReader r)
        {
            UserIdOrdinal = r.GetOrdinal("UserID");
            assert(0 == UserIdOrdinal, "UserID is not column 0 as expected");
            EmailAddressOrdinal = r.GetOrdinal("EMailAddress");
            assert(1 == EmailAddressOrdinal, "EMailAddress is not column 1 as expected");
            NameOrdinal = r.GetOrdinal("Name");
            assert(2 == NameOrdinal, "UserID is not column 2 as expected");
            PasswordOrdinal = r.GetOrdinal("Password");
            assert(3 == PasswordOrdinal, "Password is not column 3 as expected");
            HashOrdinal = r.GetOrdinal("Hash");
            assert(4 == HashOrdinal, "Hash is not column 4 as expected");
            RoleIdOrdinal = r.GetOrdinal("RoleID");
            assert(5 == RoleIdOrdinal, "RoleID is not column 5 as expected");
            RoleNameOrdinal = r.GetOrdinal("RoleName");
            assert(6 == RoleNameOrdinal, "RoleName is not column 6 as expected");

        }
        public UserDAL ToUser(SqlDataReader r)
        {
            UserDAL rv = new UserDAL();
            rv.UserID = r.GetInt32(UserIdOrdinal);
            rv.EMailAddress = r.GetString(EmailAddressOrdinal);
            rv.Name = r.GetString(NameOrdinal);
            rv.Password = r.GetString(PasswordOrdinal);
            rv.Hash = r.GetString(HashOrdinal);
            rv.RoleID = r.GetInt32(RoleIdOrdinal);
            rv.RoleName = r.GetString(RoleNameOrdinal);

            return rv;
        }
    }

    class ProductMapper : Mapper
    {
        int ProductIdOrdinal;
        int CategoryIdOrdinal;
        int SellerIdOrdinal;
        int ProductNameOrdinal;
        int DescriptionOrdinal;
        int ReservePriceOrdinal;
        int WinningOfferIdOrdinal;
        int CommentsOrdinal;

        int CategoryOrdinal;
        int SellerNameOrdinal;
        int SellerEMailAddressOrdinal;

        
        public ProductMapper(SqlDataReader r)
        {
            ProductIdOrdinal = r.GetOrdinal("ProductID");
            assert(0 == ProductIdOrdinal, " ProductId is not column 0 as expected");
            CategoryIdOrdinal = r.GetOrdinal("CategoryID");
            assert(1 == CategoryIdOrdinal, "CategoryID is not column 1 as expected");
            SellerIdOrdinal = r.GetOrdinal("SellerID");
            assert( 2== SellerIdOrdinal, "SellerID is not column 2 as expected");
            ProductNameOrdinal = r.GetOrdinal("ProductName");
            assert( 3== ProductNameOrdinal, "Name is not column 3 as expected");
            DescriptionOrdinal = r.GetOrdinal("Description");
            assert( 4 == DescriptionOrdinal, " Description is not column 4 as expected");
            ReservePriceOrdinal = r.GetOrdinal("ReservePrice");
            assert( 5 == ReservePriceOrdinal, "ReservePrice is not column 5 as expected");
            WinningOfferIdOrdinal = r.GetOrdinal("WinningOfferID");
            assert( 6== WinningOfferIdOrdinal, "WinningOfferID is not column 6 as expected");
            CommentsOrdinal = r.GetOrdinal("Comments");
            assert( 7== CommentsOrdinal, " Comments is not column 7 as expected");
            CategoryOrdinal = r.GetOrdinal("Category");
            assert( 8== CategoryOrdinal, "Category  is not column 8 as expected");
            SellerNameOrdinal = r.GetOrdinal("SellerName");
            assert( 9 == SellerNameOrdinal, "SellerName is not column 9 as expected");
            SellerEMailAddressOrdinal = r.GetOrdinal("SellerEMailAddress");
            assert( 10== SellerEMailAddressOrdinal, "SellerEMailAddress is not column 10 as expected");

        }
        public ProductDAL ToProduct(SqlDataReader r)
        {
            ProductDAL rv = new ProductDAL();
            rv.ProductID = r.GetInt32(ProductIdOrdinal);
            rv.CategoryID = r.GetInt32(CategoryIdOrdinal);
            rv.SellerID = r.GetInt32(SellerIdOrdinal);
            rv.ProductName = r.GetString(ProductNameOrdinal);
            
            rv.Description = r.GetString(DescriptionOrdinal);
            rv.ReservePrice = r.GetDecimal(ReservePriceOrdinal);
            rv.WinningOfferID = r.GetInt32(WinningOfferIdOrdinal);
            rv.Comments= r.GetString(CommentsOrdinal);
            rv.CategoryName  = r.GetString(CategoryOrdinal);
            rv.SellerName = r.GetString(SellerNameOrdinal);
            rv.SellerEMailAddress = r.GetString(SellerEMailAddressOrdinal);

            return rv;
        }
    }

    class OfferMapper : Mapper
    {
        int OfferIdOrdinal;
        int ProductIdOrdinal;
        int BuyerIdOrdinal;
        int OfferStateOrdinal;
        int OfferPriceOrdinal;
        int ExpireDateOrdinal;
        int CommentsOrdinal;

        int ProductNameOrdinal;
        int BuyerNameOrdinal;
        int BuyerEMailAddressOrdinal;


        public OfferMapper(SqlDataReader r)
        {
            OfferIdOrdinal = r.GetOrdinal("OfferID");
            assert(0 == OfferIdOrdinal, "OfferID is not column 0 as expected");
            ProductIdOrdinal = r.GetOrdinal("ProductID");
            assert(1 == ProductIdOrdinal, " ProductId is not column 1 as expected");
            BuyerIdOrdinal = r.GetOrdinal("BuyerID");
            assert(2 == BuyerIdOrdinal, "BuyerID is not column 2 as expected");
            OfferPriceOrdinal = r.GetOrdinal("OfferPrice");
            assert(3 == OfferPriceOrdinal, "OfferPrice is not column 3 as expected");
            OfferStateOrdinal = r.GetOrdinal("OfferState");
            assert(4 == OfferStateOrdinal, "OfferState is not column 4 as expected");
            ExpireDateOrdinal = r.GetOrdinal("ExpireDate");
            assert(5 == ExpireDateOrdinal, "ExpireDate is not column 5 as expected");
            CommentsOrdinal = r.GetOrdinal("Comments");
            assert(6 == CommentsOrdinal, " Comments is not column 6 as expected");

            ProductNameOrdinal = r.GetOrdinal("ProductName");
            assert(7 == ProductNameOrdinal, "ProductName is not column 7 as expected");
            BuyerNameOrdinal = r.GetOrdinal("SellerName");
            assert(8 == BuyerNameOrdinal, "BuyerName is not column 8 as expected");
            BuyerEMailAddressOrdinal = r.GetOrdinal("BuyerEMailAddress");
            assert(9 == BuyerEMailAddressOrdinal, "BuyerEMailAddress is not column 9 as expected");

        }
        public OfferDAL ToProduct(SqlDataReader r)
        {
            OfferDAL rv = new OfferDAL();
            rv.OfferID = r.GetInt32(OfferIdOrdinal);
            rv.ProductID = r.GetInt32(ProductIdOrdinal);
            rv.BuyerID = r.GetInt32(BuyerIdOrdinal);
            rv.OfferState = r.GetInt32(OfferStateOrdinal);
            rv.OfferPrice = r.GetDecimal(OfferPriceOrdinal);
            rv.ExpireDate = r.GetDateTime(ExpireDateOrdinal);
            rv.Comments = r.GetString(CommentsOrdinal);

            rv.ProductName = r.GetString(ProductNameOrdinal);

            rv.BuyerName = r.GetString(BuyerNameOrdinal);
            rv.BuyerEmailAddress = r.GetString(BuyerEMailAddressOrdinal);

            return rv;
        }
    }



    public  class ContextDAL
    {
        private System.Data.SqlClient.SqlConnection Con;

        private void Log(Exception ex)
        {

        }

        public ContextDAL ()
        {
            Con = new System.Data.SqlClient.SqlConnection();
        }
        public string ConnectionString
        {
            get
            {
                return Con.ConnectionString;
            }
            set
            {
                Con.ConnectionString = value;
            }
        }

        private void EnsureConnected()
        {
            if (Con.State != System.Data.ConnectionState.Open)
            {
                if  (Con.State == System.Data.ConnectionState.Broken  )
                {
                    Con.Close();
                    Con.Open();
                }
                  else if (Con.State == System.Data.ConnectionState.Closed  )     
                {
                    Con.Open();
                }
            }
        }

        #region Categories

        public int CreateCategory(string Category)
        {
            int rv = 0;
            try
            {

                EnsureConnected();
                using (SqlCommand command = new SqlCommand("CreateCategory", Con))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CategoryID", 0);
                    command.Parameters["@CategoryID"].Direction = System.Data.ParameterDirection.InputOutput;
                    command.Parameters.AddWithValue("@Category", Category);

                    command.ExecuteNonQuery();

                    rv = Convert.ToInt32(command.Parameters["@CategoryID"].Value);
                }
            }
            catch (Exception ex)
            {
                Log(ex);
                throw;
            }
            return rv;
        }

        public void DeleteCategory(int CategoryID)
        {
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("DeleteCategory", Con))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CategoryID", CategoryID);

                    command.ExecuteNonQuery();
                }
            }
            catch(Exception ex)
            {
                Log(ex);
                throw;
            }
        }

        public CategoryDAL FindCategoryByID(int CategoryID)
        {
            CategoryDAL rv = null;
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("FindCategoryByID", Con))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CategoryID",CategoryID);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        CategoryMapper mapper = new CategoryMapper(reader);
                        if (reader.Read())
                        {
                            rv = mapper.ToCategory(reader);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log(ex);
                throw;
            }
            return rv;
        }

        public List<CategoryDAL> GetCategories(int skip, int take)
        {
            List<CategoryDAL> rv = new List<CategoryDAL>();
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("GetCategories", Con))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@skip", skip);
                    command.Parameters.AddWithValue("@take", take);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        CategoryMapper mapper = new CategoryMapper(reader);
                        while (reader.Read())
                        {
                            CategoryDAL c = mapper.ToCategory(reader);
                            rv.Add(c);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log(ex);
                throw;
            }
            return rv;
        }

        public void JustUpdateCategory(int CategoryID, string newCategory)
        {
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("JustUpdateCategory", Con))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CategoryID", CategoryID);
                    command.Parameters.AddWithValue("@Category", newCategory);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Log(ex);
                throw;
            }
        }
        public int SafeUpdateCategory(int CategoryID, string OldCategory, string newCategory)
        {
            int rv = 0;
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("SafeUpdateCategory", Con))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CategoryID", CategoryID);
                    command.Parameters.AddWithValue("@NewCategory", newCategory);
                    command.Parameters.AddWithValue("@OldCategory", OldCategory);

                    rv = command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Log(ex);
                throw;
            }
            return rv;
        }
        #endregion categories

        #region Roles
        public int CreateRole(string Role)
        {
            int rv = 0;
            return rv;
        }

        public void deleteRole(int RoleID)
        {

        }

        public void JustUpdateRole(int RoleID, string NewRole)
        {

        }

        public int SafeUpdateRole(int RoleID, string OldRole, string NewRole)
        {
            int rv = 0;
            return rv;
        }

        public RoleDAL FindRoleByID(int RoleID)
        {
            RoleDAL rv = null;
            return rv;
        }
        public List<RoleDAL> GetRoles(int skip, int take)
        {
            List<RoleDAL> rv = new List<RoleDAL>();
            return rv;
        }
        #endregion Roles

        #region Users
        public int CreateUser(string EMailAddress, string Name, string Password, string Hash, int RoleID)
        {
            int rv = 0;
            return rv;
        }

        public void deleteUser(int UserID)
        {

        }

        public void JustUpdateUser(int UserID, string NewEMailAddress, string NewName, string NewPassword, string NewHash, int NewRoldID)
        {

        }

        public int SafeUpdateUser(int UserID, string OldEMailAddress, string OldName, string OldPassword, string OldHash, int OldRoleID, string NewEMailAddress, string NewName, string NewPassword, string NewHash, int NewRoldID)
        {
            int rv = 0;
            return rv;
        }

        public UserDAL FindUserByID(int UserID)
        {
            UserDAL rv = null;
            return rv;
        }
        public List<UserDAL> GetUsers(int skip, int take)
        {
            List<UserDAL> rv = new List<UserDAL>();
            return rv;
        }

        public List<UserDAL> GetUsersRelatedToRole(int RoleID)
        {
            List<UserDAL> rv = new List<UserDAL>();
            return rv;
        }
        #endregion Users

        #region offers
        public int CreateOffer(int ProductId, int BuyerId, decimal OfferPrice, int OfferState, DateTime ExpireDate, string Comments)
        {
            int rv = 0;
            return rv;
        }

        public void deleteOffer(int OfferID)
        {

        }

        public void JustUpdateOffer(int OfferId, int NewProductId, int NewBuyerId, decimal NewOfferPrice, int NewOfferState, DateTime NewExpireDate, string NewComments)
        {

        }

        public int SafeUpdateOffer(int OfferId, int OldProductId, int OldBuyerId, decimal OldOfferPrice, int OldOfferState, DateTime OldExpireDate, string OldComments,
                                                int NewProductId, int NewBuyerId, decimal NewOfferPrice, int NewOfferState, DateTime NewExpireDate, string NewComments)
        {
            int rv = 0;
            return rv;
        }

        public OfferDAL FindOfferByID(int OfferID)
        {
            OfferDAL rv = null;
            return rv;
        }
        public List<OfferDAL> GetOffers(int skip, int take)
        {
            List<OfferDAL> rv = new List<OfferDAL>();
            return rv;
        }

        public List<OfferDAL> GetOffersRelatedToBuyer(int BuyerID)
        {
            List<OfferDAL> rv = new List<OfferDAL>();
            return rv;
        }

        public List<OfferDAL> GetOffersRelatedToBuyerEMail(string EMailAddress)
        {
            List<OfferDAL> rv = new List<OfferDAL>();
            return rv;
        }


        public List<OfferDAL> GetOffersRelatedToProduct(int ProductID)
        {
            List<OfferDAL> rv = new List<OfferDAL>();
            return rv;

        }


        #endregion offers

        #region products
        public int CreateProduct( int CategoryID,int SellerID, string ProductName, string Description, decimal ReservePrice, int WinningOfferID, string Comments)
        {
            int rv = 0;
            return rv;
        }

        public void deleteProduct(int ProductID)
        {

        }

        public void JustUpdateProduct(int ProductID, int NewCategoryID, int NewSellerID, string NewProductName, string NewDescription, 
            decimal NewReservePrice, int NewWinningOfferID, string NewComments)
        {

        }

        public int SafeUpdateProduct(int ProductID, int OldCategoryID, int OldSellerID, string OldProductName, string OldDescription,
            decimal OldReservePrice, int OldWinningOfferID, string OldComments, int NewCategoryID, int NewSellerID, string NewProductName, string NewDescription,
            decimal NewReservePrice, int NewWinningOfferID, string NewComments)
        {
            int rv = 0;
            return rv;
        }

        public ProductDAL FindProductByID(int ProductID)
        {
            ProductDAL rv = null;
            return rv;
        }
        public List<ProductDAL> GetProducts(int skip, int take)
        {
            List<ProductDAL> rv = new List<ProductDAL>();
            return rv;
        }

        public List<ProductDAL> GetProductsRelatedToSeller(int SellerID)
        {
            List<ProductDAL> rv = new List<ProductDAL>();
            return rv;
        }
        public List<ProductDAL> GetProductsRelatedToSellerEMail(string EmailAddress)
        {
            List<ProductDAL> rv = new List<ProductDAL>();
            return rv;

        }
        public List<OfferDAL> GetProductsRelatedToCategory(int CategoryID)
        {
            List<ProductDAL> rv = new List<ProductDAL>();
            return rv;

        }



        #endregion products



    }

}
