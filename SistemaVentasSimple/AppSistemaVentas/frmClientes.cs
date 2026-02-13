using Negocio;
using Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppSistemaVentas
{
    public partial class frmClientes : Form
    {
        private ClienteNegocio cNegocio = new ClienteNegocio();
        private List<Cliente> clientes;
        public frmClientes()
        {
            InitializeComponent();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmClientes_Load(object sender, EventArgs e)
        {
            Cargar();
        }

        private void Cargar()
        {
            CambiarEstado(false);
            clientes = cNegocio.Listar();
            CargarLista(clientes);
        }

        private void CargarLista(List<Cliente> clientes)
        {
            try
            {
                dgvClientes.DataSource = null;
                dgvClientes.DataSource = clientes;
                dgvClientes.Columns["IdCliente"].Visible = false;
                dgvClientes.Columns["Estado"].Visible=false;
            }
            catch
            {
                MessageBox.Show("No se pudo cargar la lista de clientes");
            }

        }

        private void CambiarEstado(bool estado)
        {
            btnEditar.Enabled = estado;
            btnDetalles.Enabled = estado;
            btnEliminar.Enabled = estado;
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if(txtBuscar.Text.Length > 2)
            {
                CargarLista(cNegocio.BuscarConFiltro(txtBuscar.Text));
            }
            else
            {
                CargarLista(cNegocio.Listar());
            }
        }
    }
}
