//-------------------------------------------------------------------------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2013 , TH , Ltd.
//-------------------------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;
using Pub.Class;

namespace TH.Mailer.Entity {
 
    [Serializable]
    [EntityInfo("")]
    public partial class EmailListobj {
        public IList<EmailList> list { get; set; }
        public int page{ get; set; }
        public int pages { get; set; }
        public int totals { get; set; }
 
    }
}



