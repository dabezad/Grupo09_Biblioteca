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
    public partial class CtrlDatosEjemplarPrestado : UserControl
    {
        public TextBox TbCodPres
        {
            get { return this.tbCodPres; }
        }

        public TextBox TbFechaDev
        {
            get { return this.tbFechaDev; }
        }


        public CtrlDatosEjemplarPrestado()
        {
            InitializeComponent();
        }

        public CtrlDatosEjemplarPrestado(int top, int left)
        {
            this.Top = top;
            this.Left = left;
            InitializeComponent();
        }
    }
}
