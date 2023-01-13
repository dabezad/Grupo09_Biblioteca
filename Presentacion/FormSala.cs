using LogicaNegocio;
using ModeloDominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FormSala : FormGestionBiblioteca
    {
        private LNSala lnSala;
        private PersonalSala pers;
        public FormSala()
        {
            InitializeComponent();
        }

        public FormSala(PersonalSala pers) : base(pers)
        {
            this.lnSala = new LNSala();
            this.lnB = this.lnSala;
            this.pers = pers;
            this.Text = pers.Nombre + " - Gestión de biblioteca - Sala";

            this.Aniadir_tsmis();
            this.tsmiEjemplares.Enabled = false;
            this.tsmiLibros.Enabled = false;
            InitializeComponent();
        }

        private void Aniadir_tsmis()
        {
            ToolStripMenuItem tsmiAltaPres = new ToolStripMenuItem("Alta");
            tsmiAltaPres.Click += TsmiAltaPres_Click;
            ToolStripMenuItem tsmiBajaPres = new ToolStripMenuItem("Baja");
            tsmiBajaPres.Click += TsmiBajaPres_Click;
            ToolStripMenuItem tsmiBusqPres = new ToolStripMenuItem("Búsqueda");
            tsmiBusqPres.Click += TsmiBusqPres_Click;
            ToolStripMenuItem tsmiListado = new ToolStripMenuItem("Listado");
            tsmiListado.Click += TsmiListado_Click;
            ToolStripMenuItem tsmiPrestLib = new ToolStripMenuItem("Préstamos de libro");
            tsmiPrestLib.Click += TsmiPrestLib_Click;
            ToolStripMenuItem tsmiDevEj = new ToolStripMenuItem("Devolver ejemplar");
            tsmiDevEj.Click += TsmiDevEj_Click;
            ToolStripMenuItem tsmiPrestPasad = new ToolStripMenuItem("Ver préstamos pasados");
            tsmiPrestPasad.Click += TsmiPrestPasad_Click;
            ToolStripMenuItem tsmiEjNoDev = new ToolStripMenuItem("Ver ejemplares no devueltos");
            tsmiEjNoDev.Click += TsmiEjNoDev_Click;
            ToolStripMenuItem tsmiPrestAct = new ToolStripMenuItem("Ver préstamos activos");
            tsmiPrestAct.Click += TsmiPrestAct_Click;

            this.tsmiPrestamos.DropDownItems.Add(tsmiAltaPres);
            this.tsmiPrestamos.DropDownItems.Add(tsmiBajaPres);
            this.tsmiPrestamos.DropDownItems.Add(tsmiBusqPres);
            this.tsmiPrestamos.DropDownItems.Add(tsmiListado);
            this.tsmiPrestamos.DropDownItems.Add(tsmiEjNoDev);
            this.tsmiPrestamos.DropDownItems.Add(tsmiPrestLib);
            this.tsmiPrestamos.DropDownItems.Add(tsmiDevEj);

            ToolStripMenuItem subListado = this.tsmiPrestamos.DropDownItems[3] as ToolStripMenuItem;
            subListado.DropDownItems.Add(tsmiPrestPasad);
            subListado.DropDownItems.Add(tsmiPrestAct);

        }

        private void TsmiDevEj_Click(object sender, EventArgs e)
        {
            FormClave formISBN = new FormClave();
            formISBN.Text = "Introducir código";
            formISBN.LbClave.Text = "Código";
            DialogResult d = formISBN.ShowDialog();
            if (d == DialogResult.Cancel)
            {
                formISBN.Close();
            }
            else if (d == DialogResult.OK)
            {
                string cod = formISBN.TbClave.Text;
                if (cod != "")
                {
                    Ejemplar ej = lnSala.BuscarEjemplar(cod);
                    if (ej != null)
                    {
                        if (ej.Estado == EstadoEjemplarEnum.Prestado)
                        {
                            MostrarFormDevEj(ej);
                        } else
                        {
                            DialogResult res = MessageBox.Show("¿Quieres introducir otro?", "El ejemplar introducido no está actualmente prestado", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (res == DialogResult.Yes)
                            {
                                TsmiDevEj_Click(sender, e);
                            }
                        }
                        
                    }
                    else
                    {
                        DialogResult res = MessageBox.Show("¿Quieres introducir otro?", "No existe ningún ejemplar con ese código", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (res == DialogResult.Yes)
                        {
                            TsmiDevEj_Click(sender, e);
                        }
                    }
                }
            }
            formISBN.Dispose();
        }

        private void MostrarFormDevEj(Ejemplar e)
        {
            Prestamo p = lnSala.ObtenerPrestamoDeEjemplar(e);
            CtrlDatosLib control = new CtrlDatosLib(100, 50);
            FormDatos formDevEj = new FormDatos();
            formDevEj.Text = "Devolución de un ejemplar";
            formDevEj.LbClave.Text = "Código";
            formDevEj.BtAceptar.Text = "Devolver ejemplar";
            formDevEj.TbClave.Text = e.Codigo;

            control.LbTitulo.Text = "Código de préstamo";
            control.LbTitulo.Left -= 60;
            control.TbTitulo.Text = p.Codigo;
            control.TbTitulo.ReadOnly = true;
            control.LbAutor.Text = "Usuario";
            control.TbAutor.Text = p.Usuario.Dni;
            control.TbAutor.ReadOnly = true;
            control.LbEditorial.Text = "Fecha de devolución";
            control.LbEditorial.Left -= 60;
            control.TbEditorial.Text = p.FFinPrestamo.ToString(CultureInfo.GetCultureInfo("es-ES"));
            control.TbEditorial.ReadOnly = true;
            control.TbEditorial.Width += 10;
            control.BtAniadirEj.Hide();
            formDevEj.Controls.Add(control);

            DialogResult dDev = formDevEj.ShowDialog();
            if (dDev == DialogResult.Cancel)
            {
                formDevEj.Close();
            }
            else if (dDev == DialogResult.OK)
            {
                lnSala.DevolverEjemplarPrestado(p, e);
                if (lnSala.BuscarPrestamo(p.Codigo).Estado == EstadoEnum.Finalizado)
                {
                    MessageBox.Show("Se ha devuelto el ejemplar correctamente y el préstamo ha sido finalizado.", "Devolución de un ejemplar", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                } else
                {
                    MessageBox.Show("Se ha devuelto el ejemplar correctamente", "Devolución de un ejemplar", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            formDevEj.Dispose();
        }

        private void TsmiPrestAct_Click(object sender, EventArgs e)
        {
            FormListPrestEnProc fListado = new FormListPrestEnProc(lnSala.ObtenerPrestamosEnProceso());
            fListado.ShowDialog();
        }

        private void TsmiEjNoDev_Click(object sender, EventArgs e)
        {
            List<Ejemplar> ejemplares = lnSala.VerEjemplaresNoDevueltos();
            if (ejemplares.Count > 0)
            {
                FormNavig fEjNoDev = new FormNavig();
                CtrlDatosEjemplarPrestado control = new CtrlDatosEjemplarPrestado(100, 0);

                BindingSource datos = new BindingSource();

                fEjNoDev.LbClave.Text = "Código de ejemplar";
                fEjNoDev.LbClave.Left -= 30;
                fEjNoDev.TbClave.Left += 35;
                fEjNoDev.Text = "Ejemplares no devueltos";

                fEjNoDev.BnDatos.BindingSource = datos;
                fEjNoDev.BnDatos.BindingSource.DataSource = ejemplares;
                fEjNoDev.TbClave.Text = ((Ejemplar)fEjNoDev.BnDatos.BindingSource.Current).Codigo;
                Ejemplar ejCurrent = (Ejemplar)fEjNoDev.BnDatos.BindingSource.Current;
                Prestamo p = lnSala.ObtenerPrestamoDeEjemplar(ejCurrent);
                fEjNoDev.TbClave.Text = ejCurrent.Codigo;
                control.TbCodPres.Text = p.Codigo;
                control.TbFechaDev.Text = p.FFinPrestamo.ToString(CultureInfo.GetCultureInfo("es-ES"));

                fEjNoDev.PsItem.TextChanged += (s, ev) => PonerDatosEjemplarPrestado(fEjNoDev);

                fEjNoDev.Controls.Add(control);
                fEjNoDev.ShowDialog();
            }else
            {
                MessageBox.Show("Actualmente no hay ningún ejemplar prestado en el sistema", "Ver ejemplares no devueltos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


            
        }

        private void PonerDatosEjemplarPrestado(FormNavig form)
        {
            if (Int32.Parse(form.PsItem.Text) > 0)
            {
                Ejemplar e = (Ejemplar)form.BnDatos.BindingSource.Current;
                Prestamo p = lnSala.ObtenerPrestamoDeEjemplar(e);
                CtrlDatosEjemplarPrestado control = (CtrlDatosEjemplarPrestado)form.Controls["CtrlDatosEjemplarPrestado"];
                form.TbClave.Text = e.Codigo;
                control.TbCodPres.Text = p.Codigo;
                control.TbFechaDev.Text = p.FFinPrestamo.ToString(CultureInfo.GetCultureInfo("es-ES"));
            }
           

        }

        private void TsmiPrestPasad_Click(object sender, EventArgs e)
        {
            List<Prestamo> prestamos = lnSala.ObtenerPrestamosEnProcesoPasados();
            if (prestamos.Count > 0)
            {
                FormNavig fPrestCad = new FormNavig();
                BindingSource bsDatos = new BindingSource();

                fPrestCad.Text = "Préstamos caducados";
                fPrestCad.LbClave.Text = "Código de préstamo";
                fPrestCad.LbClave.Left -= 60;
                fPrestCad.TbClave.ReadOnly = true;
                

                fPrestCad.BnDatos.BindingSource = bsDatos;
                fPrestCad.BnDatos.BindingSource.DataSource = prestamos;
                Prestamo p = (Prestamo)fPrestCad.BnDatos.BindingSource.Current;
                CtrlDatosPrestamoBusq control = new CtrlDatosPrestamoBusq(100, 35, lnSala.ObtenerEjemplaresDePrestamo(p.Codigo));

                fPrestCad.TbClave.Text = p.Codigo;
                control.Tbdevolucion.Text = p.FFinPrestamo.ToString(CultureInfo.GetCultureInfo("es-ES"));
                control.Tbusuario.Text = p.Usuario.Dni;
                control.Tbfecha.Text = p.FRealizado.ToString(CultureInfo.GetCultureInfo("es-ES"));
                control.TbEstado.Text = p.Estado.ToString();

                fPrestCad.PsItem.TextChanged += (s, ev) => PonerDatosPrestamo(fPrestCad);

                fPrestCad.Controls.Add(control);
                DialogResult d = fPrestCad.ShowDialog();
                if (d == DialogResult.Cancel)
                {
                    fPrestCad.Close();
                } else
                {
                    TsmiPrestPasad_Click(sender, e);
                }
                fPrestCad.Dispose();


            } else
            {
                MessageBox.Show("Actualmente no existen préstamos caducados en el sistema", "Ver préstamos caducados", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void PonerDatosPrestamo(FormNavig fPrestCad)
        {
            if (Int32.Parse(fPrestCad.PsItem.Text) > 0)
            {
                Prestamo p = (Prestamo)fPrestCad.BnDatos.BindingSource.Current;
                CtrlDatosPrestamoBusq control = (CtrlDatosPrestamoBusq)fPrestCad.Controls["CtrlDatosPrestamoBusq"];
                fPrestCad.Controls.Remove(control);
                CtrlDatosPrestamoBusq controlNuevo = new CtrlDatosPrestamoBusq(100, 35, lnSala.ObtenerEjemplaresDePrestamo(p.Codigo));
                fPrestCad.TbClave.Text = p.Codigo;
                controlNuevo.Tbdevolucion.Text = p.FFinPrestamo.ToString(CultureInfo.GetCultureInfo("es-ES"));
                controlNuevo.Tbusuario.Text = p.Usuario.Dni;
                controlNuevo.Tbfecha.Text = p.FRealizado.ToString(CultureInfo.GetCultureInfo("es-ES"));
                controlNuevo.TbEstado.Text = p.Estado.ToString();
                fPrestCad.Controls.Add(controlNuevo);
            }
        }

        private void TsmiPrestLib_Click(object sender, EventArgs e)
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
                    Libro l = lnB.BuscarLibro(isbn);
                    if (l != null)
                    {
                        MostrarListadoPrest(l);
                    }
                    else
                    {
                        DialogResult res = MessageBox.Show("¿Quieres introducir otro?", "No existe ningún libro con ese ISBN", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (res == DialogResult.Yes)
                        {
                            TsmiPrestLib_Click(sender, e);
                        }
                    }
                }
            }
            formIsbn.Dispose();
        }

        private void MostrarListadoPrest(Libro l)
        {
            List<Prestamo> prestamos = lnSala.ObtenerPrestamosLibro(l);
            if (prestamos.Count > 0)
            {
                FormNavig fPrestLib = new FormNavig();
                BindingSource bsDatos = new BindingSource();

                fPrestLib.Text = "Préstamos de un libro";
                fPrestLib.LbClave.Text = "Código de préstamo";
                fPrestLib.LbClave.Left -= 60;
                fPrestLib.TbClave.ReadOnly = true;


                fPrestLib.BnDatos.BindingSource = bsDatos;
                fPrestLib.BnDatos.BindingSource.DataSource = prestamos;
                Prestamo p = (Prestamo)fPrestLib.BnDatos.BindingSource.Current;
                CtrlDatosPrestamoBusq control = new CtrlDatosPrestamoBusq(100, 35, lnSala.ObtenerEjemplaresDePrestamo(p.Codigo));

                fPrestLib.TbClave.Text = p.Codigo;
                control.Tbdevolucion.Text = p.FFinPrestamo.ToString(CultureInfo.GetCultureInfo("es-ES"));
                control.Tbusuario.Text = p.Usuario.Dni;
                control.Tbfecha.Text = p.FRealizado.ToString(CultureInfo.GetCultureInfo("es-ES"));
                control.TbEstado.Text = p.Estado.ToString();

                fPrestLib.PsItem.TextChanged += (s, ev) => PonerDatosPrestamo(fPrestLib);

                fPrestLib.Controls.Add(control);
                DialogResult d = fPrestLib.ShowDialog();
                if (d == DialogResult.Cancel)
                {
                    fPrestLib.Close();
                }
                fPrestLib.Dispose();
            } else
            {
                MessageBox.Show("El libro no tiene ningún préstamo actualmente", "Préstamos de un libro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void TsmiListado_Click(object sender, EventArgs e)
        {
            FormListPrest fListado = new FormListPrest(lnSala.MostrarPrestamos());
            fListado.ShowDialog();
        }

        private void TsmiBusqPres_Click(object sender, EventArgs e)
        {
            FormClave formClave = new FormClave();
            formClave.Text = "Introducir código";
            formClave.LbClave.Text = "Código";
            DialogResult d = formClave.ShowDialog();
            if (d == DialogResult.Cancel)
            {
                formClave.Close();
            }
            else
            {
                string cod = formClave.TbClave.Text;
                if ( cod != "")
                {
                    Prestamo p = lnSala.BuscarPrestamo(cod);
                    if (p != null)
                    {
                        MostrarFormBusqPres(p);
                    }
                    else
                    {
                        DialogResult res = MessageBox.Show("¿Quieres introducir otro?", "No existe ningún prestamo con ese código", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (res == DialogResult.Yes)
                        {
                            TsmiBusqPres_Click(sender, e);
                        }
                    }
                }
            }
            formClave.Dispose();
        }
        private void MostrarFormBusqPres(Prestamo p)
        {
            CtrlDatosPrestamoBusq control = new CtrlDatosPrestamoBusq(100, 100, lnSala.ObtenerEjemplaresDePrestamo(p.Codigo));
            FormDatos formBusqPres = new FormDatos();
            formBusqPres.Text = "Búsqueda de un préstamo";
            formBusqPres.LbClave.Text = "Codigo";
            formBusqPres.LbClave.Left -= 25;
            formBusqPres.BtAceptar.Text = "Ver personal alta";
            formBusqPres.TbClave.Text = p.Codigo;
            formBusqPres.BtCancelar.Text = "Salir";
            control.Tbusuario.Text = p.Usuario.Dni;
            control.Tbfecha.Text= p.FRealizado.ToString(CultureInfo.GetCultureInfo("es-ES"));
            control.Tbdevolucion.Text= p.FFinPrestamo.ToString(CultureInfo.GetCultureInfo("es-ES"));
            control.TbEstado.Text = p.Estado.ToString();
            formBusqPres.Controls.Add(control);
            DialogResult dAlta = formBusqPres.ShowDialog();
            if (dAlta == DialogResult.Cancel)
            {
                formBusqPres.Close();
            }
            else if (dAlta == DialogResult.OK)
            {
                MostrarFormPersAlta(p.PersonalBAlta);
                MostrarFormBusqPres(p);
            } else if (dAlta == DialogResult.Yes)
            {
                MostrarFormBusqPres(p);
            }
            formBusqPres.Dispose();
        }

        private void TsmiBajaPres_Click(object sender, EventArgs e)
        {
            FormClave formCodP = new FormClave();
            formCodP.Text = "Baja de préstamo";
            formCodP.LbClave.Text = "Código";
            DialogResult d = formCodP.ShowDialog();
            if (d == DialogResult.Cancel)
            {
                formCodP.Close();
            }
            else if (d == DialogResult.OK)
            {
                string codP = formCodP.TbClave.Text;
                if (codP != "")
                {
                    Prestamo p = lnSala.BuscarPrestamo(codP);
                    if (p != null)
                    {
                        MostrarFormBajaPres(p);
                    }
                    else
                    {
                        DialogResult res = MessageBox.Show("¿Quieres introducir otro?", "No existe ningún préstamo con ese código", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (res == DialogResult.Yes)
                        {
                            TsmiBajaPres_Click(sender, e);
                        }
                    }
                }
            }
            formCodP.Dispose();
        }

        private void MostrarFormBajaPres(Prestamo p)
        {
            CtrlDatosPrestamo control = new CtrlDatosPrestamo(100, 100);
            FormDatos formBajaPres = new FormDatos();
            formBajaPres.Text = "Baja de un préstamo";
            formBajaPres.LbClave.Text = "Código";
            formBajaPres.BtAceptar.Text = "Dar de baja";
            formBajaPres.TbClave.Text = p.Codigo;
            control.BtEjsPres.Text = "Ver ejemplares";
            control.BtEjsPres.Enabled = true;
            control.BtEjsPres.DialogResult = DialogResult.Yes;
            control.BtEjsPres.Top += 30;
            control.TbUsuario.Text = p.Usuario.Dni;
            control.TbUsuario.ReadOnly = true;

            Label lbNombreU = new Label();
            TextBox tbNombreU = new TextBox();
            Label lbEstadoP = new Label();
            TextBox tbEstadoP = new TextBox();

            lbNombreU.Text = "Nombre";
            lbNombreU.Top = 63;
            lbNombreU.Left = 42;
            lbNombreU.Size = new Size(51, 16);

            tbNombreU.ReadOnly = true;
            tbNombreU.Top = 61;
            tbNombreU.Left = 90;
            tbNombreU.Width = 98;
            tbNombreU.Height = 22;
            tbNombreU.Text = p.Usuario.Nombre;

            lbEstadoP.Text = "Estado";
            lbEstadoP.Top = 103;
            lbEstadoP.Left = 42;
            lbEstadoP.Size = new Size(51, 16);

            tbEstadoP.ReadOnly = true;
            tbEstadoP.Top = 101;
            tbEstadoP.Left = 90;
            tbEstadoP.Width = 98;
            tbEstadoP.Height = 22;
            tbEstadoP.Text = Enum.GetName(typeof(EstadoEnum), p.Estado);

            control.Controls.Add(lbNombreU);
            control.Controls.Add(tbNombreU);
            control.Controls.Add(lbEstadoP);
            control.Controls.Add(tbEstadoP);

            formBajaPres.Controls.Add(control);
            DialogResult dBaja = formBajaPres.ShowDialog();
            if (dBaja == DialogResult.Cancel)
            {
                formBajaPres.Close();
            } else if (dBaja == DialogResult.Yes) 
            {
                List<Ejemplar> ejemplares = lnSala.ObtenerEjemplaresDePrestamo(p.Codigo);
                if (ejemplares.Count > 0)
                {
                    CtrlDatosEjemplar ctrlEj = new CtrlDatosEjemplar(50, 35);
                    FormNavig listaEjs = new FormNavig();
                    BindingSource bnDatos = new BindingSource();

                    ctrlEj.TbCodigo.Hide();
                    ctrlEj.LbCodigo.Hide();
                    ctrlEj.CbEstadoEj.Enabled = false;
                    listaEjs.LbClave.Text = "Código";
                    listaEjs.Text = "Datos de ejemplares";

                    listaEjs.BnDatos.BindingSource = bnDatos;
                    listaEjs.BnDatos.BindingSource.DataSource = ejemplares;

                    Ejemplar ej = ((Ejemplar)listaEjs.BnDatos.BindingSource.Current);
                    listaEjs.TbClave.Text = ej.Codigo;
                    if (ej.Estado == EstadoEjemplarEnum.Disponible) { ctrlEj.CbEstadoEj.SelectedIndex = 0; }
                    else { ctrlEj.CbEstadoEj.SelectedIndex = 1; }


                    listaEjs.PsItem.TextChanged += (s, ev) => PonerDatos(listaEjs);

                    listaEjs.Controls.Add(ctrlEj);
                    listaEjs.ShowDialog();
                    
                } else
                {
                    MessageBox.Show("El préstamo actualmente no tiene ejemplares por devolver.", "Baja de un préstamo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                }
                MostrarFormBajaPres(p);


            } else if (dBaja == DialogResult.OK)
            {
                if (p.Estado == EstadoEnum.Finalizado)
                {
                    if (lnSala.BajaPrestamo(p.Codigo))
                    {
                        MessageBox.Show("El préstamo se ha dado de baja correctamente", "Baja de un préstamo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    } else
                    {
                        MessageBox.Show("El préstamo no se ha podido dar de baja correctamente", "Baja de un préstamo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                } else
                {
                    MessageBox.Show("El préstamo no se puede dar de baja porque todavía está en proceso", "Baja de un préstamo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            formBajaPres.Dispose();
        }

        private void PonerDatos(FormNavig listaEjs)
        {
            if(Int32.Parse(listaEjs.PsItem.Text) > 0)
            {
                Ejemplar ej = ((Ejemplar)listaEjs.BnDatos.BindingSource.Current);
                listaEjs.TbClave.Text = ej.Codigo;
                if (ej.Estado == EstadoEjemplarEnum.Disponible) { ((CtrlDatosEjemplar)listaEjs.Controls["CtrlDatosEjemplar"]).CbEstadoEj.SelectedIndex = 0; }
                else { ((CtrlDatosEjemplar)listaEjs.Controls["CtrlDatosEjemplar"]).CbEstadoEj.SelectedIndex = 1; }
            }
            
        }

        
        /// <summary>
        /// Muestra el formulario para la alta de prestamos
        /// </summary>
        /// <param name="codP">Codigo del prestamo a dar de alta</param>
        private void MostrarFormAltaPres(string codP)
        {
            CtrlDatosPrestamo control = new CtrlDatosPrestamo(100, 100);
            FormDatos fAltaPres = new FormDatos();
            fAltaPres.Text = "Alta de un préstamo";
            fAltaPres.LbClave.Text = "Código";
            fAltaPres.BtAceptar.Text = "Dar alta";
            fAltaPres.TbClave.Text = codP;
            fAltaPres.Controls.Add(control);

            DialogResult dAlta = fAltaPres.ShowDialog();
            if (dAlta == DialogResult.Cancel)
            {
                fAltaPres.Close();
            }
            else if (dAlta == DialogResult.OK)
            {
                string usu = control.TbUsuario.Text;
                if (usu != "")
                {
                    Usuario u = lnSala.BuscarUsuario(usu);
                    if (u != null) 
                    {
                        Prestamo p = new Prestamo(codP, u, new List<Ejemplar>(), DateTime.Now, DateTime.Now.AddDays(15), this.pers);
                        MessageBox.Show("Se ha dado de alta el préstamo correctamente.\r\nIntroduzca ahora sus ejemplares.", "Alta de un préstamo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.AniadirEjsAPres(p); //No introduciremos el préstamo en la BD hasta que se le añada AL MENOS un ejemplar 
                                                 //Para el usuario esto será invisible
                    }
                    else
                    {
                        DialogResult dU = MessageBox.Show("El usuario introducido no existe.\r\n¿Desea introducir otro?", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                        if (dU == DialogResult.OK)
                        {
                            MostrarFormAltaPres(codP);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Debes introducir el dni del usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    MostrarFormAltaPres(codP);
                }


            }
            fAltaPres.Dispose();
        }

        private void AniadirEjsAPres(Prestamo p)
        {
            CtrlDatosPrestamo control = new CtrlDatosPrestamo(100, 100);
            FormDatos fAltaPres = new FormDatos();
            fAltaPres.Text = "Alta de un préstamo";
            fAltaPres.LbClave.Text = "Código";
            fAltaPres.TbClave.Text = p.Codigo;
            fAltaPres.BtAceptar.Hide();
            fAltaPres.BtCancelar.Text = "Finalizar";
            fAltaPres.BtCancelar.DialogResult = DialogResult.Yes;

            control.TbUsuario.Text = p.Usuario.Dni;
            control.TbUsuario.ReadOnly = true;
            control.BtEjsPres.Enabled = true;

            Label lbNombreU = new Label();
            TextBox tbNombreU = new TextBox();
            
            
            lbNombreU.Text = "Nombre";
            lbNombreU.Top = 63;
            lbNombreU.Left = 42;
            lbNombreU.Size = new Size(51, 16);

            tbNombreU.ReadOnly = true;
            tbNombreU.Top = 61;
            tbNombreU.Left = 90;
            tbNombreU.Width = 98;
            tbNombreU.Height = 22;
            tbNombreU.Text = p.Usuario.Nombre;
            control.Controls.Add(lbNombreU);
            control.Controls.Add(tbNombreU);

            fAltaPres.Controls.Add(control);
            DialogResult d = fAltaPres.ShowDialog();
            if (d == DialogResult.Yes)
            {
                if (lnSala.VerEjemplaresNoDevueltos(p).Count == 0)
                {
                    DialogResult dAtencion = MessageBox.Show("El préstamo no tiene ejemplares, si sale ahora se perderá la información del préstamo.", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (dAtencion == DialogResult.Cancel)
                    {
                        AniadirEjsAPres(p);
                    } 
                } else
                {
                    lnSala.AltaPrestamo(p);
                    MessageBox.Show("Se han añadido los ejemplares correctamente", "Alta de un préstamo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    fAltaPres.Close();
                }
            }
            else if (d == DialogResult.OK)
            {
                Ejemplar ej = AniadirEjs(p);
                if (ej != null)
                {
                    p.Ejemplares.Add(ej); //Se añade al OBJETO prestamo (no en la BD)
                    
                    
                }
                
                AniadirEjsAPres(p);
            } else if (d == DialogResult.Cancel)
            {
                DialogResult dCanc = MessageBox.Show("¿Está seguro que desea salir? Se perderá toda la información relacionada con el préstamo.", "Alta de un préstamo",  MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (dCanc == DialogResult.Cancel)
                {
                    AniadirEjsAPres(p);
                }
            }
            fAltaPres.Dispose();
        }

        private Ejemplar AniadirEjs(Prestamo p)
        {
            CtrlDatosUsu control = new CtrlDatosUsu(100, 100); //Se reutiliza el control de usuario, cambiandole
            FormDatos fDatosEjPres = new FormDatos(); //el nombre a las etiquetas ya que solamente hay que añadir el codigo del ejemplar del préstamo

            fDatosEjPres.Text = "Alta de un préstamo";
            fDatosEjPres.LbClave.Text = "Código\r\n(Préstamo)";
            fDatosEjPres.TbClave.Left += 10;
            fDatosEjPres.TbClave.Text = p.Codigo;
            fDatosEjPres.BtAceptar.Text = "Añadir";

            control.LbNombre.Text = "Código\r\n(Ejemplar)";
            control.TbNombre.Left += 10;
            fDatosEjPres.Controls.Add(control);

            DialogResult dEjPres = fDatosEjPres.ShowDialog();
            Ejemplar ej = null;
            if (dEjPres == DialogResult.Cancel)
            {
                fDatosEjPres.Close();
            } else if (dEjPres == DialogResult.OK)
            {
                string codEj = control.TbNombre.Text;
                if (codEj != "")
                {
                    ej = lnSala.BuscarEjemplar(codEj);
                    if (ej != null)
                    {
                        if (p.Ejemplares.Contains(ej))
                        {
                            MessageBox.Show("No se ha podido añadir el ejemplar al préstamo porque ya lo contiene", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else if (ej.Estado == EstadoEjemplarEnum.Disponible)
                        {
                            ej.Estado = EstadoEjemplarEnum.Prestado;
                            
                            MessageBox.Show("Ejemplar introducido en el préstamo correctamente.", "Alta de un préstamo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        } else
                        {
                            MessageBox.Show("El ejemplar introducido está actualmente prestado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    } else
                    {
                        MessageBox.Show("El ejemplar introducido no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                } else
                {
                    MessageBox.Show("Debes introducir el código del ejemplar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    AniadirEjs(p);
                }
            }
            fDatosEjPres.Dispose();
            return ej;
        
        }                                                       

        private void TsmiAltaPres_Click(object sender, EventArgs e)
        {
            FormClave formCodP = new FormClave();
            formCodP.Text = "Introducir código";
            formCodP.LbClave.Text = "Código";
            DialogResult d = formCodP.ShowDialog();
            if (d == DialogResult.Cancel)
            {
                formCodP.Close();
            }
            else if (d == DialogResult.OK)
            {
                string codP = formCodP.TbClave.Text;
                if (codP != "")
                {
                    if (lnSala.BuscarPrestamo(codP) == null)
                    {
                        MostrarFormAltaPres(codP);
                    }
                    else
                    {
                        DialogResult res = MessageBox.Show("¿Quieres introducir otro?", "Ya existe un préstamo con ese código", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (res == DialogResult.Yes)
                        {
                            TsmiAltaPres_Click(sender, e);
                        }
                    }
                }
            }
            formCodP.Dispose();
        }
    }
}
