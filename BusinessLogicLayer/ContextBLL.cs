using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
  public  class ContextBLL : IDisposable 
    {
        private ContextDAL ctx = new ContextDAL();
        public void Dispose()
        {
            ctx.Dispose();
        }

        public ContextBLL()
        {
            ctx.ConnectionString = @"Data Source=.\sqlexpress;Initial Catalog=AuctionProject;Integrated Security=True"; 
        }

        #region Roles

        public int CreateRole(string Role)
        {
            return ctx.CreateRole(Role);
        }

        public void deleteRole(int RoleID)
        {
            ctx.deleteRole(RoleID);
        }

        public void JustUpdateRole(int RoleID, string NewRole)
        {
            ctx.JustUpdateRole(RoleID, NewRole);
        }

        public int SafeUpdateRole(int RoleID, string OldRole, string NewRole)
        {
            return ctx.SafeUpdateRole(RoleID, OldRole, NewRole);
        }

        public RoleBLL FindRoleByID(int RoleID)
        {
            RoleBLL rv = null;
            RoleDAL dal = ctx.FindRoleByID(RoleID);
            if (dal != null)
            {
                rv = new RoleBLL(dal);
            }

            return rv;
        }

        public List<RoleBLL> GetRoles(int skip, int take)
        {
            List<RoleBLL> rv = new List<RoleBLL>();
            List<RoleDAL> dalitems = ctx.GetRoles(skip, take);
            foreach(RoleDAL dal in dalitems)
            {
                rv.Add(new RoleBLL(dal));
            }
            return rv;
        }


        #endregion

        #region categories
        public int CreateCategory(string Category)
        {
            return ctx.CreateCategory(Category);
        }

        public void deleteCategory(int CategoryID)
        {
            ctx.DeleteCategory(CategoryID);
        }

        public void JustUpdateCategory(int CategoryID, string NewCategory)
        {
            ctx.JustUpdateCategory(CategoryID, NewCategory);
        }

        public int SafeUpdateCategory(int CategoryID, string OldCategory, string NewCategory)
        {
            return ctx.SafeUpdateCategory(CategoryID, OldCategory, NewCategory);
        }

        public CategoryBLL FindCategoryByID(int CategoryID)
        {
            CategoryBLL rv = null;
            CategoryDAL dal = ctx.FindCategoryByID(CategoryID);
            if (dal != null)
            {
                rv = new CategoryBLL(dal);
            }

            return rv;
        }

        public List<CategoryBLL> GetCategories(int skip, int take)
        {
            List<CategoryBLL> rv = new List<CategoryBLL>();
            List<CategoryDAL> dalitems = ctx.GetCategories(skip, take);
            foreach (CategoryDAL dal in dalitems)
            {
                rv.Add(new CategoryBLL(dal));
            }
            return rv;
        }

        #endregion

        #region users
        public int CreateUser(string EMailAddress, string Name,string Password, string Hash, int RoleID)
        {
            return ctx.CreateUser(EMailAddress, Name, Password,Hash, RoleID);
        }

        public void deleteUser(int UserID)
        {
            ctx.deleteUser(UserID);
        }

        public void JustUpdateUser(int UserID, string EMailAddress, string Name, string Password, string Hash, int RoleID)
        {
            ctx.JustUpdateUser(UserID, EMailAddress, Name,Password,Hash, RoleID);
        }

        public int SafeUpdateUser(int UserID, string OldEMailAddress, string OldName, string OldPassword, string OldHash, int OldRoleID, string NewEMailAddress, string NewName, string NewPassword, string NewHash, int NewRoleID)
        {
            return ctx.SafeUpdateUser( UserID,  OldEMailAddress,  OldName,  OldPassword,  OldHash,  OldRoleID,  NewEMailAddress,  NewName,  NewPassword,  NewHash,  NewRoleID);
        }

        public UserBLL FindUserByID(int UserID)
        {
            UserBLL rv = null;
            UserDAL dal = ctx.FindUserByID(UserID);
            if (dal != null)
            {
                rv = new UserBLL(dal);
            }

            return rv;
        }

        public List<UserBLL> GetUsers(int skip, int take)
        {
            List<UserBLL> rv = new List<UserBLL>();
            List<UserDAL> dalitems = ctx.GetUsers(skip, take);
            foreach (UserDAL dal in dalitems)
            {
                rv.Add(new UserBLL(dal));
            }
            return rv;
        }

        public List<UserBLL> GetUsersRelatedToRole(int skip, int take, int RoleID)
        {
            List<UserBLL> rv = new List<UserBLL>();
            List<UserDAL> dalitems = ctx.GetUsersRelatedToRole(skip, take, RoleID);
            foreach (UserDAL dal in dalitems)
            {
                rv.Add(new UserBLL(dal));
            }
            return rv;
        }

        #endregion

        #region Products
        public int CreateProduct(int CategoryID, int SellerId, string ProductName,string Description, decimal ReservePrice, int? WinningOfferID,string Comments)
        {
            return ctx.CreateProduct( CategoryID,  SellerId,  ProductName,  Description,  ReservePrice,  WinningOfferID,  Comments);
        }

        public void deleteProduct(int ProductID)
        {
            ctx.deleteProduct(ProductID);
        }

        public void JustUpdateProduct(int ProductID, int CategoryID, int SellerId, string ProductName, string Description, decimal ReservePrice, int? WinningOfferID, string Comments)
        {
            ctx.JustUpdateProduct( ProductID,  CategoryID,  SellerId,  ProductName,  Description,  ReservePrice,   WinningOfferID,  Comments);
        }

        public int SafeUpdateProduct(int ProductID, int OldCategoryID, int OldSellerId, string OldProductName, string OldDescription, decimal OldReservePrice, int? OldWinningOfferID, string OldComments, int NewCategoryID, int NewSellerId, string NewProductName, string NewDescription, decimal NewReservePrice, int? NewWinningOfferID, string NewComments)
        {
            return ctx.SafeUpdateProduct( ProductID,  OldCategoryID,  OldSellerId,  OldProductName,  OldDescription,  OldReservePrice,  OldWinningOfferID,  OldComments,
              NewCategoryID, NewSellerId, NewProductName, NewDescription, NewReservePrice, NewWinningOfferID, NewComments);
        }

        public ProductBLL FindProductByID(int ProductID)
        {
            ProductBLL rv = null;
            ProductDAL dal = ctx.FindProductByID(ProductID);
            if (dal != null)
            {
                rv = new ProductBLL(dal);
            }

            return rv;
        }

        public List<ProductBLL> GetProducts(int skip, int take)
        {
            List<ProductBLL> rv = new List<ProductBLL>();
            List<ProductDAL> dalitems = ctx.GetProducts(skip, take);
            foreach (ProductDAL dal in dalitems)
            {
                rv.Add(new ProductBLL(dal));
            }
            return rv;
        }

        public List<ProductBLL> GetProductsRelatedToSeller(int SellerID, int skip, int take)
        {
            List<ProductBLL> rv = new List<ProductBLL>();
            List<ProductDAL> dalitems = ctx.GetProductsRelatedToSeller(SellerID,skip, take);
            foreach (ProductDAL dal in dalitems)
            {
                rv.Add(new ProductBLL(dal));
            }
            return rv;
        }

        public List<ProductBLL> GetProductsRelatedToSellerEMail(string EmailAddress, int skip, int take)
        {
            List<ProductBLL> rv = new List<ProductBLL>();
            List<ProductDAL> dalitems = ctx.GetProductsRelatedToSellerEMail(EmailAddress, skip, take);
            foreach (ProductDAL dal in dalitems)
            {
                rv.Add(new ProductBLL(dal));
            }
            return rv;
        }

        public List<ProductBLL> GetProductsRelatedToCategory(int CategoryID, int skip, int take)
        {
            List<ProductBLL> rv = new List<ProductBLL>();
            List<ProductDAL> dalitems = ctx.GetProductsRelatedToCategory(CategoryID,skip, take);
            foreach (ProductDAL dal in dalitems)
            {
                rv.Add(new ProductBLL(dal));
            }
            return rv;
        }
        #endregion

        #region offers
        public int CreateOffer(int ProductID,int BuyerId,decimal OfferPrice,int OfferState,DateTime ExpireDate, string Comments)
        {
            return ctx.CreateOffer( ProductID,  BuyerId,  OfferPrice,  OfferState,  ExpireDate,  Comments);
        }

        public void deleteOffer(int OfferID)
        {
            ctx.deleteOffer(OfferID);
        }

        public void JustUpdateOffer(int OfferID, int ProductID, int BuyerId, decimal OfferPrice, int OfferState, DateTime ExpireDate, string Comments)
        {
            ctx.JustUpdateOffer(OfferID, ProductID, BuyerId, OfferPrice, OfferState, ExpireDate, Comments);
        }

        public int SafeUpdateOffer(int OfferID, int OldProductID, int OldBuyerId, decimal OldOfferPrice, int OldOfferState, DateTime OldExpireDate, string OldComments,
            int NewProductID, int NewBuyerId, decimal NewOfferPrice, int NewOfferState, DateTime NewExpireDate, string NewComments)
        {
            return ctx.SafeUpdateOffer(OfferID, OldProductID, OldBuyerId, OldOfferPrice, OldOfferState, OldExpireDate, OldComments, NewProductID, NewBuyerId, NewOfferPrice, NewOfferState, NewExpireDate, NewComments);
        }

        public OfferBLL FindOfferByID(int OfferID)
        {
            OfferBLL rv = null;
            OfferDAL dal = ctx.FindOfferByID(OfferID);
            if (dal != null)
            {
                rv = new OfferBLL(dal);
            }

            return rv;
        }

        public List<OfferBLL> GetOffers(int skip, int take)
        {
            List<OfferBLL> rv = new List<OfferBLL>();
            List<OfferDAL> dalitems = ctx.GetOffers(skip, take);
            foreach (OfferDAL dal in dalitems)
            {
                rv.Add(new OfferBLL(dal));
            }
            return rv;
        }

        public List<OfferBLL> GetOffersRelatedToBuyer(int BuyerID, int skip, int take)
        {
            List<OfferBLL> rv = new List<OfferBLL>();
            List<OfferDAL> dalitems = ctx.GetOffersRelatedToBuyer(BuyerID,skip, take);
            foreach (OfferDAL dal in dalitems)
            {
                rv.Add(new OfferBLL(dal));
            }
            return rv;

        }


        public List<OfferBLL> GetOffersRelatedToBuyerEMail(string EMailAddress, int skip, int take)

        {
            List<OfferBLL> rv = new List<OfferBLL>();
            List<OfferDAL> dalitems = ctx.GetOffersRelatedToBuyerEMail(EMailAddress,skip, take);
            foreach (OfferDAL dal in dalitems)
            {
                rv.Add(new OfferBLL(dal));
            }
            return rv;
        }

        public List<OfferBLL> GetOffersRelatedToProduct(int ProductID, int skip, int take)
        {
            List<OfferBLL> rv = new List<OfferBLL>();
            List<OfferDAL> dalitems = ctx.GetOffersRelatedToProduct( ProductID, skip, take);
            foreach (OfferDAL dal in dalitems)
            {
                rv.Add(new OfferBLL(dal));
            }
            return rv;
        }
        #endregion

    }
}
