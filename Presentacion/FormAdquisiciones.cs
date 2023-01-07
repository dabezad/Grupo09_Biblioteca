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
            this.lnB = lnAdq;
            this.pers = pers;
            this.Text = pers.Nombre + " - Gestión de biblioteca - Adquisiciones";

            this.Aniadir_tsmis();
            this.tsmiPrestamos.Enabled = false;
            InitializeComponent();
        }

        private void Aniadir_tsmis()
        {
            ToolStripMenuItem tsmiAltaLib = new ToolStripMenuItem("Alta");
            tsmiAltaLib.Click += tsmiAltaLib_Click;
            ToolStripMenuItem tsmiBajaLib = new ToolStripMenuItem("Baja");
            tsmiBajaLib.Click += tsmiBajaLib_Click;
            ToolStripMenuItem tsmiAltaEj = new ToolStripMenuItem("Alta");
            tsmiAltaEj.Click += tsmiAltaEj_Click;
            ToolStripMenuItem tsmiBajaEj = new ToolStripMenuItem("Baja");
            tsmiBajaEj.Click += tsmiBajaEj_Click;
            ToolStripMenuItem tsmiBusqLib = new ToolStripMenuItem("Búsqueda");
            tsmiBusqLib.Click += TsmiBusqLib_Click;
            ToolStripMenuItem tsmiBusqEj = new ToolStripMenuItem("Búsqueda");
            tsmiBusqEj.Click += TsmiBusqEj_Click;
            ToolStripMenuItem tsmiEjDisp = new ToolStripMenuItem("Ejemplares disponibles");
            tsmiEjDisp.Click += TsmiEjDisp_Click;
            ToolStripMenuItem tsmiListadoLib = new ToolStripMenuItem("Listado");
            tsmiListadoLib.Click += TsmiListadoLib_Click;
            ToolStripMenuItem tsmiListadoEj = new ToolStripMenuItem("Listado");
            tsmiListadoEj.Click += TsmiListadoEj_Click;
            ToolStripMenuItem tsmiLibMasLeido = new ToolStripMenuItem("Libro más leído");
            tsmiLibMasLeido.Click += TsmiLibMasLeido_Click;
            ToolStripMenuItem tsmiRecorrido = new ToolStripMenuItem("Recorrido uno a uno");
            tsmiRecorrido.Click += TsmiRecorrido_Click;


            this.tsmiLibros.DropDownItems.Add(tsmiAltaLib);
            this.tsmiLibros.DropDownItems.Add(tsmiBajaLib);
            this.tsmiLibros.DropDownItems.Add(tsmiBusqLib);
            this.tsmiLibros.DropDownItems.Add(tsmiListadoLib);
            this.tsmiLibros.DropDownItems.Add(tsmiLibMasLeido);

            
            this.tsmiEjemplares.DropDownItems.Add(tsmiAltaEj);
            this.tsmiEjemplares.DropDownItems.Add(tsmiBajaEj);
            this.tsmiEjemplares.DropDownItems.Add(tsmiBusqEj);
            this.tsmiEjemplares.DropDownItems.Add(tsmiListadoEj);
            this.tsmiEjemplares.DropDownItems.Add(tsmiEjDisp);

            ToolStripMenuItem subListado = this.tsmiLibros.DropDownItems[3] as ToolStripMenuItem;
            subListado.DropDownItems.Add(tsmiRecorrido);

        }

        private void TsmiRecorrido_Click(object sender, EventArgs e)
        {
            List<Libro> libros = lnAdq.ListarLibros();
            if (libros.Count > 0)
            {
                FormNavig fRecorrido = new FormNavig();
                CtrlDatosLibRecorrido control = new CtrlDatosLibRecorrido(100, 40);
                BindingSource datos = new BindingSource();

                fRecorrido.LbClave.Text = "ISBN";
                fRecorrido.Text = "Datos de un libro";

                fRecorrido.BnDatos.BindingSource = datos;
                fRecorrido.BnDatos.BindingSource.DataSource = libros;
                Libro l = (Libro) fRecorrido.BnDatos.BindingSource.Current;
                fRecorrido.TbClave.Text = l.Isbn;
                control.TbTitulo.Text = l.Titulo;
                control.TbAutor.Text = l.Autor;
                control.TbEditorial.Text = l.Editorial;
                control.TbNumEjs.Text = lnAdq.ListarEjemplares(l.Isbn).Count.ToString();

                fRecorrido.BtPrimero.Click += delegate (object s, EventArgs ev) {
                    fRecorrido.BnDatos.BindingSource.MoveFirst();
                    PonerDatos(fRecorrido);
                };
                fRecorrido.BtAnterior.Click += delegate (object s, EventArgs ev) {
                    fRecorrido.BnDatos.BindingSource.MovePrevious();
                    PonerDatos(fRecorrido);
                }; 
                fRecorrido.BtSiguiente.Click += delegate (object s, EventArgs ev) {
                    fRecorrido.BnDatos.BindingSource.MoveNext();
                    PonerDatos(fRecorrido);
                }; 
                fRecorrido.BtUltimo.Click += delegate (object s, EventArgs ev) {
                    fRecorrido.BnDatos.BindingSource.MoveLast();
                    PonerDatos(fRecorrido);
                }; 

                fRecorrido.Controls.Add(control);
                fRecorrido.Show();
            } else
            {
                MessageBox.Show("Actualmente no hay ningún libro registrado en el sistema", "Datos de un libro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void PonerDatos(FormNavig fRecorrido)
        {
            Libro l = (Libro)fRecorrido.BnDatos.BindingSource.Current;
            CtrlDatosLibRecorrido control = (CtrlDatosLibRecorrido)fRecorrido.Controls["CtrlDatosLibRecorrido"];
            fRecorrido.TbClave.Text = l.Isbn;
            control.TbTitulo.Text = l.Titulo;
            control.TbAutor.Text = l.Autor;
            control.TbEditorial.Text = l.Editorial;
            control.TbNumEjs.Text = lnAdq.ListarEjemplares(l.Isbn).Count.ToString();
        }

        private void TsmiLibMasLeido_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void TsmiListadoEj_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void TsmiListadoLib_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void TsmiEjDisp_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void TsmiBusqEj_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void TsmiBusqLib_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void tsmiBajaEj_Click(object sender, EventArgs e)
        {
            FormClave formCodEj = new FormClave();
            formCodEj.Text = "Introducir codigo";
            formCodEj.LbClave.Text = "Código";
            DialogResult d = formCodEj.ShowDialog();
            if (d == DialogResult.Cancel)
            {
                formCodEj.Close();
            }
            else
            {
                string cod = formCodEj.TbClave.Text;
                if (cod != "")
                {
                    Ejemplar ej = lnAdq.BuscarEjemplar(cod);
                    if (ej != null)
                    {
                        if (ej.Estado == EstadoEjemplarEnum.Prestado)
                        {
                            DialogResult res = MessageBox.Show("¿Quieres introducir otro?", "El ejemplar introducido está actualmente prestado.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (res == DialogResult.Yes)
                            {
                                tsmiBajaEj_Click(sender, e);
                            }
                        } else
                        {
                            MostrarFormBajaEj(ej);
                        }
                        
                    } 
                    else
                    {
                        DialogResult res = MessageBox.Show("¿Quieres introducir otro?", "No existe ningún ejemplar con ese código", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (res == DialogResult.Yes)
                        {
                            tsmiBajaEj_Click(sender, e);
                        }
                    }
                }
            }
            formCodEj.Dispose();
        }

        private void MostrarFormBajaEj(Ejemplar e)
        {
            CtrlDatosEjemplar control = new CtrlDatosEjemplar(100, 100);
            FormDatos formBajaEj = new FormDatos();
            formBajaEj.Text = "Baja de un ejemplar";
            formBajaEj.LbClave.Text = "Código";
            formBajaEj.BtAceptar.Text = "Dar de baja";
            formBajaEj.TbClave.Text = e.Codigo;
            control.TbCodigo.Text = e.Libro.Isbn;
            control.TbCodigo.ReadOnly = true;
            control.LbCodigo.Text = "Libro\r\n(Isbn)";
            if (e.Estado == EstadoEjemplarEnum.Disponible)
            {
                control.CbEstadoEj.SelectedIndex = 0;
            } else if (e.Estado == EstadoEjemplarEnum.Prestado)
            {
                control.CbEstadoEj.SelectedIndex = 1;
  
            }
            control.CbEstadoEj.Enabled = false;
            formBajaEj.Controls.Add(control);

            DialogResult dBaja = formBajaEj.ShowDialog();
            if (dBaja == DialogResult.Cancel)
            {
                formBajaEj.Close();
            }
            else if (dBaja == DialogResult.OK)
            {
                DialogResult dConfirm = MessageBox.Show("¿Está seguro que desea dar de baja al ejemplar?\r\nSe borrará del sistema toda la información relacionada" +
                    " con sus préstamos.", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dConfirm == DialogResult.OK)
                {
                    if (lnAdq.BajaEjemplar(e.Codigo))
                    {
                        MessageBox.Show("El ejemplar se ha dado de baja correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No se puede dar de baja al ejemplar porque actualmente está prestado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            formBajaEj.Dispose();
        }

        private void MostrarFormBajaLib(Libro l)
        {
            CtrlDatosLib control = new CtrlDatosLib(100, 100);
            FormDatos formBajaLib = new FormDatos();
            formBajaLib.Text = "Baja de un libro";
            formBajaLib.LbClave.Text = "ISBN";
            formBajaLib.BtAceptar.Text = "Dar de baja";
            formBajaLib.TbClave.Text = l.Isbn;
            control.BtAniadirEj.Hide();
            control.TbAutor.Text = l.Autor;
            control.TbAutor.ReadOnly = true;
            control.TbEditorial.Text = l.Editorial;
            control.TbEditorial.ReadOnly = true;
            control.TbTitulo.Text = l.Titulo;
            control.TbTitulo.ReadOnly = true;
            formBajaLib.Controls.Add(control);

            DialogResult dBaja = formBajaLib.ShowDialog();
            if (dBaja == DialogResult.Cancel)
            {
                formBajaLib.Close();
            }
            else if (dBaja == DialogResult.OK)
            {
                DialogResult dConfirm = MessageBox.Show("¿Está seguro que desea dar de baja al libro?\r\nSe borrará del sistema toda la información relacionada" +
                    " con sus préstamos y ejemplares.", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dConfirm == DialogResult.OK)
                {
                    if (lnAdq.BajaLibro(l.Isbn))
                    {
                        MessageBox.Show("El libro se ha dado de baja correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("El libro no se ha podido dar de baja porque tiene algún ejemplar prestado actualmente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            formBajaLib.Dispose();
        }

        private void tsmiBajaLib_Click(object sender, EventArgs e)
        {
            FormClave formISBN = new FormClave();
            formISBN.Text = "Introducir ISBN";
            formISBN.LbClave.Text = "ISBN";
            DialogResult d = formISBN.ShowDialog();
            if (d == DialogResult.Cancel)
            {
                formISBN.Close();
            }
            else
            {
                string isbn = formISBN.TbClave.Text;
                if (isbn != "")
                {
                    Libro l = lnAdq.BuscarLibro(isbn);
                    if (l != null)
                    {
                        MostrarFormBajaLib(l);
                    }
                    else
                    {
                        DialogResult res = MessageBox.Show("¿Quieres introducir otro?", "No existe ningún libro con ese ISBN", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (res == DialogResult.Yes)
                        {
                            tsmiBajaLib_Click(sender, e);
                        }
                    }
                }
            }
            formISBN.Dispose();
        }

        private void tsmiAltaLib_Click(object sender, EventArgs e)
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
                    Libro l = new Libro(isbn, titulo, control.TbAutor.Text, control.TbEditorial.Text, this.pers);
                    if (this.lnAdq.AltaLibro(l)) //Modificar por el usuario que lo da de alta CUANDO SE IMPLEMENTE
                    {
                        DialogResult dRes = MessageBox.Show("Se ha dado de alta al libro correctamente. \r\n ¿Deseas añadirle ejemplares?", "Alta de un libro", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (dRes == DialogResult.Yes)
                        {
                            this.AniadirEjsDsdLibro(l);
                        }
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

        private void AniadirEjsDsdLibro(Libro l)
        {
            CtrlDatosLib control = new CtrlDatosLib(100, 100);
            FormDatos formAltaLib = new FormDatos();
            formAltaLib.Text = "Alta de un libro";
            formAltaLib.LbClave.Text = "ISBN";
            formAltaLib.BtAceptar.Hide();
            formAltaLib.TbClave.Text = l.Isbn;
            formAltaLib.BtCancelar.Text = "Salir";

            control.BtAniadirEj.Enabled = true;
            control.TbAutor.Text = l.Autor;
            control.TbAutor.ReadOnly = true;
            control.TbEditorial.Text = l.Editorial;
            control.TbEditorial.ReadOnly = true;
            control.TbTitulo.Text = l.Titulo;
            control.TbTitulo.ReadOnly = true;
            formAltaLib.Controls.Add(control);
            DialogResult d = formAltaLib.ShowDialog();
            if (d == DialogResult.Cancel)
            {
                formAltaLib.Close();
            } else
            {
                AniadirEjsDsdLibro(l);
            }
            formAltaLib.Dispose();
        }

        private void tsmiAltaEj_Click(object sender, EventArgs e)
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
            formAltaEj.Text = "Alta de un ejemplar";
            formAltaEj.LbClave.Text = "ISBN";
            formAltaEj.BtAceptar.Text = "Dar alta";
            formAltaEj.TbClave.Text = isbn;
            control.CbEstadoEj.SelectedIndex = 0;
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
                        DialogResult d = MessageBox.Show("¿Desea introducir otro?", "Ya existe un ejemplar en el sistema con ese codigo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
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
