using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
            this.Load += async (s, e) => await Inventory_Load();
            Win_Title("Inventory");
            CustomizeDataGridView();
            dgvItems.ReadOnly = true;
            dgvItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvItems.AllowUserToAddRows = false;
            dgvItems.RowHeadersVisible = false;
            this.contextMenuStrip1 = new ContextMenuStrip();
            var addMenuItem = new ToolStripMenuItem("Editar", null, AddMenuItem_Click);
            //var editMenuItem = new ToolStripMenuItem("Editar", null, EditMenuItem_Click);
            //var deleteMenuItem = new ToolStripMenuItem("Eliminar", null, DeleteMenuItem_Click);
            this.contextMenuStrip1.Items.AddRange(new ToolStripItem[] {
                addMenuItem,
                //editMenuItem,
                //deleteMenuItem
            });
            foreach (ToolStripMenuItem item in contextMenuStrip1.Items)
            {
                item.BackColor = Color.FromArgb(30, 30, 30); // Fondo oscuro
                item.ForeColor = Color.White;               // Texto blanco
                item.Font = new Font("Segoe UI", 10);       // Fuente personalizada
            }
            this.dgvItems.ContextMenuStrip = this.contextMenuStrip1;
        }
        private void AddMenuItem_Click(object sender, EventArgs e)
        {
            // Abre un formulario para añadir un nuevo elemento
            Add_UpdateForm addForm = new Add_UpdateForm();
            addForm.ShowDialog();
        }

        private void txtbar_Enter(object sender, EventArgs e)
        {
            if (txtbar.Text == "Barcode")
            {
                txtbar.Text = string.Empty;
            }
        }
        private void txtbar_Leave(object sender, EventArgs e)
        {
            if (txtbar.Text == string.Empty)
            {
                txtbar.Text = "Barcode";
            }
        }
        private void InventoryForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Muestra el formulario principal al cerrar el formulario de inventario
            MainForm mainForm = Application.OpenForms["MainForm"] as MainForm;
            if (mainForm != null)
            {
                mainForm.Show();
            }
        }
        private async Task Inventory_Load()
        {
            var dataTable = await _inventory.LoadItems();
            dgvItems.DataSource = dataTable;
        }
        private async void txtbar_TextChanged(object sender, EventArgs e)
        {
            DataTable dataTable;

            if (txtbar.Text == "" || txtbar.Text == "Barcode")
            {
                dataTable = await _inventory.LoadItems();
            }
            else
            {
                dataTable = await _inventory.DynamicSearchItem(txtbar.Text);
            }
            dgvItems.DataSource = dataTable;
        }
        private void CustomizeDataGridView()
        {
            // Fondo del DataGridView
            dgvItems.BackgroundColor = Color.FromArgb(30, 30, 30); // Color oscuro para el fondo

            // Color de las celdas
            dgvItems.DefaultCellStyle.BackColor = Color.FromArgb(40, 40, 40); // Fondo de las celdas
            dgvItems.DefaultCellStyle.ForeColor = Color.White; // Color del texto de las celdas
            dgvItems.DefaultCellStyle.SelectionBackColor = Color.FromArgb(70, 70, 70); // Color de fondo al seleccionar
            dgvItems.DefaultCellStyle.SelectionForeColor = Color.White; // Color del texto al seleccionar

            // Cabecera de las columnas
            dgvItems.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(50, 50, 50); // Fondo de la cabecera
            dgvItems.ColumnHeadersDefaultCellStyle.ForeColor = Color.White; // Color del texto de la cabecera
            dgvItems.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Bordes y líneas
            dgvItems.GridColor = Color.FromArgb(70, 70, 70); // Color de las líneas de la cuadrícula
            dgvItems.BorderStyle = BorderStyle.None;

            // Opcional: Sin bordes en las celdas para un diseño más moderno
            dgvItems.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvItems.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            // Otros estilos
            dgvItems.EnableHeadersVisualStyles = false; // Permite aplicar estilos personalizados
        }
    }
}
