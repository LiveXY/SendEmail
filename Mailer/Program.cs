using System;
using System.Collections.Generic;
using System.Text;
using TH.Mailer;
using Pub.Class;

namespace Mailer {
    class Program {
        static void Main(string[] args) {
            Data.UsePool("ConnString");
            MailerCenter.Start((msg) => {
                msg = "[{0}]-{1}".FormatWith(DateTime.Now.ToDateTimeFFF(), msg);
                Console.WriteLine(msg);
                //Log.WriteLog(msg);
            }, () => { Console.WriteLine("END"); });
            Console.ReadKey();
        }
    }
}
