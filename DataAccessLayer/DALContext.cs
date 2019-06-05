using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    #region Mappers
    class Mapper
    {
        public void assert(bool test, string message)
        {
            if (!test)
            {
                throw new Exception(message);
            }
        }
        public string GetStringOrNull( System.Data.SqlClient.SqlDataReader r,int i)
        {
            string rv = null;
            if (!r.IsDBNull(i))
            {
                rv = r.GetString(i);
            }
            return rv;
        }
        public int GetInt32OrZero(System.Data.SqlClient.SqlDataReader r, int i)
        {
            int rv = 0;
            if (!r.IsDBNull(i))
            {
                rv = r.GetInt32(i);
            }
            return rv;
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
            rv.CategoryID = GetInt32OrZero(r,CategoryIdOrdinal);
            rv.CategoryName = GetStringOrNull(r,CategoryOrdinal);

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
            rv.RoleID = GetInt32OrZero(r,RoleIdOrdinal);
            rv.RoleName = GetStringOrNull(r,RoleOrdinal);

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
            RoleNameOrdinal = r.GetOrdinal("Role");
            assert(6 == RoleNameOrdinal, "Role is not column 6 as expected");

        }
        public UserDAL ToUser(SqlDataReader r)
        {
            UserDAL rv = new UserDAL();
            rv.UserID = GetInt32OrZero(r,UserIdOrdinal);
            rv.EMailAddress = GetStringOrNull(r,EmailAddressOrdinal);
            rv.Name = GetStringOrNull(r,NameOrdinal);
            rv.Password = GetStringOrNull(r,PasswordOrdinal);
            rv.Hash = GetStringOrNull(r,HashOrdinal);
            rv.RoleID = GetInt32OrZero(r,RoleIdOrdinal);
            rv.RoleName = GetStringOrNull(r,RoleNameOrdinal);

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
            assert( 10 == SellerNameOrdinal, "SellerName is not column 9 as expected");
            SellerEMailAddressOrdinal = r.GetOrdinal("SellerEMail");
            assert( 9== SellerEMailAddressOrdinal, "SellerEMailAddress is not column 10 as expected");

        }
        public ProductDAL ToProduct(SqlDataReader r)
        {
            ProductDAL rv = new ProductDAL();
            rv.ProductID = GetInt32OrZero(r,ProductIdOrdinal);
            rv.CategoryID = GetInt32OrZero(r,CategoryIdOrdinal);
            rv.SellerID = GetInt32OrZero(r,SellerIdOrdinal);
            rv.ProductName = GetStringOrNull(r,ProductNameOrdinal);
            
            rv.Description = GetStringOrNull(r,DescriptionOrdinal);
            rv.ReservePrice = r.GetDecimal(ReservePriceOrdinal);
            rv.WinningOfferID = GetInt32OrZero(r,WinningOfferIdOrdinal);
            rv.Comments= GetStringOrNull(r,CommentsOrdinal);
            rv.CategoryName  = GetStringOrNull(r,CategoryOrdinal);
            rv.SellerName = GetStringOrNull(r,SellerNameOrdinal);
            rv.SellerEMailAddress = GetStringOrNull(r,SellerEMailAddressOrdinal);

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
            BuyerNameOrdinal = r.GetOrdinal("BuyerName");
            assert(8 == BuyerNameOrdinal, "BuyerName is not column 8 as expected");
            BuyerEMailAddressOrdinal = r.GetOrdinal("EMailAddress");
            assert(9 == BuyerEMailAddressOrdinal, "BuyerEMailAddress is not column 9 as expected");

        }
        public OfferDAL ToOffer(SqlDataReader r)
        {
            OfferDAL rv = new OfferDAL();
            rv.OfferID = GetInt32OrZero(r,OfferIdOrdinal);
            rv.ProductID = GetInt32OrZero(r,ProductIdOrdinal);
            rv.BuyerID = GetInt32OrZero(r,BuyerIdOrdinal);
            rv.OfferState = GetInt32OrZero(r,OfferStateOrdinal);
            rv.OfferPrice = r.GetDecimal(OfferPriceOrdinal);
            rv.ExpireDate = r.GetDateTime(ExpireDateOrdinal);
           
            rv.Comments = GetStringOrNull(r,CommentsOrdinal);
            rv.ProductName = GetStringOrNull(r,ProductNameOrdinal);
            
            rv.BuyerName = GetStringOrNull(r,BuyerNameOrdinal);
            rv.BuyerEmailAddress = GetStringOrNull(r,BuyerEMailAddressOrdinal);

            return rv;
        }
    }
    #endregion Mappers


    public class ContextDAL:  IDisposable
    {
        public void Dispose()
        {
            Con.Dispose();
        }

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

        public SqlDataReader ExecuteCommand(SqlCommand cmd)
        {
            if (Con != cmd.Connection )
            {
                cmd.Connection = Con;
            }
            EnsureConnected();
            return cmd.ExecuteReader();
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
            try
            {

                EnsureConnected();
                using (SqlCommand command = new SqlCommand("CreateRole", Con))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@RoleID", 0);
                    command.Parameters["@RoleID"].Direction = System.Data.ParameterDirection.InputOutput;
                    command.Parameters.AddWithValue("@Role", Role);

                    command.ExecuteNonQuery();

                    rv = Convert.ToInt32(command.Parameters["@RoleID"].Value);
                }
            }
            catch (Exception ex)
            {
                Log(ex);
                throw;
            }
            return rv;
        }

        public void deleteRole(int RoleID)
        {
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("DeleteRole", Con))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@RoleID", RoleID);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Log(ex);
                throw;
            }
        }

        public void JustUpdateRole(int RoleID, string NewRole)
        {
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("JustUpdateRole", Con))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@RoleID", RoleID);
                    command.Parameters.AddWithValue("@Role", NewRole);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Log(ex);
                throw;
            }
        }

        public int SafeUpdateRole(int RoleID, string OldRole, string NewRole)
        {
            int rv = 0;
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("SafeUpdateRole", Con))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CRoleID", RoleID);
                    command.Parameters.AddWithValue("@NewRole", NewRole);
                    command.Parameters.AddWithValue("@OldRole", OldRole);

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

        public RoleDAL FindRoleByID(int RoleID)
        {
            RoleDAL rv = null;
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("FindRoleByID", Con))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@RoleID", RoleID);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        RoleMapper mapper = new RoleMapper(reader);
                        if (reader.Read())
                        {
                            rv = mapper.ToRole(reader);
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
        public List<RoleDAL> GetRoles(int skip, int take)
        {
            List<RoleDAL> rv = new List<RoleDAL>();
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("GetRoles", Con))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@skip", skip);
                    command.Parameters.AddWithValue("@take", take);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        RoleMapper mapper = new RoleMapper(reader);
                        while (reader.Read())
                        {
                            RoleDAL c = mapper.ToRole(reader);
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
        #endregion Roles

        #region Users
        public int CreateUser(string EMailAddress, string Name, string Password, string Hash, int RoleID)
        {
            int rv = 0;
            try
            {

                EnsureConnected();
                using (SqlCommand command = new SqlCommand("CreateUser", Con))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserID", 0);
                    command.Parameters["@UserID"].Direction = System.Data.ParameterDirection.InputOutput;
                    command.Parameters.AddWithValue("@EMailAddress", EMailAddress);
                    command.Parameters.AddWithValue("@Name", Name);
                    command.Parameters.AddWithValue("@Password", Password);
                    command.Parameters.AddWithValue("@Hash", Hash);
                    command.Parameters.AddWithValue("@RoleID", RoleID);
                    command.ExecuteNonQuery();

                    rv = Convert.ToInt32(command.Parameters["@UserID"].Value);
                }
            }
            catch (Exception ex)
            {
                Log(ex);
                throw;
            }
            return rv;
        }

        public void deleteUser(int UserID)
        {
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("DeleteUser", Con))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserID", UserID);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Log(ex);
                throw;
            }
        }

        public void JustUpdateUser(int UserID, string NewEMailAddress, string NewName, string NewPassword, string NewHash, int NewRoleID)
        {
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("JustUpdateUser", Con))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserID", UserID);
                    
                    command.Parameters.AddWithValue("@EMailAddress", NewEMailAddress);
                    command.Parameters.AddWithValue("@Name", NewName);
                    command.Parameters.AddWithValue("@Password", NewPassword);
                    command.Parameters.AddWithValue("@Hash", NewHash);
                    command.Parameters.AddWithValue("@RoleID", NewRoleID);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Log(ex);
                throw;
            }
        }

        public int SafeUpdateUser(int UserID, string OldEMailAddress, string OldName, string OldPassword, string OldHash, int OldRoleID, string NewEMailAddress, string NewName, string NewPassword, string NewHash, int NewRoleID)
        {
            int rv = 0;
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("SafeUpdateUser", Con))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserID", 0);

                    command.Parameters.AddWithValue("@NewEMailAddress", NewEMailAddress);
                    command.Parameters.AddWithValue("@NewName", NewName);
                    command.Parameters.AddWithValue("@NewPassword", NewPassword);
                    command.Parameters.AddWithValue("@NewHash", NewHash);
                    command.Parameters.AddWithValue("@NewRoleID", NewRoleID);
                    command.Parameters.AddWithValue("@OldEMailAddress", OldEMailAddress);
                    command.Parameters.AddWithValue("@OldName", OldName);
                    command.Parameters.AddWithValue("@OldPassword", OldPassword);
                    command.Parameters.AddWithValue("@OldHash", OldHash);
                    command.Parameters.AddWithValue("@OldRoleID", OldRoleID);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Log(ex);
                throw;
            }
            return rv;
        }

        public UserDAL FindUserByID(int UserID)
        {
            UserDAL rv = null;
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("FindUserByID", Con))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserID", UserID);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        UserMapper mapper = new UserMapper(reader);
                        if (reader.Read())
                        {
                            rv = mapper.ToUser(reader);
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
        public List<UserDAL> GetUsers(int skip, int take)
        {
            List<UserDAL> rv = new List<UserDAL>();
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("GetUsers", Con))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@skip", skip);
                    command.Parameters.AddWithValue("@take", take);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        UserMapper mapper = new UserMapper(reader);
                        while (reader.Read())
                        {
                            UserDAL c = mapper.ToUser(reader);
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

        public List<UserDAL> GetUsersRelatedToRole(int skip, int take,int RoleID)
        {
            List<UserDAL> rv = new List<UserDAL>();
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("GetUsersRelatedToRole", Con))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@skip", skip);
                    command.Parameters.AddWithValue("@take", take);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        UserMapper mapper = new UserMapper(reader);
                        while (reader.Read())
                        {
                            UserDAL c = mapper.ToUser(reader);
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
        #endregion Users

        #region offers
        public int CreateOffer(int ProductId, int BuyerId, decimal OfferPrice, int OfferState, DateTime ExpireDate, string Comments)
        {
            int rv = 0;
            try
            {

                EnsureConnected();
                using (SqlCommand command = new SqlCommand("CreateOffer", Con))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@OfferID", 0);
                    command.Parameters["@OfferID"].Direction = System.Data.ParameterDirection.InputOutput;
                    command.Parameters.AddWithValue("@ProductID", ProductId);
                    command.Parameters.AddWithValue("@BuyerID", BuyerId);
                    command.Parameters.AddWithValue("@OfferPrice", OfferPrice);
                    command.Parameters.AddWithValue("@OfferState", OfferState);
                    command.Parameters.AddWithValue("@ExpireDate", ExpireDate);
                    if (null == Comments)
                    {
                        command.Parameters.AddWithValue("@Comments", DBNull.Value);
                    }
                    else
                    { 
                    command.Parameters.AddWithValue("@Comments", Comments);
                    }
                    command.ExecuteNonQuery();

                    rv = Convert.ToInt32(command.Parameters["@OfferID"].Value);
                }
            }
            catch (Exception ex)
            {
                Log(ex);
                throw;
            }
            return rv;
        }

        public void deleteOffer(int OfferID)
        {
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("DeleteOffer", Con))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@OfferID", OfferID);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Log(ex);
                throw;
            }
        }

        public void JustUpdateOffer(int OfferId, int NewProductId, int NewBuyerId, decimal NewOfferPrice, int NewOfferState, DateTime NewExpireDate, string NewComments)
        {
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("JustUpdateOffer", Con))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@OfferID", OfferId);

                    command.Parameters.AddWithValue("@ProductID", NewProductId);
                    command.Parameters.AddWithValue("@BuyerID", NewBuyerId);
                    command.Parameters.AddWithValue("@OfferPrice", NewOfferPrice);
                    command.Parameters.AddWithValue("@OfferState", NewOfferState);
                    command.Parameters.AddWithValue("@ExpireDate", NewExpireDate);
                    command.Parameters.AddWithValue("@Comments", NewComments);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Log(ex);
                throw;
            }
        }

        public int SafeUpdateOffer(int OfferId, int OldProductId, int OldBuyerId, decimal OldOfferPrice, int OldOfferState, DateTime OldExpireDate, string OldComments,
                                                int NewProductId, int NewBuyerId, decimal NewOfferPrice, int NewOfferState, DateTime NewExpireDate, string NewComments)
        {
            int rv = 0;
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("SafeUpdateOffer", Con))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@OfferID", OfferId);

                    command.Parameters.AddWithValue("@NewProductID", NewProductId);
                    command.Parameters.AddWithValue("@NewBuyerID", NewBuyerId);
                    command.Parameters.AddWithValue("@NewOfferPrice", NewOfferPrice);
                    command.Parameters.AddWithValue("@NewOfferState", NewOfferState);
                    command.Parameters.AddWithValue("@NewExpireDate", NewExpireDate);
                    command.Parameters.AddWithValue("@NewComments", NewComments);

                    command.Parameters.AddWithValue("@OldProductID", OldProductId);
                    command.Parameters.AddWithValue("@OldBuyerID", OldBuyerId);
                    command.Parameters.AddWithValue("@OldOfferPrice", OldOfferPrice);
                    command.Parameters.AddWithValue("@OldOfferState", OldOfferState);
                    command.Parameters.AddWithValue("@OldExpireDate", OldExpireDate);
                    command.Parameters.AddWithValue("@OldComments", OldComments);

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

        public OfferDAL FindOfferByID(int OfferID)
        {
            OfferDAL rv = null;
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("FindOfferByID", Con))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@OfferID", OfferID);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        OfferMapper mapper = new OfferMapper(reader);
                        if (reader.Read())
                        {
                            rv = mapper.ToOffer(reader);
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
        public List<OfferDAL> GetOffers(int skip, int take)
        {
            List<OfferDAL> rv = new List<OfferDAL>();
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("GetOffers", Con))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@skip", skip);
                    command.Parameters.AddWithValue("@take", take);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        OfferMapper mapper = new OfferMapper(reader);
                        while (reader.Read())
                        {
                            OfferDAL c = mapper.ToOffer(reader);
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

        public List<OfferDAL> GetOffersRelatedToBuyer(int BuyerID,int skip,int take)
        {
            List<OfferDAL> rv = new List<OfferDAL>();
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("GetOffersRelatedToBuyer", Con))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@skip", skip);
                    command.Parameters.AddWithValue("@take", take);
                    command.Parameters.AddWithValue("@BuyerID", BuyerID);


                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        OfferMapper mapper = new OfferMapper(reader);
                        while (reader.Read())
                        {
                            OfferDAL c = mapper.ToOffer(reader);
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

        public List<OfferDAL> GetOffersRelatedToBuyerEMail(string EMailAddress,int skip, int take)
        {
            List<OfferDAL> rv = new List<OfferDAL>();
            try
            {
                EnsureConnected();
                using (SqlCommand command = 
                    new SqlCommand("GetOffersRelatedToEMail", Con))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@skip", skip);
                    command.Parameters.AddWithValue("@take", take);
                    command.Parameters.AddWithValue("@EMail", EMailAddress);


                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        OfferMapper mapper = new OfferMapper(reader);
                        while (reader.Read())
                        {
                            OfferDAL c = mapper.ToOffer(reader);
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


        public List<OfferDAL> GetOffersRelatedToProduct(int ProductID,int skip, int take)
        {
            List<OfferDAL> rv = new List<OfferDAL>();
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("GetOffersRelatedToProduct", Con))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@skip", skip);
                    command.Parameters.AddWithValue("@take", take);
                    command.Parameters.AddWithValue("@ProductID", ProductID);


                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        OfferMapper mapper = new OfferMapper(reader);
                        while (reader.Read())
                        {
                            OfferDAL c = mapper.ToOffer(reader);
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


        #endregion offers

        #region products
        public int CreateProduct( int CategoryID,int SellerID, string ProductName, string Description, decimal ReservePrice, int? WinningOfferID, string Comments)
        {
            int rv = 0;
            try
            {

                EnsureConnected();
                using (SqlCommand command = new SqlCommand("CreateProduct", Con))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ProductID", 0);
                    command.Parameters["@ProductID"].Direction = System.Data.ParameterDirection.InputOutput;
                    command.Parameters.AddWithValue("@CategoryID", CategoryID);
                    command.Parameters.AddWithValue("@SellerID", SellerID);
                    command.Parameters.AddWithValue("@Name", ProductName);
                    command.Parameters.AddWithValue("@Description", Description);
                    command.Parameters.AddWithValue("@ReservePrice", ReservePrice);
                    if (WinningOfferID.HasValue)
                    {
                        command.Parameters.AddWithValue("@WinningOfferID", WinningOfferID);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@WinningOfferID",
                            DBNull.Value);
                    }

                    if (null != Comments)
                    {
                        command.Parameters.AddWithValue("@Comments", Comments);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@Comments", "");
                    }
                    command.ExecuteNonQuery();

                    rv = Convert.ToInt32(command.Parameters["@ProductID"].Value);
                }
            }
            catch (Exception ex)
            {
                Log(ex);
                throw;
            }
            return rv;
        }

        public void deleteProduct(int ProductID)
        {
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("DeleteProduct", Con))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ProductID", ProductID);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Log(ex);
                throw;
            }
        }

        public void JustUpdateProduct(int ProductID, int NewCategoryID, int NewSellerID, string NewProductName, string NewDescription, 
            decimal NewReservePrice, int? NewWinningOfferID, string NewComments)
        {
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("JustUpdateProduct", Con))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ProductID", ProductID);

                    command.Parameters.AddWithValue("@CategoryID", NewCategoryID);
                    command.Parameters.AddWithValue("@SellerID", NewSellerID);
                    command.Parameters.AddWithValue("@ProductName", NewProductName);
                    command.Parameters.AddWithValue("@Description", NewDescription);
                    command.Parameters.AddWithValue("@ReservePrice", NewReservePrice);
                    if (NewWinningOfferID.HasValue)
                    {
                        command.Parameters.AddWithValue("@WinningOfferID", NewWinningOfferID);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@WinningOfferID",
                            DBNull.Value);
                    }

                    if (null != NewComments)
                    {
                        command.Parameters.AddWithValue("@Comments", NewComments);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@Comments", "");
                    }

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Log(ex);
                throw;
            }
        }

        public int SafeUpdateProduct(int ProductID, int OldCategoryID, int OldSellerID, string OldProductName, string OldDescription,
            decimal OldReservePrice, int ?OldWinningOfferID, string OldComments, int NewCategoryID, int NewSellerID, string NewProductName, string NewDescription,
            decimal NewReservePrice, int ?NewWinningOfferID, string NewComments)
        {
            int rv = 0;
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("SafeUpdateProduct", Con))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ProductID", ProductID);

                    command.Parameters.AddWithValue("@NewCategoryID", NewCategoryID);
                    command.Parameters.AddWithValue("@NewSellerID", NewSellerID);
                    command.Parameters.AddWithValue("@NewProductName", NewProductName);
                    command.Parameters.AddWithValue("@NewDescription", NewDescription);
                    command.Parameters.AddWithValue("@NewReservePrice", NewReservePrice);
                    if (NewWinningOfferID.HasValue)
                    {
                        command.Parameters.AddWithValue("@NewWinningOfferID", NewWinningOfferID);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@NewWinningOfferID",
                            DBNull.Value);
                    }

                    if (null != NewComments)
                    {
                        command.Parameters.AddWithValue("@NewComments", NewComments);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@NewComments", "");
                    }

                    command.Parameters.AddWithValue("@OldCategoryID", OldCategoryID);
                    command.Parameters.AddWithValue("@OldSellerID", OldSellerID);
                    command.Parameters.AddWithValue("@OldProductName", OldProductName);
                    command.Parameters.AddWithValue("@OldDescription", OldDescription);
                    command.Parameters.AddWithValue("@OldReservePrice", OldReservePrice);
                    if (OldWinningOfferID.HasValue)
                    {
                        command.Parameters.AddWithValue("@OldWinningOfferID", OldWinningOfferID);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@OldWinningOfferID",
                            DBNull.Value);
                    }

                    if (null != OldComments)
                    {
                        command.Parameters.AddWithValue("@OldComments", OldComments);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@OldComments", "");
                    }

                    rv =  command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Log(ex);
                throw;
            }

            return rv;
        }

        public ProductDAL FindProductByID(int ProductID)
        {
            ProductDAL rv = null;
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("FindProductByID", Con))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ProductID", ProductID);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        ProductMapper mapper = new ProductMapper(reader);
                        if (reader.Read())
                        {
                            rv = mapper.ToProduct(reader);
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
        public List<ProductDAL> GetProducts(int skip, int take)
        {
            List<ProductDAL> rv = new List<ProductDAL>();
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("GetProducts", Con))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@skip", skip);
                    command.Parameters.AddWithValue("@take", take);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        ProductMapper mapper = new ProductMapper(reader);
                        while (reader.Read())
                        {
                            ProductDAL c = mapper.ToProduct(reader);
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

        public List<ProductDAL> GetProductsRelatedToSeller(int SellerID, int skip, int take)
        {
            List<ProductDAL> rv = new List<ProductDAL>();
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("GetProductsRelatedToSeller", Con))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@skip", skip);
                    command.Parameters.AddWithValue("@take", take);
                    command.Parameters.AddWithValue("@SellerID", SellerID);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        ProductMapper mapper = new ProductMapper(reader);
                        while (reader.Read())
                        {
                            ProductDAL c = mapper.ToProduct(reader);
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
        public List<ProductDAL> GetProductsRelatedToSellerEMail(string EmailAddress, int skip, int take)
        {
            List<ProductDAL> rv = new List<ProductDAL>();
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("GetProductsRelatedToSeller", Con))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@skip", skip);
                    command.Parameters.AddWithValue("@take", take);
                    command.Parameters.AddWithValue("@EMail", EmailAddress);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        ProductMapper mapper = new ProductMapper(reader);
                        while (reader.Read())
                        {
                            ProductDAL c = mapper.ToProduct(reader);
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
        public List<ProductDAL> GetProductsRelatedToCategory(int CategoryID,int skip, int take)
        {
            List<ProductDAL> rv = new List<ProductDAL>();
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("GetProductsRelatedToSeller", Con))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@skip", skip);
                    command.Parameters.AddWithValue("@take", take);
                    command.Parameters.AddWithValue("@CategoryID", CategoryID);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        ProductMapper mapper = new ProductMapper(reader);
                        while (reader.Read())
                        {
                            ProductDAL c = mapper.ToProduct(reader);
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

  






        #endregion products



    }

}
