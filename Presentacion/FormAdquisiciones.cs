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
    public partial class FormAdquisiciones : FormGestionBiblioteca
    {
        private LNAdquisiciones lnAdq;
        private PersonalAdquisiciones pers;
        public FormAdquisiciones()
        {
            lnAdq = new LNAdquisiciones();
            InitializeComponent();
        }

        public FormAdquisiciones(PersonalAdquisiciones pers) : base(pers)
        {
            lnAdq = new LNAdquisiciones();
            this.pers = pers;
            this.Text = pers.Nombre + " - Gestión de biblioteca - Adquisiciones"; 
            InitializeComponent();
        }

        protected override void tsmiAltaLib_Click(object sender, EventArgs e)
        {
            FormClave formISBN = new FormClave();
            formISBN.Text = "Introducir ISBN";
            formISBN.LbClave.Text = "ISBN";
            DialogResult d = formISBN.ShowDialog();
            if (d == DialogResult.Cancel)
            {
                formISBN.Close();
            }
            else if (d == DialogResult.OK)
            {
                string isbn = formISBN.TbClave.Text;
                if (isbn != "")
                {
                    if (lnAdq.BuscarLibro(isbn) == null)
                    {
                        MostrarFormAltaLib(isbn);
                    }
                    else
                    {
                        DialogResult res = MessageBox.Show("¿Quieres introducir otro?", "Ya existe un libro con ese ISBN", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (res == DialogResult.Yes)
                        {
                            tsmiAltaLib_Click(sender, e);
                        }
                    }
                }
            }
            formISBN.Dispose();
        }

        private void MostrarFormAltaLib(string isbn)
        {
            CtrlDatosLib control = new CtrlDatosLib(100, 100);
            FormDatos formAltaLib = new FormDatos();
            formAltaLib.Text = "Alta de un libro";
            formAltaLib.LbClave.Text = "ISBN";
            formAltaLib.BtAceptar.Text = "Dar alta";
            formAltaLib.TbClave.Text = isbn;
            formAltaLib.Controls.Add(control);

            DialogResult dAlta = formAltaLib.ShowDialog();
            if (dAlta == DialogResult.Cancel)
            {
                formAltaLib.Close();
            }
            else if (dAlta == DialogResult.OK)
            {
                string titulo = control.TbTitulo.Text;
                if (titulo != "")
                {
                    if (this.lnAdq.AltaLibro(new Libro(isbn, titulo, control.TbAutor.Text, control.TbEditorial.Text, this.pers))) //Modificar por el usuario que lo da de alta CUANDO SE IMPLEMENTE
                    {
                        MessageBox.Show("Se ha dado de alta al libro correctamente", "Alta de un libro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No se ha podido dar de alta al libro correctamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Debes introducir un titulo para el libro", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    MostrarFormAltaLib(isbn);
                }


            }
            formAltaLib.Dispose();
        }

        protected override void tsmiAltaEj_Click(object sender, EventArgs e)
        {
            FormClave formISBN = new FormClave();
            formISBN.Text = "Introducir ISBN";
            formISBN.LbClave.Text = "ISBN";
            DialogResult d = formISBN.ShowDialog();
            if (d == DialogResult.Cancel)
            {
                formISBN.Close();
            }
            else if (d == DialogResult.OK)
            {
                string isbn = formISBN.TbClave.Text;
                if (isbn != "")
                {
                    if (lnAdq.BuscarLibro(isbn) != null)
                    {
                        MostrarFormAltaEj(isbn);
                    }
                    else
                    {
                        DialogResult res = MessageBox.Show("¿Quieres introducir otro?", "No existe ningún libro con ese ISBN", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (res == DialogResult.Yes)
                        {
                            tsmiAltaEj_Click(sender, e);
                        }
                    }
                }
            }
            formISBN.Dispose();
        }

        public void MostrarFormAltaEj(string isbn)
        {
            CtrlDatosEjemplar control = new CtrlDatosEjemplar(100, 100);
            FormDatos formAltaEj = new FormDatos();
            formAltaEj.Text = "Alta de un Ejemplar";
            formAltaEj.LbClave.Text = "ISBN";
            formAltaEj.BtAceptar.Text = "Dar alta";
            formAltaEj.TbClave.Text = isbn;
            formAltaEj.Controls.Add(control);

            DialogResult dAlta = formAltaEj.ShowDialog();
            if (dAlta == DialogResult.Cancel)
            {
                formAltaEj.Close();
            }
            else if (dAlta == DialogResult.OK)
            {
                Libro l = lnAdq.BuscarLibro(isbn);
                if (l == null)
                {
                    l = new Libro(isbn, this.pers);
                }
                string codigo = control.TbCodigo.Text;
                if (codigo != "")
                {
                    EstadoEjemplarEnum estado;
                    if (control.CbEstadoEj.SelectedItem as string == "Disponible")
                    {
                        estado = EstadoEjemplarEnum.Disponible;
                    } else
                    {
                        estado = EstadoEjemplarEnum.Prestado;
                    }
                    if (lnAdq.BuscarEjemplar(codigo) != null)
                    {
                        DialogResult d = MessageBox.Show("¿Desea introducir otro?", "Ya existe un ejemplar del libro con ese codigo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                        if (d == DialogResult.OK)
                        {
                            MostrarFormAltaEj(isbn);
                        }
                    } else
                    {
                        if (lnAdq.AltaEjemplar(new Ejemplar(codigo, estado, l, this.pers))) //Modificar por el usuario que lo da de alta CUANDO SE IMPLEMENTE
                        {
                            MessageBox.Show("Se ha dado de alta al ejemplar correctamente", "Alta de un ejemplar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("No se ha podido dar de alta al ejemplar correctamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    
                }
                else
                {
                    MessageBox.Show("Debes introducir un codigo para el ejemplar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    MostrarFormAltaEj(isbn);
                }


            }
            formAltaEj.Dispose();
        }

        
    }
}
