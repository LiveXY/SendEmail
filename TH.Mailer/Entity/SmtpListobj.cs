using System;
using System.Collections.Generic;
using System.Text;
using Pub.Class;

namespace TH.Mailer.Entity
{

    [Serializable]
    [EntityInfo("")]
    public partial class SmtpListobj
    {
        public IList<SmtpList> list { get; set; }
        public int page { get; set; }
        public int pages { get; set; }
        public int totals { get; set; }

    }
}
