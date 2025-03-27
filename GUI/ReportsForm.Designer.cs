namespace GUI
{
    partial class ReportsForm
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
            btngetall = new Button();
            SuspendLayout();
            // 
            // btngetall
            // 
            btngetall.Location = new Point(100, 138);
            btngetall.Name = "btngetall";
            btngetall.Size = new Size(139, 43);
            btngetall.TabIndex = 1;
            btngetall.Text = "Todas las piezas";
            btngetall.UseVisualStyleBackColor = true;
            btngetall.Click += btngetall_Click;
            // 
            // ReportsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btngetall);
            Name = "ReportsForm";
            Text = "Form1";
            Controls.SetChildIndex(btngetall, 0);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btngetall;
    }
}