using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace MailerUI {
 
	/// <summary>
	/// Event Handler for SubItem events
	/// </summary>
	public delegate void SubItemEventHandler(object sender, SubItemEventArgs e);
	/// <summary>
	/// Event Handler for SubItemEndEditing events
	/// </summary>
	public delegate void SubItemEndEditingEventHandler(object sender, SubItemEndEditingEventArgs e);

	/// <summary>
	/// Event Args for SubItemClicked event
	/// </summary>
	public class SubItemEventArgs : EventArgs
	{
		public SubItemEventArgs(ListViewItem item, int subItem)
		{
			_subItemIndex = subItem;
			_item = item;
		}
		private int _subItemIndex = -1;
		private ListViewItem _item = null;
		public int SubItem
		{
			get { return _subItemIndex; }
		}
		public ListViewItem Item
		{
			get { return _item; }
		}
	}


	/// <summary>
	/// Event Args for SubItemEndEditingClicked event
	/// </summary>
	public class SubItemEndEditingEventArgs : SubItemEventArgs
	{
		private string _text = string.Empty;
		private bool _cancel = true;

		public SubItemEndEditingEventArgs(ListViewItem item, int subItem, string display, bool cancel) :
			base(item, subItem)
		{
			_text = display;
			_cancel = cancel;
		}
		public string DisplayText
		{
			get { return _text; }
			set { _text = value; }
		}
		public bool Cancel
		{
			get { return _cancel; }
			set { _cancel = value; }
		}
	}


	///	<summary>
	///	Inherited ListView to allow in-place editing of subitems
	///	</summary>
	public class ListViewEx	: System.Windows.Forms.ListView
	{
		#region Interop structs, imports and constants
		/// <summary>
		/// MessageHeader for WM_NOTIFY
		/// </summary>
		private struct NMHDR 
		{ 
			public IntPtr hwndFrom; 
			public Int32  idFrom; 
			public Int32  code; 
		}


		[DllImport("user32.dll")]
		private	static extern IntPtr SendMessage(IntPtr hWnd, int msg,	IntPtr wPar, IntPtr	lPar);
		[DllImport("user32.dll", CharSet=CharSet.Ansi)]
		private	static extern IntPtr SendMessage(IntPtr	hWnd, int msg, int len,	ref	int	[] order);

		// ListView messages
		private const int LVM_FIRST					= 0x1000;
		private const int LVM_GETCOLUMNORDERARRAY	= (LVM_FIRST + 59);

		// Windows Messages that will abort editing
		private	const int WM_HSCROLL = 0x114;
		private	const int WM_VSCROLL = 0x115;
		private const int WM_SIZE	 = 0x05;
		private const int WM_NOTIFY	 = 0x4E;

		private const int HDN_FIRST = -300;
		private const int HDN_BEGINDRAG = (HDN_FIRST-10);
		private const int HDN_ITEMCHANGINGA = (HDN_FIRST-0);
		private const int HDN_ITEMCHANGINGW = (HDN_FIRST-20);
		#endregion

		///	<summary>
		///	Required designer variable.
		///	</summary>
		private	System.ComponentModel.Container	components = null;

		public event SubItemEventHandler SubItemClicked;
		public event SubItemEventHandler SubItemBeginEditing;
		public event SubItemEndEditingEventHandler SubItemEndEditing;

		public ListViewEx()
		{
			// This	call is	required by	the	Windows.Forms Form Designer.
			InitializeComponent();

			//base.FullRowSelect = true;
			base.View = View.Details;
			base.AllowColumnReorder = true;

            base.ColumnClick += new ColumnClickEventHandler(Xshow_ColumnClick);
            base.DragEnter += new DragEventHandler(Xshow_DragEnter);
            base.DragDrop += new DragEventHandler(Xshow_DragDrop);

            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(1, 20);
            SmallImageList = imgList;
            HideSelection = false;
		}

		///	<summary>
		///	Clean up any resources being used.
		///	</summary>
		protected override void	Dispose( bool disposing	)
		{
			if(	disposing )
			{
				if(	components != null )
					components.Dispose();
			}
			base.Dispose( disposing	);
		}

		#region Component	Designer generated code
		///	<summary>
		///	Required method	for	Designer support - do not modify 
		///	the	contents of	this method	with the code editor.
		///	</summary>
		private	void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
		}
	  #endregion



		private bool _doubleClickActivation = false;
		/// <summary>
		/// Is a double click required to start editing a cell?
		/// </summary>
		public bool DoubleClickActivation
		{
			get {  return _doubleClickActivation; }
			set { _doubleClickActivation = value; }    
		}


		/// <summary>
		/// Retrieve the order in which columns appear
		/// </summary>
		/// <returns>Current display order of column indices</returns>
		public int[] GetColumnOrder()
		{
			IntPtr lPar	= Marshal.AllocHGlobal(Marshal.SizeOf(typeof(int)) * Columns.Count);

			IntPtr res = SendMessage(Handle, LVM_GETCOLUMNORDERARRAY, new IntPtr(Columns.Count), lPar);
			if (res.ToInt32() == 0)	// Something went wrong
			{
				Marshal.FreeHGlobal(lPar);
				return null;
			}

			int	[] order = new int[Columns.Count];
			Marshal.Copy(lPar, order, 0, Columns.Count);

			Marshal.FreeHGlobal(lPar);

			return order;
		}


		/// <summary>
		/// Find ListViewItem and SubItem Index at position (x,y)
		/// </summary>
		/// <param name="x">relative to ListView</param>
		/// <param name="y">relative to ListView</param>
		/// <param name="item">Item at position (x,y)</param>
		/// <returns>SubItem index</returns>
		public int GetSubItemAt(int x, int y, out ListViewItem item)
		{
			item = this.GetItemAt(x, y);
		
			if (item !=	null)
			{
				int[] order = GetColumnOrder();
				Rectangle lviBounds;
				int	subItemX;

				lviBounds =	item.GetBounds(ItemBoundsPortion.Entire);
				subItemX = lviBounds.Left;
				for (int i=0; i<order.Length; i++)
				{
					ColumnHeader h = this.Columns[order[i]];
					if (x <	subItemX+h.Width)
					{
						return h.Index;
					}
					subItemX += h.Width;
				}
			}
			
			return -1;
		}


		/// <summary>
		/// Get bounds for a SubItem
		/// </summary>
		/// <param name="Item">Target ListViewItem</param>
		/// <param name="SubItem">Target SubItem index</param>
		/// <returns>Bounds of SubItem (relative to ListView)</returns>
		public Rectangle GetSubItemBounds(ListViewItem Item, int SubItem)
		{
			int[] order = GetColumnOrder();

			Rectangle subItemRect = Rectangle.Empty;
			if (SubItem >= order.Length)
				throw new IndexOutOfRangeException("SubItem "+SubItem+" out of range");

			if (Item == null)
				throw new ArgumentNullException("Item");
			
			Rectangle lviBounds = Item.GetBounds(ItemBoundsPortion.Entire);
			int	subItemX = lviBounds.Left;

			ColumnHeader col;
			int i;
			for (i=0; i<order.Length; i++)
			{
				col = this.Columns[order[i]];
				if (col.Index == SubItem)
					break;
				subItemX += col.Width;
			} 
			subItemRect	= new Rectangle(subItemX, lviBounds.Top, this.Columns[order[i]].Width, lviBounds.Height);
			return subItemRect;
		}


		protected override void	WndProc(ref	Message	msg)
		{
			switch (msg.Msg)
			{
				// Look	for	WM_VSCROLL,WM_HSCROLL or WM_SIZE messages.
				case WM_VSCROLL:
				case WM_HSCROLL:
				case WM_SIZE:
					EndEditing(false);
					break;
				case WM_NOTIFY:
					// Look for WM_NOTIFY of events that might also change the
					// editor's position/size: Column reordering or resizing
					NMHDR h = (NMHDR)Marshal.PtrToStructure(msg.LParam, typeof(NMHDR));
					if (h.code == HDN_BEGINDRAG ||
						h.code == HDN_ITEMCHANGINGA ||
						h.code == HDN_ITEMCHANGINGW)
						EndEditing(false);
					break;
                case WM_PAINT:
                    if (View != View.Details)
                        break;

                    // Calculate the position of all embedded controls
                    foreach (EmbeddedControl ec in _embeddedControls)
                    {
                        Rectangle rc = this.GetSubItemBounds(ec.Item, ec.Column);

                        if ((this.HeaderStyle != ColumnHeaderStyle.None) &&
                            (rc.Top < this.Font.Height)) // Control overlaps ColumnHeader
                        {
                            ec.Control.Visible = false;
                            continue;
                        }
                        else
                        {
                            ec.Control.Visible = true;
                        }

                        switch (ec.Dock)
                        {
                            case DockStyle.Fill:
                                break;
                            case DockStyle.Top:
                                rc.Height = ec.Control.Height;
                                break;
                            case DockStyle.Left:
                                rc.Width = ec.Control.Width;
                                break;
                            case DockStyle.Bottom:
                                rc.Offset(0, rc.Height - ec.Control.Height);
                                rc.Height = ec.Control.Height;
                                break;
                            case DockStyle.Right:
                                rc.Offset(rc.Width - ec.Control.Width, 0);
                                rc.Width = ec.Control.Width;
                                break;
                            case DockStyle.None:
                                rc.Size = ec.Control.Size;
                                break;
                        }

                        // Set embedded control's bounds
                        ec.Control.Bounds = rc;
                    }
                    break;
			}

			base.WndProc(ref msg);
		}


		#region Initialize editing depending of DoubleClickActivation property
		protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
		{
			base.OnMouseUp(e);

			if (DoubleClickActivation)
			{
				return;
			} 

			EditSubitemAt(new Point(e.X, e.Y));
		}
		
		protected override void OnDoubleClick(EventArgs e)
		{
			base.OnDoubleClick (e);

			if (!DoubleClickActivation)
			{
				return;
			} 

			Point pt = this.PointToClient(Cursor.Position);
		
			EditSubitemAt(pt);
		}

		///<summary>
		/// Fire SubItemClicked
		///</summary>
		///<param name="p">Point of click/doubleclick</param>
		private void EditSubitemAt(Point p)
		{
			ListViewItem item;
			int idx = GetSubItemAt(p.X, p.Y, out item);
			if (idx >= 0)
			{
				OnSubItemClicked(new SubItemEventArgs(item, idx));
			}
		}

		#endregion

		#region In-place editing functions
		// The control performing the actual editing
		private Control _editingControl;
		// The LVI being edited
		private ListViewItem _editItem;
		// The SubItem being edited
		private int _editSubItem;

		protected void OnSubItemBeginEditing(SubItemEventArgs e)
		{
			if (SubItemBeginEditing != null)
				SubItemBeginEditing(this, e);
		}
		protected void OnSubItemEndEditing(SubItemEndEditingEventArgs e)
		{
			if (SubItemEndEditing != null)
				SubItemEndEditing(this, e);
		}
		protected void OnSubItemClicked(SubItemEventArgs e)
		{
			if (SubItemClicked != null)
				SubItemClicked(this, e);
		}


		/// <summary>
		/// Begin in-place editing of given cell
		/// </summary>
		/// <param name="c">Control used as cell editor</param>
		/// <param name="Item">ListViewItem to edit</param>
		/// <param name="SubItem">SubItem index to edit</param>
		public void StartEditing(Control c, ListViewItem Item, int SubItem)
		{
			OnSubItemBeginEditing(new SubItemEventArgs(Item, SubItem));

			Rectangle rcSubItem = GetSubItemBounds(Item, SubItem);

			if (rcSubItem.X < 0)
			{
				// Left edge of SubItem not visible - adjust rectangle position and width
				rcSubItem.Width += rcSubItem.X;
				rcSubItem.X=0;
			}
			if (rcSubItem.X+rcSubItem.Width > this.Width)
			{
				// Right edge of SubItem not visible - adjust rectangle width
				rcSubItem.Width = this.Width-rcSubItem.Left;
			}

			// Subitem bounds are relative to the location of the ListView!
			rcSubItem.Offset(Left, Top);

			// In case the editing control and the listview are on different parents,
			// account for different origins
			Point origin = new Point(0,0);
			Point lvOrigin  = this.Parent.PointToScreen(origin);
			Point ctlOrigin  = c.Parent.PointToScreen(origin);

			rcSubItem.Offset(lvOrigin.X-ctlOrigin.X, lvOrigin.Y-ctlOrigin.Y);

			// Position and show editor
			c.Bounds = rcSubItem;
			c.Text = Item.SubItems[SubItem].Text;
			c.Visible = true;
			c.BringToFront();
			c.Focus();

			_editingControl = c;
			_editingControl.Leave += new EventHandler(_editControl_Leave);
			_editingControl.KeyPress += new KeyPressEventHandler(_editControl_KeyPress);

			_editItem = Item;
			_editSubItem = SubItem;
		}


		private void _editControl_Leave(object sender, EventArgs e)
		{
			// cell editor losing focus
			EndEditing(true);
		}

		private void _editControl_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			switch (e.KeyChar)
			{
				case (char)(int)Keys.Escape:
				{
					EndEditing(false);
					break;
				}

				case (char)(int)Keys.Enter:
				{  
					EndEditing(true);
					break;
				}
			}
		}

		/// <summary>
		/// Accept or discard current value of cell editor control
		/// </summary>
		/// <param name="AcceptChanges">Use the _editingControl's Text as new SubItem text or discard changes?</param>
		public void EndEditing(bool AcceptChanges)
		{
			if (_editingControl == null)
				return;

			SubItemEndEditingEventArgs e = new SubItemEndEditingEventArgs(
				_editItem,		// The item being edited
				_editSubItem,	// The subitem index being edited
				AcceptChanges ?
					_editingControl.Text :	// Use editControl text if changes are accepted
					_editItem.SubItems[_editSubItem].Text,	// or the original subitem's text, if changes are discarded
				!AcceptChanges	// Cancel?
			);

			OnSubItemEndEditing(e);

			_editItem.SubItems[_editSubItem].Text = e.DisplayText;

			_editingControl.Leave -= new EventHandler(_editControl_Leave);
			_editingControl.KeyPress -= new KeyPressEventHandler(_editControl_KeyPress);

			_editingControl.Visible = false;

			_editingControl = null;
			_editItem = null;
			_editSubItem = -1;
		}
		#endregion

        #region "文件拖放及排序"
        private bool _AllowFileDragDrop = false;
        public bool AllowFileDragDrop
        {
            set { _AllowFileDragDrop = value; }
            get { return _AllowFileDragDrop; }
        }
        public event EventHandler<DragEventArgs> XDragDrop;
        class SortType : IComparer
        {
            int _subcolIdx;
            bool _descending;
            public int SubcolIdx
            {
                get { return _subcolIdx; }
                set { _subcolIdx = value; }
            }
            public bool Descending
            {
                get { return _descending; }
                set { _descending = value; }
            }

            public SortType(int subcolIdx)
            {
                _subcolIdx = subcolIdx;
                _descending = false;
            }

            public int Compare(object a, object b)
            {
                int compareResult;

                ListViewItem x, y;
                if (_descending) { x = (ListViewItem)b; y = (ListViewItem)a; }
                else { x = (ListViewItem)a; y = (ListViewItem)b; }

                //SubItems[0] == item in first row, SubItems[1]=first subitem
                string xText = string.Empty;
                if (x.SubItems.Count > _subcolIdx) xText = x.SubItems[_subcolIdx].Text;
                string yText = string.Empty;
                if (y.SubItems.Count > _subcolIdx) yText = y.SubItems[_subcolIdx].Text;

                DateTime xDate = DateTime.MinValue;
                DateTime yDate = DateTime.MinValue;

                decimal xDec = decimal.MinValue;
                decimal yDec = decimal.MinValue;

                Int64 xInt = 0;
                Int64 yInt = 0;

                if (Int64.TryParse(xText, out xInt) && Int64.TryParse(yText, out yInt))
                { 
                    compareResult = xInt.CompareTo(yInt);
                }
                else if (DateTime.TryParse(xText, out xDate) && DateTime.TryParse(yText, out yDate))
                {
                    if (xDate > yDate)
                        compareResult = 1;
                    else if (xDate == yDate)
                        compareResult = 0;
                    else
                        compareResult = -1;
                }
                else if (decimal.TryParse(xText, out xDec) && decimal.TryParse(yText, out yDec))
                {
                    if (xDec > yDec)
                        compareResult = 1;
                    else if (xDec == yDec)
                        compareResult = 0;
                    else
                        compareResult = -1;
                }
                else
                {
                    if (string.IsNullOrEmpty(xText))
                        compareResult = 1;
                    else if (string.IsNullOrEmpty(yText))
                        compareResult = - 1;
                    else
                        compareResult = String.Compare(xText, y.Text);
                }

                return compareResult; 
            }
        }


        void Xshow_DragDrop(object sender, DragEventArgs e)
        {
            if (!AllowFileDragDrop) return;

            string[] ss = (string[])e.Data.GetData(DataFormats.FileDrop);
            BeginUpdate();
            foreach (string s in ss)
            {
                Items.Add(s);
            }
            EndUpdate();

            //add your own Event Handler
            XDragDrop(this, e);
        }

        void Xshow_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
            else e.Effect = DragDropEffects.None;
        }

        void Xshow_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (Items.Count <= 1) return;
            if (this.VirtualMode) return;

            SortType st = ListViewItemSorter as SortType;
            if (st == null) ListViewItemSorter = new SortType(e.Column);
            else
            {
                st.Descending = !st.Descending; st.SubcolIdx = e.Column;
            }
            Sort(); 
        }
        #endregion

        #region "内嵌控件" 
		
		// Windows Messages
		private const int WM_PAINT = 0x000F;
 

		/// <summary>
		/// Structure to hold an embedded control's info
		/// </summary>
		private struct EmbeddedControl
		{
			public Control Control;
			public int Column;
			public int Row;
			public DockStyle Dock;
			public ListViewItem Item;
		}

		private ArrayList _embeddedControls = new ArrayList();
	  
  
		/// <summary>
		/// Add a control to the ListView
		/// </summary>
		/// <param name="c">Control to be added</param>
		/// <param name="col">Index of column</param>
		/// <param name="row">Index of row</param>
		public void AddEmbeddedControl(Control c, int col, int row)
		{
			AddEmbeddedControl(c,col,row,DockStyle.Fill);
		}
		/// <summary>
		/// Add a control to the ListView
		/// </summary>
		/// <param name="c">Control to be added</param>
		/// <param name="col">Index of column</param>
		/// <param name="row">Index of row</param>
		/// <param name="dock">Location and resize behavior of embedded control</param>
		public void AddEmbeddedControl(Control c, int col, int row, DockStyle dock)
		{
			if (c==null)
				throw new ArgumentNullException();
			if (col>=Columns.Count || row>=Items.Count)
				throw new ArgumentOutOfRangeException();

			EmbeddedControl ec;
			ec.Control = c;
			ec.Column = col;
			ec.Row = row;
			ec.Dock = dock;
			ec.Item = Items[row];

			_embeddedControls.Add(ec);

			// Add a Click event handler to select the ListView row when an embedded control is clicked
			c.Click += new EventHandler(_embeddedControl_Click);
			
			this.Controls.Add(c);
		}
		
		/// <summary>
		/// Remove a control from the ListView
		/// </summary>
		/// <param name="c">Control to be removed</param>
		public void RemoveEmbeddedControl(Control c)
		{
			if (c == null)
				throw new ArgumentNullException();

			for (int i=0; i<_embeddedControls.Count; i++)
			{
				EmbeddedControl ec = (EmbeddedControl)_embeddedControls[i];
				if (ec.Control == c)
				{
					c.Click -= new EventHandler(_embeddedControl_Click);
					this.Controls.Remove(c);
					_embeddedControls.RemoveAt(i);
					return;
				}
			}
			//throw new Exception("Control not found!");
		}
		
		/// <summary>
		/// Retrieve the control embedded at a given location
		/// </summary>
		/// <param name="col">Index of Column</param>
		/// <param name="row">Index of Row</param>
		/// <returns>Control found at given location or null if none assigned.</returns>
		public Control GetEmbeddedControl(int col, int row)
		{
			foreach (EmbeddedControl ec in _embeddedControls)
				if (ec.Row == row && ec.Column == col)
					return ec.Control;

			return null;
		}

		[DefaultValue(View.LargeIcon)]
		public new View View
		{
			get 
			{
				return base.View;
			}
			set
			{
				// Embedded controls are rendered only when we're in Details mode
				foreach (EmbeddedControl ec in _embeddedControls)
					ec.Control.Visible = (value == View.Details);

				base.View = value;
			}
		}


		private void _embeddedControl_Click(object sender, EventArgs e)
		{
			// When a control is clicked the ListViewItem holding it is selected
			//foreach (EmbeddedControl ec in _embeddedControls)
            for (int i=0; i<_embeddedControls.Count; i++)
			{
                EmbeddedControl ec = (EmbeddedControl)_embeddedControls[i];
				if (ec.Control == (Control)sender)
				{
					this.SelectedItems.Clear();
					ec.Item.Selected = true;
                    break;
				}
			}
		}
        #endregion

        #region Group Methods

        #region Thread-Safe GroupBy Method
        delegate void dGroupBy(ColumnHeader[] Headers);
        public void GroupBy(ColumnHeader[] Headers)
        {
            if (this.InvokeRequired)
            {
                dGroupBy d = new dGroupBy(GroupBy);
                this.Invoke(d, new object[] { Headers });
            }
            else
            {
                if (this.VirtualMode)
                {
                    //
                }
                else
                {
                    #region 非虚拟模式
                    foreach (ListViewItem lvi in this.Items)
                    {
                        string header = "";

                        foreach (ColumnHeader ch in Headers)
                        {
                            header += " " + lvi.SubItems[ch.Index].Text;
                        }

                        ListViewGroup group = new ListViewGroup(header);
                        ListViewGroup found = null;
                        foreach (ListViewGroup g in Groups)
                        {
                            if (g.Header == group.Header)
                            { found = g; break; }
                        }
                        if (found == null)
                        {
                            this.Groups.Add(group);
                            group.Items.Add(lvi);
                        }
                        else
                        {
                            found.Items.Add(lvi);
                        }
                    }
                    #endregion
                }
            }
        }
        #endregion

        public virtual void GroupBy(ArrayList HeaderGroup)
        {
            GroupBy((ColumnHeader[])HeaderGroup.ToArray(typeof(ColumnHeader)));
        } 

        #endregion

        private int _AutoFillColumnIndex = -1;
        public int AutoFillColumnIndex
        {
            get { return _AutoFillColumnIndex; }
            set { 
                _AutoFillColumnIndex = value;
                if (value > this.Columns.Count - 1|| _AutoFillColumnIndex < 0) return;

                _AutoFillColumnMinWidth = Columns[value].Width;
            }
        }
        private int _AutoFillColumnMinWidth = -1;
        public int AutoFillColumnMinWidth
        {
            get { return _AutoFillColumnMinWidth; }
            set { _AutoFillColumnMinWidth = value; }
        }
 
        protected override void OnSizeChanged(EventArgs e)
        {
            if (_AutoFillColumnIndex > -1 && _AutoFillColumnIndex < Columns.Count)
            {
                int iWidth = ClientSize.Width;
                for (int i = 0; i < Columns.Count; i++)
                {
                    if (i != _AutoFillColumnIndex)
                        iWidth = iWidth - Columns[i].Width - 4;
                }

                if (iWidth > _AutoFillColumnMinWidth)
                {
                    Columns[_AutoFillColumnIndex].Width = iWidth;
                }
            }

            base.OnSizeChanged(e);
        }
    }

    public class ListViewItemEx : ListViewItem
    {
        private Color _ForeColor2 = Color.Black;
        /// <summary>
        /// 保存原有的字体颜色，以备重画后还原
        /// </summary>
        public Color ForeColor2
        {
            get { return _ForeColor2; }
            set { _ForeColor2 = value; }
        }

        private int _ImageIndexNormal = 0;
        public int ImageIndexNormal
        {
            get { return _ImageIndexNormal; }
            set { 
                _ImageIndexNormal = value;
                base.ImageIndex = value;
            }
        } 

        private int _ImageIndexSelected = 1;
        public int ImageIndexSelected
        {
            get { return _ImageIndexSelected; }
            set { _ImageIndexSelected = value; }
        }

        private Font _FontNormal = SystemFonts.IconTitleFont;
        public Font FontNormal
        {
            get { return _FontNormal; }
            set { _FontNormal = value; }
        }

        private Font _FontSelected = SystemFonts.IconTitleFont;
        public Font FontSelected
        {
            get { return _FontSelected; }
            set { _FontSelected = value; }
        }

        #region 继承ListViewItem的构造方法
        public ListViewItemEx() : base() { } 
        public ListViewItemEx(string[] items) : base(items) { } 
        public ListViewItemEx(string text) : base(text) {  } 
        public ListViewItemEx(ListViewItem.ListViewSubItem[] subItems, int imageIndex) : base(subItems, imageIndex) {  } 
        public ListViewItemEx(string[] items, int imageIndex) : base(items, imageIndex) { }
        public ListViewItemEx(string[] items, string imageKey, ListViewGroup group) : base(items, imageKey, group) { }
        public ListViewItemEx(string[] items, int imageIndex, Color foreColor, Color backColor, Font font)
            : base(items, imageIndex, foreColor, backColor, font) { }
        public ListViewItemEx(string[] items, string imageKey, Color foreColor, Color backColor, Font font)
            : base(items, imageKey, foreColor, backColor, font) { }
        #endregion
    }
}
