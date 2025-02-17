using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;

namespace GUI.CustomControl
{
    [DefaultEvent("OnSelectedIndexChanged")]
    class CustomCombobox :UserControl
    {
        //Field
        private Color backColor = Color.FromArgb(36, 36, 36);
        private Color iconColor = Color.MediumSlateBlue;
        private Color listBackColor = Color.FromArgb(36, 36, 36);
        private Color listTextColor = Color.Gray;
        private Color borderColor = Color.DarkGray;
        private int borderSize = 0;

        //Items
        private ComboBox cmbList;
        private Label lblText;
        private Button btnIcon;

        //Events
        public event EventHandler? OnSelectedIndexChanged;

        //Constructor
        public CustomCombobox()
        {
            cmbList = new ComboBox();
            lblText = new Label();
            btnIcon = new Button();
            this.SuspendLayout();

            //ComboBox: Dropdown List
            cmbList.Dock = DockStyle.Fill ;
            cmbList.BackColor = backColor;
            cmbList.Font = new Font(this.Font.Name, 10F);
            cmbList.ForeColor = listTextColor;
            cmbList.SelectedIndexChanged += new EventHandler(ComboBox_SelectedIndexChanged);
            cmbList.TextChanged += new EventHandler(ComboBox_TextChanged);

            //Button: Icon
            btnIcon.Dock = DockStyle.Right;
            btnIcon.FlatStyle = FlatStyle.Flat;
            btnIcon.FlatAppearance.BorderSize = 0;
            btnIcon.BackColor = backColor;
            btnIcon.Size = new Size(30, 30);
            btnIcon.Cursor = Cursors.Hand;
            btnIcon.Click += new EventHandler(Icon_Click);
            btnIcon.Paint += new PaintEventHandler(Icon_Paint);

            //Label: Text
            lblText.Dock = DockStyle.Fill;
            lblText.AutoSize = false;
            lblText.BackColor = backColor;
            lblText.TextAlign =ContentAlignment.MiddleLeft;
            lblText.Padding = new Padding(8,0, 0, 0);
            lblText.Font = new Font(this.Font.Name, 10F);
            lblText.Click += new EventHandler(Surface_Click);

            //User Control
            this.Controls.Add(lblText);
            this.Controls.Add(btnIcon);
            this.Controls.Add(cmbList);
            this.MinimumSize = new Size(50, 25);
            this.MaximumSize = new Size(150, 25);
            this.ForeColor = Color.DimGray;
            this.Padding = new Padding(borderSize);
            base.BackColor = backColor;
            this.ResumeLayout();
            AdjustComboBoxDimension();

        }

        private void AdjustComboBoxDimension()
        {           
            cmbList.Width = lblText.Width;
            cmbList.Location = new Point()
            {
                X = this.Width - this.Padding.Right - cmbList.Width,
                Y = lblText.Bottom - cmbList.Height
            };
        }

        private void Surface_Click(object? sender, EventArgs e)
        {
            //Select combobox
            cmbList.Select();
            if(cmbList.DropDownStyle == ComboBoxStyle.DropDownList)
                cmbList.DroppedDown = true; //Open dropdown List
        }

        private void Icon_Paint(object? sender, PaintEventArgs e)
        {
            //Field
            int iconWidht = 10;
            int iconHeigth = 6;
            var rectIcon = new Rectangle((btnIcon.Width - iconWidht)/2,(btnIcon.Height - iconHeigth) / 2, iconWidht, iconHeigth);
            Graphics graph = e.Graphics;

            //Draw arrow down icon
            using (GraphicsPath path = new GraphicsPath())
            using (Pen pen = new Pen(iconColor, 2))
            {
                graph.SmoothingMode = SmoothingMode.AntiAlias;
                path.AddLine(rectIcon.X, rectIcon.Y, rectIcon.X + (iconWidht / 2), rectIcon.Bottom);
                path.AddLine(rectIcon.X + (iconWidht / 2), rectIcon.Bottom, rectIcon.Right, rectIcon.Y);
                graph.DrawPath(pen, path);
            }
        }

        private void Icon_Click(object? sender, EventArgs e)
        {
            //Open dropdown List
            cmbList.Select();
            cmbList.DroppedDown = true;
        }

        private void ComboBox_TextChanged(object? sender, EventArgs e)
        {
            //Refresh Text
            lblText.Text = cmbList.Text;

        }

        //Default Event
        private void ComboBox_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cmbList.SelectedIndex >= 0)
                lblText.Text = cmbList.Text;
            else
                lblText.Text = placeholderText;
        }

        public object? DataSource
        {
            get { return cmbList.DataSource; }
            set { cmbList.DataSource = value; }
        }

        public string DisplayMember
        {
            get { return cmbList.DisplayMember; }
            set { cmbList.DisplayMember = value; }
        }

        public string ValueMember
        {
            get { return cmbList.ValueMember; }
            set { cmbList.ValueMember = value; }
        }

        private string placeholderText = "";
        public string PlaceholderText
        {
            get { return placeholderText; }
            set
            {
                placeholderText = value;
                lblText.Text = placeholderText;
            }
        }
        public int SelectedIndex
        {
            get { return cmbList.SelectedIndex; }
            set { cmbList.SelectedIndex = value; }
        }
        public object? SelectedValue
        {
            get { return cmbList.SelectedValue; }
            set { cmbList.SelectedValue = value; }
        }
        public object? SelectedItem
        {
            get { return cmbList.SelectedItem; }
            set { cmbList.SelectedItem = value; }
        }
    }
}
