﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KuanPT_NF.m_kdO2O
{
    public partial class Default:BaseKptPage
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
           var s= CampaignService.GetCampaignById(1);
        }
    }
}