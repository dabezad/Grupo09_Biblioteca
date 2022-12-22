using LogicaNegocio;
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
    public partial class GestionBiblioteca : Form
    {
        private LNBiblioteca lnB;
        public GestionBiblioteca()
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
                if (dni != null)
                {
                    if (lnB.BuscarUsuario(dni) != null)
                    {
                        FormAlta formAltaUsu = new FormAlta();
                        formAltaUsu.Text = "Alta de un usuario";
                        formAltaUsu.LbClave.Text = "DNI";

                        DialogResult dAlta = formAltaUsu.ShowDialog();
                    } else
                    {
                        DialogResult res = MessageBox.Show("¿Quieres introducir otro?", "Ya existe un usuario con ese DNI", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                        if (res == DialogResult.Yes)
                        {
                            tsmiAltaUsu_Click(sender, e);
                        } 
                    }
                }
                
                
            }
            formDNI.Dispose();
        }
    }
}
