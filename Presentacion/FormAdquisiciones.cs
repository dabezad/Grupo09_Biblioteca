using LogicaNegocio;
using ModeloDominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Channels;
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

        /// <summary>
        /// Añade al formulario los elementos que lo forman
        /// </summary>
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
            ToolStripMenuItem tsmiEjDisp = new ToolStripMenuItem("Ejemplares disponibles de un libro");
            tsmiEjDisp.Click += TsmiEjDisp_Click;
            ToolStripMenuItem tsmiListadoLib = new ToolStripMenuItem("Listado");
            tsmiListadoLib.Click += TsmiListadoLib_Click;
            ToolStripMenuItem tsmiListadoEj = new ToolStripMenuItem("Listado");
            tsmiListadoEj.Click += TsmiListadoEj_Click;
            ToolStripMenuItem tsmiLibMasLeido = new ToolStripMenuItem("Libro más leído");
            tsmiLibMasLeido.Click += TsmiLibMasLeido_Click;
            ToolStripMenuItem tsmiRecorrido = new ToolStripMenuItem("Recorrido uno a uno");
            tsmiRecorrido.Click += TsmiRecorrido_Click;
            ToolStripMenuItem tsmiBusqLibIsbn = new ToolStripMenuItem("Búsqueda por ISBN");
            tsmiBusqLibIsbn.Click += TsmiBusqLibIsbn_Click;
            ToolStripMenuItem tsmiBusqEjCod = new ToolStripMenuItem("Búsqueda por código");
            tsmiBusqEjCod.Click += TsmiBusqEjCod_Click;

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

            ToolStripMenuItem subListadoLib = this.tsmiLibros.DropDownItems[2] as ToolStripMenuItem;
            subListadoLib.DropDownItems.Add(tsmiBusqLibIsbn);

            ToolStripMenuItem subListadoEj = this.tsmiEjemplares.DropDownItems[2] as ToolStripMenuItem;
            subListadoEj.DropDownItems.Add(tsmiBusqEjCod);

        }

        /// <summary>
        /// Busca el ejemplar por código
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TsmiBusqEjCod_Click(object sender, EventArgs e)
        {
            List<string> codigos = lnAdq.MostrarEjemplares().Select(x=>x.Codigo).ToList();
            FormBusqPorClave FBusq = new FormBusqPorClave();
            CtrlDatosEjBusq control = new CtrlDatosEjBusq(100, 60);

            FBusq.Text = "Datos de un ejemplar";
            FBusq.LbClave.Text = "Código";
            FBusq.BsClave.DataSource = codigos;
            FBusq.CbClave.SelectedIndex = -1;
            FBusq.CbClave.SelectedIndexChanged += delegate (object s, EventArgs ev)
            {
                if (FBusq.CbClave.SelectedValue != null)
                {
                    string cod = (string)FBusq.CbClave.SelectedValue;
                    Ejemplar ej = lnAdq.BuscarEjemplar(cod);
                    control.TbIsbn.Text = ej.Libro.Isbn;
                    if (ej.Estado == EstadoEjemplarEnum.Disponible)
                    {
                        control.CbEstadoEj.SelectedIndex = 0;
                    }
                    else
                    {
                        control.CbEstadoEj.SelectedIndex = 1;
                    }
                }
            };
            FBusq.Controls.Add(control);
            DialogResult d = FBusq.ShowDialog();
            if (d == DialogResult.Cancel)
            {
                FBusq.Close();
            } else if (d == DialogResult.Yes)
            {
                if (FBusq.CbClave.SelectedValue != null)
                {
                    Ejemplar ej = lnAdq.BuscarEjemplar(FBusq.CbClave.SelectedValue as string);
                    MostrarFormBusqLib(ej.Libro);
                }
                TsmiBusqEjCod_Click(sender, e);
            }
            FBusq.Dispose();
           
        }

        /// <summary>
        /// Busca libro por isbn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TsmiBusqLibIsbn_Click(object sender, EventArgs e)
        {
            List<string> isbns = lnAdq.MostrarLibros().Select(x => x.Isbn).ToList();
            FormBusqPorClave FBusq = new FormBusqPorClave();
            CtrlDatosLib control = new CtrlDatosLib(100, 55);
            control.TbAutor.ReadOnly = true;
            control.TbEditorial.ReadOnly = true;
            control.TbTitulo.ReadOnly = true;
            control.BtAniadirEj.Text = "Ver ejemplares";
            control.BtAniadirEj.Enabled = true;
            FBusq.Text = "Datos de un libro";
            FBusq.LbClave.Text = "ISBN";
            FBusq.BsClave.DataSource = isbns;
            FBusq.CbClave.SelectedIndex = -1;
            FBusq.CbClave.SelectedIndexChanged += delegate (object s, EventArgs ev)
            {
                string isbn = (string)FBusq.CbClave.SelectedValue;
                if (isbn != null)
                {
                    Libro l = lnAdq.BuscarLibro(isbn);
                    control.TbTitulo.Text = l.Titulo;
                    control.TbAutor.Text = l.Autor;
                    control.TbEditorial.Text = l.Editorial;

                }
            };
            FBusq.Controls.Add(control);
            DialogResult d = FBusq.ShowDialog();
            if (d == DialogResult.OK)
            {
                if (FBusq.CbClave.SelectedValue != null)
                {
                    string isbn = FBusq.CbClave.SelectedValue as string;
                    List<Ejemplar> ejemplares = lnAdq.ListarEjemplares(isbn);
                    if (ejemplares.Count > 0)
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
                    else
                    {
                        MessageBox.Show("El libro no tiene ejemplares actualmente", "Listado de ejemplares de un libro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    TsmiBusqLibIsbn_Click(sender, e);
                }
            } else
            {
                FBusq.Close();
            }
            FBusq.Dispose();
        }

        /// <summary>
        /// Carga el ejemplar actual en el formulario
        /// </summary>
        /// <param name="listadoEjemplares"></param>
        private void PonerDatosEjemplar(FormNavig listadoEjemplares)
        {
            if (Int32.Parse(listadoEjemplares.PsItem.Text) > 0)
            {
                Ejemplar e = (Ejemplar)listadoEjemplares.BnDatos.BindingSource.Current;
                CtrlDatosUsu control = (CtrlDatosUsu)listadoEjemplares.Controls["CtrlAltaUsu"];
                listadoEjemplares.TbClave.Text = e.Codigo;
                control.TbNombre.Text = e.Estado.ToString();
            }
            
        }

        /// <summary>
        /// Reccorre todos los libros uno a uno
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TsmiRecorrido_Click(object sender, EventArgs e)
        {
            List<Libro> libros = lnAdq.MostrarLibros();
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

                fRecorrido.PsItem.TextChanged += (s,ev) => PonerDatos(fRecorrido);
                

                fRecorrido.Controls.Add(control);
                fRecorrido.ShowDialog();
            } else
            {
                MessageBox.Show("Actualmente no hay ningún libro registrado en el sistema", "Datos de un libro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        /// <summary>
        /// Carga los datos del libro en el formulario
        /// </summary>
        /// <param name="fRecorrido"></param>
        private void PonerDatos(FormNavig fRecorrido)
        {
            if (Int32.Parse(fRecorrido.PsItem.Text) > 0)
            {
                Libro l = (Libro)fRecorrido.BnDatos.BindingSource.Current;
                CtrlDatosLibRecorrido control = (CtrlDatosLibRecorrido)fRecorrido.Controls["CtrlDatosLibRecorrido"];
                fRecorrido.TbClave.Text = l.Isbn;
                control.TbTitulo.Text = l.Titulo;
                control.TbAutor.Text = l.Autor;
                control.TbEditorial.Text = l.Editorial;
                control.TbNumEjs.Text = lnAdq.ListarEjemplares(l.Isbn).Count.ToString();
            }
            
        }

        /// <summary>
        /// Muestra el libro más leido
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TsmiLibMasLeido_Click(object sender, EventArgs e)
        {
            Libro l=lnAdq.MostrarLibroMasLeido();
            FormDatos frm= new FormDatos();
            CtrlDatosLib control = new CtrlDatosLib(100, 50);
            frm.Text = "Libro más leído";
            frm.LbClave.Text = "ISBN";
            frm.BtAceptar.Text = "Aceptar";
            frm.TbClave.Text = l.Isbn;
            control.TbTitulo.Text = l.Titulo;
            control.TbTitulo.ReadOnly=true;
            control.TbAutor.Text = l.Autor;
            control.TbAutor.ReadOnly = true;
            control.TbEditorial.Text = l.Editorial;
            control.TbEditorial.ReadOnly = true;
            control.BtAniadirEj.Hide();

            Label lbVecesLeidas = new Label();
            TextBox tbVecesLeidas = new TextBox();

            lbVecesLeidas.Text = "Veces leídas";
            lbVecesLeidas.Location = new Point(45, 170);
            lbVecesLeidas.Width -= 25;
            tbVecesLeidas.Text = lnAdq.MostrarVecesLibroMasLeido().ToString();
            tbVecesLeidas.ReadOnly = true;
            tbVecesLeidas.Location = new Point(117, 167);
            control.Controls.Add(lbVecesLeidas);
            control.Controls.Add(tbVecesLeidas);

            frm.Controls.Add(control);
            DialogResult dLibLeido = frm.ShowDialog();
            if (dLibLeido == DialogResult.Cancel)
            {
                frm.Close();
            }
            frm.Dispose();            
        }

        /// <summary>
        /// Muestra un listado con todos los ejemplares o un mensaje indicando que no hay ningún ejemplar en el sistema
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TsmiListadoEj_Click(object sender, EventArgs e)
        {
            List<Ejemplar> ejemplares = lnAdq.MostrarEjemplares();
            if (ejemplares.Count() > 0)
            {
                FormListadoEjs listadoEjs = new FormListadoEjs(ejemplares);
                listadoEjs.ShowDialog();
            } else
            {
                MessageBox.Show("No existen ejemplares en el sistema actualmente", "Listado de ejemplares", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        /// <summary>
        /// Muestra un listado con todos los libros
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TsmiListadoLib_Click(object sender, EventArgs e)
        {
            FormListadoLib fListadoLib = new FormListadoLib(lnAdq);
            DialogResult dr = fListadoLib.ShowDialog();
            if (dr == DialogResult.Cancel)
            {
                fListadoLib.Close();
            }
            fListadoLib.Dispose();
        }
        /// <summary>
        /// Muestra un formulario que pide los datos del libro a buscar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TsmiEjDisp_Click(object sender, EventArgs e)
        {
            FormClave formIsbn = new FormClave();
            formIsbn.Text = "Introducir ISBN";
            formIsbn.LbClave.Text = "ISBN";
            DialogResult d = formIsbn.ShowDialog();
            if (d == DialogResult.Cancel)
            {
                formIsbn.Close();
            }
            else
            {
                string isbn = formIsbn.TbClave.Text;
                if (isbn != "")
                {
                    Libro l = lnAdq.BuscarLibro(isbn);
                    if (l != null)
                    {
                        MostrarEjemplaresDisponibles(l);
                    }
                    else
                    {
                        DialogResult res = MessageBox.Show("¿Quieres introducir otro?", "No existe ningún libro con ese ISBN", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (res == DialogResult.Yes)
                        {
                            TsmiEjDisp_Click(sender, e);
                        }
                    }
                }
            }
            formIsbn.Dispose();
        }

        /// <summary>
        /// Muestra todos los ejemplares disponibles de un libro
        /// </summary>
        /// <param name="l">Libro no nulo</param>
        private void MostrarEjemplaresDisponibles(Libro l)
        {
            List<Ejemplar> ejemplares = lnAdq.EjemplaresDisponibles(l.Isbn);
            if (ejemplares.Count > 0)
            {
                FormNavig fListadoEjs = new FormNavig();
                CtrlDatosEjBusq control = new CtrlDatosEjBusq(100, -2);
                BindingSource datos = new BindingSource();

                fListadoEjs.LbClave.Text = "Código";
                fListadoEjs.Text = "Ver ejemplares disponibles";

                fListadoEjs.BnDatos.BindingSource = datos;
                fListadoEjs.BnDatos.BindingSource.DataSource = ejemplares;
                Ejemplar ej = (Ejemplar)fListadoEjs.BnDatos.BindingSource.Current;
                fListadoEjs.TbClave.Text = ej.Codigo;
                control.TbIsbn.Text = ej.Libro.Isbn;
                control.BtVerLibro.Hide();
                if (ej.Estado == EstadoEjemplarEnum.Prestado)
                {
                    control.CbEstadoEj.SelectedIndex = 1;
                } else
                {
                    control.CbEstadoEj.SelectedIndex = 0;
                }

                fListadoEjs.PsItem.TextChanged += (s, ev) => PonerDatosEjemplares(fListadoEjs);

                fListadoEjs.Controls.Add(control);
                DialogResult d = fListadoEjs.ShowDialog();
                if (d == DialogResult.Cancel)
                {
                    fListadoEjs.Close();
                }
                fListadoEjs.Dispose();

            } else
            {
                List<Ejemplar> todosEjemplares = lnAdq.ListarEjemplares(l.Isbn);
                List<Prestamo> prestamos = new List<Prestamo>();
                foreach (Ejemplar ej in todosEjemplares)
                {
                    Prestamo p = lnB.ObtenerPrestamoDeEjemplar(ej);
                    if (!prestamos.Contains(p)) {
                        prestamos.Add(p);
                    }
                }

                DateTime fProxima = prestamos.Max((p) => p.FFinPrestamo);
                MessageBox.Show("El libro no tiene ejemplares disponibles actualmente.\r\nLa fecha más próxima en la" +
                    " que se espera que alguno de sus ejemplares sea devuelto es : " + fProxima.ToString(), "Ver ejemplares disponibles", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Carga los datos de los ejemplares en el formulario
        /// </summary>
        /// <param name="fListadoEjs"></param>
        private void PonerDatosEjemplares(FormNavig fListadoEjs)
        {
            if (Int32.Parse(fListadoEjs.PsItem.Text) > 0)
            {
                Ejemplar ej = (Ejemplar)fListadoEjs.BnDatos.BindingSource.Current;
                fListadoEjs.TbClave.Text = ej.Codigo;
                CtrlDatosEjBusq control = (CtrlDatosEjBusq)fListadoEjs.Controls["CtrlDatosEjBusq"];
                control.TbIsbn.Text = ej.Libro.Isbn;
                if (ej.Estado == EstadoEjemplarEnum.Prestado)
                {
                    control.CbEstadoEj.SelectedIndex = 1;
                }
                else
                {
                    control.CbEstadoEj.SelectedIndex = 0;
                }
            }
            
        }

        /// <summary>
        /// Busca un ejemplar dado un codigo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TsmiBusqEj_Click(object sender, EventArgs e)
        {
            FormClave formCodigo = new FormClave();
            formCodigo.Text = "Introducir código";
            formCodigo.LbClave.Text = "Código";
            DialogResult d = formCodigo.ShowDialog();
            if (d == DialogResult.Cancel)
            {
                formCodigo.Close();
            }
            else
            {
                string cod = formCodigo.TbClave.Text;
                if (cod != "")
                {
                    Ejemplar ej = lnAdq.BuscarEjemplar(cod);
                    if (ej != null)
                    {
                        MostrarFormBusqEj(ej);
                    }
                    else
                    {
                        DialogResult res = MessageBox.Show("¿Quieres introducir otro?", "No existe ningún ejemplar con ese código", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (res == DialogResult.Yes)
                        {
                            TsmiBusqEj_Click(sender, e);
                        }
                    }
                }
            }
            formCodigo.Dispose();
        }

        /// <summary>
        /// Muestra el formulario de busqueda de ejemplar
        /// </summary>
        /// <param name="ej"></param>
        private void MostrarFormBusqEj(Ejemplar ej)
        {
            CtrlDatosEjBusq control = new CtrlDatosEjBusq(100, 65);
            FormDatos formBusqUsu = new FormDatos();
            formBusqUsu.Text = "Búsqueda de un ejemplar";
            formBusqUsu.LbClave.Text = "Código";
            formBusqUsu.BtAceptar.Text = "Ver personal alta";
            formBusqUsu.TbClave.Text = ej.Codigo;
            formBusqUsu.BtCancelar.Text = "Salir";

            control.TbIsbn.Text = ej.Libro.Isbn;
            if (ej.Estado == EstadoEjemplarEnum.Prestado)
            {
                control.CbEstadoEj.SelectedIndex = 1;
            } else
            {
                control.CbEstadoEj.SelectedIndex = 0;
            }


            formBusqUsu.Controls.Add(control);

            DialogResult dAlta = formBusqUsu.ShowDialog();
            if (dAlta == DialogResult.Cancel)
            {
                formBusqUsu.Close();
            }
            else if (dAlta == DialogResult.OK)
            {
                MostrarFormPersAlta(ej.PersonalBAlta);
                MostrarFormBusqEj(ej);
            } else if (dAlta == DialogResult.Yes)
            {
                MostrarFormBusqLib(ej.Libro);
                MostrarFormBusqEj(ej);
            }
            formBusqUsu.Dispose();
        }

        /// <summary>
        /// Busca un libro por isbn y lo muestra
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TsmiBusqLib_Click(object sender, EventArgs e)
        {
            FormClave formIsbn = new FormClave();
            formIsbn.Text = "Introducir ISBN";
            formIsbn.LbClave.Text = "ISBN";
            DialogResult d = formIsbn.ShowDialog();
            if (d == DialogResult.Cancel)
            {
                formIsbn.Close();
            }
            else
            {
                string isbn = formIsbn.TbClave.Text;
                if (isbn != "")
                {
                    Libro l = lnAdq.BuscarLibro(isbn);
                    if (l != null)
                    {
                        MostrarFormBusqLib(l);
                    }
                    else
                    {
                        DialogResult res = MessageBox.Show("¿Quieres introducir otro?", "No existe ningún libro con ese ISBN", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (res == DialogResult.Yes)
                        {
                            TsmiBusqLib_Click(sender, e);
                        }
                    }
                }
            }
            formIsbn.Dispose();
        }

        /// <summary>
        /// Muestra el formulario de busqueda de libro
        /// </summary>
        /// <param name="l"></param>
        private void MostrarFormBusqLib(Libro l)
        {
            CtrlDatosLib control = new CtrlDatosLib(100, 50);
            FormDatos formBusqUsu = new FormDatos();
            formBusqUsu.Text = "Búsqueda de un libro";
            formBusqUsu.LbClave.Text = "ISBN";
            formBusqUsu.BtAceptar.Text = "Ver personal alta";
            formBusqUsu.TbClave.Text = l.Isbn;
            formBusqUsu.BtCancelar.Text = "Salir";

            control.BtAniadirEj.Hide();
            control.TbAutor.Text = l.Autor;
            control.TbAutor.ReadOnly = true;
            control.LbAutor.Left += 10;
            control.TbEditorial.Text = l.Editorial;
            control.TbEditorial.ReadOnly = true;
            control.TbTitulo.Text = l.Titulo;
            control.TbTitulo.ReadOnly = true;
            control.LbTitulo.Left += 10;

            formBusqUsu.Controls.Add(control);

            DialogResult dAlta = formBusqUsu.ShowDialog();
            if (dAlta == DialogResult.Cancel)
            {
                formBusqUsu.Close();
            }
            else if (dAlta == DialogResult.OK)
            {
                MostrarFormPersAlta(l.PersonalBAlta);
                MostrarFormBusqLib(l);
            }
            formBusqUsu.Dispose();
        }

        /// <summary>
        /// Da de baja un ejemplar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Muestra el ejemplar que se va a dar de baja
        /// </summary>
        /// <param name="e"></param>
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

        /// <summary>
        /// Muestra el formulario de baja de libro
        /// </summary>
        /// <param name="l"></param>
        private void MostrarFormBajaLib(Libro l)
        {
            CtrlDatosLib control = new CtrlDatosLib(100, 50);
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

        /// <summary>
        /// Da de baja un libro
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Da de alta un libro
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Muestra el formulario de alta de libro
        /// </summary>
        /// <param name="isbn"></param>
        private void MostrarFormAltaLib(string isbn)
        {
            CtrlDatosLib control = new CtrlDatosLib(100, 50);
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

        /// <summary>
        /// Añade ejemplares desde libro
        /// </summary>
        /// <param name="l"></param>
        private void AniadirEjsDsdLibro(Libro l)
        {
            CtrlDatosLib control = new CtrlDatosLib(100, 50);
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

        /// <summary>
        /// Da de alta un ejemplar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Muestra el formulairo de alta de ejemplares
        /// </summary>
        /// <param name="isbn"></param>
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
