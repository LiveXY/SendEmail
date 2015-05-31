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

namespace MailerUI {
	public partial class frm2 : DockContent {
		WinFormPager winFormPager1;
		DBGridView dbGridView1;
		int pages = 0;

		public frm2() {
			InitializeComponent();
			Init();
			InitGrid();//初始化列表和列表分页控件
		}
		private void Init() {
			splitContainer1.IsSplitterFixed = true;
			winFormPager1 = new WinFormPager(this.splitContainer1.Panel2);

			this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
			winFormPager1.BackColor = System.Drawing.SystemColors.Control;
			winFormPager1.ButtonDistance = 2;
			winFormPager1.ButtonHeight = 20;
			winFormPager1.ButtonWidth = 23;
			winFormPager1.BotomDistance = 2;
			winFormPager1.RightDistance = 5;
			winFormPager1.CurrentPage = 1;
			winFormPager1.Name = "winFormPager1";
			winFormPager1.PageSize = 30;

			winFormPager1.RecordCount = 0;//设置分页控件记录总行数为0
			winFormPager1.CurrentPage = 1;
			winFormPager1.CurrentGroup = 1;

			winFormPager1.PageChanged += new WinFormPager.PageChangeDelegate(winFormPager1_PageChanged);
			winFormPager1.Dock = System.Windows.Forms.DockStyle.Fill;
		}
		//分页改变方法 
		private void winFormPager1_PageChanged() {
			loadData();//执行查询
		}
		//初始化列表的方法 
		private void InitGrid() {
			dbGridView1 = new DBGridView();
			dbGridView1.AutoGenerateColumns = false;
			dbGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			dbGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			dbGridView1.ColumnHeadersHeight = 26;
			dbGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
			dataGridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle.WrapMode = DataGridViewTriState.False;

			DataGridViewTextBoxColumn Column1 = new DataGridViewTextBoxColumn();
			Column1.FillWeight = 200;
			Column1.HeaderText = "发送的Email";
			Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;

			DataGridViewTextBoxColumn Column2 = new DataGridViewTextBoxColumn();
			Column2.FillWeight = 100;
			Column2.HeaderText = "收件人昵称";
			Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;

			DataGridViewLinkColumn Column3 = new DataGridViewLinkColumn();
			Column3.FillWeight = 40;
			Column3.HeaderText = "操作";
			Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			Column3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

			dbGridView1.Columns.Add(Column1);
			dbGridView1.Columns.Add(Column2);
			dbGridView1.Columns.Add(Column3);

			dbGridView1.Name = "dbGridView1";

			dbGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			dbGridView1.RowHeadersVisible = false;
			dbGridView1.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));

			dbGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Panel1.Controls.Add(dbGridView1);

			this.dbGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dbGridView1_CellContentClick);
		}

		public void loadData() {
			long totals = 0;

			Where where = null;
			IList<EmailList> emailList = EmailListHelper.SelectPageList(winFormPager1.CurrentPage, winFormPager1.PageSize, out totals, "", where);
			pages = (int)(totals / winFormPager1.PageSize + (totals % winFormPager1.PageSize == 0 ? 0 : 1));
			dbGridView1.Rows.Clear();//清空列表数据
			winFormPager1.RecordCount = totals;//设置分页控件记录总行数为接口返回的记录总数

			dbGridView1.BeginInvoke(new Pub.Class.Action(() => {
				emailList.Do((p, i) => {
					dbGridView1.Rows.Add(p.EmailAddress.ToString(), p.NickName, "修改");
				});
			}));
		}

		private void frm2_Load(object sender, EventArgs e) {
			loadData();
		}

		private void dbGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) {
			var o = sender as DBGridView;
			if (e.RowIndex > -1 && e.ColumnIndex == 2) {
				try {
					string id = o.Rows[e.RowIndex].Cells[0].Value.ToString();
					MessageBox.Show(id);
				} catch (Exception) {
				}
			}
		}
	}
}
