using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TF
{
    /// <summary>
    /// Базовый класс "Заказ"
    /// </summary>
    public class Order
    {
        public DateTime DUEDATE { get; set; }
        public string CUSTOMER { get; set; }
        public string DESTINATION { get; set; }

        public IEnumerable<Line> LINES { get; set; }

        /// <summary>
        /// Базовый класс "Позиция заказа"
        /// </summary>
        public class Line
        {
            string ITEM { get; set; }
            public decimal QTY { get; set; }
            public decimal PRICE { get; set; }
            public decimal AMOUNT { get; set; }
        }
    }
}
