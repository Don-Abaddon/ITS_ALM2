using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class NewPartForm : Style
    {
        public NewPartForm()
        {
            InitializeComponent();
            this.FormClosed += NewPartForm_FormClosed;
        }
        private void NewPartForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Muestra el formulario principal al cerrar el formulario de inventario
            MainForm mainForm = Application.OpenForms["MainForm"] as MainForm;
            if (mainForm != null)
            {
                mainForm.Show();
            }
        }
    }
}
