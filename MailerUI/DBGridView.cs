using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace MailerUI {
	internal class DBGridView : DataGridView {
		Color LinkColor = ColorTranslator.FromHtml("#00529E");
		bool _AutoIncrease = true;
		/// <summary>
		/// 根据行自动增长高度
		/// </summary>
		public bool AutoIncrease {
			get { return this._AutoIncrease; }
			set { this._AutoIncrease = value; }
		}

		Dictionary<string, double> WidthDict = new Dictionary<string, double>();
		public DBGridView() {
			this.SetStyle(ControlStyles.AllPaintingInWmPaint |
			ControlStyles.DoubleBuffer |
			ControlStyles.UserPaint, true);

			this.AllowUserToAddRows = false;
			this.AllowUserToResizeRows = false;
			this.AllowUserToDeleteRows = false;
			this.ColumnHeadersHeight = 26;
			this.RowHeadersVisible = false;

			DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
			this.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

			this.BorderStyle = BorderStyle.None;
			dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle2.Font = new Font("宋体", 9F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(134)));
			dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
			this.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;

			this.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
			this.RowHeadersVisible = false;
			this.RowTemplate.DefaultCellStyle.SelectionForeColor = Color.FromArgb(101, 101, 101);
			this.RowTemplate.DefaultCellStyle.ForeColor = Color.FromArgb(101, 101, 101);
			this.RowTemplate.Height = 24;
			this.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			this.EditMode = DataGridViewEditMode.EditOnEnter;

			this.Layout += (o, e) => {
				this.TabStop = false;
				this.ClearSelection();
				if (this.Rows.Count > 0) {
					this.Rows[0].Selected = false;
				}
				this.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			};
			this.Sorted += (o, e) => {
				string jian = string.Empty, Asc = "(↑)", Desc = "(↓)", Exp = @"\((?:↑|↓)\)$",
				 HeadText = this.SortedColumn.HeaderText;
				switch (this.SortOrder) {
					case System.Windows.Forms.SortOrder.Ascending: { jian = Asc; break; }
					case System.Windows.Forms.SortOrder.Descending: { jian = Desc; break; }
				}
				HeadText += jian;
				this.SortedColumn.HeaderText = HeadText;
				this.SortedColumn.HeaderCell.Style.ForeColor = Color.Red;

			};
			this.CellBeginEdit += (o, e) => {
				if (e.ColumnIndex > -1 && e.RowIndex > -1) {
					Color clr = Color.FromArgb(247, 247, 247);
					if (e.RowIndex % 2 == 0) clr = Color.FromArgb(241, 241, 241);
					this.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = clr;
				}
			};
			this.EditingControlShowing += (o, e) => {
				e.Control.KeyPress += (o1, e1) => { e1.Handled = true; };
				e.Control.KeyUp += (o2, e2) => {
					if (e2.Control && e2.KeyCode == Keys.C) {
						try {
							Clipboard.SetText(((TextBox)o2).SelectedText, TextDataFormat.Text);
						} catch { }
					}
				};
				e.Control.KeyDown += (o3, e3) => {
					if (e3.Control && e3.KeyCode == Keys.C) {
						base.OnKeyDown(e3);
					} else e3.Handled = true;
				};
			};
		}

		protected override void OnResize(EventArgs e) {
			if (this._AutoIncrease)
				this.Height = this.RowTemplate.Height * this.Rows.Count + 26;
			base.OnResize(e);
		}

		protected override void OnRowsAdded(DataGridViewRowsAddedEventArgs e) {
			if (this._AutoIncrease)
				this.Height = this.RowTemplate.Height * this.Rows.Count + 26;
			base.OnRowsAdded(e);
		}

		protected override void OnRowsRemoved(DataGridViewRowsRemovedEventArgs e) {
			if (this._AutoIncrease)
				this.Height = this.RowTemplate.Height * this.Rows.Count + 26;
			base.OnRowsRemoved(e);
		}

		/// <summary>
		/// 重绘Column、Row
		/// </summary>
		/// <param name="e"></param>
		protected override void OnCellPainting(DataGridViewCellPaintingEventArgs e) {
			this.ColumnHeadersHeight = 26;
			if (e.RowIndex == -1) {
				drawColumnHead(e); e.Handled = true;
			} else if (e.ColumnIndex < 0 && e.RowIndex >= 0) {
				drawColumnHead(e); e.Handled = true;
			}
			if (e.RowIndex > -1) {
				drawColumnRow(e); e.Handled = true;
			}
			base.OnCellPainting(e);
		}

		protected override void OnColumnAdded(DataGridViewColumnEventArgs e) {
			if (e.Column.GetType() == typeof(DataGridViewLinkColumn)) {
				var link = e.Column as DataGridViewLinkColumn;
				link.LinkColor = LinkColor;
				link.VisitedLinkColor = LinkColor;
			}
			base.OnColumnAdded(e);
		}

		/// <summary>
		/// Column和RowHeader绘制
		/// </summary>
		/// <param name="e"></param>
		void drawColumnHead(DataGridViewCellPaintingEventArgs e) {
			Image image = global::MailerUI.Properties.Resources.titlebg;
			Color clr = Color.FromArgb(247, 247, 247), clr2 = Color.FromArgb(214, 214, 214);
			TextureBrush tBrush = new TextureBrush(image);
			Rectangle border = e.CellBounds;
			border.Width += 1;
			e.Graphics.FillRectangle(tBrush, border);
			e.Graphics.DrawLine(new Pen(clr2, 1), new PointF(border.Left, border.Top), new PointF(border.Right, border.Top));
			if (e.ColumnIndex == 0) {
				e.Graphics.DrawLine(new Pen(clr2, 1), new PointF(border.Left, border.Top), new PointF(border.Left, border.Bottom));
			}
			if (e.ColumnIndex == this.Columns.Count - 1) {
				e.Graphics.DrawLine(new Pen(clr2, 1), new PointF(border.Right - 2, border.Top), new PointF(border.Right - 2, border.Bottom));
			}
			e.Graphics.DrawLine(new Pen(clr2, 1),
				new PointF(border.Left, border.Bottom - 1), new PointF(border.Right, border.Bottom - 1)
				);
			e.PaintContent(e.CellBounds);
		}

		/// <summary>
		/// Column和RowHeader绘制
		/// </summary>
		/// <param name="e"></param>
		void drawColumnRow(DataGridViewCellPaintingEventArgs e) {
			Rectangle border = e.CellBounds;
			Color clr = Color.FromArgb(247, 247, 247),
				  clr2 = Color.FromArgb(214, 214, 214);
			if (e.RowIndex % 2 == 0) clr = Color.FromArgb(241, 241, 241);

			using (Brush br = new SolidBrush(clr)) {
				e.Graphics.FillRectangle(br, border);
			}

			border.Width += 1;
			e.Graphics.DrawLine(new Pen(clr2, 1),
				new PointF(border.Left, border.Bottom - 1),
				new PointF(border.Right, border.Bottom - 1)
				);
			if (e.ColumnIndex == 0) {
				//左线
				e.Graphics.DrawLine(new Pen(clr2, 1), new PointF(border.Left, border.Top), new PointF(border.Left, border.Bottom));
			}
			if (e.ColumnIndex == this.Columns.Count - 1) {
				//右线
				e.Graphics.DrawLine(new Pen(clr2, 1), new PointF(border.Right - 2, border.Top), new PointF(border.Right - 2, border.Bottom));
			}

			e.PaintContent(e.CellBounds);
		}
	}
}
