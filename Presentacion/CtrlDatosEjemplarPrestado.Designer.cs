namespace Presentacion
{
    partial class CtrlDatosEjemplarPrestado
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbPrest = new System.Windows.Forms.Label();
            this.lbFechaDev = new System.Windows.Forms.Label();
            this.tbCodPres = new System.Windows.Forms.TextBox();
            this.tbFechaDev = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lbPrest
            // 
            this.lbPrest.AutoSize = true;
            this.lbPrest.Location = new System.Drawing.Point(57, 28);
            this.lbPrest.Name = "lbPrest";
            this.lbPrest.Size = new System.Drawing.Size(130, 16);
            this.lbPrest.TabIndex = 0;
            this.lbPrest.Text = "Código de préstamo";
            // 
            // lbFechaDev
            // 
            this.lbFechaDev.AutoSize = true;
            this.lbFechaDev.Location = new System.Drawing.Point(54, 88);
            this.lbFechaDev.Name = "lbFechaDev";
            this.lbFechaDev.Size = new System.Drawing.Size(133, 16);
            this.lbFechaDev.TabIndex = 1;
            this.lbFechaDev.Text = "Fecha de devolución";
            // 
            // tbCodPres
            // 
            this.tbCodPres.Location = new System.Drawing.Point(193, 28);
            this.tbCodPres.Name = "tbCodPres";
            this.tbCodPres.ReadOnly = true;
            this.tbCodPres.Size = new System.Drawing.Size(151, 22);
            this.tbCodPres.TabIndex = 2;
            // 
            // tbFechaDev
            // 
            this.tbFechaDev.Location = new System.Drawing.Point(193, 85);
            this.tbFechaDev.Name = "tbFechaDev";
            this.tbFechaDev.ReadOnly = true;
            this.tbFechaDev.Size = new System.Drawing.Size(151, 22);
            this.tbFechaDev.TabIndex = 3;
            // 
            // CtrlDatosEjemplarPrestado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tbFechaDev);
            this.Controls.Add(this.tbCodPres);
            this.Controls.Add(this.lbFechaDev);
            this.Controls.Add(this.lbPrest);
            this.Name = "CtrlDatosEjemplarPrestado";
            this.Size = new System.Drawing.Size(362, 136);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbPrest;
        private System.Windows.Forms.Label lbFechaDev;
        private System.Windows.Forms.TextBox tbCodPres;
        private System.Windows.Forms.TextBox tbFechaDev;
    }
}
