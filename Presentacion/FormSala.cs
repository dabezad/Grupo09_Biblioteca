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

        public FormSala(PersonalSala pers): base(pers)
        {
            lnSala = new LNSala();
            this.pers = pers;
            this.Text = pers.Nombre + " - Gestión de biblioteca - Sala";

            this.Aniadir_tsmis();
            InitializeComponent();
        }

        private void Aniadir_tsmis()
        {
            ToolStripMenuItem tsmiAltaPres = new ToolStripMenuItem("Alta");
            tsmiAltaPres.Click += tsmiAltaPres_Click;
            ToolStripMenuItem tsmiBajaPres = new ToolStripMenuItem("Baja");
            tsmiBajaPres.Click += tsmiBajaPres_Click;
            

            this.tsmiPrestamos.DropDownItems.Add(tsmiAltaPres);
            this.tsmiPrestamos.DropDownItems.Add(tsmiBajaPres);
        }

        private void tsmiBajaPres_Click(object sender, EventArgs e)
        {
            
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
                        if (lnSala.AltaPrestamo(p))
                        {
                            MessageBox.Show("Se ha dado de alta el préstamo correctamente.\r\nIntroduzca ahora sus ejemplares.", "Alta de un préstamo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.AniadirEjsAPres(p);
                        }
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
            

            fAltaPres.Controls.Add(control);
            DialogResult d = fAltaPres.ShowDialog();
            if (d == DialogResult.Cancel)
            {
                if (lnSala.VerEjemplaresNoDevueltos(p).Count == 0)
                {
                    MessageBox.Show("No se puede dar de alta un préstamo sin ejemplares", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    AniadirEjsAPres(p);
                } else
                {
                    lnSala.ActualizarPrestamo(p);
                    MessageBox.Show("Se han añadido los ejemplares correctamente", "Alta de un préstamo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    fAltaPres.Close();
                }
            }
            else
            {
                p = AniadirEjs(p);
                AniadirEjsAPres(p);
            }
            fAltaPres.Dispose();
        }

        private Prestamo AniadirEjs(Prestamo p)
        {
            CtrlDatosUsu control = new CtrlDatosUsu(100, 100); //Se reutiliza el control de usuario, cambiandole
            FormDatos fDatosEjPres = new FormDatos(); //el nombre a las etiquetas ya que solamente hay que añadir el codigo del ejemplar del préstamo

            fDatosEjPres.Text = "Alta de un préstamo";
            fDatosEjPres.LbClave.Text = "Código\r\n(Préstamo)";
            fDatosEjPres.TbClave.Text = p.Codigo;
            fDatosEjPres.BtAceptar.Text = "Añadir al préstamo";

            control.LbNombre.Text = "Código\r\n(Ejemplar)";
            fDatosEjPres.Controls.Add(control);

            DialogResult dEjPres = fDatosEjPres.ShowDialog();
            if (dEjPres == DialogResult.Cancel)
            {
                fDatosEjPres.Close();
            } else if (dEjPres == DialogResult.OK)
            {
                string codEj = control.TbNombre.Text;
                if (codEj != "")
                {
                    LNAdquisiciones lnAdq = new LNAdquisiciones();
                    Ejemplar ej = lnAdq.BuscarEjemplar(codEj);
                    if (ej != null)
                    {
                        if (ej.Estado == EstadoEjemplarEnum.Disponible)
                        {
                            ej.Estado = EstadoEjemplarEnum.Prestado;
                            p.Ejemplares.Add(ej);
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
            return p;
        
        }                                                       

        private void tsmiAltaPres_Click(object sender, EventArgs e)
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
                            tsmiAltaPres_Click(sender, e);
                        }
                    }
                }
            }
            formCodP.Dispose();
        }
    }
}
