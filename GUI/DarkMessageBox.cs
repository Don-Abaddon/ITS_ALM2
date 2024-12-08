
namespace GUI
{
    public partial class DarkMessageBox : Style
    {
        public DarkMessageBox(string message, string title, MessageBoxButtons buttons)
        {
            InitializeComponent();
            Message_Title(title);
            lblmessage.Text = message;
            ConfigureButtons(buttons);

        }
        private void ConfigureButtons(MessageBoxButtons buttons)
        {
            btnyes.Visible = buttons == MessageBoxButtons.YesNo;
            btnno.Visible = buttons == MessageBoxButtons.YesNo;
            btnOk.Visible = buttons == MessageBoxButtons.OK;
         
            ButtonStyle(btnyes);
            ButtonStyle(btnno);
            ButtonStyle(btnOk);
        }
        public static DialogResult Show(string message, string title, MessageBoxButtons buttons)
        {
            using (var dialog = new DarkMessageBox(message, title, buttons))
            {
                return dialog.ShowDialog();
            } 
              
            
        }
        private void btnYes_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
