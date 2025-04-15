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
            btnResumen = new Button();
            dataGridView1 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // btngetall
            // 
            btngetall.Location = new Point(12, 75);
            btngetall.Name = "btngetall";
            btngetall.Size = new Size(139, 43);
            btngetall.TabIndex = 1;
            btngetall.Text = "Todas las piezas";
            btngetall.UseVisualStyleBackColor = true;
            btngetall.Click += btngetall_Click;
            // 
            // btnResumen
            // 
            btnResumen.Location = new Point(157, 75);
            btnResumen.Name = "btnResumen";
            btnResumen.Size = new Size(139, 43);
            btnResumen.TabIndex = 2;
            btnResumen.Text = "resumen";
            btnResumen.UseVisualStyleBackColor = true;
            btnResumen.Click += btnResumen_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(7, 193);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(781, 245);
            dataGridView1.TabIndex = 3;
            // 
            // ReportsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridView1);
            Controls.Add(btnResumen);
            Controls.Add(btngetall);
            Name = "ReportsForm";
            Text = "Form1";
            Controls.SetChildIndex(btngetall, 0);
            Controls.SetChildIndex(btnResumen, 0);
            Controls.SetChildIndex(dataGridView1, 0);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btngetall;
        private Button btnResumen;
        private DataGridView dataGridView1;
    }
}