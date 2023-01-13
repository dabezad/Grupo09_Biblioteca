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
    public partial class FormListPrest : Form
    {
        private List<Prestamo> prestamos;
        public FormListPrest()
        {
            InitializeComponent();
        }
        public FormListPrest(List<Prestamo> prestamosBD)
        {
            this.prestamos = prestamosBD;
            InitializeComponent();
        }

        /// <summary>
        /// Muestra el formulario con la lista de prestamos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <summary>
        /// Carga en el DataGridView todos los préstamos de la BD, si no existen muestra un mensaje por pantalla y muestra el datagridview vacío
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormListPrest_Load(object sender, EventArgs e)
        {
            
                this.dgPrestamos.BackgroundColor = SystemColors.Control;
                int n = 0;
                DataGridViewColumn codP = new DataGridViewTextBoxColumn();
                codP.HeaderText = "Código de préstamo";
                DataGridViewColumn dniU = new DataGridViewTextBoxColumn();
                dniU.HeaderText = "DNI de usuario";
                DataGridViewColumn fRealizado = new DataGridViewTextBoxColumn();
                fRealizado.HeaderText = "Fecha de préstamo";
                DataGridViewColumn fFin = new DataGridViewTextBoxColumn();
                fFin.HeaderText = "Fecha de fin de préstamo";
                DataGridViewColumn ejemplares = new DataGridViewTextBoxColumn();
                ejemplares.HeaderText = "Ejemplares del préstamo";
                DataGridViewColumn estado = new DataGridViewTextBoxColumn();
                estado.HeaderText = "Estado del préstamo";
                DataGridViewColumn nomPerAlta = new DataGridViewTextBoxColumn();
                nomPerAlta.HeaderText = "Nombre de personal de alta";
                this.dgPrestamos.Columns.Add(codP);
                this.dgPrestamos.Columns.Add(dniU);
                this.dgPrestamos.Columns.Add(fRealizado);
                this.dgPrestamos.Columns.Add(fFin);
                this.dgPrestamos.Columns.Add(ejemplares);
                this.dgPrestamos.Columns.Add(estado);
                this.dgPrestamos.Columns.Add(nomPerAlta);

                foreach (Prestamo prestamo in prestamos)
                {
                    this.dgPrestamos.Rows.Add();
                    this.dgPrestamos[0, n].Value = prestamo.Codigo;
                    this.dgPrestamos[1, n].Value = prestamo.Usuario.Dni;
                    this.dgPrestamos[2, n].Value = prestamo.FRealizado;
                    this.dgPrestamos[3, n].Value = prestamo.FFinPrestamo;
                    foreach (Ejemplar ej in prestamo.Ejemplares)
                    {
                        this.dgPrestamos[4, n].Value += ej.Codigo + " ";
                    }
                    this.dgPrestamos[5, n].Value = prestamo.Estado;
                    this.dgPrestamos[6, n].Value = prestamo.PersonalBAlta.Nombre;
                    n++;
                }
            
            
        }
    }
}
