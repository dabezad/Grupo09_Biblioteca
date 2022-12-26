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
    public partial class FormGestionBiblioteca : Form
    {
        private LNBiblioteca lnB;
        private PersonalBiblioteca personal; //DATO DE PRUEBA, cambiar despues por el personal que accede 

        public FormGestionBiblioteca()
        {
            InitializeComponent();
        }

        public FormGestionBiblioteca(PersonalBiblioteca pers)
        {
            this.personal = pers;
            lnB = new LNBiblioteca();
            lnB.AltaPersonal(pers);
            InitializeComponent();
            
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {

        }

        private void tsmiAltaUsu_Click(object sender, EventArgs e)
        {
            FormClave formDNI = new FormClave();
            formDNI.Text = "Introducir DNI";
            formDNI.LbClave.Text = "DNI";
            DialogResult d = formDNI.ShowDialog();
            if (d == DialogResult.Cancel)
            {
                formDNI.Close();
            }
            else if (d == DialogResult.OK)
            {
                string dni = formDNI.TbClave.Text;
                if (dni != "")
                {
                    if (lnB.BuscarUsuario(dni) == null)
                    {
                        MostrarFormAltaUsu(dni);
                    }
                    else
                    {
                        DialogResult res = MessageBox.Show("¿Quieres introducir otro?", "Ya existe un usuario con ese DNI", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (res == DialogResult.Yes)
                        {
                            tsmiAltaUsu_Click(sender, e);
                        }
                    }
                }


            }
            formDNI.Dispose();
        }

        private void MostrarFormAltaUsu(string dni)
        {
            CtrlDatosUsu control = new CtrlDatosUsu(100, 100);
            FormDatos formAltaUsu = new FormDatos();
            formAltaUsu.Text = "Alta de un usuario";
            formAltaUsu.LbClave.Text = "DNI";
            formAltaUsu.BtAceptar.Text = "Dar alta";
            formAltaUsu.TbClave.Text = dni;
            formAltaUsu.Controls.Add(control);

            DialogResult dAlta = formAltaUsu.ShowDialog();
            if (dAlta == DialogResult.Cancel)
            {
                formAltaUsu.Close();
            }
            else if (dAlta == DialogResult.OK)
            {
                string nombre = control.TbNombre.Text;
                if (nombre != "")
                {
                    if (this.lnB.AltaUsuario(new Usuario(dni, nombre, this.personal))) //Modificar por el usuario que lo da de alta CUANDO SE IMPLEMENTE
                    {
                        MessageBox.Show("Se ha dado de alta al usuario correctamente", "Alta de un usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No se ha podido dar de alta al usuario correctamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Debes introducir un nombre para el usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    MostrarFormAltaUsu(dni);
                }


            }
            formAltaUsu.Dispose();
        }

        private void tsmiBajaUsu_Click(object sender, EventArgs e)
        {
            FormClave formDNI = new FormClave();
            formDNI.Text = "Introducir DNI";
            formDNI.LbClave.Text = "DNI";
            DialogResult d = formDNI.ShowDialog();
            if (d == DialogResult.Cancel)
            {
                formDNI.Close();
            }
            else
            {
                string dni = formDNI.TbClave.Text;
                if (dni != "")
                {
                    Usuario u = lnB.BuscarUsuario(dni);
                    if (u != null)
                    {
                        MostrarFormBajaUsu(u);
                    }
                    else
                    {
                        DialogResult res = MessageBox.Show("¿Quieres introducir otro?", "No existe ningún usuario con ese DNI", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (res == DialogResult.Yes)
                        {
                            tsmiBajaUsu_Click(sender, e);
                        }
                    }
                }
            }
            formDNI.Dispose();
        }

        private void MostrarFormBajaUsu(Usuario u)
        {
            CtrlDatosUsu control = new CtrlDatosUsu(100, 100);
            FormDatos formBajaUsu = new FormDatos();
            formBajaUsu.Text = "Baja de un usuario";
            formBajaUsu.LbClave.Text = "DNI";
            formBajaUsu.BtAceptar.Text = "Dar de baja";
            formBajaUsu.TbClave.Text = u.Dni;
            control.TbNombre.Text = u.Nombre;
            control.TbNombre.ReadOnly = true;
            formBajaUsu.Controls.Add(control);

            DialogResult dAlta = formBajaUsu.ShowDialog();
            if (dAlta == DialogResult.Cancel)
            {
                formBajaUsu.Close();
            }
            else if (dAlta == DialogResult.OK)
            {
                DialogResult dConfirm = MessageBox.Show("¿Está seguro que desea dar de baja al usuario?", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dConfirm == DialogResult.OK)
                {
                    if (lnB.BajaUsuario(u.Dni))
                    {
                        MessageBox.Show("El usuario se ha dado de baja correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error en el sistema al dar de baja al usuario", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            formBajaUsu.Dispose();
        }

        

       
    }
}
