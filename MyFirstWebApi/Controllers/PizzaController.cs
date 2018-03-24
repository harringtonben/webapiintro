using Dapper;
using MyFirstWebApi.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyFirstWebApi.Controllers
{
    [RoutePrefix("orderapi/pizza")]
    public class PizzaController : ApiController
    {
        [HttpPost,Route("{id}")]
        public HttpResponseMessage PlaceOrder(int id)
        {
            if (id == 10)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "No order with that id was found");
            }
            return Request.CreateResponse(HttpStatusCode.Created, 5);
        }

        [HttpGet,Route("")]
        public HttpResponseMessage GetAllOrders()
        {
            using (var db = new SqlConnection(ConfigurationManager.ConnectionStrings["PizzaTime"].ConnectionString))
            {
                db.Open();

                var orders = db.Query<Order>("select * from Orders");

                return Request.CreateResponse(HttpStatusCode.OK, orders);

            }
        }

        [HttpGet, Route("{id}")]
        public HttpResponseMessage GetOrder(int id)
        {
            using (var db = new SqlConnection(ConfigurationManager.ConnectionStrings["PizzaTime"].ConnectionString))
            {
                db.Open();

                var order = db.QueryFirst<Order>("select * from Orders where Id = @id", new {id});

                return Request.CreateResponse(HttpStatusCode.OK, order); 
            }
        }
    }
}
