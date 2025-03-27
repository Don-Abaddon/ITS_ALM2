
using System.Runtime.InteropServices;

namespace GUI
{
    /// <summary>
    /// Clase que contiene los estilos de los formularios
    /// </summary>
    public partial class Style : Form
    {
        /// <summary>
        /// Permite mover el formulario sin bordes
        /// </summary>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool ReleaseCapture();
        /// <summary>
        /// Permite mover el formulario sin bordes
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="Msg"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;
        public Style()
        {
            InitializeComponent();
            //Win_Title("Almacen ITS");
        }
        /// <summary>
        /// Cambia el titulo del formulario
        /// </summary>
        /// <param name="Title"></param>
        public void Win_Title(string Title)
        {
            title.Text = Title;
        }
        /// <summary>
        /// Cierra el formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Minimiza el formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnmin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        /// <summary>
        /// Mueve el formulario sin bordes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        /// <summary>
        /// Mueve el formulario sin bordes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        /// <summary>
        /// Estilo de los TextBox
        /// </summary>
        /// <param name="textBox"></param>
        public static void TextBoxStyle(TextBox textBox)
        {
            textBox.BorderStyle = BorderStyle.None;
            textBox.Font = new Font("Arial", 10, FontStyle.Regular);
            textBox.ForeColor = Color.Gray;
            textBox.BackColor = Color.FromArgb(36, 36, 36);
            textBox.Multiline = false;
        }
        /// <summary>
        /// Estilo de los botones
        /// </summary>
        /// <param name="button"></param>
        public static void ButtonStyle(Button button)
        {
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 2;
            button.FlatAppearance.BorderColor = Color.FromArgb(64, 64, 64);
            button.ForeColor = Color.White;
            button.BackColor = Color.FromArgb(36, 36, 36);
            button.Font = new Font("Arial", 10, FontStyle.Regular);
        }
        /// <summary>
        /// Estilo de los MessageBox
        /// </summary>
        /// <param name="MessageTitle"></param>
        public void Message_Title(string MessageTitle)
         {
            lblMessageTitle.Text = MessageTitle;
         }
        /// <summary>
        /// Estilo de los DataGridView
        /// </summary>
        /// <param name="DataGrid"></param>
        public void CustomizeDataGridView(DataGridView DataGrid)
        {
            DataGrid.BackgroundColor = Color.FromArgb(30, 30, 30);

            DataGrid.DefaultCellStyle.BackColor = Color.FromArgb(40, 40, 40);
            DataGrid.DefaultCellStyle.ForeColor = Color.White;
            DataGrid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(70, 70, 70);
            DataGrid.DefaultCellStyle.SelectionForeColor = Color.White;

            DataGrid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(50, 50, 50);
            DataGrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            DataGrid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            DataGrid.GridColor = Color.FromArgb(70, 70, 70);
            DataGrid.BorderStyle = BorderStyle.None;

            DataGrid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            DataGrid.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            DataGrid.EnableHeadersVisualStyles = false;
        }
    }
}
