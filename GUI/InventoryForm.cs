using System.Data;
using System.Security.Policy;
using Domain;

namespace GUI
{
    /// <summary>
    /// Clase que representa el formulario de inventario
    /// </summary>
    public partial class InventoryForm : Style
    {
        private Inventory _inventory;
        private ContextMenuStrip contextMenuStrip1;
        public InventoryForm()
        {
            InitializeComponent();            
            this.FormClosed += InventoryForm_FormClosed;
            _inventory = new Inventory();
            _inventory.InventoryUpdated += async (s, e) => await Inventory_Load();
            this.Load += async (s, e) => await Inventory_Load();
            Win_Title("Inventory");
            CustomizeDataGridView(); 
            this.Load += async (s, e) => await LoadComboBox();
            this.contextMenuStrip1 = new ContextMenuStrip();
            var editMenuItem = new ToolStripMenuItem("Edit", null, editMenuItem_Click);
            var deleteMenuItem = new ToolStripMenuItem("Delete", null, deleteMenuItem_Click);
            var newMenuItem = new ToolStripMenuItem("New", null, NewMenuItem_Click);
            this.contextMenuStrip1.Items.AddRange(new ToolStripItem[] {
                editMenuItem,
                newMenuItem,
                deleteMenuItem
            });
            /// Agregar los elementos al menú contextual
            contextMenuStrip1.Items.Add(editMenuItem);
            foreach (ToolStripMenuItem item in contextMenuStrip1.Items)
            {
                item.BackColor = ColorTranslator.FromHtml("#19201f"); // Fondo oscuro
                item.ForeColor = ColorTranslator.FromHtml("#a8a9a8"); // Texto blanco
                item.Font = new Font("Segoe UI", 10); // Fuente personalizada
            }
            this.dgvItems.ContextMenuStrip = this.contextMenuStrip1;
            cmbcategory.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        /// <summary>
        /// Formulario para agregar o editar una pieza
        /// </summary>
        private Add_UpdateForm? newPartForm = null;
        private void NewMenuItem_Click(object? sender, EventArgs e)
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
        /// Abre el formulario de edición con los datos de la fila seleccionada
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void editMenuItem_Click(object? sender, EventArgs e)
        {   /// Verifica si hay una fila seleccionada
            if (dgvItems.SelectedRows.Count > 0)
            {
                var selectedRow = dgvItems.SelectedRows[0];

                // Obtén los valores de las celdas
                string id = selectedRow.Cells["PiezaID"].Value?.ToString() ?? string.Empty;
                string marcaNombre = selectedRow.Cells["Marca"].Value?.ToString() ?? string.Empty;
                string modelo = selectedRow.Cells["Modelo"].Value?.ToString() ?? string.Empty;
                string barcode = selectedRow.Cells["BarCode"].Value?.ToString() ?? string.Empty;
                string descripcion = selectedRow.Cells["Descripcion"].Value?.ToString() ?? string.Empty;
                string categoriaNombre = selectedRow.Cells["Categoria"].Value?.ToString() ?? string.Empty;
                int.TryParse(selectedRow.Cells["Cantidad"].Value?.ToString(), out int cantidad);

                //Obtener los IDs reales de la base de datos basados en los nombres
                /// Esto es necesario porque la base de datos almacena los IDs, no los nombres
                DataTable marcasTable = await _inventory.Combobox_Marca();
                DataTable categoriasTable = await _inventory.Combobox_Categoria();

                int marcaID = ObtenerIDDesdeDataTable(marcasTable, "Nombre", marcaNombre, "ID");
                int categoriaID = ObtenerIDDesdeDataTable(categoriasTable, "Category", categoriaNombre, "ID");


                // Abre el formulario de edición con los datos
                /// El formulario se cierra automáticamente al guardar o cancelar
                using (Add_UpdateForm editForm = new Add_UpdateForm(id, marcaID, modelo, barcode, descripcion, categoriaID, cantidad))
                {                 
                    editForm.ShowDialog();                    
                }


                // Opcional: Actualiza el DataGridView después de editar
                _ = Inventory_Load();
            }
            else
            {
                MessageBox.Show("Seleccione una fila para editar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Elimina un registro de la base de datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void deleteMenuItem_Click(object? sender, EventArgs e)
        {   /// Verifica si hay una fila seleccionada
            if (dgvItems.SelectedRows.Count > 0)
            {
                var selectedRow = dgvItems.SelectedRows[0];
                string id = selectedRow.Cells["PiezaID"].Value?.ToString() ?? string.Empty;

                var confirm = DarkMessageBox.Show("¿Estás seguro de que deseas eliminar este registro?",
                                            "Confirmar eliminación", MessageBoxButtons.YesNo);
                /// Si el usuario confirma la eliminación, elimina el registro
                if (confirm == DialogResult.Yes)
                {
                    await _inventory.DeleteItems(id);
                    _ = Inventory_Load();
                }
                else
                {
                    DarkMessageBox.Show("Eliminación cancelada.", "Información", MessageBoxButtons.OK);
                }
            }
            else
            {
                DarkMessageBox.Show("Seleccione una fila para eliminar.", "Error", MessageBoxButtons.OK);
            }
        }
        /// <summary>
        /// Evento que se dispara al hacer clic en el TextBox de búsqueda
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_Enter(object sender, EventArgs e)
        {
            /// Establece el texto del TextBox en blanco si es igual al Tag
            txtbar.Tag = "Barcode";

            /// Establece el texto del TextBox en blanco si es igual al Tag
            if (sender is TextBox textBox)
            {
                if (textBox.Text == textBox.Tag?.ToString())
                {
                    textBox.Text = string.Empty;
                }
            }
        }
        /// <summary>
        /// Evento que se dispara al salir del TextBox de búsqueda
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_Leave(object sender, EventArgs e)
        {
            /// Establece el texto del TextBox en el Tag si está vacío
            if (sender is TextBox textBox)
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    textBox.Text = textBox.Tag?.ToString();
                }
            }
        }
        /// <summary>
        /// Actualiza el contenido del TextBox de búsqueda
        /// </summary>
        private void TextBoxRefresh()
        {
            txtbar.Tag = "Barcode";            
            txtbar.Text = txtbar.Tag?.ToString();
        }
        /// <summary>
        /// Evento que se dispara al cerrar el formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InventoryForm_FormClosed(object? sender, FormClosedEventArgs e)
        {
            /// Muestra el formulario principal al cerrar
            MainForm? mainForm = Application.OpenForms["MainForm"] as MainForm;
            if (mainForm != null)
            {
                mainForm.Show();
            }
        }
        /// <summary>
        /// Carga los datos de la base de datos en el DataGridView
        /// </summary>
        /// <returns></returns>
        private async Task Inventory_Load()
        {
            var dataTable = await _inventory.LoadItems();
            //Asegurar que la UI se actualiza en el hilo principal
            if (dgvItems.InvokeRequired)
            {
                dgvItems.Invoke(new Action(() => dgvItems.DataSource = dataTable));
            }
            else
            {
                dgvItems.DataSource = dataTable;
            }
            AutoDataGridSize();
        }
        /// <summary>
        /// Evento que se dispara al escribir en el TextBox de búsqueda
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void TextBox_TextChanged(object? sender, EventArgs e)
        {
            DataTable dataTable;
            string? categoryID = cmbcategory.SelectedValue?.ToString() ?? "";

            if ((txtbar.Text == "" || txtbar.Text == "Barcode") && (string.IsNullOrEmpty(categoryID)))
            {
                dataTable = await _inventory.LoadItems();
            }
            else
            {
                dataTable = await _inventory.DynamicSearchItem(txtbar.Text, categoryID);
            }
            dgvItems.DataSource = dataTable;
        }
        /// <summary>
        /// Personaliza el DataGridView
        /// </summary>
        private void CustomizeDataGridView()
        {
            dgvItems.BackgroundColor = Color.FromArgb(30, 30, 30);

            dgvItems.DefaultCellStyle.BackColor = Color.FromArgb(40, 40, 40);
            dgvItems.DefaultCellStyle.ForeColor = Color.White;
            dgvItems.DefaultCellStyle.SelectionBackColor = Color.FromArgb(70, 70, 70);
            dgvItems.DefaultCellStyle.SelectionForeColor = Color.White;

            dgvItems.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(50, 50, 50);
            dgvItems.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvItems.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvItems.GridColor = Color.FromArgb(70, 70, 70);
            dgvItems.BorderStyle = BorderStyle.None;

            dgvItems.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvItems.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            dgvItems.EnableHeadersVisualStyles = false;

            dgvItems.ReadOnly = true;
            dgvItems.AllowUserToAddRows = false;
            dgvItems.RowHeadersVisible = false;            
        }
        /// <summary>
        /// Evento que se dispara al hacer clic en una celda del DataGridView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvItems_CellMouseDown(object? sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                dgvItems.ClearSelection();
                dgvItems.Rows[e.RowIndex].Selected = true;
                dgvItems.CurrentCell = dgvItems.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }
        }
        /// <summary>
        /// Evento que se dispara al hacer clic en el botón de refrescar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnrefresh_Click(object sender, EventArgs e)
        {
            await Inventory_Load();
            await LoadComboBox();
            TextBoxRefresh();
        }
        /// <summary>
        /// Obtiene el ID de un elemento en un DataTable
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
        /// Ajusta automáticamente el tamaño de las celdas del DataGridView
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
        /// Carga las categorías en el ComboBox
        /// </summary>
        /// <returns></returns>
        private async Task LoadComboBox()
        {
            DataTable dataTable2 = await _inventory.Combobox_Categoria();            
            cmbcategory.DisplayMember = "Category";
            cmbcategory.ValueMember = "ID";
            cmbcategory.DataSource = dataTable2;
            cmbcategory.SelectedIndex = -1;
            cmbcategory.PlaceholderText = "Categoria";
        }
    }
}