using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMCustSys.Model;
using IMCustSys.DAL;
using IMCustSys.Common;
using DapperExtensions;
using IMCustSys.BLL.Caching;

namespace IMCustSys.BLL.Services
{
    public class OrderService : IOrderService
    {
        private readonly ICacheManager _cacheManager;
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<Shop> _shopRepository;
        private readonly IRepository<User> _userRepository;
        public OrderService(IRepository<Order>  orderRepository, IRepository<Shop>  shopRepository, IRepository<User> userRepository)
        {
            _orderRepository = orderRepository;
            _shopRepository = shopRepository;
            _userRepository = userRepository;
            this._cacheManager = new KptRequestCache();
        }
        /// <summary>
        /// 设置订单状态
        /// </summary>
        /// <param name="order">Order</param>
        /// <param name="os">New order status</param>
        /// <param name="notifyCustomer">是否通知客户</param>
        protected void SetOrderStatus(Order order,
            OrderStatusEnum os, bool notifyCustomer)
        {
            if (order == null)
                throw new ArgumentNullException("order");

            OrderStatusEnum prevOrderStatus = (OrderStatusEnum)order.OrderState;
            if (prevOrderStatus == os)
                return;

            //set and save new order status
            order.OrderState = (int)os;
            UpdateOrder(order);

            //order notes, notifications
            InsertOrderNote(order.OrderId, string.Format("Order status has been changed to {0}", os.ToString()), false, DateTime.UtcNow);

            if (prevOrderStatus != OrderStatusEnum.Complete &&
                os == OrderStatusEnum.Complete
                && notifyCustomer)
            {
                 
             // InsertOrderNote(order.OrderId, string.Format("\"Order completed\" email (to customer) has been queued. Queued email identifier: {0}.", orderCompletedCustomerNotificationQueuedEmailId), false, DateTime.UtcNow);
                
            }

            if (prevOrderStatus != OrderStatusEnum.Cancelled &&
                os == OrderStatusEnum.Cancelled
                && notifyCustomer)
            {
                
              //  InsertOrderNote(order.OrderId, string.Format("\"Order cancelled\" email (to customer) has been queued. Queued email identifier: {0}.", orderCancelledCustomerNotificationQueuedEmailId), false, DateTime.UtcNow);
              
            } 
        }
        
        protected Order CheckOrderStatus(int orderId)
        {
            var order = GetOrderById(orderId);
            if (order == null)
                return null;

            if (order.OrderState ==(int)OrderStatusEnum.Pending)
            {
                if (order.PaymentStatus ==(int)PaymentStatusEnum.Paid)
                {
                    SetOrderStatus(order, OrderStatusEnum.Processing, false);
                }
            }
             

            if (order.OrderState != (int) OrderStatusEnum.Cancelled &&
                order.OrderState != (int) OrderStatusEnum.Complete)
            {
                if (order.PaymentStatus == (int)PaymentStatusEnum.Paid)
                {

                    SetOrderStatus(order, OrderStatusEnum.Complete, true);
                }
            }

            if (order.PaymentStatus == (int)PaymentStatusEnum.Paid && !order.PaymentDate.HasValue)
            {
                //确认支付时间
                order.PaymentDate = DateTime.Now; ;
                UpdateOrder(order);
            }

            return order;
        }
       

        public Order CancelOrder(int orderId, bool notifyCustomer)
        {
            throw new NotImplementedException();
        }
     

        public void DeleteOrderNote(int orderNoteId)
        {
            throw new NotImplementedException();
        }
       

        public Order GetOrderById(int orderId)
        {
            if (orderId == 0)
                return null;
            var order=_orderRepository.GetById(orderId);
            return order;
        }
        public void MarkOrderAsDeleted(int orderId)
        {
            var order = GetOrderById(orderId);
            if (order != null)
            {
                order.Deleted = true;
                UpdateOrder(order);
            }
        }
        public Order_Note GetOrderNoteById(int orderNoteId)
        {
            throw new NotImplementedException();
        }

        public List<Order_Note> GetOrderNoteByOrderId(int orderId)
        {
            throw new NotImplementedException();
        }

        public List<Order_Note> GetOrderNoteByOrderId(int orderId, bool showHidden)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetOrdersByUserId(int userId)
        {
            throw new NotImplementedException();
        }

        public void InsertOrder(Order order)
        {
            if (order == null)
                throw new ArgumentNullException("order");

            order.CustomerName = CommonHelper.EnsureNotNull(order.CustomerName);
            order.CustomerName = CommonHelper.EnsureMaximumLength(order.CustomerTel,50);
            order.CustomerTel = CommonHelper.EnsureNotNull(order.CustomerTel);
            order.CustomerTel = CommonHelper.EnsureMaximumLength(order.CustomerTel,50);
            order.CustomerAddress = CommonHelper.EnsureNotNull(order.CustomerAddress);
            order.CustomerAddress = CommonHelper.EnsureMaximumLength(order.CustomerAddress,200);
            _orderRepository.Insert(order);
            
        }

        public Order_Note InsertOrderNote(int orderId, string note, DateTime createdOn)
        {
            throw new NotImplementedException();
        }

        public Order_Note InsertOrderNote(int orderId, string note, bool displayToCustomer, DateTime createdOn)
        {
            throw new NotImplementedException();
        }

        public List<Order> LoadAllOrders()
        {
            throw new NotImplementedException();
        }
         
        /// <summary>
        /// 标记已支付
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public Order MarkOrderAsPaid(int orderId)
        {
            var order = GetOrderById(orderId);
            if (order != null)
            {
                order.PaymentStatus = (int)PaymentStatusEnum.Paid;
                UpdateOrder(order);
            }
            return order;
        }

       

        public List<Order> SearchOrders(DateTime? startTime, DateTime? endTime, OrderStatusEnum? os, PaymentStatusEnum? paymentStatus, string comId="",string phoneNum = "", int pageIndex = 0, int pageSize = int.MaxValue)
        {
            int? orderStatusId = null;
            if (os.HasValue)
                orderStatusId = (int)os.Value;

            int? paymentStatusId = null;
            if (paymentStatus.HasValue)
                paymentStatusId = (int)paymentStatus.Value;
            var pgMain = new PredicateGroup { Operator = GroupOperator.Or, Predicates = new List<IPredicate>() };
            var pgb = new PredicateGroup { Operator = GroupOperator.And, Predicates = new List<IPredicate>() };
            if (startTime != null)
            {
                pgb.Predicates.Add(Predicates.Field<Order>(f => f.CreateDate, Operator.Ge, startTime));
            }
            if (endTime != null)
            {
                pgb.Predicates.Add(Predicates.Field<Order>(f => f.CreateDate, Operator.Le, endTime));
            }
            if (orderStatusId != null)
            {
                pgb.Predicates.Add(Predicates.Field<Order>(f => f.OrderState, Operator.Eq, orderStatusId));
            }
            if (paymentStatusId != null)
            {
                pgb.Predicates.Add(Predicates.Field<Order>(f => f.PaymentStatus, Operator.Eq, paymentStatusId));
            }
            if (!string.IsNullOrEmpty(comId))
            {
                pgb.Predicates.Add(Predicates.Field<Order>(f => f.ComId, Operator.Eq, comId));
            }
            if (!string.IsNullOrEmpty(phoneNum))
            {
                pgb.Predicates.Add(Predicates.Field<Order>(f => f.CustomerTel, Operator.Like, "%" + phoneNum + "%"));
            }
            pgMain.Predicates.Add(pgb);
            IEnumerable<Order> list = _orderRepository.GetList(pgMain);
            return list.ToList(); 
        }

        public void UpdateOrder(Order order)
        {
            if (order == null)
                return;
            _orderRepository.Update(order);
        }

        public void UpdateOrderNote(Order_Note orderNote)
        {
            throw new NotImplementedException();
        }

        public Order VoidOffline(int orderId)
        {
            throw new NotImplementedException();
        }
    }
}
