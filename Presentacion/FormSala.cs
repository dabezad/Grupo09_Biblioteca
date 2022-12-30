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
            lnSala = new LNSala();
            lnSala.IniciarBD();
            this.pers = pers;
            this.Text = pers.Nombre + " - Gestión de biblioteca - Sala";

            this.Aniadir_tsmis();
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
            tsmiPrestLib.Click += tsmiPrestLib_Click;
            ToolStripMenuItem tsmiDevEj = new ToolStripMenuItem("Devolver ejemplar");
            tsmiPrestLib.Click += TsmiPrestLib_Click;
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

        private void TsmiPrestAct_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void TsmiEjNoDev_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void TsmiPrestPasad_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void TsmiPrestLib_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void tsmiPrestLib_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void TsmiListado_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void TsmiBusqPres_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
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
            control.TbUsuario.Text = p.Usuario.Dni;
            control.TbUsuario.ReadOnly = true;

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

            formBajaPres.Controls.Add(control);
            DialogResult dBaja = formBajaPres.ShowDialog();
            if (dBaja == DialogResult.Cancel)
            {
                formBajaPres.Close();
            } else if (dBaja == DialogResult.Yes) //Mostrar menu con ejemplares
            {
                List<Ejemplar> l = lnSala.ObtenerEjemplaresDePrestamo(p.Codigo);
                CtrlDatosEjemplar ctrlEj = new CtrlDatosEjemplar(50, 50);
                FormNavig listaEjs = new FormNavig(l);
                listaEjs.Text = "Lista de ejemplares";

                ctrlEj.TbCodigo.ReadOnly = true;
                ctrlEj.CbEstadoEj.Enabled = false;


                listaEjs.Controls.Add(ctrlEj);
                listaEjs.ShowDialog();

                
            }
            formBajaPres.Dispose();
        }

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
            fAltaPres.BtCancelar.Text = "Salir";

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
            if (d == DialogResult.Cancel)
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
            else
            {
                Ejemplar ej = AniadirEjs(p);
                if (ej != null)
                {
                    p.Ejemplares.Add(ej); //Se añade al OBJETO prestamo (no en la BD)
                }
                
                AniadirEjsAPres(p);
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
                        if (ej.Estado == EstadoEjemplarEnum.Disponible)
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
