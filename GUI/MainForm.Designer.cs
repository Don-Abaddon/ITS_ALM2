namespace GUI
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pnlnav = new Panel();
            btnnew = new Button();
            btnInventory = new Button();
            txtpiezaID = new TextBox();
            label1 = new Label();
            txtmodelo = new TextBox();
            label3 = new Label();
            txtbar = new TextBox();
            label4 = new Label();
            txtdescription = new TextBox();
            label5 = new Label();
            txtqty = new TextBox();
            label7 = new Label();
            btnsust = new Button();
            btnadd = new Button();
            cmbmarca = new CustomControl.CustomCombobox();
            label2 = new Label();
            cmbcategory = new CustomControl.CustomCombobox();
            label6 = new Label();
            dgvItems = new DataGridView();
            btnSearch = new Button();
            btnrefresh = new Button();
            label8 = new Label();
            btnreports = new Button();
            pnlnav.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvItems).BeginInit();
            SuspendLayout();
            // 
            // pnlnav
            // 
            pnlnav.BorderStyle = BorderStyle.FixedSingle;
            pnlnav.Controls.Add(btnreports);
            pnlnav.Controls.Add(btnnew);
            pnlnav.Controls.Add(btnInventory);
            pnlnav.Location = new Point(0, 40);
            pnlnav.Name = "pnlnav";
            pnlnav.Size = new Size(147, 225);
            pnlnav.TabIndex = 1;
            // 
            // btnnew
            // 
            btnnew.FlatStyle = FlatStyle.Flat;
            btnnew.Font = new Font("Segoe UI", 14F);
            btnnew.ForeColor = SystemColors.ControlDark;
            btnnew.Location = new Point(24, 87);
            btnnew.Name = "btnnew";
            btnnew.Size = new Size(103, 35);
            btnnew.TabIndex = 1;
            btnnew.Text = "New";
            btnnew.UseVisualStyleBackColor = true;
            btnnew.Click += btnnew_Click;
            // 
            // btnInventory
            // 
            btnInventory.FlatStyle = FlatStyle.Flat;
            btnInventory.Font = new Font("Segoe UI", 14F);
            btnInventory.ForeColor = SystemColors.ControlDark;
            btnInventory.Location = new Point(24, 37);
            btnInventory.Name = "btnInventory";
            btnInventory.Size = new Size(103, 36);
            btnInventory.TabIndex = 0;
            btnInventory.Text = "Inventory";
            btnInventory.UseVisualStyleBackColor = true;
            btnInventory.Click += btnInventory_Click;
            // 
            // txtpiezaID
            // 
            txtpiezaID.Location = new Point(192, 74);
            txtpiezaID.Name = "txtpiezaID";
            txtpiezaID.Size = new Size(100, 23);
            txtpiezaID.TabIndex = 10;
            txtpiezaID.TabStop = false;
            txtpiezaID.Text = "ID";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = SystemColors.ControlDark;
            label1.Location = new Point(189, 84);
            label1.Name = "label1";
            label1.Size = new Size(107, 15);
            label1.TabIndex = 3;
            label1.Text = "____________________";
            // 
            // txtmodelo
            // 
            txtmodelo.Location = new Point(572, 74);
            txtmodelo.Name = "txtmodelo";
            txtmodelo.Size = new Size(100, 23);
            txtmodelo.TabIndex = 12;
            txtmodelo.TabStop = false;
            txtmodelo.Text = "Modelo";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = SystemColors.ControlDark;
            label3.Location = new Point(569, 84);
            label3.Name = "label3";
            label3.Size = new Size(107, 15);
            label3.TabIndex = 7;
            label3.Text = "____________________";
            // 
            // txtbar
            // 
            txtbar.Location = new Point(189, 147);
            txtbar.Name = "txtbar";
            txtbar.Size = new Size(140, 23);
            txtbar.TabIndex = 2;
            txtbar.Text = "Barcode";
            txtbar.Enter += txtbar_Enter;
            txtbar.KeyDown += txtbar_KeyDown;
            txtbar.Leave += txtbar_Leave;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = SystemColors.ControlDark;
            label4.Location = new Point(186, 157);
            label4.Name = "label4";
            label4.Size = new Size(147, 15);
            label4.TabIndex = 9;
            label4.Text = "____________________________";
            // 
            // txtdescription
            // 
            txtdescription.Location = new Point(383, 147);
            txtdescription.Multiline = true;
            txtdescription.Name = "txtdescription";
            txtdescription.Size = new Size(149, 67);
            txtdescription.TabIndex = 13;
            txtdescription.TabStop = false;
            txtdescription.Text = "Descripcion";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = SystemColors.ControlDark;
            label5.Location = new Point(380, 201);
            label5.Name = "label5";
            label5.Size = new Size(152, 15);
            label5.TabIndex = 11;
            label5.Text = "_____________________________";
            // 
            // txtqty
            // 
            txtqty.Location = new Point(573, 219);
            txtqty.Name = "txtqty";
            txtqty.Size = new Size(58, 23);
            txtqty.TabIndex = 3;
            txtqty.Text = "Cantidad";
            txtqty.Enter += txtqty_Enter;
            txtqty.Leave += txtqty_Leave;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.ForeColor = SystemColors.ControlDark;
            label7.Location = new Point(569, 229);
            label7.Name = "label7";
            label7.Size = new Size(67, 15);
            label7.TabIndex = 15;
            label7.Text = "____________";
            // 
            // btnsust
            // 
            btnsust.Font = new Font("Segoe UI", 16F);
            btnsust.Location = new Point(649, 219);
            btnsust.Name = "btnsust";
            btnsust.Size = new Size(27, 25);
            btnsust.TabIndex = 4;
            btnsust.Text = "-";
            btnsust.TextAlign = ContentAlignment.TopCenter;
            btnsust.UseVisualStyleBackColor = true;
            btnsust.Click += btnsust_Click;
            // 
            // btnadd
            // 
            btnadd.Font = new Font("Segoe UI", 16F);
            btnadd.Location = new Point(694, 219);
            btnadd.Name = "btnadd";
            btnadd.Size = new Size(27, 25);
            btnadd.TabIndex = 5;
            btnadd.Text = "+";
            btnadd.TextAlign = ContentAlignment.TopCenter;
            btnadd.UseVisualStyleBackColor = true;
            btnadd.Click += btnadd_Click;
            // 
            // cmbmarca
            // 
            cmbmarca.BackColor = Color.FromArgb(36, 36, 36);
            cmbmarca.DataSource = null;
            cmbmarca.DisplayMember = "";
            cmbmarca.DropDownStyle = ComboBoxStyle.DropDown;
            cmbmarca.Font = new Font("Segoe UI", 10F);
            cmbmarca.ForeColor = Color.Gray;
            cmbmarca.Location = new Point(360, 74);
            cmbmarca.MaximumSize = new Size(150, 25);
            cmbmarca.MinimumSize = new Size(50, 25);
            cmbmarca.Name = "cmbmarca";
            cmbmarca.PlaceholderText = "";
            cmbmarca.SelectedIndex = -1;
            cmbmarca.SelectedItem = null;
            cmbmarca.SelectedValue = null;
            cmbmarca.Size = new Size(122, 25);
            cmbmarca.TabIndex = 33;
            cmbmarca.TextFont = new Font("Segoe UI", 10F);
            cmbmarca.TextForeColor = Color.DimGray;
            cmbmarca.ValueMember = "";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F);
            label2.ForeColor = Color.DimGray;
            label2.Location = new Point(360, 86);
            label2.Name = "label2";
            label2.Size = new Size(111, 19);
            label2.TabIndex = 32;
            label2.Text = "_________________";
            // 
            // cmbcategory
            // 
            cmbcategory.BackColor = Color.FromArgb(36, 36, 36);
            cmbcategory.DataSource = null;
            cmbcategory.DisplayMember = "";
            cmbcategory.DropDownStyle = ComboBoxStyle.DropDown;
            cmbcategory.ForeColor = Color.Gray;
            cmbcategory.Location = new Point(569, 147);
            cmbcategory.MaximumSize = new Size(150, 25);
            cmbcategory.MinimumSize = new Size(50, 25);
            cmbcategory.Name = "cmbcategory";
            cmbcategory.PlaceholderText = "";
            cmbcategory.SelectedIndex = -1;
            cmbcategory.SelectedItem = null;
            cmbcategory.SelectedValue = null;
            cmbcategory.Size = new Size(122, 25);
            cmbcategory.TabIndex = 36;
            cmbcategory.TextFont = new Font("Segoe UI", 9F);
            cmbcategory.TextForeColor = Color.DimGray;
            cmbcategory.ValueMember = "";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10F);
            label6.ForeColor = Color.DimGray;
            label6.Location = new Point(569, 159);
            label6.Name = "label6";
            label6.Size = new Size(111, 19);
            label6.TabIndex = 35;
            label6.Text = "_________________";
            // 
            // dgvItems
            // 
            dgvItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvItems.Location = new Point(12, 271);
            dgvItems.Name = "dgvItems";
            dgvItems.Size = new Size(711, 243);
            dgvItems.TabIndex = 37;
            dgvItems.CellClick += SelectItem;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(183, 225);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(94, 34);
            btnSearch.TabIndex = 38;
            btnSearch.Text = "Busqueda";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += SearchItems;
            // 
            // btnrefresh
            // 
            btnrefresh.Location = new Point(283, 225);
            btnrefresh.Name = "btnrefresh";
            btnrefresh.Size = new Size(93, 34);
            btnrefresh.TabIndex = 39;
            btnrefresh.Text = "Refrescar";
            btnrefresh.UseVisualStyleBackColor = true;
            btnrefresh.Click += RefreshMainForm;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.ForeColor = Color.Silver;
            label8.Location = new Point(696, 43);
            label8.Name = "label8";
            label8.Size = new Size(31, 15);
            label8.TabIndex = 40;
            label8.Text = "1.0.4";
            // 
            // btnreports
            // 
            btnreports.FlatStyle = FlatStyle.Flat;
            btnreports.Font = new Font("Segoe UI", 14F);
            btnreports.ForeColor = SystemColors.ControlDark;
            btnreports.Location = new Point(23, 140);
            btnreports.Name = "btnreports";
            btnreports.Size = new Size(103, 35);
            btnreports.TabIndex = 2;
            btnreports.Text = "Reports";
            btnreports.UseVisualStyleBackColor = true;
            btnreports.Click += btnreports_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(735, 265);
            Controls.Add(label8);
            Controls.Add(btnrefresh);
            Controls.Add(btnSearch);
            Controls.Add(dgvItems);
            Controls.Add(cmbcategory);
            Controls.Add(label6);
            Controls.Add(cmbmarca);
            Controls.Add(label2);
            Controls.Add(btnadd);
            Controls.Add(btnsust);
            Controls.Add(txtqty);
            Controls.Add(label7);
            Controls.Add(txtdescription);
            Controls.Add(label5);
            Controls.Add(txtbar);
            Controls.Add(label4);
            Controls.Add(txtmodelo);
            Controls.Add(label3);
            Controls.Add(txtpiezaID);
            Controls.Add(label1);
            Controls.Add(pnlnav);
            Name = "MainForm";
            Text = "";
            Controls.SetChildIndex(pnlnav, 0);
            Controls.SetChildIndex(label1, 0);
            Controls.SetChildIndex(txtpiezaID, 0);
            Controls.SetChildIndex(label3, 0);
            Controls.SetChildIndex(txtmodelo, 0);
            Controls.SetChildIndex(label4, 0);
            Controls.SetChildIndex(txtbar, 0);
            Controls.SetChildIndex(label5, 0);
            Controls.SetChildIndex(txtdescription, 0);
            Controls.SetChildIndex(label7, 0);
            Controls.SetChildIndex(txtqty, 0);
            Controls.SetChildIndex(btnsust, 0);
            Controls.SetChildIndex(btnadd, 0);
            Controls.SetChildIndex(label2, 0);
            Controls.SetChildIndex(cmbmarca, 0);
            Controls.SetChildIndex(label6, 0);
            Controls.SetChildIndex(cmbcategory, 0);
            Controls.SetChildIndex(dgvItems, 0);
            Controls.SetChildIndex(btnSearch, 0);
            Controls.SetChildIndex(btnrefresh, 0);
            Controls.SetChildIndex(label8, 0);
            pnlnav.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvItems).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnlnav;
        private Button btnInventory;
        private TextBox txtpiezaID;
        private Label label1;
        private TextBox txtmodelo;
        private Label label3;
        private TextBox txtbar;
        private Label label4;
        private TextBox txtdescription;
        private Label label5;
        private TextBox txtqty;
        private Label label7;
        private Button btnsust;
        private Button btnadd;
        private Button btnnew;
        private CustomControl.CustomCombobox cmbmarca;
        private Label label2;
        private CustomControl.CustomCombobox cmbcategory;
        private Label label6;
        private DataGridView dgvItems;
        private Button btnSearch;
        private Button btnrefresh;
        private Label label8;
        private Button btnreports;
    }
}
