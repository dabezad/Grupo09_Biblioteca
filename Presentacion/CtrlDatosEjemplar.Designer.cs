namespace Presentacion
{
    partial class CtrlDatosEjemplar
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
            this.lbCodigo = new System.Windows.Forms.Label();
            this.lbEstado = new System.Windows.Forms.Label();
            this.tbCodigo = new System.Windows.Forms.TextBox();
            this.cbEstadoEj = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lbCodigo
            // 
            this.lbCodigo.AutoSize = true;
            this.lbCodigo.Location = new System.Drawing.Point(53, 28);
            this.lbCodigo.Name = "lbCodigo";
            this.lbCodigo.Size = new System.Drawing.Size(51, 16);
            this.lbCodigo.TabIndex = 0;
            this.lbCodigo.Text = "Codigo";
            // 
            // lbEstado
            // 
            this.lbEstado.AutoSize = true;
            this.lbEstado.Location = new System.Drawing.Point(53, 88);
            this.lbEstado.Name = "lbEstado";
            this.lbEstado.Size = new System.Drawing.Size(50, 16);
            this.lbEstado.TabIndex = 1;
            this.lbEstado.Text = "Estado";
            // 
            // tbCodigo
            // 
            this.tbCodigo.Location = new System.Drawing.Point(115, 25);
            this.tbCodigo.Name = "tbCodigo";
            this.tbCodigo.Size = new System.Drawing.Size(132, 22);
            this.tbCodigo.TabIndex = 3;
            // 
            // cbEstadoEj
            // 
            this.cbEstadoEj.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEstadoEj.FormattingEnabled = true;
            this.cbEstadoEj.Items.AddRange(new object[] {
            "Disponible",
            "Prestado"});
            this.cbEstadoEj.Location = new System.Drawing.Point(115, 85);
            this.cbEstadoEj.Name = "cbEstadoEj";
            this.cbEstadoEj.Size = new System.Drawing.Size(132, 24);
            this.cbEstadoEj.TabIndex = 5;
            // 
            // CtrlDatosEjemplar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbEstadoEj);
            this.Controls.Add(this.tbCodigo);
            this.Controls.Add(this.lbEstado);
            this.Controls.Add(this.lbCodigo);
            this.Name = "CtrlDatosEjemplar";
            this.Size = new System.Drawing.Size(301, 143);
            this.Load += new System.EventHandler(this.CtrlDatosEjemplar_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbCodigo;
        private System.Windows.Forms.Label lbEstado;
        private System.Windows.Forms.TextBox tbCodigo;
        private System.Windows.Forms.ComboBox cbEstadoEj;
    }
}
