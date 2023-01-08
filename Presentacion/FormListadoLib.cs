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
    public partial class FormListadoLib : Form
    {
        private List<Libro> libros;

        public FormListadoLib()
        {
            InitializeComponent();
        }

        public FormListadoLib(LNAdquisiciones lnAdq)
        {
            this.libros = lnAdq.MostrarLibros();
            InitializeComponent();
        }

        private void CargarDatos()
        {
            bsClave.DataSource = libros.Select(x => x.Isbn).ToList();
            bsTit.DataSource = libros.Select(x => x.Titulo).ToList();
            bsAut.DataSource = libros.Select(x => x.Autor).ToList();
            bsEdi.DataSource = libros.Select(x => x.Editorial).ToList();
            lbClave.DataSource = bsClave;
            lbTitulo.DataSource = bsTit;
            lbAutor.DataSource = bsAut;
            lbEditorial.DataSource = bsEdi;
        }
        private void FormListadoLib_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void btOrdClave_Click(object sender, EventArgs e)
        {
            libros.Sort((p, q) => string.Compare(p.Isbn, q.Isbn));
            CargarDatos();
        }

        private void btOrdTit_Click(object sender, EventArgs e)
        {
            libros.Sort((p, q) => string.Compare(p.Titulo, q.Titulo));
            CargarDatos();
        }

        private void btOrdAut_Click(object sender, EventArgs e)
        {
            libros.Sort((p, q) => string.Compare(p.Autor, q.Autor));
            CargarDatos();
        }

        private void btOrdEdit_Click(object sender, EventArgs e)
        {
            libros.Sort((p, q) => string.Compare(p.Editorial, q.Editorial));
            CargarDatos();
        }

        
    }
}
