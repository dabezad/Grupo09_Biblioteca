namespace Presentacion
{
    partial class CtrlRegistroPersonal
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
            this.lbNombre = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbNombre = new System.Windows.Forms.TextBox();
            this.tbContraseña = new System.Windows.Forms.TextBox();
            this.cbRol = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lbNombre
            // 
            this.lbNombre.AutoSize = true;
            this.lbNombre.Location = new System.Drawing.Point(53, 28);
            this.lbNombre.Name = "lbNombre";
            this.lbNombre.Size = new System.Drawing.Size(56, 16);
            this.lbNombre.TabIndex = 0;
            this.lbNombre.Text = "Nombre";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Contraseña";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(53, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Rol";
            // 
            // tbNombre
            // 
            this.tbNombre.Location = new System.Drawing.Point(115, 28);
            this.tbNombre.Name = "tbNombre";
            this.tbNombre.Size = new System.Drawing.Size(121, 22);
            this.tbNombre.TabIndex = 3;
            // 
            // tbContraseña
            // 
            this.tbContraseña.Location = new System.Drawing.Point(115, 85);
            this.tbContraseña.Name = "tbContraseña";
            this.tbContraseña.PasswordChar = '*';
            this.tbContraseña.Size = new System.Drawing.Size(121, 22);
            this.tbContraseña.TabIndex = 4;
            // 
            // cbRol
            // 
            this.cbRol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRol.FormattingEnabled = true;
            this.cbRol.Items.AddRange(new object[] {
            "Personal de adquisiciones",
            "Personal de sala"});
            this.cbRol.Location = new System.Drawing.Point(87, 145);
            this.cbRol.Name = "cbRol";
            this.cbRol.Size = new System.Drawing.Size(216, 24);
            this.cbRol.TabIndex = 5;
            // 
            // CtrlRegistroPersonal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbRol);
            this.Controls.Add(this.tbContraseña);
            this.Controls.Add(this.tbNombre);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbNombre);
            this.Name = "CtrlRegistroPersonal";
            this.Size = new System.Drawing.Size(352, 228);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbNombre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbNombre;
        private System.Windows.Forms.TextBox tbContraseña;
        private System.Windows.Forms.ComboBox cbRol;
    }
}
