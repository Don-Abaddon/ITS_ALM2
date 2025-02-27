using Domain;
using GUI.CustomControl;
using System.Data;

namespace GUI
{
    public partial class Add_UpdateForm : Style
    {
        private Inventory _inventory;
        public Add_UpdateForm(string? id = null, int? marca = null, string? modelo = null, string? barcode = null, string? descripcion = null, int? categoria = null, int? cantidad = null)
        {
            InitializeComponent();
            ConfigurarFormulario();
            this.FormClosed += NewPartForm_FormClosed;
            _inventory = new Inventory();
            this.Load += async (s, e) => await LoadComboBox();
            TextBoxStyle(txtbar);
            TextBoxStyle(txtmodelo);
            TextBoxStyle(txtdescription);
            TextBoxStyle(txtqty);
            TextBoxStyle(txtpiezaID);
            ButtonStyle(btnsave);
            txtdescription.Multiline = true;
            txtpiezaID.Enabled = false;
            Win_Title("Nueva Pieza");
            ResetFields();
            Updates(id ?? string.Empty, marca ?? 0, modelo ?? string.Empty,
            barcode ?? string.Empty, descripcion ?? string.Empty,
            categoria ?? 0, cantidad?.ToString() ?? "0");
            if (txtpiezaID.Text != "ID" && txtpiezaID.Text != "")
            {
                Disable_entries();
            }
            else
            {
                ResetFields();
            }
            cmbcategory.TextFont = new Font("Arial", 10F);
            cmbcategory.TextForeColor = Color.Gray;
            cmbmarca.TextFont = new Font("Arial", 10F);
            cmbmarca.TextForeColor = Color.Gray;
            cmbcategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbmarca.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        private void ResetFields()
        {
            txtpiezaID.Text = "ID";
            txtmodelo.Text = "Modelo";
            txtbar.Text = "Barcode";
            txtdescription.Text = "Descripcion";
            txtqty.Text = "Cantidad";
        }
        private void TextBox_Enter(object sender, EventArgs e)
        {
            txtbar.Tag = "Barcode";
            txtmodelo.Tag = "Modelo";
            txtdescription.Tag = "Descripcion";
            txtqty.Tag = "Cantidad";

            if (sender is TextBox textBox)
            {
                if (textBox.Text == textBox.Tag?.ToString())
                {
                    textBox.Text = string.Empty;
                }
            }
        }

        private void TextBox_Leave(object sender, EventArgs e)
        {
            if (sender is TextBox textBox)
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    textBox.Text = textBox.Tag?.ToString();
                }
            }
        }
        private void ConfigurarFormulario()
        {
            _inventory = new Inventory();
            TextBoxStyle(txtbar);
            TextBoxStyle(txtmodelo);
            TextBoxStyle(txtdescription);
            TextBoxStyle(txtqty);
            TextBoxStyle(txtpiezaID);
            ButtonStyle(btnsave);
            txtpiezaID.Enabled = false;
            txtpiezaID.ReadOnly = true;
            txtdescription.Multiline = true;
            
        }
        private void Disable_entries()
        {
            txtbar.Enabled = false;
            txtbar.ReadOnly = true;
            //txtqty.ReadOnly = true;
            //txtdescription.ReadOnly = true;
            txtmodelo.ReadOnly = true;
           //txtdescription.Enabled = false;
            txtmodelo.Enabled = false;
            txtpiezaID.Enabled = false;
        }
        private void NewPartForm_FormClosed(object? sender, FormClosedEventArgs e)
        { 
            MainForm? mainForm = Application.OpenForms["MainForm"] as MainForm;
            if (mainForm != null)
            {
                mainForm.Show();
            }
        }
        private async void btnsave_Click(object sender, EventArgs e)
        {
            string marca = cmbmarca.SelectedValue?.ToString() ?? string.Empty;
            string modelo = txtmodelo.Text;
            string categoria = cmbcategory.SelectedValue?.ToString() ?? string.Empty;
            string descripcion = txtdescription.Text;
            string cantidad = txtqty.Text;
            string barcode = txtbar.Text;
            string id = txtpiezaID.Text;
            if (txtpiezaID.Text == "" || txtpiezaID.Text == "ID")
            {
                if (!int.TryParse(marca, out int marcaID) || !int.TryParse(categoria, out int categoriaID))
                {
                    DarkMessageBox.Show("Seleccione una marca y una categoría válidas.", "Error", MessageBoxButtons.OK);
                    return;
                }
                if (string.IsNullOrWhiteSpace(marca) || marca == "Marca" ||
                string.IsNullOrWhiteSpace(modelo) || modelo == "Modelo" ||
                string.IsNullOrWhiteSpace(categoria) || categoria == "Categoria" ||
                string.IsNullOrWhiteSpace(descripcion) || descripcion == "Descripcion" ||
                string.IsNullOrWhiteSpace(barcode) || barcode == "Barcode" ||
                string.IsNullOrWhiteSpace(cantidad) || cantidad == "Cantidad")
                {
                    DarkMessageBox.Show("Llene todos los campos.", "Error", MessageBoxButtons.OK);
                }
                else
                {
                    if (int.TryParse(cantidad, out int cantidadNumerica) && cantidadNumerica >= 0)
                    {
                        DataTable dataTable = await _inventory.SaveItemsAsync(marca, modelo, barcode, descripcion, categoria, cantidadNumerica);
                        DarkMessageBox.Show("Registro guardado correctamente.", "Éxito", MessageBoxButtons.OK);
                        RefreshForm();
                        return;  
                    }
                }
            }
            else
            {
                if (int.TryParse(cantidad, out int cantidadNumerica) && cantidadNumerica >= 0)
                {
                    DataTable dataTable = await _inventory.UpdateItems(id, marca, modelo, barcode, descripcion, categoria, cantidadNumerica);
                    DarkMessageBox.Show("Registro ha actualizado correctamente.", "Éxito", MessageBoxButtons.OK);
                    this.Close();
                }                
            }            
        }
        private void Updates(string id, int marcaID, string modelo, string barcode, string descripcion, int categoriaID, string cantidad)
        {
            if (!string.IsNullOrEmpty(id) && id != "ID") // Caso de edición
            {
                txtpiezaID.Text = id;
                txtpiezaID.Enabled = false;
                Win_Title("Editar Pieza");
            }
            else // Caso de nuevo registro
            {
                txtpiezaID.Text = "ID";
                txtpiezaID.Enabled = false;
                Win_Title("Nueva Pieza");
            }
            
            txtmodelo.Text = modelo ?? "Modelo";
            txtbar.Text = barcode ?? "Barcode";
            txtdescription.Text = descripcion ?? "Descripcion";
            txtqty.Text = cantidad?.ToString() ?? "Cantidad";
            cmbmarca.SelectedValue = marcaID > 0 ? marcaID : -1;
            cmbcategory.SelectedValue = categoriaID > 0 ? categoriaID : -1;
        }
        private async Task LoadComboBox()
        {
            DataTable dataTable = await _inventory.Combobox_Marca();
            DataTable dataTable2 = await _inventory.Combobox_Categoria();
            cmbmarca.DisplayMember = "Nombre";  // Mostrar el nombre en el ComboBox
            cmbmarca.ValueMember = "ID";        // Guardar el ID internamente
            cmbmarca.DataSource = dataTable;
            cmbmarca.SelectedIndex = -1;
            cmbmarca.PlaceholderText = "Marca";
            cmbcategory.DisplayMember = "Category";
            cmbcategory.ValueMember = "ID";
            cmbcategory.DataSource = dataTable2;
            cmbcategory.SelectedIndex = -1;
            cmbcategory.PlaceholderText = "Category";
        }
        private async void RefreshForm()
        {
            txtpiezaID.Text = "ID";
            txtmodelo.Text = "Modelo";
            txtdescription.Text = "Descripción";
            txtqty.Text = "Cantidad";
            txtbar.Text = "Barcode";
            await LoadComboBox();
        }
    }
}
