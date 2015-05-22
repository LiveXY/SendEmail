using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing;
namespace MailerUI
{
    internal partial class PageButton : Label
    {
        private enum MouseActionType
        {
            None,
            Hover,
            Click
        }

        private MouseActionType mouseAction;
        public PageButton()
        {
            InitializeComponent();
            mouseAction = MouseActionType.None;
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                ControlStyles.DoubleBuffer |
                ControlStyles.UserPaint, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Color backColor = this.BackColor;
           
            if (this.ForeColor != Color.Red && mouseAction == MouseActionType.Click)
            {
                mouseAction = MouseActionType.None;
            }
            if (this.ForeColor == Color.Red)
            {
                mouseAction = MouseActionType.Click;
            }
            switch (mouseAction)
            {
                case MouseActionType.None:
                    backColor = Color.Transparent;
                    this.Cursor = Cursors.Default;
                    break;
                case MouseActionType.Hover:
                    backColor = ColorTranslator.FromHtml("#417EB7"); //ColorTranslator.FromHtml("#ADA8AC"); 标签栏的背景色
                    this.Cursor = Cursors.Hand;
                    break;
                case MouseActionType.Click:
                    backColor = Color.Transparent;
                    this.Cursor = Cursors.Default;
                    break;
            }


            Brush backbrush = new SolidBrush(backColor);
            e.Graphics.FillRectangle(backbrush, ClientRectangle);//刷背景色
            Color borderColor = ColorTranslator.FromHtml("#A6A6A6");// #F7F7F7是背景色
            if (mouseAction == MouseActionType.None) //画边框
            {
                ControlPaint.DrawBorder(e.Graphics,
                                    this.ClientRectangle,
                                    borderColor,
                                    1,
                                    ButtonBorderStyle.Solid,
                                    borderColor,
                                    1,
                                    ButtonBorderStyle.Solid,
                                    borderColor,
                                    1,
                                    ButtonBorderStyle.Solid,
                                    borderColor,
                                    1,
                                    ButtonBorderStyle.Solid);
            }            
            base.OnPaint(e);


        }

        protected override void OnMouseHover(EventArgs e)
        {
            if (this.ForeColor != Color.Red)
            {
                this.mouseAction = MouseActionType.Hover;
                base.OnMouseHover(e);
                this.Invalidate();
            }

        }

        protected override void OnMouseLeave(EventArgs e)
        {
            if (this.ForeColor != Color.Red)
            {
                this.mouseAction = MouseActionType.None;
                base.OnMouseLeave(e);
                this.Invalidate();
            }

        }
    }
}
