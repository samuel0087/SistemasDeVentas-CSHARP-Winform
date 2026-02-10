using Negocio;
using System.Windows.Forms;

namespace AppSistemaVentas
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }

        private void btnClientes_Click(object sender, System.EventArgs e)
        {
            frmClientes frmClientes = new frmClientes();
            frmClientes.ShowDialog();
        }
    }
}
