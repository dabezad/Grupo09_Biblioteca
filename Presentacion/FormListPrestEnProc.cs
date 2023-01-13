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
    public partial class FormListPrestEnProc : Form
    {
        private List<Prestamo> prestamos;
        public FormListPrestEnProc()
        {
            InitializeComponent();
        }

        public FormListPrestEnProc(List<Prestamo> prestamos)
        {
            this.prestamos = prestamos;
            InitializeComponent();
        }
        /// <summary>
        /// Carga en el DataGridView los préstamos que actualmente están en proceso, si no existen muestra un mensaje por pantalla y muestra el datagridview vacío
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormListPrestEnProc_Load(object sender, EventArgs e)
        {
            if (prestamos.Count > 0)
            {
                this.dgPrestEnProceso.BackgroundColor = SystemColors.Control;
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
                DataGridViewColumn nomPerAlta = new DataGridViewTextBoxColumn();
                nomPerAlta.HeaderText = "Nombre de personal de alta";
                this.dgPrestEnProceso.Columns.Add(codP);
                this.dgPrestEnProceso.Columns.Add(dniU);
                this.dgPrestEnProceso.Columns.Add(fRealizado);
                this.dgPrestEnProceso.Columns.Add(fFin);
                this.dgPrestEnProceso.Columns.Add(ejemplares);
                this.dgPrestEnProceso.Columns.Add(nomPerAlta);

                foreach (Prestamo prestamo in prestamos)
                {
                    this.dgPrestEnProceso.Rows.Add();
                    this.dgPrestEnProceso[0, n].Value = prestamo.Codigo;
                    this.dgPrestEnProceso[1, n].Value = prestamo.Usuario.Dni;
                    this.dgPrestEnProceso[2, n].Value = prestamo.FRealizado;
                    this.dgPrestEnProceso[3, n].Value = prestamo.FFinPrestamo;
                    foreach (Ejemplar ej in prestamo.Ejemplares)
                    {
                        this.dgPrestEnProceso[4, n].Value += ej.Codigo + " ";
                    }
                    this.dgPrestEnProceso[5, n].Value = prestamo.PersonalBAlta.Nombre;
                    n++;
                }
            } else
            {
                MessageBox.Show("No existen préstamos en proceso actualmente", "Listado de préstamos en proceso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            

            
        }
    }
}
