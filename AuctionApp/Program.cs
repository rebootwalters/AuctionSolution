using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DataAccessLayer;

namespace AuctionApp
{
    class Program
    {
        static void MainOld(string[] args)
        {
            SqlConnection conn;

            conn = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=AuctionProject;Integrated Security=True");
            conn.Open();
            SqlCommand cmd;
            cmd = new SqlCommand("select * from Offers", conn);


            var reader = cmd.ExecuteReader();

            Console.WriteLine($"Number of Fields:{reader.FieldCount}");

            for (int i = 0; i < reader.FieldCount; i++)
            {
                Console.WriteLine(reader.GetName(i));
            }

            List<OfferDAL> L = new List<OfferDAL>();
            int offeridcolumn = reader.GetOrdinal("OfferID");
            int productidcolumn = reader.GetOrdinal("ProductID");
            int buyeridcolumn   = reader.GetOrdinal("BuyerID");


            while (reader.Read())
            {
                //for (int i = 0; i < reader.FieldCount; i++)
                //{
                //    Console.Write(reader.GetValue(i));
                //    Console.Write(' ');

                //}
                //Console.WriteLine();

                 OfferDAL o = new OfferDAL();

                o.OfferID = reader.GetInt32(offeridcolumn);
                o.ProductID = reader.GetInt32(productidcolumn);
               
                o.BuyerID = reader.GetInt32(buyeridcolumn);
                o.OfferPrice = reader.GetDecimal(3);
                o.OfferState = reader.GetInt32(4);
                o.ExpireDate = reader.GetDateTime(5);
                if (reader.IsDBNull(6))
                {

                }
                else
                {
                    o.Comments = reader.GetString(6);
                }

                L.Add(o);

                               
            }
            // after the while loop is over
            // it is acceptable to close the connection
        }

        static void Main()
        {
            ContextDAL ctx = new ContextDAL();
            
            ctx.ConnectionString = @"Data Source=.\sqlexpress;Initial Catalog=AuctionProject;Integrated Security=True";

            var alloffers = ctx.GetOffers(0,100);
            foreach (OfferDAL o in alloffers)
            {
                ctx.deleteOffer(o.OfferID);
            }
            var allProducts = ctx.GetProducts(0, 100);
            foreach (var o in allProducts)
            {
                ctx.deleteProduct(o.ProductID);
            }
            var allUsers = ctx.GetUsers(0, 100);
            foreach (var o in allUsers)
            {
                ctx.deleteUser(o.UserID);
            }
            var allRoles = ctx.GetRoles(0, 100);
            foreach (var o in allRoles)
            {
                ctx.deleteRole(o.RoleID);
            }
            var allCategories = ctx.GetCategories(0, 100);
            foreach (var o in allCategories)
            {
                ctx.DeleteCategory(o.CategoryID);
            }

            SqlCommand cmd = new SqlCommand("TEST_ResetDatabase");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                using (var x = ctx.ExecuteCommand(cmd)) { }

            ctx.CreateCategory ("Boots");
            ctx.CreateCategory ("Books");
            ctx.CreateCategory ("Magazines");
            ctx.CreateCategory ("Apparel");
            ctx.CreateCategory ("DVDs");
            ctx.CreateCategory ("CD-ROMs");
            ctx.CreateCategory ("Records");
            ctx.CreateCategory ("Dishes");
            ctx.CreateCategory ("furnature");


            ctx.CreateRole ("Buyer");
            ctx.CreateRole ("Seller");
            ctx.CreateRole ("BuyerSeller");
            ctx.CreateRole ("Administrator");

            ctx.CreateUser ( "luckyhunter@email.com","Lucky Hunter","12345","12345",1);
            ctx.CreateUser ( "harrypotter@email.com","Harry Potter","12345","12345",1);
            ctx.CreateUser ( "lukeskywalker@email.com","Luke Skywalker","12345","12345",1);
            ctx.CreateUser ( "lucilleball@email.com","Lucille Ball","12345","12345",1);

            ctx.CreateUser ( "madseller@email.com","Mad Seller","12345","12345",2);
            ctx.CreateUser ( "hermionegranger@email.com","Hermione Granger","12345","12345",2);
            ctx.CreateUser ( "princessleia@email.com","leia Organa","12345","12345",2);
            ctx.CreateUser ( "rickiricardo@email.com","Ricki Ricardo","12345","12345",2);

            ctx.CreateUser ( "bobbyflay@email.com","Bobby Flay","12345","12345",3);
            ctx.CreateUser ( "donaldtrump@email.com","Donald Trump","12345","12345",3);

            ctx.CreateUser ( "clarkkent@email.com","Clark Kent","12345","12345",4);

            ctx.CreateProduct ( 1,5,"Olathe Boots","Size 11 Olathe 19 inch green boots",100.00m,null,null);
            ctx.CreateProduct (1,5,"justin boots","size 11.5 Justin Square toe boots",75.50m,null,null);
            ctx.CreateProduct (1,9,"Tony Lama boots","size 12 blue 3R Buckaroo boots",150.05m,null,null);
            ctx.CreateProduct (2,6,"Harry Potter Books","set of 7 books, include the entire series",45.98m,null,null);
            ctx.CreateProduct (5,7,"Star Wars DVDs","set of 10 DVDs, includes cartoons as well as movies",120.00m,null,null);
            ctx.CreateProduct (4,8,"Wizard Cloak","A Standard Cloak as seen in Lord of the Rings",250.99m,null,null);
            ctx.CreateProduct (8,8,"Hobbit Dishes","Hobbit dish set as seen in The Hobbit movie",75.00m,null,null);
            ctx.CreateProduct (4,4,"Wizard Hat","This is a blue hat with an embossed star, and moon",50m,null,null);

            DateTime today = DateTime.Now.AddDays(7);


            ctx.CreateOffer(3, 3, 160m, 0, today, null);

            ctx.CreateOffer(5, 3, 125.00m, 0, today, null);

            ctx.CreateOffer(3, 9, 175m, 0, today, null);

            ctx.CreateOffer(6, 10, 300m, 0, today, null);

            ctx.CreateOffer(7, 11, 80m, 0, today, null);




        }
    }
}
