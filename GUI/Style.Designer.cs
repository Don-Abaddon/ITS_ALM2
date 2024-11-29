namespace GUI
{
    partial class Style
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
            panel1 = new Panel();
            lblMessageTitle = new Label();
            title = new Label();
            btnmin = new Button();
            btnclose = new Button();
            lblTitle = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(lblMessageTitle);
            panel1.Controls.Add(title);
            panel1.Controls.Add(btnmin);
            panel1.Controls.Add(btnclose);
            panel1.Dock = DockStyle.Top;
            panel1.Font = new Font("Segoe UI", 16F);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(725, 40);
            panel1.TabIndex = 0;
            panel1.MouseDown += panel1_MouseDown;
            // 
            // lblMessageTitle
            // 
            lblMessageTitle.Anchor = AnchorStyles.Left;
            lblMessageTitle.AutoSize = true;
            lblMessageTitle.ForeColor = SystemColors.ControlDark;
            lblMessageTitle.Location = new Point(23, 4);
            lblMessageTitle.Name = "lblMessageTitle";
            lblMessageTitle.Size = new Size(0, 30);
            lblMessageTitle.TabIndex = 102;
            lblMessageTitle.MouseDown += label1_MouseDown;
            // 
            // title
            // 
            title.Anchor = AnchorStyles.None;
            title.AutoSize = true;
            title.ForeColor = Color.DarkGray;
            title.Location = new Point(297, 4);
            title.Name = "title";
            title.Size = new Size(0, 30);
            title.TabIndex = 101;
            title.MouseDown += label1_MouseDown;
            // 
            // btnmin
            // 
            btnmin.Anchor = AnchorStyles.Right;
            btnmin.FlatAppearance.BorderColor = Color.FromArgb(36, 33, 36);
            btnmin.FlatStyle = FlatStyle.Flat;
            btnmin.Font = new Font("Segoe UI", 14F);
            btnmin.ForeColor = Color.LightGray;
            btnmin.Location = new Point(646, 0);
            btnmin.Name = "btnmin";
            btnmin.Size = new Size(35, 36);
            btnmin.TabIndex = 100;
            btnmin.TabStop = false;
            btnmin.Text = "_";
            btnmin.UseVisualStyleBackColor = true;
            btnmin.Click += btnmin_Click;
            // 
            // btnclose
            // 
            btnclose.Anchor = AnchorStyles.Right;
            btnclose.FlatAppearance.BorderColor = Color.FromArgb(36, 33, 36);
            btnclose.FlatStyle = FlatStyle.Flat;
            btnclose.Font = new Font("Segoe UI", 14F);
            btnclose.ForeColor = Color.Red;
            btnclose.Location = new Point(685, 1);
            btnclose.Name = "btnclose";
            btnclose.Size = new Size(35, 36);
            btnclose.TabIndex = 99;
            btnclose.TabStop = false;
            btnclose.Text = "X";
            btnclose.UseVisualStyleBackColor = true;
            btnclose.Click += btnclose_Click;
            // 
            // lblTitle
            // 
            lblTitle.Anchor = AnchorStyles.Top;
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F);
            lblTitle.ForeColor = Color.DarkGray;
            lblTitle.Location = new Point(301, 12);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(0, 30);
            lblTitle.TabIndex = 0;
            lblTitle.MouseDown += panel1_MouseDown;
            // 
            // Style
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(36, 33, 36);
            ClientSize = new Size(725, 450);
            Controls.Add(lblTitle);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Style";
            Text = "Style";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label lblTitle;
        private Button btnclose;
        private Button btnmin;
        private Label title;
        private Label lblMessageTitle;
    }
}