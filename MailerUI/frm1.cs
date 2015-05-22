using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using Pub.Class;
using TH.Mailer.Entity;
using TH.Mailer.Helper;
using System.Threading;

namespace MailerUI
{
    public partial class frm1 : DockContent
    {
        private delegate void CallFormInThread(object data);  //为了在线程里访问控件
 
        private int pageSize = 50;
        private int page = 1;
        private int pages = 0;
        public frm1()
        {
            InitializeComponent();

        }

        public void loadData(object obj)
        {
        
            EmailListobj o1 = obj as EmailListobj;

            IList<EmailList> emailList = o1.list;

            listView1.Columns.Add("序号", 60, HorizontalAlignment.Left);
            listView1.Columns.Add("邮件地址", 150, HorizontalAlignment.Left);
            listView1.Columns.Add("昵称", 80, HorizontalAlignment.Left);
            

			this.listView1.BeginInvoke(new Pub.Class.Action(() =>
            {
                string tempStatus = string.Empty;
                emailList.Do((p, i) =>
                {
                  
                    ListViewItem item = new ListViewItem((i + 1).ToString());
                    item.Tag = p.EmailAddress.ToString();
                    item.ToolTipText = p.EmailAddress.ToString();
                    item.SubItems.Add(p.EmailAddress.ToString());
 
                    item.SubItems.Add(p.NickName.ToString());
                    if (i % 2 == 0)
                    {
                        item.BackColor = Color.FromArgb(247, 247, 247);
                    }
                    this.listView1.Items.Add(item);
                });

            }));

            if (o1.page <= 1)
            {
                mnuNext.Enabled = true;
                mnuPrev.Enabled = false;
            }

            if (o1.page == o1.pages)
            {
                mnuNext.Enabled = false;
                mnuPrev.Enabled = true;
            }

            if (o1.page <= 1 && o1.page >= o1.pages)
            {
                mnuNext.Enabled = false;
                mnuPrev.Enabled = false;
            }

            if (o1.page > 1 && o1.page < o1.pages)
            {
                mnuNext.Enabled = true;
                mnuPrev.Enabled = true;
            }
            toolStripLabel1.Text = "总记录数：{0}，总页数：{1}，当前页：{2}".FormatWith(o1.totals, o1.pages, o1.page);


            this.listView1.EndUpdate();
           
        }
        private void BindData( )
        {
            int totals = 0;
            listView1.View = View.Details;
            listView1.Columns.Clear();
            listView1.Items.Clear();
            listView1.BeginUpdate();
            Where where = null;
            ThreadPool.QueueUserWorkItem(new WaitCallback((o) =>
            {
                IList<EmailList> emailList = EmailListHelper.SelectPageList(page, pageSize, out totals, "", where);

                pages = totals / pageSize + (totals % pageSize == 0 ? 0 : 1);
   
                EmailListobj obj1 = new EmailListobj();
                obj1.list = emailList;
                obj1.page = page;
                obj1.pages = pages;
                obj1.totals = totals;

                this.Invoke(new CallFormInThread(loadData), obj1);

            }), null);

            
         
        }



        private void frm1_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private void mnuPrev_Click(object sender, EventArgs e)
        {
            --page;
            BindData();
        }

        private void mnuNext_Click(object sender, EventArgs e)
        {
            ++page;
            BindData();
        }

    }
}
