﻿using LogicaNegocio;
using ModeloDominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FormGestionBiblioteca : Form
    {
        protected LNBiblioteca lnB;
        private PersonalBiblioteca personal; //DATO DE PRUEBA, cambiar despues por el personal que accede 

        public FormGestionBiblioteca()
        {
            InitializeComponent();
        }

        public FormGestionBiblioteca(PersonalBiblioteca pers)
        {
            this.personal = pers;
            InitializeComponent();
            
        }


        /// <summary>
        /// Muestra el formulario de alta de usuario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Muestra el formulario de alta usuario y le da caracteristicas especificas
        /// </summary>
        /// <param name="dni"></param>
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

        /// <summary>
        /// Muestra el formulario de baja de usuario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Le da caracterisiticas especificas al formulario de baja de usuario
        /// </summary>
        /// <param name="u"></param>
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

        /// <summary>
        /// Devuelve el formulario de busqueda de usuario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiBusqUsu_Click(object sender, EventArgs e)
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
                        MostrarFormBusqUsu(u);
                    }
                    else
                    {
                        DialogResult res = MessageBox.Show("¿Quieres introducir otro?", "No existe ningún usuario con ese DNI", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (res == DialogResult.Yes)
                        {
                            tsmiBusqUsu_Click(sender, e);
                        }
                    }
                }
            }
            formDNI.Dispose();
        }

        /// <summary>
        /// Le da las caracterisiticas necesarias al formulario de busqueda de usuarios
        /// </summary>
        /// <param name="u"></param>
        private void MostrarFormBusqUsu(Usuario u)
        {
            CtrlDatosUsu control = new CtrlDatosUsu(100, 100);
            FormDatos formBusqUsu = new FormDatos();
            formBusqUsu.Text = "Búsqueda de un usuario";
            formBusqUsu.LbClave.Text = "DNI";
            formBusqUsu.BtAceptar.Text = "Ver personal alta";
            formBusqUsu.TbClave.Text = u.Dni;
            formBusqUsu.BtCancelar.Text = "Salir";
            control.TbNombre.Text = u.Nombre;
            control.TbNombre.ReadOnly = true;
            formBusqUsu.Controls.Add(control);

            DialogResult dAlta = formBusqUsu.ShowDialog();
            if (dAlta == DialogResult.Cancel)
            {
                formBusqUsu.Close();
            } else if (dAlta == DialogResult.OK)
            {
                MostrarFormPersAlta(u.PersonalBAlta);
                MostrarFormBusqUsu(u);
            }
            formBusqUsu.Dispose();
        }

        /// <summary>
        /// Muestra el formulario personal 
        /// </summary>
        /// <param name="pers"></param>
        protected void MostrarFormPersAlta(PersonalBiblioteca pers)
        {
            FormDatos formPers = new FormDatos();
            CtrlDatosPersonal control = new CtrlDatosPersonal(100, 100);
            control.TbRol.Text = pers.GetType().Name;
            formPers.BtAceptar.Hide();
            formPers.LbClave.Text = "Nombre";
            formPers.TbClave.Text = pers.Nombre;
            formPers.Text = "Búsqueda del personal de alta";
            formPers.BtCancelar.Text = "Salir";
            formPers.Controls.Add(control);
            DialogResult d = formPers.ShowDialog();
            if (d == DialogResult.Cancel)
            {
                formPers.Close();
            }
            formPers.Dispose();

        }

        /// <summary>
        /// Muestra el formulario para prestar ejemplares
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiEjPrest_Click(object sender, EventArgs e)
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
                        MostrarEjsPrestados(u);
                    }
                    else
                    {
                        DialogResult res = MessageBox.Show("¿Quieres introducir otro?", "No existe ningún usuario con ese DNI", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (res == DialogResult.Yes)
                        {
                            tsmiEjPrest_Click(sender, e);
                        }
                    }
                }
            }
            formDNI.Dispose();
        }

        /// <summary>
        /// Muestra los ejemplares prestados a un usaurio
        /// </summary>
        /// <param name="u"></param>
        private void MostrarEjsPrestados(Usuario u)
        {
            List<Ejemplar> ejemplares = lnB.MostrarEjemplaresPrestados(u);
            if (ejemplares.Count == 0)
            {
                MessageBox.Show("El usuario no tiene ningún ejemplar en su posesión actualmente", "Ejemplares prestados de un usuario", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                FormNavig fRecorrido = new FormNavig();
                BindingSource bnDatos = new BindingSource();
                CtrlDatosEjemplarPrestado control = new CtrlDatosEjemplarPrestado(100, -40);

                fRecorrido.BnDatos.BindingSource = bnDatos;
                fRecorrido.BnDatos.BindingSource.DataSource = ejemplares;

                Ejemplar e = (Ejemplar)fRecorrido.BnDatos.BindingSource.Current;
                Prestamo p = lnB.ObtenerPrestamoDeEjemplar(e);

                fRecorrido.LbClave.Text = "Código de ejemplar";
                fRecorrido.LbClave.Left -= 45;
                fRecorrido.TbClave.Left += 6;
                fRecorrido.Text = "Ejemplares prestados de un usuario";

                fRecorrido.TbClave.Text = e.Codigo;
                control.TbCodPres.Text = p.Codigo;
                control.TbFechaDev.Text = p.FRealizado.ToString(CultureInfo.GetCultureInfo("es-ES"));

                
                fRecorrido.PsItem.TextChanged += (s, ev) => PonerDatosEjemplar(fRecorrido);
                

                fRecorrido.Controls.Add(control);
                DialogResult d = fRecorrido.ShowDialog();
                if (d == DialogResult.Cancel)
                {
                    fRecorrido.Close();
                }
                fRecorrido.Dispose();
            }
        }

        /// <summary>
        /// carga los datos de un ejemplar en el formulario
        /// </summary>
        /// <param name="fRecorrido"></param>
        private void PonerDatosEjemplar(FormNavig fRecorrido)
        {
            
            if (Int32.Parse(fRecorrido.PsItem.Text) > 0)
            {
                Ejemplar e = (Ejemplar)fRecorrido.BnDatos.BindingSource.Current;
                Prestamo p = lnB.ObtenerPrestamoDeEjemplar(e);
                CtrlDatosEjemplarPrestado control = (CtrlDatosEjemplarPrestado)fRecorrido.Controls["CtrlDatosEjemplarPrestado"];
                fRecorrido.TbClave.Text = e.Codigo;
                control.TbCodPres.Text = p.Codigo;
                control.TbFechaDev.Text = p.FRealizado.ToString(CultureInfo.GetCultureInfo("es-ES"));
            }
        }

        /// <summary>
        /// Muestrael formulario con los prestamos caducados respecto a un usuario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiPrestCad_Click(object sender, EventArgs e)
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
                        MostrarPrestCaducados(u);
                    }
                    else
                    {
                        DialogResult res = MessageBox.Show("¿Quieres introducir otro?", "No existe ningún usuario con ese DNI", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (res == DialogResult.Yes)
                        {
                            tsmiPrestCad_Click(sender, e);
                        }
                    }
                }
            }
            formDNI.Dispose();
        }

        /// <summary>
        /// Muestra prestamos caducados de un usuario
        /// </summary>
        /// <param name="u"></param>
        private void MostrarPrestCaducados(Usuario u)
        {
            List<Prestamo> prestamos = lnB.MostrarPrestamosCaducados(u);
            if (prestamos.Count == 0)
            {
                MessageBox.Show("El usuario no tiene ningún préstamo caducado", "Préstamos caducados de un usuario", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            } else
            {
                FormNavig fRecorrido = new FormNavig();
                BindingSource bnDatos = new BindingSource();
                fRecorrido.BnDatos.BindingSource = bnDatos;
                fRecorrido.BnDatos.BindingSource.DataSource = prestamos;

                Prestamo p = (Prestamo)fRecorrido.BnDatos.BindingSource.Current;

                CtrlDatosPrestamoBusq control = new CtrlDatosPrestamoBusq(100, 35, lnB.ObtenerEjemplaresDePrestamo(p.Codigo));
               
                fRecorrido.LbClave.Text = "Código de préstamo";
                fRecorrido.LbClave.Left -= 60;
                fRecorrido.Text = "Préstamos caducados de un usuario";

                fRecorrido.TbClave.Text = p.Codigo;
                control.Tbdevolucion.Text = p.FFinPrestamo.ToString(CultureInfo.GetCultureInfo("es-ES"));
                control.Tbusuario.Text = p.Usuario.Dni;
                control.Tbfecha.Text = p.FRealizado.ToString(CultureInfo.GetCultureInfo("es-ES"));
                control.TbEstado.Text = p.Estado.ToString();

                fRecorrido.PsItem.TextChanged += (s, e) => PonerDatos(fRecorrido);

                fRecorrido.Controls.Add(control);
                DialogResult d = fRecorrido.ShowDialog();
                if (d == DialogResult.Cancel)
                {
                    fRecorrido.Close();
                } else
                {
                    MostrarPrestCaducados(u);
                }
                fRecorrido.Dispose();
            }
        }

        /// <summary>
        /// carga los datos de frecorrdido en el formualrio
        /// </summary>
        /// <param name="fRecorrido"></param>
        private void PonerDatos(FormNavig fRecorrido)
        {
            if (Int32.Parse(fRecorrido.PsItem.Text) > 0)
            {
                Prestamo p = (Prestamo)fRecorrido.BnDatos.BindingSource.Current;
                CtrlDatosPrestamoBusq control = (CtrlDatosPrestamoBusq)fRecorrido.Controls["CtrlDatosPrestamoBusq"];
                fRecorrido.Controls.Remove(control);
                CtrlDatosPrestamoBusq controlNuevo = new CtrlDatosPrestamoBusq(100, 35, lnB.ObtenerEjemplaresDePrestamo(p.Codigo));
                fRecorrido.TbClave.Text = p.Codigo;
                controlNuevo.Tbdevolucion.Text = p.FFinPrestamo.ToString(CultureInfo.GetCultureInfo("es-ES"));
                controlNuevo.Tbusuario.Text = p.Usuario.Dni;
                controlNuevo.Tbfecha.Text = p.FRealizado.ToString(CultureInfo.GetCultureInfo("es-ES"));
                controlNuevo.TbEstado.Text = p.Estado.ToString();
                fRecorrido.Controls.Add(controlNuevo);
            }
            
        }

        /// <summary>
        /// Muestra el listado de usuarios
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiListado_Click(object sender, EventArgs e)
        {
            FormListadoUsu FListado = new FormListadoUsu(lnB);
            DialogResult d = FListado.ShowDialog();
            if (d == DialogResult.Cancel)
            {
                FListado.Close();
            }
            FListado.Dispose();
        }

        /// <summary>
        /// Busca por dni un usuario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void búsquedaPorDNIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<string> dnis = lnB.MostrarUsuarios().Select(x => x.Dni).ToList();
            FormBusqPorClave FBusq = new FormBusqPorClave();
            CtrlDatosUsu control = new CtrlDatosUsu(100, 100);
            control.TbNombre.Size = new Size(135,24);
            control.TbNombre.ReadOnly = true;
            FBusq.Text = "Datos de un usuario";
            FBusq.LbClave.Text = "DNI";
            FBusq.BsClave.DataSource = dnis;
            FBusq.CbClave.SelectedIndex = -1;
            FBusq.CbClave.SelectedIndexChanged += (s, ev) => CambiarNombreUsu(sender, e, FBusq);
            FBusq.Controls.Add(control);
            FBusq.Show();
        }

        /// <summary>
        /// Cambia el nombre de un usuario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="form"></param>
        private void CambiarNombreUsu(object sender, EventArgs e, FormBusqPorClave form)
        {
            CtrlDatosUsu control = (CtrlDatosUsu) form.Controls["CtrlAltaUsu"];
            string dni = (string) form.CbClave.SelectedValue;
            if (dni != null)
            {
                string nomUsu = lnB.BuscarUsuario(dni).Nombre;
                control.TbNombre.Text = nomUsu;
                
            }
       
        }

        /// <summary>
        /// recorre una lista con todos los usuarios
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiRecorrido_Click(object sender, EventArgs e)
        {
            FormNavig fRecorrido = new FormNavig();
            CtrlDatosUsu control = new CtrlDatosUsu(100, 35);
            List<Usuario> usuarios = lnB.MostrarUsuarios();
            BindingSource bnDatos = new BindingSource();

            control.TbNombre.ReadOnly = true;
            control.TbNombre.Size = new Size(108, 22);
            fRecorrido.LbClave.Text = "DNI";
            fRecorrido.Text = "Datos de un usuario";
           
            fRecorrido.BnDatos.BindingSource = bnDatos;
            fRecorrido.BnDatos.BindingSource.DataSource = usuarios;
            fRecorrido.TbClave.Text = ((Usuario)fRecorrido.BnDatos.BindingSource.Current).Dni;
            control.TbNombre.Text = ((Usuario)fRecorrido.BnDatos.BindingSource.Current).Nombre;

            fRecorrido.PsItem.TextChanged += delegate (object s, EventArgs ev)
            {
                if (Int32.Parse(fRecorrido.PsItem.Text) > 0)
                {
                    fRecorrido.TbClave.Text = ((Usuario)fRecorrido.BnDatos.BindingSource.Current).Dni;
                    control.TbNombre.Text = ((Usuario)fRecorrido.BnDatos.BindingSource.Current).Nombre;
                }

            };

            fRecorrido.Controls.Add(control);
            DialogResult d = fRecorrido.ShowDialog();
            if (d == DialogResult.Cancel)
            {
                fRecorrido.Close();
            }
            fRecorrido.Dispose();
        }

        /// <summary>
        /// Cierra la sesión y muestra el formulario inicial
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiCerrarSes_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
        }

        private void tsmiSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
