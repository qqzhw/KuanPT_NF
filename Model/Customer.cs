using System;
using System.Collections.Generic; 
using Dapper.Contrib.Extensions;

namespace Model
{
	/// <summary>
	/// Represents a customer
	/// </summary>
	 [Table("SYS_USER")] 
	public partial class Customer
    {
      
       // private virtual ICollection<SYS_USER_DEPT> _sYS_USER_DEPT;
        /// <summary>
        /// Ctor
        /// </summary>
        public Customer()
        { 
        }
       [Key]
        public string USER_ID { get; set; }

       
        public string LOGIN_NAME { get; set; }

        
        public string PASSWORD { get; set; }

        
        public string USER_NAME { get; set; }

      
        public string USER_NO { get; set; }

     
        public string RIGHTS { get; set; }

      
        public string ROLE_ID { get; set; }

  
        public string SKIN { get; set; }

 
        public string EMAIL { get; set; }

 
        public string WORK_PHONE { get; set; }

     
        public string MOBILE_PHONE { get; set; }

    
        public string OFFICE_PHONE { get; set; }

       
        public string ID_CARD_NO { get; set; }

 
        public string CALL_NO { get; set; }

 
        public string ADDRESS { get; set; }

        public short? SEX { get; set; }

        public short? USER_TYPE { get; set; }

      
        public string USER_TYPENAME_EX { get; set; }

        public int? UNIT_ID { get; set; }

        public int? ORDERID { get; set; }

       
        public string STATUS { get; set; }

         
        public string BZ { get; set; }

 
        public string LAST_LOGIN { get; set; }

 
        public string IP { get; set; }

        public DateTime? CREATE_TIME { get; set; }

        public DateTime? UPDATE_TIME { get; set; }

        public short? IS_LEADER { get; set; }

      
       // public virtual ICollection<SYS_USER_DEPT> SYS_USER_DEPT { get; set; }
        //public virtual ICollection<Discount> AppliedDiscounts
        //{
        //    get { return _appliedDiscounts ?? (_appliedDiscounts = new List<Discount>()); }
        //    protected set { _appliedDiscounts = value; }
        //} 

        /// <summary>
        /// Gets or sets the customer system name
        /// </summary>
        public string SystemName { get; set; }
     
        public  DateTime? LastActivityDate{ get; set; }
     
    }
}