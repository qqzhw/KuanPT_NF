using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Services
{
    public interface IOrderService
    {
        
        Order GetOrderById(int orderId);
        
        void MarkOrderAsDeleted(int orderId);
         
        List<Order> SearchOrders(DateTime? startTime, DateTime? endTime,
         OrderStatusEnum? os,   string phoneNum="",int pageIndex=0,int pageSize=int.MaxValue);

       
        List<Order> LoadAllOrders();

        
        List<Order> GetOrdersByUserId(int userId);
         
        /// <summary>
        /// Inserts an order
        /// </summary>
        /// <param name="order">Order</param>
        void InsertOrder(Order order);

        /// <summary>
        /// Updates the order
        /// </summary>
        /// <param name="order">The order</param>
        void UpdateOrder(Order order);

 

        

        #region Order notes

       
        Order_Note GetOrderNoteById(int orderNoteId);

        
        List<Order_Note> GetOrderNoteByOrderId(int orderId);

       
        List<Order_Note> GetOrderNoteByOrderId(int orderId, bool showHidden);

      
        void DeleteOrderNote(int orderNoteId);

        
        Order_Note InsertOrderNote(int orderId, string note, DateTime createdOn);

       
        Order_Note InsertOrderNote(int orderId, string note,
            bool displayToCustomer, DateTime createdOn);

       
        void UpdateOrderNote(Order_Note orderNote);

        #endregion

         

        #region Etc
        
  
        /// <summary>
        /// Place order items in current user shopping cart.
        /// </summary>
        /// <param name="orderId">The order identifier</param>
        void ReOrder(int orderId);

      
        bool CanDeliver(Order order);

       
        Order Deliver(int orderId, bool notifyCustomer);

      
        bool CanCancelOrder(Order order);

       
        Order CancelOrder(int orderId, bool notifyCustomer);

     
        /// <summary>
        /// Gets a value indicating whether capture from admin panel is allowed
        /// </summary>
        /// <param name="order">Order</param>
        /// <returns>A value indicating whether capture from admin panel is allowed</returns>
        bool CanCapture(Order order);

       
      
        Order MarkOrderAsPaid(int orderId);
         
        
        Order VoidOffline(int orderId);

        
        #endregion

        

        
    }
}
