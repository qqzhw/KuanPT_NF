using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IMCustSys.Model
{
    public class Order_Note
    {
        public int NoteId { get; set; }

        public int OrderId { get; set; }

        public int? NoteType { get; set; }

        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ComId { get; set; }
        public int BmId { get; set; }
    }
}
