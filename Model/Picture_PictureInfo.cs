using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Picture
    {
        
        public int PictureId { get; set; }

       
        public byte[] PictureBinary { get; set; } 
     
        public string MimeType { get; set; }

        
        public bool IsNew { get; set; }

    
    }
}
