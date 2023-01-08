namespace Presentacion
{
    partial class CtrlDatosPersonal
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
            this.lbRol = new System.Windows.Forms.Label();
            this.tbRol = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lbRol
            // 
            this.lbRol.AutoSize = true;
            this.lbRol.Location = new System.Drawing.Point(53, 28);
            this.lbRol.Name = "lbRol";
            this.lbRol.Size = new System.Drawing.Size(28, 16);
            this.lbRol.TabIndex = 4;
            this.lbRol.Text = "Rol";
            // 
            // tbRol
            // 
            this.tbRol.Location = new System.Drawing.Point(115, 25);
            this.tbRol.Name = "tbRol";
            this.tbRol.ReadOnly = true;
            this.tbRol.Size = new System.Drawing.Size(152, 22);
            this.tbRol.TabIndex = 5;
            // 
            // CtrlDatosPersonal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tbRol);
            this.Controls.Add(this.lbRol);
            this.Name = "CtrlDatosPersonal";
            this.Size = new System.Drawing.Size(293, 79);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbRol;
        private System.Windows.Forms.TextBox tbRol;
    }
}
