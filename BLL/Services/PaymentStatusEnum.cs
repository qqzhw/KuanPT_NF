namespace BLL.Services
{
    /// <summary>
    /// ֧��״̬
    /// </summary>
    public enum PaymentStatusEnum : int
    {
        /// <summary>
        /// ��֧��
        /// </summary>
        Pending = 0,
        /// <summary>
        /// ��Ȩ
        /// </summary>
       // Authorized = 1,
        /// <summary>
        /// ��֧��
        /// </summary>
        Paid = 2,
        /// <summary>
        /// �����˿�
        /// </summary>
        PartiallyRefunded = 3,
        /// <summary>
        /// ���˿�
        /// </summary>
        Refunded = 4,
        /// <summary>
        /// ȡ��/����
        /// </summary>
        Voided = 5,
    }
}
