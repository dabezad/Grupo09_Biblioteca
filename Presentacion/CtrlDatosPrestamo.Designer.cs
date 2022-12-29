namespace Presentacion
{
    partial class CtrlDatosPrestamo
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
            this.lbUsuario = new System.Windows.Forms.Label();
            this.btEjsPres = new System.Windows.Forms.Button();
            this.tbUsuario = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lbUsuario
            // 
            this.lbUsuario.AutoSize = true;
            this.lbUsuario.Location = new System.Drawing.Point(53, 28);
            this.lbUsuario.Name = "lbUsuario";
            this.lbUsuario.Size = new System.Drawing.Size(54, 32);
            this.lbUsuario.TabIndex = 0;
            this.lbUsuario.Text = "Usuario\r\n  (DNI)";
            // 
            // btEjsPres
            // 
            this.btEjsPres.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btEjsPres.Enabled = false;
            this.btEjsPres.Location = new System.Drawing.Point(200, 145);
            this.btEjsPres.Name = "btEjsPres";
            this.btEjsPres.Size = new System.Drawing.Size(100, 53);
            this.btEjsPres.TabIndex = 1;
            this.btEjsPres.Text = "Añadir ejemplares";
            this.btEjsPres.UseVisualStyleBackColor = true;
            // 
            // tbUsuario
            // 
            this.tbUsuario.Location = new System.Drawing.Point(115, 25);
            this.tbUsuario.Name = "tbUsuario";
            this.tbUsuario.Size = new System.Drawing.Size(132, 22);
            this.tbUsuario.TabIndex = 2;
            // 
            // CtrlDatosPrestamo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tbUsuario);
            this.Controls.Add(this.btEjsPres);
            this.Controls.Add(this.lbUsuario);
            this.Name = "CtrlDatosPrestamo";
            this.Size = new System.Drawing.Size(364, 253);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbUsuario;
        private System.Windows.Forms.Button btEjsPres;
        private System.Windows.Forms.TextBox tbUsuario;
    }
}
