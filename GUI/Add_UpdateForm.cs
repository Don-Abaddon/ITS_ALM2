using Domain;
using GUI.CustomControl;
using System.Data;

namespace GUI
{
    /// <summary>
    /// Clase para agregar o actualizar piezas en el inventario.
    /// </summary>
    public partial class Add_UpdateForm : Style
    {
        private Inventory _inventory;
        private int _marcaIDEdit = -1;
        private int _categoriaIDEdit = -1;
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
            if (!string.IsNullOrEmpty(id) && id != "ID")
            {
                Updates(id, marca ?? 0, modelo ?? string.Empty, barcode ?? string.Empty, descripcion ?? string.Empty, categoria ?? 0, cantidad?.ToString() ?? "0");
            }
            else
            {
                ResetFields();
            }
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
        /// <summary>
        /// Reinicia los campos del formulario.
        /// </summary>
        private void ResetFields()
        {
            txtpiezaID.Text = "ID";
            txtmodelo.Text = "Modelo";
            txtbar.Text = "Barcode";
            txtdescription.Text = "Descripcion";
            txtqty.Text = "Cantidad";
        }
        /// <summary>
        /// Establece el texto de los TextBox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Restaura el texto de los TextBox si están vacíos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Configura el formulario.
        /// </summary>
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

        /// <summary>
        /// Deshabilita los campos de texto.
        /// </summary>
        private void Disable_entries()
        {
            txtbar.Enabled = false;
            txtbar.ReadOnly = true;
            txtmodelo.ReadOnly = true;
            txtmodelo.Enabled = false;
            txtpiezaID.Enabled = false;
        }

        /// <summary>
        /// Habilita los campos de texto.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewPartForm_FormClosed(object? sender, FormClosedEventArgs e)
        { 
            MainForm? mainForm = Application.OpenForms["MainForm"] as MainForm;
            if (mainForm != null)
            {
                mainForm.Show();
            }
        }

        /// <summary>
        /// Guarda los datos de la pieza.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnsave_Click(object sender, EventArgs e)
        {
            /// Obtiene los valores de los campos.
            string marca = cmbmarca.SelectedValue?.ToString() ?? string.Empty;
            string modelo = txtmodelo.Text;
            string categoria = cmbcategory.SelectedValue?.ToString() ?? string.Empty;
            string descripcion = txtdescription.Text;
            string cantidad = txtqty.Text;
            string barcode = txtbar.Text;
            string id = txtpiezaID.Text;
            /// Valida si los campos están vacíos.
            if (txtpiezaID.Text == "" || txtpiezaID.Text == "ID")
            {
                if (!int.TryParse(marca, out int marcaID) || !int.TryParse(categoria, out int categoriaID))
                {
                    DarkMessageBox.Show("Seleccione una marca y una categoría válidas.", "Error", MessageBoxButtons.OK);
                    return;
                }
                /// Valida si los campos están vacíos.
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
                    /// Valida si la cantidad es un número.
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
                /// Valida si los campos están vacíos.
                if (int.TryParse(cantidad, out int cantidadNumerica) && cantidadNumerica >= 0)
                {
                    DataTable dataTable = await _inventory.UpdateItems(id, marca, modelo, barcode, descripcion, categoria, cantidadNumerica);
                    DarkMessageBox.Show("Registro ha actualizado correctamente.", "Éxito", MessageBoxButtons.OK);
                    this.Close();
                }                
            }            
        }

        /// <summary>
        /// Actualiza los campos del formulario.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="marcaID"></param>
        /// <param name="modelo"></param>
        /// <param name="barcode"></param>
        /// <param name="descripcion"></param>
        /// <param name="categoriaID"></param>
        /// <param name="cantidad"></param>
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
            // Guarda los IDs para la edición
            _marcaIDEdit = marcaID;
            _categoriaIDEdit = categoriaID;
        }

        /// <summary>
        /// Carga los datos en el ComboBox.
        /// </summary>
        /// <returns></returns>
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

            if (_marcaIDEdit > 0)
            {
                cmbmarca.SelectedValue = _marcaIDEdit;
            }
            if (_categoriaIDEdit > 0)
            {
                cmbcategory.SelectedValue = _categoriaIDEdit;
            }
        }
        /// <summary>
        /// Refresca el formulario.
        /// </summary>
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
