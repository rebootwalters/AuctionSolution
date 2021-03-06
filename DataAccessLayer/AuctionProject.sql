USE [master]
GO
/****** Object:  Database [AuctionProject]    Script Date: 6/5/2019 8:33:39 AM ******/
/*CREATE DATABASE [AuctionProject]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'AuctionProject', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\AuctionProject.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'AuctionProject_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\AuctionProject_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO */
ALTER DATABASE [AuctionProject] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [AuctionProject].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [AuctionProject] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [AuctionProject] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [AuctionProject] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [AuctionProject] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [AuctionProject] SET ARITHABORT OFF 
GO
ALTER DATABASE [AuctionProject] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [AuctionProject] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [AuctionProject] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [AuctionProject] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [AuctionProject] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [AuctionProject] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [AuctionProject] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [AuctionProject] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [AuctionProject] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [AuctionProject] SET  DISABLE_BROKER 
GO
ALTER DATABASE [AuctionProject] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [AuctionProject] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [AuctionProject] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [AuctionProject] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [AuctionProject] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [AuctionProject] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [AuctionProject] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [AuctionProject] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [AuctionProject] SET  MULTI_USER 
GO
ALTER DATABASE [AuctionProject] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [AuctionProject] SET DB_CHAINING OFF 
GO
ALTER DATABASE [AuctionProject] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [AuctionProject] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [AuctionProject] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [AuctionProject] SET QUERY_STORE = OFF
GO
USE [AuctionProject]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 6/5/2019 8:33:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[RoleID] [int] IDENTITY(1,1) NOT NULL,
	[Role] [nvarchar](100) NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 6/5/2019 8:33:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[CategoryID] [int] IDENTITY(1,1) NOT NULL,
	[Category] [nvarchar](100) NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 6/5/2019 8:33:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[EMailAddress] [nvarchar](150) NULL,
	[Name] [nvarchar](150) NULL,
	[Password] [nvarchar](150) NULL,
	[Hash] [nvarchar](150) NULL,
	[RoleID] [int] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Offers]    Script Date: 6/5/2019 8:33:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Offers](
	[OfferID] [int] IDENTITY(1,1) NOT NULL,
	[ProductID] [int] NULL,
	[BuyerID] [int] NULL,
	[OfferPrice] [decimal](18, 2) NULL,
	[OfferState] [int] NULL,
	[ExpireDate] [datetime] NULL,
	[Comments] [nvarchar](max) NULL,
 CONSTRAINT [PK_Offers] PRIMARY KEY CLUSTERED 
(
	[OfferID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 6/5/2019 8:33:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryID] [int] NULL,
	[SellerID] [int] NULL,
	[Name] [nvarchar](50) NULL,
	[Description] [nvarchar](max) NULL,
	[ReservePrice] [decimal](18, 2) NULL,
	[WinningOfferID] [int] NULL,
	[Comments] [nvarchar](max) NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  View [dbo].[UsersWithRoles]    Script Date: 6/5/2019 8:33:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[UsersWithRoles]
AS
SELECT        dbo.Users.UserID, dbo.Users.Name, dbo.Users.RoleID, dbo.Users.EMailAddress, dbo.Users.Password, dbo.Users.Hash, dbo.Roles.Role
FROM            dbo.Users INNER JOIN
                         dbo.Roles ON dbo.Users.RoleID = dbo.Roles.RoleID INNER JOIN
                         dbo.Products ON dbo.Users.UserID = dbo.Products.SellerID INNER JOIN
                         dbo.Categories ON dbo.Products.CategoryID = dbo.Categories.CategoryID INNER JOIN
                         dbo.Offers ON dbo.Users.UserID = dbo.Offers.BuyerID AND dbo.Products.ProductID = dbo.Offers.ProductID
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([CategoryID], [Category]) VALUES (1, N'Boots')
INSERT [dbo].[Categories] ([CategoryID], [Category]) VALUES (2, N'Books')
INSERT [dbo].[Categories] ([CategoryID], [Category]) VALUES (3, N'Magazines')
INSERT [dbo].[Categories] ([CategoryID], [Category]) VALUES (4, N'Apparel')
INSERT [dbo].[Categories] ([CategoryID], [Category]) VALUES (5, N'DVDs')
INSERT [dbo].[Categories] ([CategoryID], [Category]) VALUES (6, N'CD-ROMs')
INSERT [dbo].[Categories] ([CategoryID], [Category]) VALUES (7, N'Records')
INSERT [dbo].[Categories] ([CategoryID], [Category]) VALUES (8, N'Dishes')
INSERT [dbo].[Categories] ([CategoryID], [Category]) VALUES (9, N'furnature')
SET IDENTITY_INSERT [dbo].[Categories] OFF
SET IDENTITY_INSERT [dbo].[Offers] ON 

INSERT [dbo].[Offers] ([OfferID], [ProductID], [BuyerID], [OfferPrice], [OfferState], [ExpireDate], [Comments]) VALUES (1, 3, 3, CAST(160.00 AS Decimal(18, 2)), 0, CAST(N'2019-06-10T15:49:14.083' AS DateTime), NULL)
INSERT [dbo].[Offers] ([OfferID], [ProductID], [BuyerID], [OfferPrice], [OfferState], [ExpireDate], [Comments]) VALUES (2, 5, 3, CAST(125.00 AS Decimal(18, 2)), 0, CAST(N'2019-06-10T15:49:14.083' AS DateTime), NULL)
INSERT [dbo].[Offers] ([OfferID], [ProductID], [BuyerID], [OfferPrice], [OfferState], [ExpireDate], [Comments]) VALUES (3, 3, 9, CAST(175.00 AS Decimal(18, 2)), 0, CAST(N'2019-06-10T15:49:14.083' AS DateTime), NULL)
INSERT [dbo].[Offers] ([OfferID], [ProductID], [BuyerID], [OfferPrice], [OfferState], [ExpireDate], [Comments]) VALUES (4, 6, 10, CAST(300.00 AS Decimal(18, 2)), 0, CAST(N'2019-06-10T15:49:14.083' AS DateTime), NULL)
INSERT [dbo].[Offers] ([OfferID], [ProductID], [BuyerID], [OfferPrice], [OfferState], [ExpireDate], [Comments]) VALUES (5, 7, 11, CAST(80.00 AS Decimal(18, 2)), 0, CAST(N'2019-06-10T15:49:14.083' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[Offers] OFF
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([ProductID], [CategoryID], [SellerID], [Name], [Description], [ReservePrice], [WinningOfferID], [Comments]) VALUES (1, 1, 5, N'Olathe Boots', N'Size 11 Olathe 19 inch green boots', CAST(100.00 AS Decimal(18, 2)), NULL, N'')
INSERT [dbo].[Products] ([ProductID], [CategoryID], [SellerID], [Name], [Description], [ReservePrice], [WinningOfferID], [Comments]) VALUES (2, 1, 5, N'justin boots', N'size 11.5 Justin Square toe boots', CAST(75.50 AS Decimal(18, 2)), NULL, N'')
INSERT [dbo].[Products] ([ProductID], [CategoryID], [SellerID], [Name], [Description], [ReservePrice], [WinningOfferID], [Comments]) VALUES (3, 1, 9, N'Tony Lama boots', N'size 12 blue 3R Buckaroo boots', CAST(150.05 AS Decimal(18, 2)), NULL, N'')
INSERT [dbo].[Products] ([ProductID], [CategoryID], [SellerID], [Name], [Description], [ReservePrice], [WinningOfferID], [Comments]) VALUES (4, 2, 6, N'Harry Potter Books', N'set of 7 books, include the entire series', CAST(45.98 AS Decimal(18, 2)), NULL, N'')
INSERT [dbo].[Products] ([ProductID], [CategoryID], [SellerID], [Name], [Description], [ReservePrice], [WinningOfferID], [Comments]) VALUES (5, 5, 7, N'Star Wars DVDs', N'set of 10 DVDs, includes cartoons as well as movies', CAST(120.00 AS Decimal(18, 2)), NULL, N'')
INSERT [dbo].[Products] ([ProductID], [CategoryID], [SellerID], [Name], [Description], [ReservePrice], [WinningOfferID], [Comments]) VALUES (6, 4, 8, N'Wizard Cloak', N'A Standard Cloak as seen in Lord of the Rings', CAST(250.99 AS Decimal(18, 2)), NULL, N'')
INSERT [dbo].[Products] ([ProductID], [CategoryID], [SellerID], [Name], [Description], [ReservePrice], [WinningOfferID], [Comments]) VALUES (7, 8, 8, N'Hobbit Dishes', N'Hobbit dish set as seen in The Hobbit movie', CAST(75.00 AS Decimal(18, 2)), NULL, N'')
INSERT [dbo].[Products] ([ProductID], [CategoryID], [SellerID], [Name], [Description], [ReservePrice], [WinningOfferID], [Comments]) VALUES (8, 4, 4, N'Wizard Hat', N'This is a blue hat with an embossed star, and moon', CAST(50.00 AS Decimal(18, 2)), NULL, N'')
SET IDENTITY_INSERT [dbo].[Products] OFF
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([RoleID], [Role]) VALUES (1, N'Buyer')
INSERT [dbo].[Roles] ([RoleID], [Role]) VALUES (2, N'Seller')
INSERT [dbo].[Roles] ([RoleID], [Role]) VALUES (3, N'BuyerSeller')
INSERT [dbo].[Roles] ([RoleID], [Role]) VALUES (4, N'Administrator')
SET IDENTITY_INSERT [dbo].[Roles] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([UserID], [EMailAddress], [Name], [Password], [Hash], [RoleID]) VALUES (1, N'luckyhunter@email.com', N'Lucky Hunter', N'12345', N'12345', 1)
INSERT [dbo].[Users] ([UserID], [EMailAddress], [Name], [Password], [Hash], [RoleID]) VALUES (2, N'harrypotter@email.com', N'Harry Potter', N'12345', N'12345', 1)
INSERT [dbo].[Users] ([UserID], [EMailAddress], [Name], [Password], [Hash], [RoleID]) VALUES (3, N'lukeskywalker@email.com', N'Luke Skywalker', N'12345', N'12345', 1)
INSERT [dbo].[Users] ([UserID], [EMailAddress], [Name], [Password], [Hash], [RoleID]) VALUES (4, N'lucilleball@email.com', N'Lucille Ball', N'12345', N'12345', 1)
INSERT [dbo].[Users] ([UserID], [EMailAddress], [Name], [Password], [Hash], [RoleID]) VALUES (5, N'madseller@email.com', N'Mad Seller', N'12345', N'12345', 2)
INSERT [dbo].[Users] ([UserID], [EMailAddress], [Name], [Password], [Hash], [RoleID]) VALUES (6, N'hermionegranger@email.com', N'Hermione Granger', N'12345', N'12345', 2)
INSERT [dbo].[Users] ([UserID], [EMailAddress], [Name], [Password], [Hash], [RoleID]) VALUES (7, N'princessleia@email.com', N'leia Organa', N'12345', N'12345', 2)
INSERT [dbo].[Users] ([UserID], [EMailAddress], [Name], [Password], [Hash], [RoleID]) VALUES (8, N'rickiricardo@email.com', N'Ricki Ricardo', N'12345', N'12345', 2)
INSERT [dbo].[Users] ([UserID], [EMailAddress], [Name], [Password], [Hash], [RoleID]) VALUES (9, N'bobbyflay@email.com', N'Bobby Flay', N'12345', N'12345', 3)
INSERT [dbo].[Users] ([UserID], [EMailAddress], [Name], [Password], [Hash], [RoleID]) VALUES (10, N'donaldtrump@email.com', N'Donald Trump', N'12345', N'12345', 3)
INSERT [dbo].[Users] ([UserID], [EMailAddress], [Name], [Password], [Hash], [RoleID]) VALUES (11, N'clarkkent@email.com', N'Clark Kent', N'12345', N'12345', 4)
SET IDENTITY_INSERT [dbo].[Users] OFF
SET ANSI_PADDING ON
GO
/****** Object:  Index [NonClusteredIndex-20190515-114455]    Script Date: 6/5/2019 8:33:39 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [NonClusteredIndex-20190515-114455] ON [dbo].[Users]
(
	[EMailAddress] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Offers]  WITH CHECK ADD  CONSTRAINT [FK_Offers_Products] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Products] ([ProductID])
GO
ALTER TABLE [dbo].[Offers] CHECK CONSTRAINT [FK_Offers_Products]
GO
ALTER TABLE [dbo].[Offers]  WITH CHECK ADD  CONSTRAINT [FK_Offers_Users] FOREIGN KEY([BuyerID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Offers] CHECK CONSTRAINT [FK_Offers_Users]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Categories] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Categories] ([CategoryID])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Categories]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Users] FOREIGN KEY([SellerID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Users]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Roles] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Roles] ([RoleID])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Roles]
GO
/****** Object:  StoredProcedure [dbo].[CreateCategory]    Script Date: 6/5/2019 8:33:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Brian Walters
-- Create date: 5/15/2019
-- Description:	Create a New Role
-- =============================================
Create PROCEDURE [dbo].[CreateCategory] 
	-- Add the parameters for the stored procedure here
	@CategoryID int output, 
	@Category nvarchar(100)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO [dbo].[Categories]
           ([Category])
     VALUES
           (@Category);

select @CategoryID = @@IDENTITY;
END
GO
/****** Object:  StoredProcedure [dbo].[CreateOffer]    Script Date: 6/5/2019 8:33:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Brian Walters
-- Create date: 5/15/2019
-- Description:	Create a New Role
-- =============================================
Create PROCEDURE [dbo].[CreateOffer] 
	-- Add the parameters for the stored procedure here
	@OfferID int output, 
	@ProductID int,
	@BuyerID int,
	@OfferPrice decimal(18,2),
	@OfferState int,
	@ExpireDate DateTime,
	@Comments nvarchar(max)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO [dbo].[Offers]
           (ProductID,BuyerID,OfferPrice,OfferState,ExpireDate,Comments)
     VALUES
           (@ProductID,@BuyerID,@OfferPrice,@OfferState,@ExpireDate,@Comments);

select @OfferID = @@IDENTITY;
END
GO
/****** Object:  StoredProcedure [dbo].[CreateProduct]    Script Date: 6/5/2019 8:33:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Brian Walters
-- Create date: 5/15/2019
-- Description:	Create a New Role
-- =============================================
CREATE PROCEDURE [dbo].[CreateProduct] 
	-- Add the parameters for the stored procedure here
	@ProductID int output, 
	@CategoryID int,
	@SellerID int,
	@Name nvarchar(50),
	@Description nvarchar(max),
	@ReservePrice decimal(18,2),
	@WinningOfferID int null,
	@Comments nvarchar(max) null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO [dbo].[Products]
           (CategoryID,SellerID,Name,Description,ReservePrice,WinningOfferID,Comments)
     VALUES
           (@CategoryID,@SellerID,@Name,@Description,@ReservePrice,@WinningOfferID,@Comments);

select @ProductID = @@IDENTITY;
END
GO
/****** Object:  StoredProcedure [dbo].[CreateRole]    Script Date: 6/5/2019 8:33:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Brian Walters
-- Create date: 5/15/2019
-- Description:	Create a New Role
-- =============================================
CREATE PROCEDURE [dbo].[CreateRole] 
	-- Add the parameters for the stored procedure here
	@RoleID int output, 
	@Role nvarchar(100)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO [dbo].[Roles]
           ([Role])
     VALUES
           (@Role);

select @RoleID = @@IDENTITY;
END
GO
/****** Object:  StoredProcedure [dbo].[CreateUser]    Script Date: 6/5/2019 8:33:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Brian Walters
-- Create date: 5/15/2019
-- Description:	Create a New Role
-- =============================================
create PROCEDURE [dbo].[CreateUser] 
	-- Add the parameters for the stored procedure here
	@UserID int output, 
	@EMailAddress nvarchar(150),
	@Name nvarchar(150),
	@Password nvarchar(150),
	@Hash nvarchar(150),
	@RoleID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO [dbo].[Users]
           ([EMailAddress],Name,Password,Hash,RoleID)
     VALUES
           (@EMailAddress,@Name,@Password,@Hash,@RoleID);

select @UserID = @@IDENTITY;
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteCategory]    Script Date: 6/5/2019 8:33:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create PROCEDURE [dbo].[DeleteCategory]
	-- Add the parameters for the stored procedure here
	@CategoryID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	delete from Categories where @CategoryID = CategoryID
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteOffer]    Script Date: 6/5/2019 8:33:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[DeleteOffer]
	-- Add the parameters for the stored procedure here
	@OfferID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	delete from Offers where @OfferID = OfferID
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteProduct]    Script Date: 6/5/2019 8:33:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[DeleteProduct]
	-- Add the parameters for the stored procedure here
	@ProductID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	delete from Products where @ProductID = ProductID
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteRole]    Script Date: 6/5/2019 8:33:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteRole]
	-- Add the parameters for the stored procedure here
	@RoleID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	delete from Roles where @RoleID = RoleID
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteUser]    Script Date: 6/5/2019 8:33:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[DeleteUser]
	-- Add the parameters for the stored procedure here
	@UserID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	delete from Users where @UserID = UserID
END
GO
/****** Object:  StoredProcedure [dbo].[FindCategoryByID]    Script Date: 6/5/2019 8:33:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create PROCEDURE [dbo].[FindCategoryByID]
	-- Add the parameters for the stored procedure here
	@CategoryID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Select CategoryID, Category from Categories where CategoryID = @CategoryID
END
GO
/****** Object:  StoredProcedure [dbo].[FindOfferByID]    Script Date: 6/5/2019 8:33:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[FindOfferByID]
	-- Add the parameters for the stored procedure here
	@OfferID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Select OfferId, Offers.ProductID, BuyerID, OfferPrice, Offerstate, ExpireDate, Offers.Comments,
	     Products.Name as ProductName,
		 Users.Name as BuyerName, Users.EMailAddress
	     from offers 
		 inner join Users on Users.UserID = Offers.BuyerID
		 inner join Products on Products.ProductID = Offers.ProductID
		 where OfferID = @OfferID
END
GO
/****** Object:  StoredProcedure [dbo].[FindProductByID]    Script Date: 6/5/2019 8:33:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[FindProductByID]
	-- Add the parameters for the stored procedure here
	@ProductID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Select ProductID, Products.CategoryID, SellerID, Products.Name as ProductName,Description, ReservePrice, WinningOfferID, Comments,
	    Category,
		EMailAddress as SellerEMail, Users.Name as SellerName
		
		from Products 
	inner join Users on users.UserID = SellerID
	inner join Categories on Products.CategoryID = Categories.CategoryID
	where ProductID = @ProductID
END
GO
/****** Object:  StoredProcedure [dbo].[FindRoleByID]    Script Date: 6/5/2019 8:33:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[FindRoleByID]
	-- Add the parameters for the stored procedure here
	@RoleID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Select RoleID, Role from Roles where RoleID = @RoleID
END
GO
/****** Object:  StoredProcedure [dbo].[FindUserByEMailAddress]    Script Date: 6/5/2019 8:33:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[FindUserByEMailAddress]
	-- Add the parameters for the stored procedure here
	@EMailAddress nvarchar(150)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Select UserID, EMailAddress,Name,Password,Hash,Users.RoleID,Role from Users 
	inner join Roles on Users.RoleID = Roles.RoleID
	where EMailAddress = @EMailAddress
END
GO
/****** Object:  StoredProcedure [dbo].[FindUserByID]    Script Date: 6/5/2019 8:33:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[FindUserByID]
	-- Add the parameters for the stored procedure here
	@UserID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Select UserID, EMailAddress,Name,Password,Hash,Users.RoleID,
	Role 
	from Users 
	inner join Roles on users.RoleID = Roles.RoleID
	where UserID = @UserID
END
GO
/****** Object:  StoredProcedure [dbo].[GetCategories]    Script Date: 6/5/2019 8:33:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[GetCategories]

   @skip int,
   @take int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here 
	select CategoryID, Category from Categories order by Category OFFSET @skip rows fetch next @take rows only;
end
GO
/****** Object:  StoredProcedure [dbo].[GetOffers]    Script Date: 6/5/2019 8:33:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[GetOffers]

   @skip int,
   @take int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here 
	Select OfferId, Offers.ProductID, BuyerID, OfferPrice, Offerstate, ExpireDate, Offers.Comments,
	     Products.Name as ProductName,
		 Users.Name as BuyerName, Users.EMailAddress
	     from offers 
		 inner join Users on Users.UserID = Offers.BuyerID
		 inner join Products on Products.ProductID = Offers.ProductID
	order by OfferID OFFSET @skip rows fetch next @take rows only;
end
GO
/****** Object:  StoredProcedure [dbo].[GetOffersRelatedToEMail]    Script Date: 6/5/2019 8:33:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[GetOffersRelatedToEMail]

   @EMail nvarchar(150),
   @skip int,
   @take int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here 
	Select OfferId, Offers.ProductID, BuyerID, OfferPrice, Offerstate, ExpireDate, Offers.Comments,
	     Products.Name as ProductName,
		 Users.Name as BuyerName, Users.EMailAddress
	     from offers 
		 inner join Users on Users.UserID = Offers.BuyerID
		 inner join Products on Products.ProductID = Offers.ProductID
		 where Users.EMailAddress = @EMail
	order by OfferID OFFSET @skip rows fetch next @take rows only;
end
GO
/****** Object:  StoredProcedure [dbo].[GetOffersRelatedToProduct]    Script Date: 6/5/2019 8:33:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[GetOffersRelatedToProduct]

   @ProductID int,
   @skip int,
   @take int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here 
	Select OfferId, Offers.ProductID, BuyerID, OfferPrice, Offerstate, ExpireDate, Offers.Comments,
	     Products.Name as ProductName,
		 Users.Name as BuyerName, Users.EMailAddress
	     from offers 
		 inner join Users on Users.UserID = Offers.BuyerID
		 inner join Products on Products.ProductID = Offers.ProductID
		 where Offers.ProductID = @ProductID
	order by OfferID OFFSET @skip rows fetch next @take rows only;
end
GO
/****** Object:  StoredProcedure [dbo].[GetOffersRelatedToUserID]    Script Date: 6/5/2019 8:33:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[GetOffersRelatedToUserID]

   @UserID int,
   @skip int,
   @take int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here 
	Select OfferId, Offers.ProductID, BuyerID, OfferPrice, Offerstate, ExpireDate, Offers.Comments,
	     Products.Name as ProductName,
		 Users.Name as BuyerName, Users.EMailAddress
	     from offers 
		 inner join Users on Users.UserID = Offers.BuyerID
		 inner join Products on Products.ProductID = Offers.ProductID
		 where Offers.BuyerID = @UserID
	order by OfferID OFFSET @skip rows fetch next @take rows only;
end
GO
/****** Object:  StoredProcedure [dbo].[GetProducts]    Script Date: 6/5/2019 8:33:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[GetProducts]

   @skip int,
   @take int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here 
	Select ProductID, Products.CategoryID, SellerID, Products.Name as ProductName,Description, ReservePrice, WinningOfferID, Comments,
	    Category,
		EMailAddress as SellerEMail, Users.Name as SellerName
		
		from Products 
	inner join Users on users.UserID = SellerID
	inner join Categories on Products.CategoryID = Categories.CategoryID
	order by ProductName, ProductID OFFSET @skip rows fetch next @take rows only;
end
GO
/****** Object:  StoredProcedure [dbo].[GetProductsRelatedToCategory]    Script Date: 6/5/2019 8:33:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[GetProductsRelatedToCategory]

   @CategoryID int,
   @skip int,
   @take int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here 
	Select ProductID, Products.CategoryID, SellerID, Products.Name as ProductName,Description, ReservePrice, WinningOfferID, Comments,
	    Category,
		EMailAddress as SellerEMail, Users.Name as SellerName
		
		from Products 
	inner join Users on users.UserID = SellerID
	inner join Categories on Products.CategoryID = Categories.CategoryID
	where Products.CategoryID = @CategoryID
	order by ProductName, ProductID OFFSET @skip rows fetch next @take rows only;
end
GO
/****** Object:  StoredProcedure [dbo].[GetProductsRelatedToEMail]    Script Date: 6/5/2019 8:33:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetProductsRelatedToEMail]

   @EMail nvarchar(150),
   @skip int,
   @take int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here 
	Select ProductID, Products.CategoryID, SellerID, Products.Name as ProductName,Description, ReservePrice, WinningOfferID, Comments,
	    Category,
		EMailAddress as SellerEMail, Users.Name as SellerName
		
		from Products 
	inner join Users on users.UserID = SellerID
	inner join Categories on Products.CategoryID = Categories.CategoryID
	where Users.EMailAddress = @EMail
	order by ProductName, ProductID OFFSET @skip rows fetch next @take rows only;
end
GO
/****** Object:  StoredProcedure [dbo].[GetProductsRelatedToUserID]    Script Date: 6/5/2019 8:33:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[GetProductsRelatedToUserID]

   @UserID int,
   @skip int,
   @take int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here 
	Select ProductID, Products.CategoryID, SellerID, Products.Name as ProductName,Description, ReservePrice, WinningOfferID, Comments,
	    Category,
		EMailAddress as SellerEMail, Users.Name as SellerName
		
		from Products 
	inner join Users on users.UserID = SellerID
	inner join Categories on Products.CategoryID = Categories.CategoryID
	where Products.SellerID = @UserID
	order by ProductName, ProductID OFFSET @skip rows fetch next @take rows only;
end
GO
/****** Object:  StoredProcedure [dbo].[GetRoles]    Script Date: 6/5/2019 8:33:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetRoles]

   @skip int,
   @take int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here 
	select RoleID, Role from Roles order by Role OFFSET @skip rows fetch next @take rows only;
end
GO
/****** Object:  StoredProcedure [dbo].[GetUsers]    Script Date: 6/5/2019 8:33:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[GetUsers]

   @skip int,
   @take int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here 
	Select UserID, EMailAddress,Name,Password,Hash,Users.RoleID,Role from Users 
	inner join Roles on Users.RoleID = Roles.RoleID
	order by UserID OFFSET @skip rows fetch next @take rows only;
end
GO
/****** Object:  StoredProcedure [dbo].[GetUsersRelatedToRole]    Script Date: 6/5/2019 8:33:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[GetUsersRelatedToRole]

   @RoleID int,
   @skip int,
   @take int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here 
	Select UserID, EMailAddress,Name,Password,Hash,Users.RoleID,Role from Users 
	inner join Roles on Users.RoleID = Roles.RoleID
	where Users.RoleID = @RoleID
	order by UserID OFFSET @skip rows fetch next @take rows only;
end
GO
/****** Object:  StoredProcedure [dbo].[JustUpdateCategory]    Script Date: 6/5/2019 8:33:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[JustUpdateCategory]
	-- Add the parameters for the stored procedure here
	@CategoryID int,
	@Category nvarchar(100)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	update Categories set Category = @Category where @CategoryID = CategoryID
END
GO
/****** Object:  StoredProcedure [dbo].[JustUpdateOffer]    Script Date: 6/5/2019 8:33:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create PROCEDURE [dbo].[JustUpdateOffer]
	-- Add the parameters for the stored procedure here
    @OfferID int,
	@ProductID int, 
	@BuyerID int,
	@OfferPrice decimal(18,2),
	@OfferState int,
	@ExpireDate datetime,
	@Comments nvarchar(max)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	update Offers set ProductID = @ProductID, BuyerID = @BuyerID, OfferPrice = @OfferPrice, OfferState = @OfferState,
	       ExpireDate = @ExpireDate, Comments = @Comments 
		   where OfferID = @OfferID
END
GO
/****** Object:  StoredProcedure [dbo].[JustUpdateProduct]    Script Date: 6/5/2019 8:33:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[JustUpdateProduct]
	-- Add the parameters for the stored procedure here
    @ProductID int, 
	@CategoryID int,
	@SellerID int,
	@Name nvarchar(50),
	@Description nvarchar(max),
	@ReservePrice decimal(18,2),
	@WinningOfferID int,
	@Comments nvarchar(max)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	update Products set CategoryID = @CategoryID, SellerId = @SellerID, Name = @name, Description = @Description,
	       ReservePrice = @ReservePrice, WinningOfferID = @WinningOfferID, Comments = @Comments 
		   where ProductID = @ProductID
END
GO
/****** Object:  StoredProcedure [dbo].[JustUpdateRole]    Script Date: 6/5/2019 8:33:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[JustUpdateRole]
	-- Add the parameters for the stored procedure here
	@RoleID int,
	@Role nvarchar(100)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	update Roles set Role = @Role where @RoleID = RoleID
END
GO
/****** Object:  StoredProcedure [dbo].[JustUpdateUser]    Script Date: 6/5/2019 8:33:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[JustUpdateUser]
	-- Add the parameters for the stored procedure here
	@UserID int, 
	@EMailAddress nvarchar(150),
	@Name nvarchar(150),
	@Password nvarchar(150),
	@Hash nvarchar(150),
	@RoleID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	update Users set EMailAddress = @EMailAddress, Name = @Name, Password = @Password,
	                 Hash = @Hash, RoleID = @RoleID 
		   where UserID = @UserID
END
GO
/****** Object:  StoredProcedure [dbo].[SafeUpdateCategory]    Script Date: 6/5/2019 8:33:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SafeUpdateCategory]
	-- Add the parameters for the stored procedure here
	@CategoryID int,
	@OldCategory nvarchar(100),
	@NewCategory nvarchar(100)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	declare @rv int
	SET NOCOUNT ON;
	 select @rv =  count(*) from Categories       where @CategoryID = CategoryID AND Category = @OldCategory
    -- Insert statements for procedure here
	update Categories set Category = @NewCategory where @CategoryID = CategoryID AND Category = @OldCategory
    return @rv
END
GO
/****** Object:  StoredProcedure [dbo].[SafeUpdateOffer]    Script Date: 6/5/2019 8:33:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SafeUpdateOffer]
	-- Add the parameters for the stored procedure here
    @OfferID int,
	@NewProductID int, 
	@NewBuyerID int,
	@NewOfferPrice decimal(18,2),
	@NewOfferState int,
	@NewExpireDate datetime,
	@NewComments nvarchar(max),
	@OldProductID int, 
	@OldBuyerID int,
	@OldOfferPrice decimal(18,2),
	@OldOfferState int,
	@OldExpireDate datetime,
	@OldComments nvarchar(max)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	declare @rv int
	select @rv = count(*) from Offers where OfferID = @OfferID and ProductId = @OldProductID and BuyerID = @OldBuyerID and OfferPrice = @OldOfferPrice and
		   OfferState = @OldOfferstate and ExpireDate = @OldExpireDate and Comments = @OldComments
    -- Insert statements for procedure here
	update Offers set ProductID = @NewProductID, BuyerID = @NewBuyerID, OfferPrice = @NewOfferPrice, OfferState = @NewOfferState,
	       ExpireDate = @NewExpireDate, Comments = @NewComments 
		   where OfferID = @OfferID and ProductId = @OldProductID and BuyerID = @OldBuyerID and OfferPrice = @OldOfferPrice and
		   OfferState = @OldOfferstate and ExpireDate = @OldExpireDate and Comments = @OldComments
    return @rv
END
GO
/****** Object:  StoredProcedure [dbo].[SafeUpdateProduct]    Script Date: 6/5/2019 8:33:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SafeUpdateProduct]
	-- Add the parameters for the stored procedure here
    @ProductID int, 
	@NewCategoryID int,
	@NewSellerID int,
	@NewName nvarchar(50),
	@NewDescription nvarchar(max),
	@NewReservePrice decimal(18,2),
	@NewWinningOfferID int,
	@NewComments nvarchar(max),
	@OldCategoryID int,
	@OldSellerID int,
	@OldName nvarchar(50),
	@OldDescription nvarchar(max),
	@OldReservePrice decimal(18,2),
	@OldWinningOfferID int,
	@OldComments nvarchar(max)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	declare @rv int
	select @rv = count(*) from Products  where ProductID = @ProductID and CategoryID = @OldCategoryID and SellerID = @OldSellerID and Name = @OldName
		   and Description = @OldDescription and ReservePrice = @OldReservePrice and WinningOfferId = @OldWinningOfferID
		   and Comments = @OldComments
    -- Insert statements for procedure here
	update Products set CategoryID = @NewCategoryID, SellerId = @NewSellerID, Name = @NewName, Description = @NewDescription,
	       ReservePrice = @NewReservePrice, WinningOfferID = @NewWinningOfferID, Comments = @NewComments 
		   where ProductID = @ProductID and CategoryID = @OldCategoryID and SellerID = @OldSellerID and Name = @OldName
		   and Description = @OldDescription and ReservePrice = @OldReservePrice and WinningOfferId = @OldWinningOfferID
		   and Comments = @OldComments
    return @rv
END
GO
/****** Object:  StoredProcedure [dbo].[SafeUpdateRole]    Script Date: 6/5/2019 8:33:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SafeUpdateRole]
	-- Add the parameters for the stored procedure here
	@RoleID int,
	@OldRole nvarchar(100),
	@NewRole nvarchar(100)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	declare @rv int
	select @rv = count(*) from Roles where @RoleID = RoleID AND Role = @OldRole

    -- Insert statements for procedure here
	update Roles set Role = @NewRole where @RoleID = RoleID AND Role = @OldRole
	return @rv
END
GO
/****** Object:  StoredProcedure [dbo].[SafeUpdateUser]    Script Date: 6/5/2019 8:33:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SafeUpdateUser]
	-- Add the parameters for the stored procedure here
	@UserID int, 
	@NewEMailAddress nvarchar(150),
	@NewName nvarchar(150),
	@NewPassword nvarchar(150),
	@NewHash nvarchar(150),
	@NewRoleID int,
	@OldEMailAddress nvarchar(150),
	@OldName nvarchar(150),
	@OldPassword nvarchar(150),
	@OldHash nvarchar(150),
	@OldRoleID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	declare @rv int
	select @rv = count(*) from Users  where UserID = @UserID and EMailAddress = @OldEMailAddress and Name = @OldName and
		   Password = @OldPassword and Hash = @OldHash and RoleID = @OldRoleID
    -- Insert statements for procedure here
	update Users set EMailAddress = @NewEMailAddress, Name = @NewName, Password = @NewPassword,
	                 Hash = @NewHash, RoleID = @newRoleID 
		   where UserID = @UserID and EMailAddress = @OldEMailAddress and Name = @OldName and
		   Password = @OldPassword and Hash = @OldHash and RoleID = @OldRoleID
	return @rv
END
GO
/****** Object:  StoredProcedure [dbo].[TEST_Creates]    Script Date: 6/5/2019 8:33:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[TEST_Creates]

AS
BEGIN
     declare @id int;

      exec CreateCategory @id,'Boots';
	  exec CreateCategory @id,'Books';
	  exec CreateCategory @id,'Magazines';
	  exec CreateCategory @id,'Apparel';
	  exec CreateCategory @id,'DVDs';
	  exec CreateCategory @id,'CD-ROMs';
	  exec createcategory @id,'Records';
      exec createcategory @id,'Dishes';
	  exec createcategory @id,'furnature';


	  exec createrole @id,'Buyer';
	  exec createrole @id,'Seller';
	  exec createrole @id,'BuyerSeller';
	  exec createrole @id,'Administrator';

	  exec createuser @id, 'luckyhunter@email.com','Lucky Hunter','12345','12345',1;
	  exec createuser @id, 'harrypotter@email.com','Harry Potter','12345','12345',1;
	  exec createuser @id, 'lukeskywalker@email.com','Luke Skywalker','12345','12345',1;
	  exec createuser @id, 'lucilleball@email.com','Lucille Ball','12345','12345',1;

	  exec createuser @id, 'madseller@email.com','Mad Seller','12345','12345',2;
	  exec createuser @id, 'hermionegranger@email.com','Hermione Granger','12345','12345',2;
	  exec createuser @id, 'princessleia@email.com','leia Organa','12345','12345',2;
	  exec createuser @id, 'rickiricardo@email.com','Ricki Ricardo','12345','12345',2;

	  exec createuser @id, 'bobbyflay@email.com','Bobby Flay','12345','12345',3;
	  exec createuser @id, 'donaldtrump@email.com','Donald Trump','12345','12345',3;

	  exec createuser @id, 'clarkkent@email.com','Clark Kent','12345','12345',4;

      exec createproduct @id, 1,5,'Olathe Boots','Size 11 Olathe 19 inch green boots',100.00,null,null;
	  exec createproduct @id,1,5,'justin boots','size 11.5 Justin Square toe boots',75.50,null,null;
	  exec createproduct @id,1,9,'Tony Lama boots','size 12 blue 3R Buckaroo boots',150.05,null,null;
	  exec createproduct @id,2,6,'Harry Potter Books','set of 7 books, include the entire series',45.98,null,null;
	  exec createproduct @id,5,7,'Star Wars DVDs','set of 10 DVDs, includes cartoons as well as movies',120.00,null,null;
	  exec createproduct @id,4,8,'Wizard Cloak','A Standard Cloak as seen in Lord of the Rings',250.99,null,null;
	  exec createproduct @id,8,8,'Hobbit Dishes','Hobbit dish set as seen in The Hobbit movie',75.00,null,null;
	  exec createproduct @id,4,4,'Wizard Hat','This is a blue hat with an embossed star, and moon',50,null,null;

	 declare @date datetime
	 select @Date = dateadd(dd,7,getdate())
	  exec createoffer @id,3,3,160,0,@date,null
	  exec createoffer @id,5,3,125.00,0,@date,null
	  exec createoffer @id,3,9,175,0,@date,null
	  exec createoffer @id,6,10,300,0,@date,null
	  exec createoffer @id,7,11,80,0,@date,null






	end
GO
/****** Object:  StoredProcedure [dbo].[TEST_ResetDatabase]    Script Date: 6/5/2019 8:33:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[TEST_ResetDatabase]

AS
BEGIN
	
	delete from offers;
	delete from products;
	delete from users;
	delete from categories;
	delete from roles;

	DBCC CHECKIDENT ('offers', RESEED, 0)  
    DBCC CHECKIDENT ('products', RESEED, 0)  
	DBCC CHECKIDENT ('users', RESEED, 0)  
	DBCC CHECKIDENT ('categories', RESEED, 0)  
	DBCC CHECKIDENT ('roles', RESEED, 0)  
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[68] 4[4] 2[10] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Users"
            Begin Extent = 
               Top = 193
               Left = 73
               Bottom = 364
               Right = 243
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Roles"
            Begin Extent = 
               Top = 261
               Left = 476
               Bottom = 357
               Right = 646
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Products"
            Begin Extent = 
               Top = 14
               Left = 348
               Bottom = 144
               Right = 520
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Categories"
            Begin Extent = 
               Top = 35
               Left = 48
               Bottom = 131
               Right = 218
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Offers"
            Begin Extent = 
               Top = 86
               Left = 649
               Bottom = 216
               Right = 819
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'UsersWithRoles'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'UsersWithRoles'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'UsersWithRoles'
GO
USE [master]
GO
ALTER DATABASE [AuctionProject] SET  READ_WRITE 
GO
