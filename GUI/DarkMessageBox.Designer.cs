namespace GUI
{
    partial class DarkMessageBox
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
            btnyes = new Button();
            btnno = new Button();
            lblmessage = new Label();
            btnOk = new Button();
            SuspendLayout();
            // 
            // btnyes
            // 
            btnyes.Location = new Point(60, 119);
            btnyes.Name = "btnyes";
            btnyes.Size = new Size(75, 27);
            btnyes.TabIndex = 1;
            btnyes.Text = "Yes";
            btnyes.UseVisualStyleBackColor = true;
            btnyes.Click += btnYes_Click;
            // 
            // btnno
            // 
            btnno.Location = new Point(241, 119);
            btnno.Name = "btnno";
            btnno.Size = new Size(75, 27);
            btnno.TabIndex = 2;
            btnno.Text = "No";
            btnno.UseVisualStyleBackColor = true;
            btnno.Click += btnNo_Click;
            // 
            // lblmessage
            // 
            lblmessage.AutoSize = true;
            lblmessage.Font = new Font("Segoe UI", 12F);
            lblmessage.ForeColor = SystemColors.ControlDark;
            lblmessage.Location = new Point(26, 69);
            lblmessage.Name = "lblmessage";
            lblmessage.Size = new Size(52, 21);
            lblmessage.TabIndex = 3;
            lblmessage.Text = "label1";
            // 
            // btnOk
            // 
            btnOk.AutoSize = true;
            btnOk.Location = new Point(168, 119);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(42, 27);
            btnOk.TabIndex = 4;
            btnOk.Text = "Ok";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // DarkMessageBox
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(414, 173);
            Controls.Add(btnOk);
            Controls.Add(lblmessage);
            Controls.Add(btnno);
            Controls.Add(btnyes);
            Name = "DarkMessageBox";
            Text = "DarkMessageBox";
            Controls.SetChildIndex(btnyes, 0);
            Controls.SetChildIndex(btnno, 0);
            Controls.SetChildIndex(lblmessage, 0);
            Controls.SetChildIndex(btnOk, 0);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnyes;
        private Button btnno;
        private Label lblmessage;
        private Button btnOk;
    }
}