using Domain;
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
    public partial class Add_UpdateForm : Style
    {
        private Inventory _inventory;
        public Add_UpdateForm()
        {
            InitializeComponent();
            this.FormClosed += NewPartForm_FormClosed;
            _inventory = new Inventory();
            TextBoxStyle(txtbar);
            TextBoxStyle(txtmarca);
            TextBoxStyle(txtmodelo);
            TextBoxStyle(txtcategory);
            TextBoxStyle(txtdescription);
            TextBoxStyle(txtqty);
            TextBoxStyle(txtpiezaID);
            ButtonStyle(btnsave);
            txtdescription.Multiline = true;
            txtpiezaID.Enabled = false;
            Win_Title("Nueva Pieza");
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
        private async void btnsave_Click(object sender, EventArgs e)
        {
            string marca = txtmarca.Text;
            string modelo = txtmodelo.Text;
            string categoria = txtcategory.Text;
            string descripcion = txtdescription.Text;
            string cantidad = txtqty.Text;
            string barcode = txtbar.Text;
            string ID = txtpiezaID.Text;
            if (txtpiezaID.Text == "" || txtpiezaID.Text == "ID")
            {
                if (string.IsNullOrWhiteSpace(marca) || marca == "Marca" ||
                string.IsNullOrWhiteSpace(modelo) || modelo == "Modelo" ||
                string.IsNullOrWhiteSpace(categoria) || categoria == "Categoria" ||
                string.IsNullOrWhiteSpace(descripcion) || descripcion == "Descripcion" ||
                string.IsNullOrWhiteSpace(barcode) || barcode == "Barcode" ||
                string.IsNullOrWhiteSpace(cantidad) || cantidad == "Cantidad")
                {
                    MessageBox.Show("Llene todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (int.TryParse(cantidad, out int cantidadNumerica) && cantidadNumerica >= 0)
                    {
                        // Llamar al método para guardar los datos
                        DataTable dataTable = await _inventory.SaveItemsAsync(marca, modelo, barcode, descripcion, categoria, cantidadNumerica);
                        MessageBox.Show("Registro guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                if (int.TryParse(cantidad, out int cantidadNumerica) && cantidadNumerica >= 0)
                {
                    // Llamar al método para guardar los datos
                    DataTable dataTable = await _inventory.UpdateItems(ID, marca, modelo, barcode, descripcion, categoria, cantidadNumerica);
                    MessageBox.Show("Registro ha actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
               
            }
        }
    }
}
