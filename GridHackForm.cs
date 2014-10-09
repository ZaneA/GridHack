using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace GridHack
{
    public partial class GridHackForm : Form
    {
        // Grid size is 8 rows, 8 cols
        // gridWidth and gridHeight are pixel values of the cell size
        const int gridSize = 8, gridWidth = 42, gridHeight = 24;

        // Store a handle to a window that should be resized
        IntPtr hwnd;

        public GridHackForm()
        {
            InitializeComponent();
            this.Visible = false; // Form is hidden at launch

            // Setup columns
            windowGrid.AutoGenerateColumns = false;

            for (int i = 0; i < gridSize; i++)
            {
                windowGrid.Columns.Add(new DataGridViewTextBoxColumn());
            }


            // Setup rows
            Array[] rows = new Array[gridSize];
            windowGrid.DataSource = rows;

            // The DataGrid control is docked in Form, so calculate the form size so everything fits
            // The last part isn't right (only works with the current gridWidth / gridHeight
            this.ClientSize = new Size(gridSize * gridWidth, gridSize * gridHeight - (gridSize * 2 - 1));

            // Register a global hotkey, the 8 is a bitmask, with the value of WIN_KEY
            if (!RegisterHotKey(this.Handle, 1, 8, (int)Keys.Oemtilde))
            {
                MessageBox.Show("Hotkey not registered, GridHack running already?");
                Application.Exit();
            }
        }

        private void GridHack_FormClosing(object sender, FormClosingEventArgs e)
        {
            // When form is being closed, unregister the hotkey
            // Not sure if this is still called with the current setup
            UnregisterHotKey(this.Handle, 1);
        }

        protected override void WndProc(ref Message m)
        {
            // We override WndProc to handle extra messages outside of the usual WinForms reach
            // This will catch the HotKey messages
            if (m.Msg == 0x0312 && m.WParam.ToInt32() == 1)
            {
                if (this.Visible)
                {
                    // Hide the form if it's already visible
                    this.Hide();
                }
                else
                {
                    // Pretty self-explanatory, get the current cursor position as a POINT (see below)
                    POINT p;
                    GetCursorPos(out p);

                    // Get the window handle for the window at point
                    hwnd = WindowFromPoint(p);
                    // Make sure to get the root window
                    // i.e. calling GridHack on an alert window will grab the parent instead
                    hwnd = GetAncestor(hwnd, 2);

                    // Get the window dimensions using the handle above
                    RECT r;
                    GetWindowRect(hwnd, out r);

                    // Calculate center position of the above window
                    int x = r.Left + (r.Right - r.Left) / 2;
                    int y = r.Top + (r.Bottom - r.Top) / 2;

                    // Clear the selection of the DataGrid
                    this.windowGrid.ClearSelection();

                    // Move our form to the center of the above window
                    this.SetBounds(x - this.Bounds.Width / 2, y - this.Bounds.Height / 2, this.Bounds.Width, this.Bounds.Height);

                    this.Show();
                }
            }

            base.WndProc(ref m);
        }

        private void windowGrid_Click(object sender, EventArgs e)
        {
            MouseEventArgs m = e as MouseEventArgs;

            // If the left button is released on the grid
            if (m.Button == MouseButtons.Left)
            {
                int x = 99, y = 99, x2 = -99, y2 = -99;
                int width = 0, height = 0;

                // Find the min/max row and column
                foreach (DataGridViewCell c in windowGrid.SelectedCells)
                {
                    if (c.RowIndex < y) y = c.RowIndex;
                    if (c.ColumnIndex < x) x = c.ColumnIndex;
                    if (c.RowIndex > y2) y2 = c.RowIndex;
                    if (c.ColumnIndex > x2) x2 = c.ColumnIndex;
                }

                // Find the grid width / height (cells)
                width = x2 - x + 1;
                height = y2 - y + 1;

                // Get the area of the primary screen
                int sWidth = Screen.FromHandle(hwnd).WorkingArea.Width;
                int sHeight = Screen.FromHandle(hwnd).WorkingArea.Height;

                // Calculate grid width in screen terms
                int cWidth = sWidth / gridSize;
                int cHeight = sHeight / gridSize;

                // Resize the window to fit in this grid space
                // Resize the window to fit in this grid space
                SetWindowPos(hwnd, (IntPtr)0, 
                    x * cWidth + Screen.FromHandle(hwnd).Bounds.X,
                    y * cHeight + Screen.FromHandle(hwnd).Bounds.Y,
                    width * cWidth,
                    height * cHeight, 
                    0);

                this.Hide();
            }
        }

        // Win32 API methods below, .NET/C# makes this too easy

        [DllImport("user32.dll")]
        public static extern IntPtr GetCursorPos(out POINT point);

        [DllImport("user32.dll")]
        public static extern IntPtr WindowFromPoint(POINT point);

        [DllImport("user32.dll")]
        public static extern IntPtr GetAncestor(IntPtr hwnd, uint gaFlags);

        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public long x;
            public long y;
        }

        [DllImport("user32.dll")]
        public static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        [DllImport("user32.dll")]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vlc);

        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);
    }
}
