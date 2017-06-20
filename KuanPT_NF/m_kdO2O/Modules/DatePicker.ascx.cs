using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KuanPT_NF.Modules
{
    public partial class DatePicker : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region 属性
        public bool ShowTime
        {
            get
            {
                return Convert.ToBoolean(ViewState["ShowTime"]);
            }
            set
            {
                ViewState["ShowTime"] = value;
            }
        }

        public DateTime? SelectedDate
        {
            get
            {
                DateTime inputDate;
                if (!DateTime.TryParse(txtDateTime.Text, out inputDate))
                {
                    return null;
                }
                return inputDate;
            }
            set
            {
                ajaxCalendar.SelectedDate = value;
            }
        }

        public string Format
        {
            get
            {
                return ajaxCalendar.Format;
            }
            set
            {
                ajaxCalendar.Format = value;
            }
        }
        #endregion
    }
}