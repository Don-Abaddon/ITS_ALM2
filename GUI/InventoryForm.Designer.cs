namespace GUI
{
    partial class InventoryForm
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            txtbar = new TextBox();
            dgvItems = new DataGridView();
            label1 = new Label();
            btnrefresh = new Button();
            txtmodel = new TextBox();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvItems).BeginInit();
            SuspendLayout();
            // 
            // txtbar
            // 
            txtbar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtbar.BackColor = Color.FromArgb(36, 33, 36);
            txtbar.BorderStyle = BorderStyle.None;
            txtbar.Font = new Font("Segoe UI", 14F);
            txtbar.ForeColor = SystemColors.ScrollBar;
            txtbar.Location = new Point(442, 71);
            txtbar.Name = "txtbar";
            txtbar.Size = new Size(209, 25);
            txtbar.TabIndex = 1;
            txtbar.Text = "Barcode";
            txtbar.TextChanged += TextBox_TextChanged;
            txtbar.Enter += TextBox_Enter;
            txtbar.Leave += TextBox_Leave;
            // 
            // dgvItems
            // 
            dgvItems.BackgroundColor = Color.FromArgb(38, 38, 39);
            dgvItems.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvItems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvItems.Location = new Point(10, 132);
            dgvItems.Name = "dgvItems";
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.ActiveCaptionText;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.Info;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvItems.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvItems.RowHeadersVisible = false;
            dgvItems.Size = new Size(809, 298);
            dgvItems.TabIndex = 0;
            dgvItems.CellMouseDown += dgvItems_CellMouseDown;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = SystemColors.ControlDark;
            label1.Location = new Point(439, 84);
            label1.Name = "label1";
            label1.Size = new Size(212, 15);
            label1.TabIndex = 3;
            label1.Text = "_________________________________________";
            // 
            // btnrefresh
            // 
            btnrefresh.BackColor = Color.Gainsboro;
            btnrefresh.BackgroundImage = Properties.Resources.pngwing_com;
            btnrefresh.BackgroundImageLayout = ImageLayout.Zoom;
            btnrefresh.Cursor = Cursors.Hand;
            btnrefresh.FlatStyle = FlatStyle.Flat;
            btnrefresh.ImageAlign = ContentAlignment.TopCenter;
            btnrefresh.Location = new Point(794, 100);
            btnrefresh.Name = "btnrefresh";
            btnrefresh.Size = new Size(22, 26);
            btnrefresh.TabIndex = 4;
            btnrefresh.UseVisualStyleBackColor = false;
            btnrefresh.Click += btnrefresh_Click;
            // 
            // txtmodel
            // 
            txtmodel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtmodel.BackColor = Color.FromArgb(36, 33, 36);
            txtmodel.BorderStyle = BorderStyle.None;
            txtmodel.Font = new Font("Segoe UI", 14F);
            txtmodel.ForeColor = SystemColors.ScrollBar;
            txtmodel.Location = new Point(157, 71);
            txtmodel.Name = "txtmodel";
            txtmodel.Size = new Size(209, 25);
            txtmodel.TabIndex = 5;
            txtmodel.Text = "Modelo";
            txtmodel.TextChanged += TextBox_TextChanged;
            txtmodel.Enter += TextBox_Enter;
            txtmodel.Leave += TextBox_Leave;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = SystemColors.ControlDark;
            label2.Location = new Point(154, 84);
            label2.Name = "label2";
            label2.Size = new Size(212, 15);
            label2.TabIndex = 6;
            label2.Text = "_________________________________________";
            // 
            // InventoryForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(833, 458);
            Controls.Add(txtmodel);
            Controls.Add(label2);
            Controls.Add(btnrefresh);
            Controls.Add(dgvItems);
            Controls.Add(txtbar);
            Controls.Add(label1);
            Name = "InventoryForm";
            Text = "Inventory";
            Controls.SetChildIndex(label1, 0);
            Controls.SetChildIndex(txtbar, 0);
            Controls.SetChildIndex(dgvItems, 0);
            Controls.SetChildIndex(btnrefresh, 0);
            Controls.SetChildIndex(label2, 0);
            Controls.SetChildIndex(txtmodel, 0);
            ((System.ComponentModel.ISupportInitialize)dgvItems).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtbar;
        private DataGridView dgvItems;
        private Label label1;
        private Button btnrefresh;
        private TextBox txtmodel;
        private Label label2;
    }
}