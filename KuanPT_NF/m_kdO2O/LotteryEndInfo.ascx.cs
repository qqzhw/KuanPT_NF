using IMCustSys.BLL;
using IMCustSys.Common;
using IMCustSys.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IMCustSys
{
    public partial class LotteryEndInfo : BaseKptUserControl
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.BindData();
            }
        }
        private void BindData()
        {
            Lottery lottery = this.LotteryService.GetLotteryById(LotteryId);

            if (lottery != null)
            {
                this.txtNotice.Text = lottery.LotteryEndNotice;
                this.txtDesc.Text = lottery.LotteryEndInfo;
            }
        }
        //protected override void OnPreRender(EventArgs e)
        //{
        //    BindJQuery();
        //    BindJQueryIdTabs();

        //    base.OnPreRender(e);
        //}

        public void SaveInfo()
        {
            SaveInfo(this.LotteryId);
        }

        public void SaveInfo(int lotteryId)
        {
            Lottery lottery = this.LotteryService.GetLotteryById(lotteryId); 
            if (lottery != null)
            {
                var imgPath = string.Empty;
                HttpPostedFile pictureFile = uploadImg.PostedFile;

                if ((pictureFile != null) && (!String.IsNullOrEmpty(pictureFile.FileName)))
                {
                    byte[] pictureBinary = pictureFile.GetPictureBits(); 
                    imgPath = this.PictureService.UploadPicture(pictureBinary, pictureFile.ContentType);
                   
                }
                if (!string.IsNullOrEmpty(imgPath))
                {
                    lottery.LotteryEndImg = imgPath;
                }                
                lottery.LotteryEndNotice = txtNotice.Text;
                lottery.LotteryEndInfo = txtDesc.Text; 
                this.LotteryService.UpdateLottery(lottery);
            } 
        }
          
        public int LotteryId
        {
            get
            {
                return CommonHelper.QueryStringInt("LotteryId");
            }
        }
    }
}