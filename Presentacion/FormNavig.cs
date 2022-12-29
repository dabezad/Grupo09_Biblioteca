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
    public partial class FormNavig : Form
    {
        public FormNavig()
        {
            InitializeComponent();
        }

        public FormNavig(List<Ejemplar> lista)
        {
            this.bindSource = new BindingSource() { DataSource = lista };
            
        }
    }
}
