

namespace IMCustSys.BLL.Services
{ 
    public enum OrderStatusEnum : int
    {
        /// <summary>
        /// ������
        /// </summary>
        Pending = 0,
        /// <summary>
        /// ������
        /// </summary>
        Processing = 1,
        /// <summary>
        /// ��ɶ���
        /// </summary>
        Complete = 2,
        /// <summary>
        /// ȡ������
        /// </summary>
        Cancelled = 3
    }
}
