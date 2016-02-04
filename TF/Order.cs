using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//hi there!
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
            public string ITEM { get; set; }
            public decimal QTY { get; set; }
            public decimal PRICE { get; set; }
            public decimal AMOUNT { get; set; }
        }

        private Dictionary<string, object> plugins = null;

        public Order()
        {
            this.plugins = new Dictionary<string, object>();
        }

        public object this[string key]
        {
            get
            {
                // Добавить проверку
                return this.plugins[key];
            }
            set
            {
                // Добавить проверку
                this.plugins.Add(key, value);
            }
        }
    }
}
