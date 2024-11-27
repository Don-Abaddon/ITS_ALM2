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
        private void btnInventory_Click(object sender, EventArgs e)
        {
            InventoryForm inventoryForm = new InventoryForm();
            inventoryForm.Show();
        }
        private void btnnew_Click(object sender, EventArgs e)
        {
            this.Hide();
            Add_UpdateForm newPartForm = new Add_UpdateForm();
            newPartForm.ShowDialog();
        }
        private async void txtbar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) // Para que funcione al presionar Enter
            {
                DataTable dataTable = await _inventory.ExactSearchItem(txtbar.Text);
                if (dataTable != null && dataTable.Rows.Count > 0) // Asegúrate de que hay datos
                {
                    // Accede al primer registro y a la columna correspondiente
                    txtpiezaID.Text = dataTable.Rows[0]["PiezaID"].ToString();
                    txtmarca.Text = dataTable.Rows[0]["Marca"].ToString();
                    txtmodelo.Text = dataTable.Rows[0]["Modelo"].ToString();
                    txtdescription.Text = dataTable.Rows[0]["Descripcion"].ToString();
                    txtcategory.Text = dataTable.Rows[0]["Categoria"].ToString();
                    txtqty.Text = dataTable.Rows[0]["Cantidad"].ToString();
                }
                else
                {
                    MessageBox.Show("No se encontró ningún elemento con ese código de barras.", "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
