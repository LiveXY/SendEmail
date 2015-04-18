using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Xml.Serialization;
using System.Xml;
using System.Collections;
using System.Net;
using TH.Mailer.Entity;
using System.Text.RegularExpressions;
using System.IO;
using TH.Mailer.Helper;

namespace TH.Mailer {
    public interface IController {
        /// <summary>
        /// 重启接口
        /// </summary>
        /// <returns></returns>
        string Reset();
    }
}