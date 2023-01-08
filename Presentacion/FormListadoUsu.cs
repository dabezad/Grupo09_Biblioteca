using LogicaNegocio;
using ModeloDominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FormListadoUsu : Form
    {
        private List<Usuario> usuarios;
        public FormListadoUsu()
        {
            InitializeComponent();
        }

        public FormListadoUsu(LNBiblioteca lnB)
        {
            this.usuarios = lnB.MostrarUsuarios();
            InitializeComponent();
        }

        private void CargarDatos()
        {
            bsClaves.DataSource = usuarios.Select(x => x.Dni).ToList();
            bsDatos.DataSource = usuarios.Select(x => x.Nombre).ToList();
            lbClave.DataSource = bsClaves;
            lbDato.DataSource = bsDatos;
        }
        private void FormListadoUsu_Load(object sender, EventArgs e)
        {
            CargarDatos();
           
        }

        private void btOrdClave_Click(object sender, EventArgs e)
        {
            usuarios.Sort((p, q) => string.Compare(p.Dni, q.Dni));
            CargarDatos();

        }

        private void btOrdDato_Click(object sender, EventArgs e)
        {
            usuarios.Sort((p, q) => string.Compare(p.Nombre, q.Nombre));
            CargarDatos();

        }

        
    }
}
