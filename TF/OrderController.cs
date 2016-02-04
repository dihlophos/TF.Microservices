using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TF
{
    /*
     * Сценарий:
     * 1. Сохранение базового класса
     * 2. Добавление атрибута: Карта лояльности, вариант обработки карты
     * 3. Изменение логики: 
     *      для варианта обработки карты лояльности А: скидка 5% на сумму заказа
     *      для варианта обработки карты лояльности Б: добавить бесплатную колу в заказ
     * 4. Добавление логики: списание товара со склада
     */

    /// <summary>
    /// /api/order/
    /// Действия с заказом:
    /// 1.Создать драфт заказа
    /// Драфт может храниться в памяти
    /// 2. Изменять драфт заказа
    /// Отправляется на сервер любое изменение драфта: поля, позиции
    /// 3. Подтвердить заказ
    /// </summary>
    public class OrderController
    {
        private readonly OrderApplicationManager app;

        public OrderController()
        {
            app = new OrderApplicationManager();
        }

        /// <summary>
        /// Work-Flow "Изменение заказа"
        /// </summary>
        /// <param name="context"></param>
        public HttpResponseMessage Patch(System.Web.HttpContext context)
        {
            app.UseAuthServer(context);

            throw new NotImplementedException();
        }

        /// <summary>
        /// Work-Flow "Сохранение заказа"
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public HttpResponseMessage Post(System.Web.HttpContext context)
        {
            /// Видимо, здесь нужно будет инициировать некую транзакцию
            /// И навешивать на нее все дальнейшие обработчики

            /// Нужно получить базовую информацию о заказе из request или из хранилища (?)
            /// Запустить обработку лояльности
            ///     - будет получена информация о лояльности
            ///     - изменена базовая информация о заказе (скидка на сумму или добавлен новый товар)
            ///     - сохранить информацию о лояльности
            /// Сохранить информацию о заказе
            /// Списать остатки в WH

            /// Выполнение базового обработчика
            app.UseDefaultOrderProcess(context);

            /// Обработка карты лояльности
            app.UseLoyaltyAmountModificatorForOrder(context);

            /// Обработка списаний
            app.UseWriteOffForOrder(context);

            throw new NotImplementedException();
        }

        /// <summary>
        /// Получает "заказ"
        /// </summary>
        /// <returns></returns>
        public HttpResponseMessage Get()
        {
            var order = new Order()
            {
                CUSTOMER = "Иван",
                DESTINATION = "Москва",
                DUEDATE = DateTime.Now,
                LINES = new[] { 
                    new Order.Line { ITEM = "mars",  AMOUNT = 100, PRICE = 5, QTY = 500},
                    new Order.Line { ITEM = "cars", AMOUNT = 200, PRICE = 1, QTY = 200} 
                }
            };

            order["Loyalty"] = new LoyaltyCard() { LOYALTY = "QWE", LOYALTY_VARIANT = "A" };

            return new HttpResponseMessage() { Content = new StringContent(order.ToString()) };
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class OrderApplicationManager
    {
        public void UseAuthServer(System.Web.HttpContext context)
        {
            /// Auth request
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public void UseDefaultOrderProcess(System.Web.HttpContext context)
        {
            /// Get Order from context
            /// Save Order to DB
        }

        public void UseLoyaltyAmountModificatorForOrder(System.Web.HttpContext context)
        {
            /// Get loyalty number from context
            /// Get Order from ???
            /// Modify Order
            /// Save Loyalty Info
        }

        public void UseWriteOffForOrder(System.Web.HttpContext context)
        {
            /// Get order from ???
            /// Create WriteOff
            /// Processed WriteOff
        }
    }

    public class LoyaltyCard
    {
        public string LOYALTY { get; set; }
        public string LOYALTY_VARIANT { get; set; }
    }

    public class AggregateOrder
    {

    }


    public class TransactionController
    {

    }
}
