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
    public partial class FormInicial : Form
    {
        private LNBiblioteca lnB;
        private bool autentificacionCorrecta;
        private Form formGestion;

        public bool AutentificacionCorrecta
        {
            get { return this.autentificacionCorrecta; }
        }

        public Form FormGestion
        {
            get { return this.formGestion; }
        }
        public FormInicial()
        {
            
            lnB = new LNBiblioteca();
            lnB.IniciarBD();
            InitializeComponent();
        }

        private void btIniciarSesion_Click(object sender, EventArgs e)
        {
            PersonalBiblioteca personal = new PersonalBiblioteca(tbUsuario.Text, tbContraseña.Text);
            PersonalBiblioteca personalBD = lnB.BuscarPersonal(tbUsuario.Text);
            if (personalBD == null)
            {
                MessageBox.Show("No existe ningún usuario con ese nombre", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else if (personalBD.Nombre == personal.Nombre)
            {
                this.autentificacionCorrecta = true;
                if (personalBD.Contraseña == personal.Contraseña)
                {
                    switch (personalBD.GetType().Name)
                    {
                        case "PersonalAdquisiciones":
                            FormAdquisiciones formAdq = new FormAdquisiciones(personalBD as PersonalAdquisiciones);
                            this.formGestion = formAdq;
                            break;
                        case "PersonalSala":
                            FormSala formSala = new FormSala(personalBD as PersonalSala);
                            this.formGestion = formSala;
                            break;
                    }
                    this.Dispose();
                } else
                {
                    MessageBox.Show("Contraseña incorrecta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
        }

        private void btRegistrar_Click(object sender, EventArgs e)
        {
            CtrlRegistroPersonal control = new CtrlRegistroPersonal(100, 100);
            FormDatos formRegisPers = new FormDatos();
            formRegisPers.Text = "Registro de personal";
            formRegisPers.LbClave.Hide();
            formRegisPers.BtAceptar.Text = "Registrarse";
            formRegisPers.TbClave.Hide();
            control.TbNombre.Text = this.tbUsuario.Text;
            control.TbContraseña.Text = this.tbContraseña.Text;
            control.CbRol.SelectedIndex = 0;
            formRegisPers.Controls.Add(control);

            DialogResult dAlta = formRegisPers.ShowDialog();
            if (dAlta == DialogResult.Cancel)
            {
                formRegisPers.Close();
            }
            else if (dAlta == DialogResult.OK)
            {
                string nombre = control.TbNombre.Text;
                string contraseña = control.TbContraseña.Text;
                if (nombre != "")
                {
                    PersonalBiblioteca personalBD = lnB.BuscarPersonal(nombre);
                    if (personalBD == null)
                    {
                        if (contraseña != "")
                        {
                            if (control.CbRol.SelectedIndex == 0)
                            {
                                if (lnB.AltaPersonal(new PersonalAdquisiciones(nombre, contraseña)))
                                {
                                    MessageBox.Show("Se ha registrado correctamente el personal de adquisiciones.", "Registro de personal", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    MessageBox.Show("No se ha podido registrar al personal de adquisiciones correctamente.", "Registro de personal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                if (lnB.AltaPersonal(new PersonalSala(nombre, contraseña)))
                                {
                                    MessageBox.Show("Se ha registrado correctamente el personal de sala.", "Registro de personal", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    MessageBox.Show("No se ha podido registrar al personal de sala correctamente.", "Registro de personal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("La contraseña no puede ser vacía", "Registro de personal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    } else
                    {
                        MessageBox.Show("Ya existe un personal con ese nombre", "Registro de personal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    
                } else
                {
                    MessageBox.Show("El nombre del personal no puede ser vacío", "Registro de personal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
            formRegisPers.Dispose();
        }
    }
}
