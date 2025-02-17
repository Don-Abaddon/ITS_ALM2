namespace GUI
{
    partial class Add_UpdateForm
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
            txtqty = new TextBox();
            label7 = new Label();
            txtdescription = new TextBox();
            label5 = new Label();
            txtbar = new TextBox();
            label4 = new Label();
            txtmodelo = new TextBox();
            label3 = new Label();
            label2 = new Label();
            txtpiezaID = new TextBox();
            label1 = new Label();
            btnsave = new Button();
            cmbmarca = new CustomControl.CustomCombobox();
            cmbcategory = new CustomControl.CustomCombobox();
            label6 = new Label();
            SuspendLayout();
            // 
            // txtqty
            // 
            txtqty.Location = new Point(385, 161);
            txtqty.Name = "txtqty";
            txtqty.Size = new Size(61, 23);
            txtqty.TabIndex = 6;
            txtqty.Text = "Cantidad";
            txtqty.Enter += TextBox_Enter;
            txtqty.Leave += TextBox_Leave;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.ForeColor = SystemColors.ControlDark;
            label7.Location = new Point(382, 171);
            label7.Name = "label7";
            label7.Size = new Size(67, 15);
            label7.TabIndex = 29;
            label7.Text = "____________";
            // 
            // txtdescription
            // 
            txtdescription.Location = new Point(206, 161);
            txtdescription.Multiline = true;
            txtdescription.Name = "txtdescription";
            txtdescription.Size = new Size(149, 67);
            txtdescription.TabIndex = 5;
            txtdescription.TabStop = false;
            txtdescription.Text = "Descripcion";
            txtdescription.Enter += TextBox_Enter;
            txtdescription.Leave += TextBox_Leave;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = SystemColors.ControlDark;
            label5.Location = new Point(203, 215);
            label5.Name = "label5";
            label5.Size = new Size(152, 15);
            label5.TabIndex = 26;
            label5.Text = "_____________________________";
            // 
            // txtbar
            // 
            txtbar.BackColor = SystemColors.ControlLightLight;
            txtbar.ForeColor = SystemColors.ControlDark;
            txtbar.Location = new Point(12, 161);
            txtbar.Name = "txtbar";
            txtbar.Size = new Size(140, 23);
            txtbar.TabIndex = 4;
            txtbar.Text = "Barcode";
            txtbar.Enter += TextBox_Enter;
            txtbar.Leave += TextBox_Leave;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = SystemColors.ControlDark;
            label4.Location = new Point(9, 171);
            label4.Name = "label4";
            label4.Size = new Size(147, 15);
            label4.TabIndex = 25;
            label4.Text = "____________________________";
            // 
            // txtmodelo
            // 
            txtmodelo.Location = new Point(206, 80);
            txtmodelo.Name = "txtmodelo";
            txtmodelo.Size = new Size(100, 23);
            txtmodelo.TabIndex = 2;
            txtmodelo.TabStop = false;
            txtmodelo.Text = "Modelo";
            txtmodelo.Enter += TextBox_Enter;
            txtmodelo.Leave += TextBox_Leave;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = SystemColors.ControlDark;
            label3.Location = new Point(203, 90);
            label3.Name = "label3";
            label3.Size = new Size(107, 15);
            label3.TabIndex = 23;
            label3.Text = "____________________";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = SystemColors.ControlDark;
            label2.Location = new Point(60, 90);
            label2.Name = "label2";
            label2.Size = new Size(92, 15);
            label2.TabIndex = 21;
            label2.Text = "_________________";
            // 
            // txtpiezaID
            // 
            txtpiezaID.Location = new Point(14, 80);
            txtpiezaID.Name = "txtpiezaID";
            txtpiezaID.ReadOnly = true;
            txtpiezaID.Size = new Size(22, 23);
            txtpiezaID.TabIndex = 18;
            txtpiezaID.TabStop = false;
            txtpiezaID.Text = "ID";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = SystemColors.ControlDark;
            label1.Location = new Point(12, 90);
            label1.Name = "label1";
            label1.Size = new Size(27, 15);
            label1.TabIndex = 19;
            label1.Text = "____";
            // 
            // btnsave
            // 
            btnsave.FlatStyle = FlatStyle.Flat;
            btnsave.Font = new Font("Segoe UI", 14F);
            btnsave.ForeColor = SystemColors.ControlDark;
            btnsave.Location = new Point(181, 262);
            btnsave.Name = "btnsave";
            btnsave.Size = new Size(103, 35);
            btnsave.TabIndex = 0;
            btnsave.Text = "Save";
            btnsave.UseVisualStyleBackColor = true;
            btnsave.Click += btnsave_Click;
            // 
            // cmbmarca
            // 
            cmbmarca.BackColor = Color.FromArgb(36, 36, 36);
            cmbmarca.DataSource = null;
            cmbmarca.DisplayMember = "";
            cmbmarca.ForeColor = Color.DimGray;
            cmbmarca.Location = new Point(60, 78);
            cmbmarca.MaximumSize = new Size(150, 25);
            cmbmarca.MinimumSize = new Size(50, 25);
            cmbmarca.Name = "cmbmarca";
            cmbmarca.PlaceholderText = "";
            cmbmarca.SelectedIndex = -1;
            cmbmarca.SelectedItem = null;
            cmbmarca.SelectedValue = null;
            cmbmarca.Size = new Size(122, 25);
            cmbmarca.TabIndex = 31;
            cmbmarca.ValueMember = "";
            // 
            // cmbcategory
            // 
            cmbcategory.BackColor = Color.FromArgb(36, 36, 36);
            cmbcategory.DataSource = null;
            cmbcategory.DisplayMember = "";
            cmbcategory.ForeColor = Color.DimGray;
            cmbcategory.Location = new Point(382, 80);
            cmbcategory.MaximumSize = new Size(150, 25);
            cmbcategory.MinimumSize = new Size(50, 25);
            cmbcategory.Name = "cmbcategory";
            cmbcategory.PlaceholderText = "";
            cmbcategory.SelectedIndex = -1;
            cmbcategory.SelectedItem = null;
            cmbcategory.SelectedValue = null;
            cmbcategory.Size = new Size(122, 25);
            cmbcategory.TabIndex = 34;
            cmbcategory.ValueMember = "";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.ForeColor = SystemColors.ControlDark;
            label6.Location = new Point(382, 92);
            label6.Name = "label6";
            label6.Size = new Size(92, 15);
            label6.TabIndex = 33;
            label6.Text = "_________________";
            // 
            // Add_UpdateForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(514, 309);
            Controls.Add(label6);
            Controls.Add(label2);
            Controls.Add(btnsave);
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
            Controls.Add(cmbmarca);
            Controls.Add(cmbcategory);
            Name = "Add_UpdateForm";
            Text = "NewPart";
            Controls.SetChildIndex(cmbcategory, 0);
            Controls.SetChildIndex(cmbmarca, 0);
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
            Controls.SetChildIndex(btnsave, 0);
            Controls.SetChildIndex(label2, 0);
            Controls.SetChildIndex(label6, 0);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtqty;
        private Label label7;
        private TextBox txtdescription;
        private Label label5;
        private TextBox txtbar;
        private Label label4;
        private TextBox txtmodelo;
        private Label label3;
        private Label label2;
        private TextBox txtpiezaID;
        private Label label1;
        private Button btnsave;
        private CustomControl.CustomCombobox cmbmarca;
        private CustomControl.CustomCombobox cmbcategory;
        private Label label6;
    }
}