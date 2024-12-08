using System.Data;
using Domain;

namespace GUI
{
    public partial class MainForm : Style
    {
        private Inventory _inventory;
        public MainForm()
        {
            _inventory = new Inventory();
            InitializeComponent();
            TextBoxStyle(txtbar);
            TextBoxStyle(txtmarca);
            TextBoxStyle(txtmodelo);
            TextBoxStyle(txtcategory);
            TextBoxStyle(txtdescription);
            TextBoxStyle(txtqty);
            TextBoxStyle(txtpiezaID);
            ButtonStyle(btnadd);
            ButtonStyle(btnsust);
            txtdescription.Multiline = true;
            //txtdescription.ScrollBars = ScrollBars.Vertical;
            Disable_entries();
            Win_Title("Almacen ITS");
        }
        private void Disable_entries()
        {
            txtqty.ReadOnly = true;
            txtdescription.ReadOnly = true;
            txtmarca.ReadOnly = true;
            txtmodelo.ReadOnly = true;
            txtcategory.ReadOnly = true;
            txtdescription.Enabled = false;
            txtmarca.Enabled = false;
            txtmodelo.Enabled = false;
            txtcategory.Enabled = false;
            txtpiezaID.Enabled = false;
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
        private void txtqty_Enter(object sender, EventArgs e)
        {
            if (txtqty.Text == "Cantidad")
            {
                txtqty.Text = string.Empty;
            }
        }
        private void txtqty_Leave(object sender, EventArgs e)
        {
            if (txtqty.Text == string.Empty)
            {
                txtqty.Text = "Cantidad";
            }
        }
        private InventoryForm? inventoryForm = null;
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
        private async void txtbar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DataTable dataTable = await _inventory.ExactSearchItem(txtbar.Text);
                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                  
                    txtpiezaID.Text = dataTable.Rows[0]["PiezaID"].ToString();
                    txtmarca.Text = dataTable.Rows[0]["Marca"].ToString();
                    txtmodelo.Text = dataTable.Rows[0]["Modelo"].ToString();
                    txtdescription.Text = dataTable.Rows[0]["Descripcion"].ToString();
                    txtcategory.Text = dataTable.Rows[0]["Categoria"].ToString();
                    //txtqty.Text = dataTable.Rows[0]["Cantidad"].ToString();
                }
                else
                {
                    MessageBox.Show("No se encontró ningún elemento con ese código de barras.", "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
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
        private async void btnadd_Click(object sender, EventArgs e)
        {
            DataTable datatable = await _inventory.ExactSearchItem(txtbar.Text);
            int cantidad = 1;
            int cantidaddb = 0;
            
            if ( !string.IsNullOrWhiteSpace(txtqty.Text) && txtqty.Text != "Cantidad" && int.TryParse(txtqty.Text, out int cantidadin))
            {
                cantidad = cantidadin;
            }

            if (datatable.Rows.Count > 0 && !Convert.IsDBNull(datatable.Rows[0]["Cantidad"]))
            {
                string? cantidadstr = datatable.Rows[0]["Cantidad"].ToString();
                if(!string.IsNullOrWhiteSpace(cantidadstr))
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
    }
}
