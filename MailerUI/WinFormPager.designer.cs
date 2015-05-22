namespace MailerUI
{
    partial class WinFormPager
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnLastPage = new System.Windows.Forms.Label();
            this.btnNextPage = new System.Windows.Forms.Label();
            this.btnPrePage = new System.Windows.Forms.Label();
            this.btnFirstPage = new System.Windows.Forms.Label();
            this.btnNextGroup = new PageButton();
            this.btnPreGroup = new PageButton();
            this.pageButton10 = new PageButton();
            this.pageButton9 = new PageButton();
            this.pageButton8 = new PageButton();
            this.pageButton7 = new PageButton();
            this.pageButton6 = new PageButton();
            this.pageButton5 = new PageButton();
            this.pageButton4 = new PageButton();
            this.pageButton3 = new PageButton();
            this.pageButton2 = new PageButton();
            this.pageButton1 = new PageButton();
            this.SuspendLayout();
            // 
            // btnLastPage
            // 
            this.btnLastPage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLastPage.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnLastPage.Location = new System.Drawing.Point(505, 8);
            this.btnLastPage.Name = "btnLastPage";
            this.btnLastPage.Size = new System.Drawing.Size(30, 23);
            this.btnLastPage.TabIndex = 23;
            this.btnLastPage.Text = "末页";
            this.btnLastPage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnLastPage.Click += new System.EventHandler(this.btnLastPage_Click);
            this.btnLastPage.MouseLeave += new System.EventHandler(this.btnFirstPage_MouseLeave);
            this.btnLastPage.MouseHover += new System.EventHandler(this.btnFirstPage_MouseHover);
            // 
            // btnNextPage
            // 
            this.btnNextPage.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnNextPage.Location = new System.Drawing.Point(462, 8);
            this.btnNextPage.Name = "btnNextPage";
            this.btnNextPage.Size = new System.Drawing.Size(42, 23);
            this.btnNextPage.TabIndex = 22;
            this.btnNextPage.Text = "下一页";
            this.btnNextPage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnNextPage.Click += new System.EventHandler(this.btnNextPage_Click);
            this.btnNextPage.MouseLeave += new System.EventHandler(this.btnFirstPage_MouseLeave);
            this.btnNextPage.MouseHover += new System.EventHandler(this.btnFirstPage_MouseHover);
            // 
            // btnPrePage
            // 
            this.btnPrePage.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPrePage.Location = new System.Drawing.Point(46, 8);
            this.btnPrePage.Name = "btnPrePage";
            this.btnPrePage.Size = new System.Drawing.Size(42, 23);
            this.btnPrePage.TabIndex = 21;
            this.btnPrePage.Text = "上一页";
            this.btnPrePage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnPrePage.Click += new System.EventHandler(this.btnPrePage_Click);
            this.btnPrePage.MouseLeave += new System.EventHandler(this.btnFirstPage_MouseLeave);
            this.btnPrePage.MouseHover += new System.EventHandler(this.btnFirstPage_MouseHover);
            // 
            // btnFirstPage
            // 
            this.btnFirstPage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFirstPage.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnFirstPage.Location = new System.Drawing.Point(15, 8);
            this.btnFirstPage.Name = "btnFirstPage";
            this.btnFirstPage.Size = new System.Drawing.Size(30, 23);
            this.btnFirstPage.TabIndex = 20;
            this.btnFirstPage.Text = "首页";
            this.btnFirstPage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnFirstPage.Click += new System.EventHandler(this.btnFirstPage_Click);
            this.btnFirstPage.MouseLeave += new System.EventHandler(this.btnFirstPage_MouseLeave);
            this.btnFirstPage.MouseHover += new System.EventHandler(this.btnFirstPage_MouseHover);
            // 
            // btnNextGroup
            // 
            this.btnNextGroup.BackColor = System.Drawing.Color.Transparent;
            this.btnNextGroup.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnNextGroup.Location = new System.Drawing.Point(431, 8);
            this.btnNextGroup.Name = "btnNextGroup";
            this.btnNextGroup.Size = new System.Drawing.Size(25, 23);
            this.btnNextGroup.TabIndex = 35;
            this.btnNextGroup.Text = "...";
            this.btnNextGroup.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnNextGroup.Click += new System.EventHandler(this.btnNextGroup_Click);
            // 
            // btnPreGroup
            // 
            this.btnPreGroup.BackColor = System.Drawing.Color.Transparent;
            this.btnPreGroup.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnPreGroup.Location = new System.Drawing.Point(90, 8);
            this.btnPreGroup.Name = "btnPreGroup";
            this.btnPreGroup.Size = new System.Drawing.Size(25, 23);
            this.btnPreGroup.TabIndex = 34;
            this.btnPreGroup.Text = "...";
            this.btnPreGroup.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnPreGroup.Click += new System.EventHandler(this.btnPreGroup_Click);
            // 
            // pageButton10
            // 
            this.pageButton10.BackColor = System.Drawing.Color.Transparent;
            this.pageButton10.Cursor = System.Windows.Forms.Cursors.Default;
            this.pageButton10.Location = new System.Drawing.Point(400, 8);
            this.pageButton10.Name = "pageButton10";
            this.pageButton10.Size = new System.Drawing.Size(25, 23);
            this.pageButton10.TabIndex = 33;
            this.pageButton10.Text = "10";
            this.pageButton10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pageButton9
            // 
            this.pageButton9.BackColor = System.Drawing.Color.Transparent;
            this.pageButton9.Cursor = System.Windows.Forms.Cursors.Default;
            this.pageButton9.Location = new System.Drawing.Point(369, 8);
            this.pageButton9.Name = "pageButton9";
            this.pageButton9.Size = new System.Drawing.Size(25, 23);
            this.pageButton9.TabIndex = 32;
            this.pageButton9.Text = "9";
            this.pageButton9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pageButton8
            // 
            this.pageButton8.BackColor = System.Drawing.Color.Transparent;
            this.pageButton8.Cursor = System.Windows.Forms.Cursors.Default;
            this.pageButton8.Location = new System.Drawing.Point(338, 8);
            this.pageButton8.Name = "pageButton8";
            this.pageButton8.Size = new System.Drawing.Size(25, 23);
            this.pageButton8.TabIndex = 31;
            this.pageButton8.Text = "8";
            this.pageButton8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pageButton7
            // 
            this.pageButton7.BackColor = System.Drawing.Color.Transparent;
            this.pageButton7.Cursor = System.Windows.Forms.Cursors.Default;
            this.pageButton7.Location = new System.Drawing.Point(307, 8);
            this.pageButton7.Name = "pageButton7";
            this.pageButton7.Size = new System.Drawing.Size(25, 23);
            this.pageButton7.TabIndex = 30;
            this.pageButton7.Text = "7";
            this.pageButton7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pageButton6
            // 
            this.pageButton6.BackColor = System.Drawing.Color.Transparent;
            this.pageButton6.Cursor = System.Windows.Forms.Cursors.Default;
            this.pageButton6.Location = new System.Drawing.Point(276, 8);
            this.pageButton6.Name = "pageButton6";
            this.pageButton6.Size = new System.Drawing.Size(25, 23);
            this.pageButton6.TabIndex = 29;
            this.pageButton6.Text = "6";
            this.pageButton6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pageButton5
            // 
            this.pageButton5.BackColor = System.Drawing.Color.Transparent;
            this.pageButton5.Cursor = System.Windows.Forms.Cursors.Default;
            this.pageButton5.Location = new System.Drawing.Point(245, 8);
            this.pageButton5.Name = "pageButton5";
            this.pageButton5.Size = new System.Drawing.Size(25, 23);
            this.pageButton5.TabIndex = 28;
            this.pageButton5.Text = "5";
            this.pageButton5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pageButton4
            // 
            this.pageButton4.BackColor = System.Drawing.Color.Transparent;
            this.pageButton4.Cursor = System.Windows.Forms.Cursors.Default;
            this.pageButton4.Location = new System.Drawing.Point(214, 8);
            this.pageButton4.Name = "pageButton4";
            this.pageButton4.Size = new System.Drawing.Size(25, 23);
            this.pageButton4.TabIndex = 27;
            this.pageButton4.Text = "4";
            this.pageButton4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pageButton3
            // 
            this.pageButton3.BackColor = System.Drawing.Color.Transparent;
            this.pageButton3.Cursor = System.Windows.Forms.Cursors.Default;
            this.pageButton3.Location = new System.Drawing.Point(183, 8);
            this.pageButton3.Name = "pageButton3";
            this.pageButton3.Size = new System.Drawing.Size(25, 23);
            this.pageButton3.TabIndex = 26;
            this.pageButton3.Text = "3";
            this.pageButton3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pageButton2
            // 
            this.pageButton2.BackColor = System.Drawing.Color.Transparent;
            this.pageButton2.Cursor = System.Windows.Forms.Cursors.Default;
            this.pageButton2.Location = new System.Drawing.Point(152, 8);
            this.pageButton2.Name = "pageButton2";
            this.pageButton2.Size = new System.Drawing.Size(25, 23);
            this.pageButton2.TabIndex = 25;
            this.pageButton2.Text = "2";
            this.pageButton2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pageButton1
            // 
            this.pageButton1.BackColor = System.Drawing.Color.Transparent;
            this.pageButton1.Cursor = System.Windows.Forms.Cursors.Default;
            this.pageButton1.Location = new System.Drawing.Point(121, 8);
            this.pageButton1.Name = "pageButton1";
            this.pageButton1.Size = new System.Drawing.Size(25, 23);
            this.pageButton1.TabIndex = 24;
            this.pageButton1.Text = "1";
            this.pageButton1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // WinFormPager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnNextGroup);
            this.Controls.Add(this.btnPreGroup);
            this.Controls.Add(this.pageButton10);
            this.Controls.Add(this.pageButton9);
            this.Controls.Add(this.pageButton8);
            this.Controls.Add(this.pageButton7);
            this.Controls.Add(this.pageButton6);
            this.Controls.Add(this.pageButton5);
            this.Controls.Add(this.pageButton4);
            this.Controls.Add(this.pageButton3);
            this.Controls.Add(this.pageButton2);
            this.Controls.Add(this.pageButton1);
            this.Controls.Add(this.btnLastPage);
            this.Controls.Add(this.btnNextPage);
            this.Controls.Add(this.btnPrePage);
            this.Controls.Add(this.btnFirstPage);
            this.Name = "WinFormPager";
            this.Size = new System.Drawing.Size(569, 37);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label btnLastPage;
        private System.Windows.Forms.Label btnNextPage;
        private System.Windows.Forms.Label btnPrePage;
        private System.Windows.Forms.Label btnFirstPage;
        private PageButton pageButton1;
        private PageButton pageButton2;
        private PageButton pageButton3;
        private PageButton pageButton4;
        private PageButton pageButton5;
        private PageButton pageButton6;
        private PageButton pageButton7;
        private PageButton pageButton8;
        private PageButton pageButton9;
        private PageButton pageButton10;
        private PageButton btnPreGroup;
        private PageButton btnNextGroup;
    }
}
