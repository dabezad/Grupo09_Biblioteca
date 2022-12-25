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

        public FormSala(PersonalSala pers)
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
            throw new NotImplementedException();
        }

        private void tsmiAltaPres_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
