using BLL;
using Common;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KuanPT_NF.m_kdO2O
{
    public partial class LotteryInfo : BaseKptUserControl
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
            Lottery lottery = this.LotteryService.GetLotteryById(this.LotteryId);

            if (lottery != null)
            {
                this.txtName.Text = lottery.LotteryName;
                txtDesc.Text = lottery.Description;
                txtKeyword.Text = lottery.KeyWord;
                txtExchangeInfo.Text = lottery.ExchangeInfo;
                txtLotteryPassword.Text = lottery.LotteryPassword;
                txtIntroduction.Text = lottery.Description;
                txtRepeatTips.Text = lottery.RepeatLotteryInfo;
                txtUrl.Text = lottery.LotteryUrl;
                ctrlStartDatePicker.SelectedDate = lottery.BeginDate;
                ctrlEndDatePicker.SelectedDate = lottery.EndDate;
                imgLottery.ImageUrl = CommonHelper.GetStoreLocation() + "\\" + lottery.LotteryImg;
                imgHidden.Value = lottery.LotteryImg;
                if (!string.IsNullOrEmpty(imgLottery.ImageUrl))
                {
                    btnDelete.Visible = true;
                }
            }
         
        }
        protected override void OnPreRender(EventArgs e)
        {
            BindJQuery();
            BindJQueryIdTabs(); 
            base.OnPreRender(e);
        }
          
        public Lottery SaveInfo()
        {
            Lottery lottery = this.LotteryService.GetLotteryById(this.LotteryId);
            if (lottery != null)
            {
                var imgPath = string.Empty;
                HttpPostedFile pictureFile = uploadImg.PostedFile;

                if ((pictureFile != null) && (!String.IsNullOrEmpty(pictureFile.FileName)))
                {
                    byte[] pictureBinary = pictureFile.GetPictureBits(); 
                    imgPath = this.PictureService.UploadPicture(pictureBinary, pictureFile.ContentType);                   
                } 
                lottery.Description = txtDesc.Text;
                lottery.BeginDate = ctrlStartDatePicker.SelectedDate;
                lottery.EndDate = ctrlEndDatePicker.SelectedDate;
                lottery.ExchangeInfo = txtExchangeInfo.Text;
                lottery.Introduction = txtIntroduction.Text;
                lottery.KeyWord = txtKeyword.Text;
                lottery.LotteryName = txtName.Text;
                if (!string.IsNullOrEmpty(imgPath))
                {
                    lottery.LotteryImg = imgPath;
                } 
                lottery.LotteryPassword = txtLotteryPassword.Text;
                lottery.LotteryTips = txtRepeatTips.Text;
                lottery.RepeatLotteryInfo = txtRepeatTips.Text;
                lottery.LotteryUrl = txtUrl.Text;
                lottery.MaxLotteryCount = txtMaxCount.Value;
                lottery.PersonCount = txtPersonCount.Value;
                lottery.TodayLotteryCount = txtTodayCount.Value; 
                this.LotteryService.UpdateLottery(lottery);
            }
            else
            {
                var imgPath = string.Empty; 
                HttpPostedFile pictureFile = uploadImg.PostedFile;

                if ((pictureFile != null) && (!String.IsNullOrEmpty(pictureFile.FileName)))
                {
                    byte[] pictureBinary = pictureFile.GetPictureBits();

                    imgPath = this.PictureService.UploadPicture(pictureBinary, pictureFile.ContentType);
                    if (string.IsNullOrEmpty(imgPath))
                    {
                        ShowMessage("图片上传失败!");
                        return null;
                    }
                }
                lottery = new Lottery();
                lottery.BmId = 1;
                lottery.ComId = "test";
                lottery.CreatedDate = DateTime.Now;
                lottery.Description = txtDesc.Text;
                lottery.BeginDate = ctrlStartDatePicker.SelectedDate;
                lottery.EndDate = ctrlEndDatePicker.SelectedDate;
                lottery.ExchangeInfo = txtExchangeInfo.Text;
                lottery.Introduction = txtIntroduction.Text;
                lottery.KeyWord = txtKeyword.Text;
                lottery.LotteryName = txtName.Text;
                lottery.LotteryImg = imgPath;
                lottery.LotteryPassword = txtLotteryPassword.Text;
                lottery.LotteryTips = txtRepeatTips.Text;
                lottery.RepeatLotteryInfo = txtRepeatTips.Text;
                lottery.LotteryUrl = txtUrl.Text;
                lottery.MaxLotteryCount = txtMaxCount.Value;
                lottery.PersonCount = txtPersonCount.Value;
                lottery.TodayLotteryCount = txtTodayCount.Value;
                LotteryService.InsertLottery(lottery);
            }
            return lottery; 

        }
         
      
        public int LotteryId
        {
            get
            {
                return CommonHelper.QueryStringInt("LotteryId");
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            PictureService.DeletePicture(imgHidden.Value);
        }
    }
 
}