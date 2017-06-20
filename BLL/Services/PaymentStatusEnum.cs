namespace BLL.Services
{
    /// <summary>
    /// 支付状态
    /// </summary>
    public enum PaymentStatusEnum : int
    {
        /// <summary>
        /// 待支付
        /// </summary>
        Pending = 0,
        /// <summary>
        /// 授权
        /// </summary>
       // Authorized = 1,
        /// <summary>
        /// 已支付
        /// </summary>
        Paid = 2,
        /// <summary>
        /// 部分退款
        /// </summary>
        PartiallyRefunded = 3,
        /// <summary>
        /// 已退款
        /// </summary>
        Refunded = 4,
        /// <summary>
        /// 取消/作废
        /// </summary>
        Voided = 5,
    }
}
