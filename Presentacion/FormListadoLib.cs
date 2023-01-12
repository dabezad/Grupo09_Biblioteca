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

        /// <summary>
        /// Carga los datos
        /// </summary>
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

        /// <summary>
        /// Carga los datos en el formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormListadoLib_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        /// <summary>
        /// Boton que ordena por clave los datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btOrdClave_Click(object sender, EventArgs e)
        {
            libros.Sort((p, q) => string.Compare(p.Isbn, q.Isbn));
            CargarDatos();
        }

        /// <summary>
        /// Boton que ordena por titulo los datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btOrdTit_Click(object sender, EventArgs e)
        {
            libros.Sort((p, q) => string.Compare(p.Titulo, q.Titulo));
            CargarDatos();
        }

        /// <summary>
        /// Ordena por autor los datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btOrdAut_Click(object sender, EventArgs e)
        {
            libros.Sort((p, q) => string.Compare(p.Autor, q.Autor));
            CargarDatos();
        }
        /// <summary>
        /// Ordena por editorial los datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btOrdEdit_Click(object sender, EventArgs e)
        {
            libros.Sort((p, q) => string.Compare(p.Editorial, q.Editorial));
            CargarDatos();
        }

        
    }
}
