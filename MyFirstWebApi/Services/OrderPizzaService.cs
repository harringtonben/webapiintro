using Dapper;
using MyFirstWebApi.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MyFirstWebApi.Services
{
    public class OrderPizzaService
    {
        public bool OrderPizza(Order order)
        {
            using (var db = new SqlConnection(ConfigurationManager.ConnectionStrings["PizzaTime"].ConnectionString))
            {
                db.Open();

                var createOrder = db.Execute(@"insert into Orders (TypeOfPizza,NumberOfPizzas,Cost,AddressForDelivery,NameOfCustomer)
                                         Values(@TypeOfPizza,@NumberOfPizzas,@Cost,@AddressForDelivery,@NameOfCustomer)", order);

                return createOrder == 1;
            }
        }

    }
}