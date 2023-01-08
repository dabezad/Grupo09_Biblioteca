namespace Presentacion
{
    partial class FormNavig
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormNavig));
            this.bnDatos = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.btPrimero = new System.Windows.Forms.ToolStripButton();
            this.btAnterior = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.psItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btSiguiente = new System.Windows.Forms.ToolStripButton();
            this.btUltimo = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.lbClave = new System.Windows.Forms.Label();
            this.tbClave = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.bnDatos)).BeginInit();
            this.bnDatos.SuspendLayout();
            this.SuspendLayout();
            // 
            // bnDatos
            // 
            this.bnDatos.AddNewItem = this.bindingNavigatorAddNewItem;
            this.bnDatos.CountItem = this.bindingNavigatorCountItem;
            this.bnDatos.DeleteItem = this.bindingNavigatorDeleteItem;
            this.bnDatos.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.bnDatos.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btPrimero,
            this.btAnterior,
            this.bindingNavigatorSeparator,
            this.psItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.btSiguiente,
            this.btUltimo,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem});
            this.bnDatos.Location = new System.Drawing.Point(0, 0);
            this.bnDatos.MoveFirstItem = this.btPrimero;
            this.bnDatos.MoveLastItem = this.btUltimo;
            this.bnDatos.MoveNextItem = this.btSiguiente;
            this.bnDatos.MovePreviousItem = this.btAnterior;
            this.bnDatos.Name = "bnDatos";
            this.bnDatos.PositionItem = this.psItem;
            this.bnDatos.Size = new System.Drawing.Size(395, 31);
            this.bnDatos.TabIndex = 0;
            this.bnDatos.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Enabled = false;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(29, 28);
            this.bindingNavigatorAddNewItem.Text = "Agregar nuevo";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(48, 28);
            this.bindingNavigatorCountItem.Text = "de {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Número total de elementos";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Enabled = false;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(29, 28);
            this.bindingNavigatorDeleteItem.Text = "Eliminar";
            // 
            // btPrimero
            // 
            this.btPrimero.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btPrimero.Image = ((System.Drawing.Image)(resources.GetObject("btPrimero.Image")));
            this.btPrimero.Name = "btPrimero";
            this.btPrimero.RightToLeftAutoMirrorImage = true;
            this.btPrimero.Size = new System.Drawing.Size(29, 28);
            this.btPrimero.Text = "Mover primero";
            // 
            // btAnterior
            // 
            this.btAnterior.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btAnterior.Image = ((System.Drawing.Image)(resources.GetObject("btAnterior.Image")));
            this.btAnterior.Name = "btAnterior";
            this.btAnterior.RightToLeftAutoMirrorImage = true;
            this.btAnterior.Size = new System.Drawing.Size(29, 28);
            this.btAnterior.Text = "Mover anterior";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 31);
            // 
            // psItem
            // 
            this.psItem.AccessibleName = "Posición";
            this.psItem.AutoSize = false;
            this.psItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.psItem.Name = "psItem";
            this.psItem.ReadOnly = true;
            this.psItem.Size = new System.Drawing.Size(50, 27);
            this.psItem.Text = "0";
            this.psItem.ToolTipText = "Posición actual";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // btSiguiente
            // 
            this.btSiguiente.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btSiguiente.Image = ((System.Drawing.Image)(resources.GetObject("btSiguiente.Image")));
            this.btSiguiente.Name = "btSiguiente";
            this.btSiguiente.RightToLeftAutoMirrorImage = true;
            this.btSiguiente.Size = new System.Drawing.Size(29, 28);
            this.btSiguiente.Text = "Mover siguiente";
            // 
            // btUltimo
            // 
            this.btUltimo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btUltimo.Image = ((System.Drawing.Image)(resources.GetObject("btUltimo.Image")));
            this.btUltimo.Name = "btUltimo";
            this.btUltimo.RightToLeftAutoMirrorImage = true;
            this.btUltimo.Size = new System.Drawing.Size(29, 28);
            this.btUltimo.Text = "Mover último";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 31);
            // 
            // lbClave
            // 
            this.lbClave.AutoSize = true;
            this.lbClave.Location = new System.Drawing.Point(83, 75);
            this.lbClave.Name = "lbClave";
            this.lbClave.Size = new System.Drawing.Size(0, 16);
            this.lbClave.TabIndex = 1;
            // 
            // tbClave
            // 
            this.tbClave.Location = new System.Drawing.Point(145, 72);
            this.tbClave.Name = "tbClave";
            this.tbClave.ReadOnly = true;
            this.tbClave.Size = new System.Drawing.Size(140, 22);
            this.tbClave.TabIndex = 2;
            // 
            // FormNavig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 430);
            this.Controls.Add(this.tbClave);
            this.Controls.Add(this.lbClave);
            this.Controls.Add(this.bnDatos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormNavig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.bnDatos)).EndInit();
            this.bnDatos.ResumeLayout(false);
            this.bnDatos.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingNavigator bnDatos;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton btPrimero;
        private System.Windows.Forms.ToolStripButton btAnterior;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox psItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton btSiguiente;
        private System.Windows.Forms.ToolStripButton btUltimo;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.Label lbClave;
        private System.Windows.Forms.TextBox tbClave;
    }
}