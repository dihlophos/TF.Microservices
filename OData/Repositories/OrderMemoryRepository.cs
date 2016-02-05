using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OData.Repositories
{
    public class OrderMemoryRepository
    {
        private readonly IEnumerable<OData.Models.Order> _data;

        public OrderMemoryRepository()
        {
            _data = new[] { 
                new OData.Models.Order()
                {
                    Id = Guid.NewGuid(),
                    CUSTOMER = "Иван",
                    DESTINATION = "Москва",
                    DUEDATE = DateTime.Now,
                    LINES = new[] { 
                        new OData.Models.Order.Line { ITEM = "mars",  AMOUNT = 100, PRICE = 5, QTY = 500},
                        new OData.Models.Order.Line { ITEM = "cars", AMOUNT = 200, PRICE = 1, QTY = 200} 
                    }
                }, 
                new OData.Models.Order()
                {
                    Id = Guid.NewGuid(),
                    CUSTOMER = "Петр",
                    DESTINATION = "Москва",
                    DUEDATE = DateTime.Now,
                    LINES = new[] { 
                        new OData.Models.Order.Line { ITEM = "mars",  AMOUNT = 100, PRICE = 5, QTY = 500},
                        new OData.Models.Order.Line { ITEM = "cars", AMOUNT = 200, PRICE = 1, QTY = 200} 
                    }
                },
                new OData.Models.Order()
                {
                    Id = Guid.NewGuid(),
                    CUSTOMER = "Сергей",
                    DESTINATION = "Москва",
                    DUEDATE = DateTime.Now,
                    LINES = new[] { 
                        new OData.Models.Order.Line { ITEM = "mars",  AMOUNT = 100, PRICE = 5, QTY = 500},
                        new OData.Models.Order.Line { ITEM = "cars", AMOUNT = 200, PRICE = 1, QTY = 200} 
                    }
                }
            };
        }

        public IEnumerable<OData.Models.Order> Get()
        {
            return _data;
        }
    }
}