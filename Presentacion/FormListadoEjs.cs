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
    public partial class FormListadoEjs : Form
    {
        private List<Ejemplar> ejemplares;
        public FormListadoEjs()
        {
            InitializeComponent();
        }

        public FormListadoEjs(List<Ejemplar> ejemplaresBD)
        {
            this.ejemplares = ejemplaresBD;
            InitializeComponent();
        }
        /// <summary>
        /// Carga en el DataGridView los ejemplares, si no existen muestra un mensaje por pantalla y muestra el datagridview vacío
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormListadoEjs_Load(object sender, EventArgs e)
        {
            if (ejemplares.Count > 0)
            {
                this.dgEjemplares.BackgroundColor = SystemColors.Control;
                int n = 0;
                DataGridViewColumn codEj = new DataGridViewTextBoxColumn();
                codEj.HeaderText = "Código de ejemplar";
                DataGridViewColumn estado = new DataGridViewTextBoxColumn();
                estado.HeaderText = "Estado de ejemplar";
                DataGridViewColumn libISBN = new DataGridViewTextBoxColumn();
                libISBN.HeaderText = "ISBN de libro";
                DataGridViewColumn personal = new DataGridViewTextBoxColumn();
                personal.HeaderText = "Nombre del personal de alta";
                this.dgEjemplares.Columns.Add(codEj);
                this.dgEjemplares.Columns.Add(estado);
                this.dgEjemplares.Columns.Add(libISBN);
                this.dgEjemplares.Columns.Add(personal);

                foreach (Ejemplar ej in ejemplares)
                {
                    this.dgEjemplares.Rows.Add();
                    this.dgEjemplares[0, n].Value = ej.Codigo;
                    this.dgEjemplares[1, n].Value = ej.Estado;
                    this.dgEjemplares[2, n].Value = ej.Libro.Isbn;
                    this.dgEjemplares[3, n].Value = ej.PersonalBAlta.Nombre;
                    n++;
                }
            }
            else
            {
                MessageBox.Show("No existen ejemplares en el sistema actualmente", "Listado de ejemplares", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
