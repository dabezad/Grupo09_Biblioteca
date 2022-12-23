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

        
        public FormGestionBiblioteca()
        {
            InitializeComponent();
            lnB = new LNBiblioteca();
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
            } else if (d == DialogResult.OK)
            {
                string dni = formDNI.TbClave.Text;
                if (dni != "")
                {
                    if (lnB.BuscarUsuario(dni) == null)
                    {
                        MostrarFormAlta(dni);
                    } else
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

        private void MostrarFormAlta(string dni)
        {
            CtrlAltaUsu control = new CtrlAltaUsu(100, 100);
            FormAlta formAltaUsu = new FormAlta();
            formAltaUsu.Text = "Alta de un usuario";
            formAltaUsu.LbClave.Text = "DNI";
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
                    if (this.lnB.AltaUsuario(new Usuario(dni, nombre, new PersonalBiblioteca("Pepe", "123")))) //Modificar por el usuario que lo da de alta CUANDO SE IMPLEMENTE
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
                    MostrarFormAlta(dni);
                }


            }
        }
    }
}
