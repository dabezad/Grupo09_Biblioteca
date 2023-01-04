using LogicaNegocio;
using ModeloDominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FormListadoUsu : Form
    {
        private LNBiblioteca lnB;
        public FormListadoUsu()
        {
            InitializeComponent();
        }

        public FormListadoUsu(LNBiblioteca lnB)
        {
            this.lnB = lnB;
            InitializeComponent();
        }

        private void FormListadoUsu_Load(object sender, EventArgs e)
        {
            List<string> dnis = lnB.MostrarUsuarios().Select(x => x.Dni).ToList();
            List<string> nombres = lnB.MostrarUsuarios().Select(x => x.Nombre).ToList();
            bsClaves.DataSource = dnis;
            bsDatos.DataSource = nombres;
            lbClave.DataSource = bsClaves;
            lbDato.DataSource = bsDatos;

        }

        private void btOrdClave_Click(object sender, EventArgs e)
        {
            List<Usuario> usuarios = lnB.MostrarUsuarios();
            usuarios.Sort((p, q) => string.Compare(p.Dni, q.Dni));
            bsClaves.DataSource = usuarios.Select(x => x.Dni).ToList();
            bsDatos.DataSource = usuarios.Select(x => x.Nombre).ToList();
            lbClave.DataSource = bsClaves;
            lbDato.DataSource = bsDatos;
        }

        private void btOrdDato_Click(object sender, EventArgs e)
        {
            List<Usuario> usuarios = lnB.MostrarUsuarios();
            usuarios.Sort((p, q) => string.Compare(p.Nombre, q.Nombre));
            bsClaves.DataSource = usuarios.Select(x => x.Dni).ToList();
            bsDatos.DataSource = usuarios.Select(x => x.Nombre).ToList();
            lbClave.DataSource = bsClaves;
            lbDato.DataSource = bsDatos;
        }

        private void btCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
