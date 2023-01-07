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
    public partial class CtrlDatosPrestamoBusq : UserControl
    {
        public CtrlDatosPrestamoBusq()
        {
            InitializeComponent();
        }
        public CtrlDatosPrestamoBusq(int top, int left)
        {
            Left = left;
            Top = top;
            InitializeComponent();
        }
        
        public TextBox Tbusuario
        {
            get { return tbusuario; }
        }
        
        public Button Btejemplares
        {
            get { return btejemplares; }
        }
        
        public TextBox Tbfecha
        {
            get { return tbfecha; }
        }

        public TextBox Tbdevolucion
        {
            get { return tbdevolucion; }
        }
    }
}
