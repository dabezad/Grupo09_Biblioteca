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
    public partial class CtrlDatosLibRecorrido : UserControl
    {
        public TextBox TbTitulo
        {
            get { return this.tbTitulo; }
        }

        public TextBox TbAutor
        {
            get { return this.tbAutor; }
        }

        public TextBox TbEditorial
        {
            get { return this.tbEditorial; }
        }

        public TextBox TbNumEjs
        {
            get { return this.tbNumEjs; }
        }

        public CtrlDatosLibRecorrido()
        {
            InitializeComponent();
        }

        public CtrlDatosLibRecorrido(int top, int left)
        {
            this.Top = top;
            this.Left = left;
            InitializeComponent();
        }
    }
}
