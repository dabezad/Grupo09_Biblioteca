﻿using LogicaNegocio;
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
    public partial class CtrlDatosLib : UserControl
    {
        public Label LbEditorial
        {
            get { return lbEditorial; }
        }
        public Label LbAutor
        {
            get { return lbAutor; }
        }
        public Label LbTitulo
        {
            get { return lbTitulo; }
        }
        public TextBox TbTitulo
        {
            get { return tbTitulo;  }
        }

        public TextBox TbAutor
        {
            get { return tbAutor; }
        }

        public TextBox TbEditorial
        {
            get { return tbEditorial; }
        }

        public Button BtAniadirEj
        {
            get { return btAniadirEj;  }
        }
        public CtrlDatosLib()
        {
            InitializeComponent();
        }

        public CtrlDatosLib(int top, int left)
        {
            this.Top = top;
            this.Left = left;
            InitializeComponent();
        }

        /// <summary>
        /// Muestra el formulario para añadir ejemplares
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btAniadirEj_Click(object sender, EventArgs e)
        {
            Form f = this.FindForm();
            if (f is FormDatos)
            {
                FormDatos fDatos = (f as FormDatos);
                if (fDatos.TbClave.Text != "")
                {
                    FormAdquisiciones fAdq = (FormAdquisiciones) Application.OpenForms["FormAdquisiciones"];
                    fAdq.MostrarFormAltaEj(fDatos.TbClave.Text);
                }
                
            }
        }

        /// <summary>
        /// Actualiza el titulo dentro del textbox cuando este cambia
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbTitulo_TextChanged(object sender, EventArgs e)
        {
            Size size = TextRenderer.MeasureText(tbTitulo.Text, tbTitulo.Font);
            tbTitulo.Width = size.Width;
            tbTitulo.Height = size.Height;
        }

        /// <summary>
        /// Actualiza el autor dentro del textbox cuando este cambia
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbAutor_TextChanged(object sender, EventArgs e)
        {
            Size size = TextRenderer.MeasureText(tbAutor.Text, tbAutor.Font);
            tbAutor.Width = size.Width;
            tbAutor.Height = size.Height;
        }
    }
}
