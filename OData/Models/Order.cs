using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OData.Models
{
    /// <summary>
    /// Базовый класс "Заказ"
    /// </summary>
    public class Order
    {
        [Key]
        public Guid Id { get; set; }

        public DateTime DUEDATE { get; set; }
        public string CUSTOMER { get; set; }
        public string DESTINATION { get; set; }

        public IEnumerable<Line> LINES { get; set; }

        /// <summary>
        /// Базовый класс "Позиция заказа"
        /// </summary>
        public class Line
        {
            public string ITEM { get; set; }
            public decimal QTY { get; set; }
            public decimal PRICE { get; set; }
            public decimal AMOUNT { get; set; }
        }
    }
}