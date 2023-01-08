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
    public partial class CtrlDatosPrestamoBusq : UserControl
    {
        private List<Ejemplar> ejemplares;
        public CtrlDatosPrestamoBusq()
        {
            InitializeComponent();
        }
        public CtrlDatosPrestamoBusq(int top, int left, List<Ejemplar> ejs)
        {
            Left = left;
            Top = top;
            ejemplares = ejs;
            InitializeComponent();
        }
        
        public TextBox Tbusuario
        {
            get { return tbusuario; }
        }
        
        public Button Btejemplares
        {
            get { return btejemplares; }
        }
        
        public TextBox Tbfecha
        {
            get { return tbfecha; }
        }

        public TextBox Tbdevolucion
        {
            get { return tbdevolucion; }
        }

        private void btejemplares_Click(object sender, EventArgs e)
        {
            FormNavig listadoEjemplares = new FormNavig();
            CtrlDatosUsu controlEj = new CtrlDatosUsu(100, 35);
            BindingSource datos = new BindingSource();

            listadoEjemplares.LbClave.Text = "Código";
            listadoEjemplares.Text = "Datos de un ejemplar";

            listadoEjemplares.BnDatos.BindingSource = datos;
            listadoEjemplares.BnDatos.BindingSource.DataSource = ejemplares;
            Ejemplar ej = (Ejemplar)listadoEjemplares.BnDatos.BindingSource.Current;
            listadoEjemplares.TbClave.Text = ej.Codigo;
            listadoEjemplares.TbClave.ReadOnly = true;
            controlEj.LbNombre.Text = "Estado";
            controlEj.TbNombre.ReadOnly = true;
            controlEj.TbNombre.Text = ej.Estado.ToString();

            listadoEjemplares.PsItem.TextChanged += (se, eve) => PonerDatosEjemplar(listadoEjemplares);

            listadoEjemplares.Controls.Add(controlEj);

            listadoEjemplares.ShowDialog();
            

        }

        private void PonerDatosEjemplar(FormNavig listadoEjemplares)
        {
            if (listadoEjemplares.BnDatos.BindingSource != null)
            {
                Ejemplar e = (Ejemplar)listadoEjemplares.BnDatos.BindingSource.Current;
                CtrlDatosUsu control = (CtrlDatosUsu)listadoEjemplares.Controls["CtrlAltaUsu"];
                listadoEjemplares.TbClave.Text = e.Codigo;
                control.TbNombre.Text = e.Estado.ToString();
            }
        }
    }
}
