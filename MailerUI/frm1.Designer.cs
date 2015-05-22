namespace MailerUI
{
    partial class frm1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm1));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.listView1 = new MailerUI.ListViewEx();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.mnuNext = new System.Windows.Forms.ToolStripButton();
            this.mnuPrev = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStrip3.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1112, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // listView1
            // 
            this.listView1.AllowColumnReorder = true;
            this.listView1.AllowFileDragDrop = false;
            this.listView1.AutoFillColumnIndex = -1;
            this.listView1.AutoFillColumnMinWidth = -1;
            this.listView1.CheckBoxes = true;
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.DoubleClickActivation = false;
            this.listView1.FullRowSelect = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(0, 25);
            this.listView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1112, 406);
            this.listView1.TabIndex = 9;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // toolStrip3
            // 
            this.toolStrip3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuPrev,
            this.mnuNext,
            this.toolStripLabel1});
            this.toolStrip3.Location = new System.Drawing.Point(0, 404);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Size = new System.Drawing.Size(1112, 27);
            this.toolStrip3.TabIndex = 10;
            this.toolStrip3.Text = "toolStrip3";
            // 
            // mnuNext
            // 
            this.mnuNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.mnuNext.Image = ((System.Drawing.Image)(resources.GetObject("mnuNext.Image")));
            this.mnuNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuNext.Name = "mnuNext";
            this.mnuNext.Size = new System.Drawing.Size(118, 24);
            this.mnuNext.Text = "显示下一页数据";
            this.mnuNext.Click += new System.EventHandler(this.mnuNext_Click);
            // 
            // mnuPrev
            // 
            this.mnuPrev.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.mnuPrev.Image = global::MailerUI.Properties.Resources.edit16;
            this.mnuPrev.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuPrev.Name = "mnuPrev";
            this.mnuPrev.Size = new System.Drawing.Size(118, 24);
            this.mnuPrev.Text = "显示上一页数据";
            this.mnuPrev.Click += new System.EventHandler(this.mnuPrev_Click);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(122, 24);
            this.toolStripLabel1.Text = "toolStripLabel1";
            // 
            // frm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1112, 431);
            this.Controls.Add(this.toolStrip3);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frm1";
            this.TabText = "frm1";
            this.Text = "frm1";
            this.Load += new System.EventHandler(this.frm1_Load);
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private ListViewEx listView1;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripButton mnuNext;
        private System.Windows.Forms.ToolStripButton mnuPrev;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
    }
}