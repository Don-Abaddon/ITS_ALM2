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

        public InventoryForm()
        {
            InitializeComponent();
            this.FormClosed += InventoryForm_FormClosed;
            _inventory = new Inventory();
            this.Load += async (s, e) => await Inventory_Load();
            Win_Title("Inventory");
            dgvItems.ReadOnly = true;
            dgvItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvItems.AllowUserToAddRows = false;
            dgvItems.RowHeadersVisible = false;
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
    }
}
