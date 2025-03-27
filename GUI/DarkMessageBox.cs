
namespace GUI
{
    /// <summary>
    /// Clase que representa un MessageBox personalizado
    /// </summary>
    public partial class DarkMessageBox : Style
    {
        public DarkMessageBox(string message, string title, MessageBoxButtons buttons)
        {
            InitializeComponent();
            Message_Title(title);
            lblmessage.Text = message;
            ConfigureButtons(buttons);

        }
        /// <summary>
        /// Configura los botones del MessageBox
        /// </summary>
        /// <param name="buttons"></param>
        private void ConfigureButtons(MessageBoxButtons buttons)
        {
            btnyes.Visible = buttons == MessageBoxButtons.YesNo;
            btnno.Visible = buttons == MessageBoxButtons.YesNo;
            btnOk.Visible = buttons == MessageBoxButtons.OK;
         
            ButtonStyle(btnyes);
            ButtonStyle(btnno);
            ButtonStyle(btnOk);
        }
        /// <summary>
        /// Muestra el MessageBox
        /// </summary>
        /// <param name="message"></param>
        /// <param name="title"></param>
        /// <param name="buttons"></param>
        /// <returns></returns>
        public static DialogResult Show(string message, string title, MessageBoxButtons buttons)
        {
            using (var dialog = new DarkMessageBox(message, title, buttons))
            {
                return dialog.ShowDialog();
            } 
              
            
        }
        /// <summary>
        /// Evento del boton Yes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnYes_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }
        /// <summary>
        /// Evento del boton No
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNo_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }
        /// <summary>
        /// Evento del boton Ok
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
