using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Query;
using System.Web.Http.OData.Routing;
using OData.Models;
using Microsoft.Data.OData;

namespace OData.Controllers
{
    public class OrdersController : ODataController
    {
        private static ODataValidationSettings _validationSettings = new ODataValidationSettings();

        // GET: odata/Orders
        public async Task<IHttpActionResult> GetOrders(ODataQueryOptions<Order> queryOptions)
        {
            // validate the query.
            try
            {
                queryOptions.Validate(_validationSettings);
            }
            catch (ODataException ex)
            {
                return BadRequest(ex.Message);
            }

            var repository = new Repositories.OrderMemoryRepository();
            var orders = queryOptions.ApplyTo(repository.Get().AsQueryable<Order>());

            return Ok<IQueryable<Order>>((IQueryable<Order>)orders);
        }

        // GET: odata/Orders(5)
        public async Task<IHttpActionResult> GetOrder([FromODataUri] System.Guid key, ODataQueryOptions<Order> queryOptions)
        {
            // validate the query.
            try
            {
                queryOptions.Validate(_validationSettings);
            }
            catch (ODataException ex)
            {
                return BadRequest(ex.Message);
            }

            // return Ok<Order>(order);
            return StatusCode(HttpStatusCode.NotImplemented);
        }
    }
}
