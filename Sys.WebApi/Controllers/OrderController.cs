using Sys.Data.BaseRepositories;
using Sys.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Sys.WebApi.Controllers
{
    
    public class OrderController : ApiController
    {
        IEfRepository<Order> _order;
        public OrderController()
        {
            _order = new EfRepository<Order>();
        }
        public IHttpActionResult GetAll()
        {
            return Ok(_order.GetAll());
        }
    }
}
