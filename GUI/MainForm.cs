using System.Data;
using Domain;
using static DataAccess.DBConnection;

namespace GUI
{
    /// <summary>
    /// Clase principal del formulario de inventario.
    /// </summary>
    public partial class MainForm : Style
    {
        private Inventory _inventory;
        public MainForm()
        {
            _inventory = new Inventory();
            InitializeComponent();
            this.Load += async (s, e) => await LoadComboBox();
            dgvItems.CellClick += SelectItem;
            TextBoxStyle(txtbar);
            TextBoxStyle(txtmodelo);
            TextBoxStyle(txtdescription);
            TextBoxStyle(txtqty);
            TextBoxStyle(txtpiezaID);
            ButtonStyle(btnadd);
            ButtonStyle(btnsust);
            ButtonStyle(btnSearch);
            ButtonStyle(btnrefresh);
            txtdescription.Multiline = true;
            //txtdescription.ScrollBars = ScrollBars.Vertical;
            Disable_entries();
            Win_Title("Almacen ITS");
            dgvItems.ReadOnly = true;
            dgvItems.AllowUserToAddRows = false;
            dgvItems.RowHeadersVisible = false;
            CustomizeDataGridView(dgvItems);
            dgvItems.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            var style = new DataGridViewCellStyle();
            style.WrapMode = DataGridViewTriState.True;
            int lastColIndex = dgvItems.Columns.Count - 1;
            if (lastColIndex >= 0)
            {
                dgvItems.Columns[lastColIndex].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            cmbcategory.TextFont = new Font("Arial", 10F);
            cmbcategory.TextForeColor = Color.Gray;
            cmbmarca.TextFont = new Font("Arial", 10F);
            cmbmarca.TextForeColor = Color.Gray;
            cmbcategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbmarca.DropDownStyle = ComboBoxStyle.DropDownList;
            ErrorException();
        }
        /// <summary>
        /// Deshabilita la edición de los campos de texto.
        /// </summary>
        private void Disable_entries()
        {
            txtdescription.ReadOnly = true;
            txtmodelo.ReadOnly = true;
            txtdescription.Enabled = false;
            txtmodelo.Enabled = false;
            txtpiezaID.Enabled = false;
        }
        /// <summary>
        /// Establece el estilo de los campos de texto.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtbar_Enter(object sender, EventArgs e)
        {
            if (txtbar.Text == "Barcode")
            {
                txtbar.Text = string.Empty;
            }
        }
        /// <summary>
        /// Establece el estilo de los campos de texto.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtbar_Leave(object sender, EventArgs e)
        {
            if (txtbar.Text == string.Empty)
            {
                txtbar.Text = "Barcode";
            }
        }
        /// <summary>
        /// Establece el estilo de los campos de texto.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtqty_Enter(object sender, EventArgs e)
        {
            if (txtqty.Text == "Cantidad")
            {
                txtqty.Text = string.Empty;
            }
        }
        /// <summary>
        /// Establece el estilo de los campos de texto.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtqty_Leave(object sender, EventArgs e)
        {
            if (txtqty.Text == string.Empty)
            {
                txtqty.Text = "Cantidad";
            }
        }
        private InventoryForm? inventoryForm = null;
        /// <summary>
        /// Abre el formulario de inventario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInventory_Click(object sender, EventArgs e)
        {
            if (inventoryForm == null || inventoryForm.IsDisposed)
            {
                inventoryForm = new InventoryForm();
                inventoryForm.Show();

            }
            else
            {
                inventoryForm.BringToFront();
            }
        }
        private Add_UpdateForm? newPartForm = null;
        /// <summary>
        /// Abre el formulario para agregar una nueva parte.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnnew_Click(object sender, EventArgs e)
        {
            if (newPartForm == null || newPartForm.IsDisposed)
            {
                newPartForm = new Add_UpdateForm();
                newPartForm.Show();
            }
            else
            {
                newPartForm.BringToFront();
            }
        }
        /// <summary>
        /// Realiza una búsqueda exacta de un elemento en la base de datos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void txtbar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DataTable dataTable = await _inventory.ExactSearchItem(txtbar.Text);
                if (dataTable != null && dataTable.Rows.Count > 0)
                {

                    txtpiezaID.Text = dataTable.Rows[0]["PiezaID"].ToString();
                    txtmodelo.Text = dataTable.Rows[0]["Modelo"].ToString();
                    txtdescription.Text = dataTable.Rows[0]["Descripcion"].ToString();
                    cmbmarca.SelectedValue = dataTable.Rows[0]["Marca"].ToString();
                    cmbcategory.SelectedValue = dataTable.Rows[0]["Categoria"].ToString();
                    txtqty.Text = dataTable.Rows[0]["Cantidad"].ToString();
                }
                else
                {
                    DarkMessageBox.Show("No se encontró ningún elemento con ese código de barras.", "Sin resultados", MessageBoxButtons.OK);
                    txtbar.Text = "";
                    txtqty.Text = "Cantidad";
                    txtdescription.Text = "Descripcion";
                    txtmodelo.Text = "Modelo";
                    txtpiezaID.Text = "ID";

                }
            }
        }
        /// <summary>
        /// Carga las marcas y categorías en los ComboBox.
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
            cmbcategory.PlaceholderText = "Categoria";
        }
        /// <summary>
        /// Realiza una búsqueda de elementos en la base de datos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnsust_Click(object sender, EventArgs e)
        {
            DataTable datatable = await _inventory.ExactSearchItem(txtbar.Text);
            int cantidad = 1;
            int cantidaddb = 0;

            if (!string.IsNullOrWhiteSpace(txtqty.Text) && txtqty.Text != "Cantidad" && int.TryParse(txtqty.Text, out int cantidadin))
            {
                cantidad = cantidadin;

            }

            if (datatable.Rows.Count > 0 && !Convert.IsDBNull(datatable.Rows[0]["Cantidad"]))
            {
                string? cantidadstr = datatable.Rows[0]["Cantidad"].ToString();
                if (!string.IsNullOrWhiteSpace(cantidadstr))
                {
                    cantidaddb = int.Parse(cantidadstr);
                }
                string ID = txtpiezaID.Text;
                int newcantidad;

                newcantidad = cantidaddb - cantidad;

                await _inventory.AddItems(ID, newcantidad);
                DarkMessageBox.Show($"La cantidad se actualizó correctamente.\nNueva cantidad: {newcantidad}", "Éxito", MessageBoxButtons.OK);
            }
        }
        /// <summary>
        /// Realiza una búsqueda de elementos en la base de datos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnadd_Click(object sender, EventArgs e)
        {
            DataTable datatable = await _inventory.ExactSearchItem(txtbar.Text);
            int cantidad = 1;
            int cantidaddb = 0;

            if (!string.IsNullOrWhiteSpace(txtqty.Text) && txtqty.Text != "Cantidad" && int.TryParse(txtqty.Text, out int cantidadin))
            {
                cantidad = cantidadin;
            }

            if (datatable.Rows.Count > 0 && !Convert.IsDBNull(datatable.Rows[0]["Cantidad"]))
            {
                string? cantidadstr = datatable.Rows[0]["Cantidad"].ToString();
                if (!string.IsNullOrWhiteSpace(cantidadstr))
                {
                    cantidaddb = int.Parse(cantidadstr);
                }
            }
            string ID = txtpiezaID.Text;
            int newcantidad;

            newcantidad = cantidaddb + cantidad;

            await _inventory.AddItems(ID, newcantidad);
            DarkMessageBox.Show($"La cantidad se actualizó correctamente.\nNueva cantidad: {newcantidad}", "Éxito", MessageBoxButtons.OK);
        }
        /// <summary>
        /// Realiza una búsqueda de elementos en la base de datos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void SearchItems(object? sender, EventArgs e)
        {
            string? marcaID = cmbmarca.SelectedValue?.ToString();
            string? categoriaID = cmbcategory.SelectedValue?.ToString();
            if (string.IsNullOrEmpty(marcaID) && string.IsNullOrEmpty(categoriaID))
            {
                DarkMessageBox.Show("Seleccione al menos una Marca o Categoría.", " ", MessageBoxButtons.OK);
                return;
            }
            this.Height = 526;
            DataTable dataTable = await _inventory.SearchItem(marcaID, categoriaID);
            dgvItems.DataSource = dataTable;
            AutoDataGridSize();
        }
        /// <summary>
        /// Refresca el formulario principal.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void RefreshMainForm(object? sender, EventArgs e)
        {
            this.Height = 265;
            await LoadComboBox();
            txtpiezaID.Text = "ID";
            txtmodelo.Text = "Modelo";
            txtdescription.Text = "Descripción";
            txtqty.Text = "Cantidad";
            txtbar.Text = "Barcode";
            dgvItems.DataSource = null;

        }
        /// <summary>
        /// Selecciona un elemento del DataGridView.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void SelectItem(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgvItems.Rows[e.RowIndex];
                DataTable marcasTable = await _inventory.Combobox_Marca();
                DataTable categoriasTable = await _inventory.Combobox_Categoria();

                string marcaNombre = selectedRow.Cells["Marca"].Value?.ToString() ?? string.Empty;
                string categoriaNombre = selectedRow.Cells["Categoria"].Value?.ToString() ?? string.Empty;
                int.TryParse(selectedRow.Cells["Cantidad"].Value?.ToString(), out int cantidad);

                int marcaID = ObtenerIDDesdeDataTable(marcasTable, "Nombre", marcaNombre, "ID");
                int categoriaID = ObtenerIDDesdeDataTable(categoriasTable, "Category", categoriaNombre, "ID");

                txtpiezaID.Text = selectedRow.Cells["PiezaID"].Value?.ToString() ?? string.Empty;
                txtmodelo.Text = selectedRow.Cells["Modelo"].Value?.ToString() ?? string.Empty;
                txtdescription.Text = selectedRow.Cells["Descripcion"].Value?.ToString() ?? string.Empty;
                txtbar.Text = selectedRow.Cells["BarCode"].Value?.ToString() ?? string.Empty;
                cmbmarca.SelectedValue = marcaID > 0 ? marcaID : -1;
                cmbcategory.SelectedValue = categoriaID > 0 ? categoriaID : -1;
            }
        }
        /// <summary>
        /// Obtiene el ID de un elemento en un DataTable.
        /// </summary>
        /// <param name="table"></param>
        /// <param name="columnName"></param>
        /// <param name="searchValue"></param>
        /// <param name="idColumn"></param>
        /// <returns></returns>
        private int ObtenerIDDesdeDataTable(DataTable table, string columnName, string searchValue, string idColumn)
        {
            foreach (DataRow row in table.Rows)
            {
                if (row[columnName].ToString() == searchValue)
                {
                    return Convert.ToInt32(row[idColumn]);
                }
            }
            return 0;
        }
        /// <summary>
        /// Establece el tamaño de las columnas del DataGridView.
        /// </summary>
        private void AutoDataGridSize()
        {
            dgvItems.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            var style = new DataGridViewCellStyle();
            style.WrapMode = DataGridViewTriState.True;
            int lastColIndex = dgvItems.Columns.Count - 3;
            if (lastColIndex >= 0)
            {
                dgvItems.Columns[lastColIndex].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            dgvItems.Columns["Cantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }
        /// <summary>
        /// Muestra un MessageBox en caso de error.
        /// </summary>
        private void ErrorException()
        {
            try
            {
                // Asegurarte de que la base de datos esté creada
                _inventory.EnsureDatabaseCreated();
            }
            catch (DataAccessException ex)
            {
                // Aquí sí puedes mostrar el MessageBox
                DarkMessageBox.Show(
                    $"Ha ocurrido un error de acceso a datos: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK
                );
            }
        }
        /// <summary>
        /// Abre el formulario de reportes.
        /// </summary>
        private ReportsForm? reports;
        private void btnreports_Click(object sender, EventArgs e)
        {
            reports = new ReportsForm();
            reports.Show();
        }
    }
}

