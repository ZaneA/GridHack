namespace GridHack
{
    partial class GridHackForm
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
            this.windowGrid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.windowGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // windowGrid
            // 
            this.windowGrid.AllowUserToAddRows = false;
            this.windowGrid.AllowUserToDeleteRows = false;
            this.windowGrid.AllowUserToResizeColumns = false;
            this.windowGrid.AllowUserToResizeRows = false;
            this.windowGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.windowGrid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.windowGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.windowGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.windowGrid.ColumnHeadersVisible = false;
            this.windowGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.windowGrid.EnableHeadersVisualStyles = false;
            this.windowGrid.Location = new System.Drawing.Point(0, 0);
            this.windowGrid.Margin = new System.Windows.Forms.Padding(0);
            this.windowGrid.Name = "windowGrid";
            this.windowGrid.ReadOnly = true;
            this.windowGrid.RowHeadersVisible = false;
            this.windowGrid.ShowCellErrors = false;
            this.windowGrid.ShowCellToolTips = false;
            this.windowGrid.ShowEditingIcon = false;
            this.windowGrid.ShowRowErrors = false;
            this.windowGrid.Size = new System.Drawing.Size(84, 51);
            this.windowGrid.TabIndex = 1;
            this.windowGrid.VirtualMode = true;
            this.windowGrid.Click += new System.EventHandler(this.windowGrid_Click);
            // 
            // GridHackForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(84, 51);
            this.ControlBox = false;
            this.Controls.Add(this.windowGrid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GridHackForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "GridHack";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GridHack_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.windowGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView windowGrid;
    }
}

