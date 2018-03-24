using System;
using System.Collections.Generic;
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
            return Request.CreateResponse(HttpStatusCode.Created, 5);
        }
    }
}
