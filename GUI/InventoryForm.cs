using System.Data;
using System.Security.Policy;
using Domain;

namespace GUI
{

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
            dgvItems.ReadOnly = true;
            dgvItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvItems.AllowUserToAddRows = false;
            dgvItems.RowHeadersVisible = false;
            this.contextMenuStrip1 = new ContextMenuStrip();
            var editMenuItem = new ToolStripMenuItem("Edit", null, editMenuItem_Click);
            var deleteMenuItem = new ToolStripMenuItem("Delete", null, deleteMenuItem_Click);
            var newMenuItem = new ToolStripMenuItem("New", null, NewMenuItem_Click);
            this.contextMenuStrip1.Items.AddRange(new ToolStripItem[] {
                editMenuItem,
                newMenuItem,
                deleteMenuItem
            });
            contextMenuStrip1.Items.Add(editMenuItem);
            foreach (ToolStripMenuItem item in contextMenuStrip1.Items)
            {
                item.BackColor = ColorTranslator.FromHtml("#19201f"); // Fondo oscuro
                item.ForeColor = ColorTranslator.FromHtml("#a8a9a8");               // Texto blanco
                item.Font = new Font("Segoe UI", 10);       // Fuente personalizada
            }
            this.dgvItems.ContextMenuStrip = this.contextMenuStrip1;
            //dgvItems.MouseDown += dgvItems_MouseDown;
        }
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
        private async void editMenuItem_Click(object? sender, EventArgs e)
        {
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
                DataTable marcasTable = await _inventory.Combobox_Marca();
                DataTable categoriasTable = await _inventory.Combobox_Categoria();

                int marcaID = ObtenerIDDesdeDataTable(marcasTable, "Nombre", marcaNombre, "ID");
                int categoriaID = ObtenerIDDesdeDataTable(categoriasTable, "Category", categoriaNombre, "ID");


                // Abre el formulario de edición con los datos
                using (Add_UpdateForm editForm = new Add_UpdateForm(id, marcaID, modelo, barcode, descripcion, categoriaID, cantidad))
                {
                    MessageBox.Show(marcaNombre + " "+ marcaID + " " + categoriaNombre + categoriaID);
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
        private async void deleteMenuItem_Click(object? sender, EventArgs e)
        {
            if (dgvItems.SelectedRows.Count > 0)
            {
                var selectedRow = dgvItems.SelectedRows[0];
                string id = selectedRow.Cells["PiezaID"].Value?.ToString() ?? string.Empty;

                var confirm = DarkMessageBox.Show("¿Estás seguro de que deseas eliminar este registro?",
                                            "Confirmar eliminación", MessageBoxButtons.YesNo);

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
        private void TextBox_Enter(object sender, EventArgs e)
        {
            txtbar.Tag = "Barcode";
            txtmodel.Tag = "Modelo";
           

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
       private void TextBoxRefresh()
        {
            txtbar.Tag = "Barcode";
            txtmodel.Tag = "Modelo";
            txtbar.Text = txtbar.Tag?.ToString();
            txtmodel.Text = txtmodel.Tag?.ToString();
        }
        private void InventoryForm_FormClosed(object? sender, FormClosedEventArgs e)
        {

            MainForm? mainForm = Application.OpenForms["MainForm"] as MainForm;
            if (mainForm != null)
            {
                mainForm.Show();
            }
        }
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
        }
        private async void TextBox_TextChanged(object? sender, EventArgs e)
        {
            DataTable dataTable;

            if ((txtbar.Text == "" || txtbar.Text == "Barcode") && (txtmodel.Text == "" || txtmodel.Text == "Modelo"))
            {
                dataTable = await _inventory.LoadItems();
            }
            else
            {
                dataTable = await _inventory.DynamicSearchItem(txtbar.Text, txtmodel.Text);
            }
            dgvItems.DataSource = dataTable;
        }
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
        }
        private void dgvItems_CellMouseDown(object? sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                dgvItems.ClearSelection();
                dgvItems.Rows[e.RowIndex].Selected = true;
                dgvItems.CurrentCell = dgvItems.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }
        }
        private async void btnrefresh_Click(object sender, EventArgs e)
        {
            await Inventory_Load();
            TextBoxRefresh();

        }
        private int ObtenerIDDesdeDataTable(DataTable table, string columnName, string searchValue, string idColumn)
        {
            foreach (DataRow row in table.Rows)
            {
                if (row[columnName].ToString() == searchValue)
                {
                    return Convert.ToInt32(row[idColumn]);
                }
            }
            return 0; // Si no se encuentra, devuelve 0 (o lanza una excepción según tu lógica)
        }
    }
}