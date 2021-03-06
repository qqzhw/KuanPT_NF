﻿using IMCustSys.BLL;
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
                txtPersonCount.Value = lottery.PersonCount;
                txtMaxCount.Value = lottery.MaxLotteryCount;
                txtTodayCount.Value = lottery.TodayLotteryCount;
                ctrlStartDatePicker.SelectedDate = lottery.BeginDate;
                ctrlEndDatePicker.SelectedDate = lottery.EndDate;               
                
                if (!string.IsNullOrWhiteSpace(lottery.LotteryImg))
                {
                    btnDelete.Visible = true;
                    imgLottery.ImageUrl = CommonHelper.GetStoreLocation() + lottery.LotteryImg;
                    imgHidden.Value = lottery.LotteryImg;
                }
                else
                {
                    imgLottery.Visible = false;
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
                var comId = "0000100001";//BLL.sys_admin.GetUserComid();
                lottery = new Lottery();
                lottery.BmId = 1;
                lottery.ComId = comId;
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
            if(PictureService.DeletePicture(imgHidden.Value))
            {
                imgLottery.ImageUrl = string.Empty;
                Lottery lottery = this.LotteryService.GetLotteryById(this.LotteryId);
                if (lottery != null)
                {
                    lottery.LotteryImg = string.Empty;
                    LotteryService.UpdateLottery(lottery);
                }
                  btnDelete.Visible = false;
            }
        }
    }
 
}