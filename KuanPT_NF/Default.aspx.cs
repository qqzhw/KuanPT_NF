using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using BLL.Infrastructure;
using BLL.Services;

namespace KuanPT_NF
{
    public partial class _Default : System.Web.UI.Page
    {
        private readonly ICampaignService _IUser;
        public _Default()
        {
            _IUser = EngineContext.Current.Resolve<ICampaignService>();
          //  var ss = _IUser.GetCampaignById(1);
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}
