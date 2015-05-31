using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace MailerUI {
	/// <summary>
	/// 分页控件
	/// </summary>
	internal partial class WinFormPager : UserControl {
		Control ParentControl = null;
		/// <summary>
		/// 构造函数 
		/// </summary>
		/// <param name="parentControl">父容器控件，就是承载分页控件的容器</param>
		public WinFormPager(Control parentControl) {
			ParentControl = parentControl;
			InitializeComponent();
			ParentControl.Controls.Add(this);
			this.SetStyle(ControlStyles.AllPaintingInWmPaint |
				ControlStyles.DoubleBuffer |
				ControlStyles.UserPaint |
				ControlStyles.SupportsTransparentBackColor
				, true);

			PageChanged = SetBtnPrePageAndBtnNextPage;
			PageChanged();
		}

		int currentPage = 1;//当前页 
		/// <summary>
		/// 当前页 
		/// </summary>
		[Description("当前页"), Category("分页设置")]
		public int CurrentPage {
			get { return currentPage; }
			set { currentPage = value; }
		}
		int pageSize = 16;//每页显示条数
		/// <summary>
		/// 每页显示条数
		/// </summary>
		[Description("每页显示条数"), Category("分页设置")]
		public int PageSize {
			get { return pageSize; }
			set { pageSize = value; }
		}
		int pageTotal = 0;//总共多少页 
		/// <summary>
		/// 总共多少页 
		/// </summary>
		[Description("总共多少页"), Category("分页设置")]
		public int PageTotal {
			get { return pageTotal; }
			set { pageTotal = value; }
		}
		int currentGroup = 1;//当前组
		/// <summary>
		/// 当前组
		/// </summary>
		[Description("当前组"), Category("分页设置")]
		public int CurrentGroup {
			get { return currentGroup; }
			set { currentGroup = value; }
		}
		int groupSize = 10;//每组显示页数
		/// <summary>
		/// 每组显示页数
		/// </summary>
		[Description("每组显示页数"), Category("分页设置")]
		public int GroupSize {
			get { return groupSize; }
			set {
				if (value < 1) {
					groupSize = 1;
				} else if (value > 10) {
					groupSize = 10;
				} else {
					groupSize = value;
				}
			}
		}
		int groupTotal = 0;//总共多少组
		/// <summary>
		/// 总共多少组
		/// </summary>
		[Description("总共多少组"), Category("分页设置")]
		public int GroupTotal {
			get { return groupTotal; }
			set { groupTotal = value; }
		}
		/// <summary>
		/// 总的记录数
		/// </summary>
		private long recordCount;//总的记录数
		[Description("总的记录数"), Category("分页设置")]
		public long RecordCount {
			get { return recordCount; }
			set {
				recordCount = value;
				InitData();// 初始化数据
				BuildPageControl();//当前页改变事件
			}
		}
		private int buttonWidth = 35;//按钮宽度
		/// <summary>
		/// 按钮宽度
		/// </summary>
		[Description("按钮宽度"), Category("分页设置")]
		public int ButtonWidth {
			get { return buttonWidth; }
			set { buttonWidth = value; }
		}
		private int buttonHeight = 23;//按钮高度
		/// <summary>
		/// 按钮高度
		/// </summary>
		[Description("按钮高度"), Category("分页设置")]
		public int ButtonHeight {
			get { return buttonHeight; }
			set { buttonHeight = value; }
		}
		private int buttonDistance = 4;//按钮间距离
		/// <summary>
		/// 按钮间距离
		/// </summary>
		[Description("按钮间距离"), Category("分页设置")]
		public int ButtonDistance {
			get { return buttonDistance; }
			set { buttonDistance = value; }
		}

		private int botomDistance = 5;
		[Description("分页控件距离父控件底部距离"), Category("分页设置")]
		public int BotomDistance {
			get { return botomDistance; }
			set { botomDistance = value; }
		}

		private int rightDistance = 5;
		[Description("分页控件距离父控件右边距离"), Category("分页设置")]
		public int RightDistance {
			get { return rightDistance; }
			set { rightDistance = value; }
		}

		public delegate void PageChangeDelegate();
		/// <summary>
		/// 当前页改变时发生的事件
		/// </summary>
		[Description("当前页改变时发生的事件"), Category("分页设置")]
		public event PageChangeDelegate PageChanged;

		/// <summary>
		/// 初始化数据
		/// </summary>
		private void InitData() {
			PageTotal = (int)(RecordCount / PageSize);//总共多少页            
			if (RecordCount % PageSize != 0) {
				PageTotal++;
			}
			GroupTotal = PageTotal / GroupSize;//总共多少组
			if (PageTotal % GroupSize != 0) {
				GroupTotal++;
			}

			BuildPageControl();//创建分页数字按钮       
		}
		/// <summary>
		/// 创建分页数字按钮
		/// </summary>
		private void BuildPageControl() {
			try {
				int x = 0;//按钮横坐标
				int y = 0;//按钮纵坐标
				if (CurrentPage > 1) //当前页大于1可以显示首页和第一页 否则不显示
                {
					btnFirstPage.Location = new Point(x, y);
					x = x + btnFirstPage.Width;
					btnFirstPage.Visible = true;

					btnPrePage.Location = new Point(x, y);
					x = x + btnPrePage.Width;
					btnPrePage.Visible = true;
				} else {
					btnFirstPage.Visible = false;
					btnPrePage.Visible = false;
				}
				//指定上一组 坐标 
				if (CurrentGroup > 1)//当前组大于1 可以显示上一组 否则不显示
                {
					btnPreGroup.Location = new Point(x, y);
					btnPreGroup.Width = ButtonWidth;
					x = x + btnPreGroup.Width + this.buttonDistance;
					btnPreGroup.Visible = true;
				} else {
					btnPreGroup.Visible = false;
				}
				PageButton button = null;
				int btnNum = 1;
				//循环显示数字 按钮控件
				for (int i = GroupSize * (currentGroup - 1) + 1; i <= GroupSize * CurrentGroup; i++) {
					if (i > PageTotal) {
						break;
					}
					btnNum = i % GroupSize;
					if (btnNum == 0) btnNum = 10;
					button = (PageButton)this.Controls.Find("pageButton" + btnNum.ToString(), false)[0];
					button.Visible = true;
					button.Text = i.ToString();
					button.TextAlign = ContentAlignment.MiddleCenter;
					if (button.Text == CurrentPage.ToString()) {
						button.ForeColor = Color.Red;

					} else {
						button.ForeColor = ColorTranslator.FromHtml("#A6A6A6");
					}
					button.Width = ButtonWidth;
					button.Height = ButtonHeight;
					button.Location = new Point(x, y);
					button.Click -= new EventHandler(button_Click);
					button.Click += new EventHandler(button_Click);
					button.BringToFront();
					x += ButtonWidth + ButtonDistance;
				}
				while (btnNum < 10) {
					btnNum++;
					button = (PageButton)this.Controls.Find("pageButton" + btnNum.ToString(), false)[0];
					button.Visible = false;
				}

				if (GroupTotal > 1 && CurrentGroup < GroupTotal) //显示下一组
                {
					btnNextGroup.Location = new Point(x, y);
					btnNextGroup.Width = ButtonWidth;
					x = x + btnNextGroup.Width + ButtonDistance;
					btnNextGroup.Visible = true;
				} else {
					btnNextGroup.Visible = false;
				}
				if (PageTotal > 1 && CurrentPage < PageTotal) //显示下一页和 末页
                {
					btnNextPage.Location = new Point(x, y);
					x = x + btnNextPage.Width;
					btnNextPage.Visible = true;

					btnLastPage.Location = new Point(x, y);
					x = x + btnLastPage.Width;
					btnLastPage.Visible = true;

				} else {
					btnNextPage.Visible = false;
					btnLastPage.Visible = false;
				}

				this.Height = ButtonHeight;
				this.Width = x;
				if (ParentControl != null) {
					this.Location = new Point(ParentControl.Width - this.Width - this.RightDistance, ParentControl.Height - ButtonHeight - this.BotomDistance);
				}
				this.ReInitButtonHeight();
				this.BackColor = Color.Transparent;//ColorTranslator.FromHtml("#005291E"); //
				if (this.recordCount <= this.PageSize) {
					this.Visible = false;
				} else {
					this.Visible = true;
				}
			} catch {
			}
		}

		/// <summary>
		/// 重置按钮的高度
		/// </summary>
		private void ReInitButtonHeight() {
			btnFirstPage.Height = ButtonHeight;
			btnPrePage.Height = ButtonHeight;
			btnPreGroup.Height = ButtonHeight;
			btnNextGroup.Height = ButtonHeight;
			btnNextPage.Height = ButtonHeight;
			btnLastPage.Height = ButtonHeight;
		}
		/// <summary>
		/// 数字按钮分页
		/// </summary>
		private void button_Click(object sender, EventArgs e) {
			CurrentPage = int.Parse((sender as PageButton).Text);
			PageChanged();
		}
		/// <summary>
		/// 设置上一页、下一页是否可用以及当前页按钮字体颜色
		/// </summary>
		private void SetBtnPrePageAndBtnNextPage() {
			BuildPageControl();
		}
		/// <summary>
		/// 上一组
		/// </summary>
		private void btnPreGroup_Click(object sender, EventArgs e) {
			if (CurrentGroup > 1) {
				CurrentGroup--;
				CurrentPage = GroupSize * (CurrentGroup - 1) + 1; ;
				PageChanged();
			}
		}
		/// <summary>
		/// 下一组
		/// </summary>
		private void btnNextGroup_Click(object sender, EventArgs e) {
			if (CurrentGroup < GroupTotal) {
				CurrentGroup++;
				CurrentPage = GroupSize * (CurrentGroup - 1) + 1; ;
				PageChanged();
			}
		}
		/// <summary>
		/// 上一页
		/// </summary>
		private void btnPrePage_Click(object sender, EventArgs e) {
			//如果是当前组的第一页 且当前组不是第一组，直接上一组
			if (CurrentPage % GroupSize == 1 && CurrentGroup > 1) {
				CurrentGroup--;
				CurrentPage--;
				PageChanged();
			} else {
				CurrentPage--;
				PageChanged();
			}
		}
		/// <summary>
		/// 下一页
		/// </summary>
		private void btnNextPage_Click(object sender, EventArgs e) {
			//如果是当前组的最后一页，直接下一组
			if (CurrentPage % GroupSize == 0 && CurrentGroup < GroupTotal) {
				CurrentGroup++;
				CurrentPage++;
				PageChanged();
			} else {
				CurrentPage++;
				PageChanged();
			}
		}

		private void btnFirstPage_Click(object sender, EventArgs e) {
			CurrentGroup = 1;
			CurrentPage = 1;
			PageChanged();
		}

		private void btnLastPage_Click(object sender, EventArgs e) {
			CurrentGroup = GroupTotal;
			CurrentPage = PageTotal;
			PageChanged();
		}

		private void btnFirstPage_MouseHover(object sender, EventArgs e) {
			Label lab = sender as Label;
			lab.Cursor = Cursors.Hand;
		}

		private void btnFirstPage_MouseLeave(object sender, EventArgs e) {
			Label lab = sender as Label;
			lab.Cursor = Cursors.Default;
		}
	}
}
