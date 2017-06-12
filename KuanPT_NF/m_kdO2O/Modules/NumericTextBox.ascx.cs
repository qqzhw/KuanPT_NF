using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KuanPT_NF.Modules
{
    public partial class NumericTextBox : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public int Value
        {
            get
            {
                return int.Parse(txtValue.Text);
            }
            set
            {
                txtValue.Text = value.ToString();
            }
        }

        public string RequiredErrorMessage
        {
            get
            {
                return rfvValue.ErrorMessage;
            }
            set
            {
                rfvValue.ErrorMessage = value;
            }
        }

        public string RangeErrorMessage
        {
            get
            {
                return rvValue.ErrorMessage;
            }
            set
            {
                rvValue.ErrorMessage = value;
            }
        }

        public string MinimumValue
        {
            get
            {
                return rvValue.MinimumValue;
            }
            set
            {
                rvValue.MinimumValue = value;
            }
        }

        public string MaximumValue
        {
            get
            {
                return rvValue.MaximumValue;
            }
            set
            {
                rvValue.MaximumValue = value;
            }
        }

        public string ValidationGroup
        {
            get
            {
                return rfvValue.ValidationGroup;
            }
            set
            {
                txtValue.ValidationGroup = value;
                rfvValue.ValidationGroup = value;
                rvValue.ValidationGroup = value;
            }
        }

        public Unit Width
        {
            get
            {
                return txtValue.Width;
            }
            set
            {
                txtValue.Width = value;
            }
        }

        public string CssClass
        {
            get
            {
                return txtValue.CssClass;
            }
            set
            {
                txtValue.CssClass = value;
            }
        }
    }
}
 