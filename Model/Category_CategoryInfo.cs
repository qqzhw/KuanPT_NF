using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IMCustSys.Model
{
    public class Category
    {
       // Category 分类表 CategoryId INT PK IDENTITY NOT NULL
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public int ParentCategoryId { get; set; }
        public bool ShowOnHomePage { get; set; }
        public bool Published { get; set; }
        public bool Deleted { get; set; }
        public int DisplayOrder { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string ComId { get; set; }
        public int BmId { get; set; }
        //                CategoryName NVARCHAR(100) NOT NULL

        //                Description NVARCHAR(500)  NULL
        //                ParentCategoryId    INT NOT NULL
        //                ShowOnHomePage  BIT NOT NULL
        //                Published   Bit NOT NULL
        //                Deleted Bit Not NULL
        //                DisplayOrder    int not null

        //                CreateDate DATETIME NOT NULL

        //                UpdateDate DATETIME NULL
        //               comId   VARCHAR(10) NOT NULL

        //                bmId INT NOT NULL
    }
}
