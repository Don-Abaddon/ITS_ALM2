
using System.Runtime.InteropServices;

namespace GUI
{
    public partial class Style : Form
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;
        public Style()
        {
            InitializeComponent();
            //Win_Title("Almacen ITS");
        }

        public void Win_Title(string Title)
        {
            title.Text = Title;
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            if (this is MainForm)
            {
                Application.Exit();
            }
            else
            {
                this.Close();
            }
        }

        private void btnmin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        public static void TextBoxStyle(TextBox textBox)
        {
            textBox.BorderStyle = BorderStyle.None;
            textBox.Font = new Font("Arial", 10, FontStyle.Regular);
            textBox.ForeColor = Color.Gray;
            textBox.BackColor = Color.FromArgb(36, 36, 36);
            textBox.Multiline = false;
        }

        public static void ButtonStyle(Button button)
        {
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 2;
            button.FlatAppearance.BorderColor = Color.FromArgb(64, 64, 64);
            button.ForeColor = Color.White;
            button.BackColor = Color.FromArgb(36, 36, 36);
            button.Font = new Font("Arial", 10, FontStyle.Regular);
        }
     public void Message_Title(string MessageTitle)
        {
            lblMessageTitle.Text = MessageTitle;
        }
    }
}
