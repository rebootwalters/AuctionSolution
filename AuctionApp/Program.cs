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

              int i = ctx.CreateCategory("Houses");
           
            Console.WriteLine($"Created record {i}");
            Console.WriteLine("Press return to continue executing and list all categories.....");
            Console.ReadLine();
            foreach (var x in ctx.GetCategories(0,100))
            {
                Console.WriteLine(x);
            }


            Console.WriteLine("Press return to continue executing and delete the new record.....");
            Console.ReadLine();
            ctx.DeleteCategory(i);
            Console.WriteLine($"Deleted record {i}");
            




        }
    }
}
