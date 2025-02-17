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
            txtmarca = new TextBox();
            label2 = new Label();
            txtmodelo = new TextBox();
            label3 = new Label();
            txtbar = new TextBox();
            label4 = new Label();
            txtdescription = new TextBox();
            label5 = new Label();
            txtcategory = new TextBox();
            label6 = new Label();
            txtqty = new TextBox();
            label7 = new Label();
            btnsust = new Button();
            btnadd = new Button();
            pnlnav.SuspendLayout();
            SuspendLayout();
            // 
            // pnlnav
            // 
            pnlnav.BorderStyle = BorderStyle.FixedSingle;
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
            // txtmarca
            // 
            txtmarca.Location = new Point(383, 74);
            txtmarca.Name = "txtmarca";
            txtmarca.Size = new Size(100, 23);
            txtmarca.TabIndex = 11;
            txtmarca.TabStop = false;
            txtmarca.Text = "Marca";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = SystemColors.ControlDark;
            label2.Location = new Point(380, 84);
            label2.Name = "label2";
            label2.Size = new Size(107, 15);
            label2.TabIndex = 5;
            label2.Text = "____________________";
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
            txtbar.Location = new Point(189, 155);
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
            label4.Location = new Point(186, 165);
            label4.Name = "label4";
            label4.Size = new Size(147, 15);
            label4.TabIndex = 9;
            label4.Text = "____________________________";
            // 
            // txtdescription
            // 
            txtdescription.Location = new Point(383, 155);
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
            label5.Location = new Point(380, 209);
            label5.Name = "label5";
            label5.Size = new Size(152, 15);
            label5.TabIndex = 11;
            label5.Text = "_____________________________";
            // 
            // txtcategory
            // 
            txtcategory.Location = new Point(572, 155);
            txtcategory.Name = "txtcategory";
            txtcategory.Size = new Size(100, 23);
            txtcategory.TabIndex = 14;
            txtcategory.TabStop = false;
            txtcategory.Text = "Categoria";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.ForeColor = SystemColors.ControlDark;
            label6.Location = new Point(569, 165);
            label6.Name = "label6";
            label6.Size = new Size(107, 15);
            label6.TabIndex = 13;
            label6.Text = "____________________";
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
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(735, 266);
            Controls.Add(btnadd);
            Controls.Add(btnsust);
            Controls.Add(txtqty);
            Controls.Add(label7);
            Controls.Add(txtcategory);
            Controls.Add(label6);
            Controls.Add(txtdescription);
            Controls.Add(label5);
            Controls.Add(txtbar);
            Controls.Add(label4);
            Controls.Add(txtmodelo);
            Controls.Add(label3);
            Controls.Add(txtmarca);
            Controls.Add(label2);
            Controls.Add(txtpiezaID);
            Controls.Add(label1);
            Controls.Add(pnlnav);
            Name = "MainForm";
            Text = "Form1";
            Controls.SetChildIndex(pnlnav, 0);
            Controls.SetChildIndex(label1, 0);
            Controls.SetChildIndex(txtpiezaID, 0);
            Controls.SetChildIndex(label2, 0);
            Controls.SetChildIndex(txtmarca, 0);
            Controls.SetChildIndex(label3, 0);
            Controls.SetChildIndex(txtmodelo, 0);
            Controls.SetChildIndex(label4, 0);
            Controls.SetChildIndex(txtbar, 0);
            Controls.SetChildIndex(label5, 0);
            Controls.SetChildIndex(txtdescription, 0);
            Controls.SetChildIndex(label6, 0);
            Controls.SetChildIndex(txtcategory, 0);
            Controls.SetChildIndex(label7, 0);
            Controls.SetChildIndex(txtqty, 0);
            Controls.SetChildIndex(btnsust, 0);
            Controls.SetChildIndex(btnadd, 0);
            pnlnav.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnlnav;
        private Button btnInventory;
        private TextBox txtpiezaID;
        private Label label1;
        private TextBox txtmarca;
        private Label label2;
        private TextBox txtmodelo;
        private Label label3;
        private TextBox txtbar;
        private Label label4;
        private TextBox txtdescription;
        private Label label5;
        private TextBox txtcategory;
        private Label label6;
        private TextBox txtqty;
        private Label label7;
        private Button btnsust;
        private Button btnadd;
        private Button btnnew;
    }
}
