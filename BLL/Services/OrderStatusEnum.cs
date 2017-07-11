

namespace IMCustSys.BLL.Services
{ 
    public enum OrderStatusEnum : int
    {
        /// <summary>
        /// 待处理
        /// </summary>
        Pending = 0,
        /// <summary>
        /// 处理中
        /// </summary>
        Processing = 1,
        /// <summary>
        /// 完成订单
        /// </summary>
        Complete = 2,
        /// <summary>
        /// 取消订单
        /// </summary>
        Cancelled = 3
    }
}
