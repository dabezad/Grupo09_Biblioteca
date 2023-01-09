namespace Presentacion
{
    partial class CtrlDatosEjBusq
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
            this.cbEstadoEj = new System.Windows.Forms.ComboBox();
            this.tbIsbn = new System.Windows.Forms.TextBox();
            this.lbEstado = new System.Windows.Forms.Label();
            this.lbIsbn = new System.Windows.Forms.Label();
            this.btVerLibro = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbEstadoEj
            // 
            this.cbEstadoEj.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEstadoEj.Enabled = false;
            this.cbEstadoEj.FormattingEnabled = true;
            this.cbEstadoEj.Items.AddRange(new object[] {
            "Disponible",
            "Prestado"});
            this.cbEstadoEj.Location = new System.Drawing.Point(150, 90);
            this.cbEstadoEj.Name = "cbEstadoEj";
            this.cbEstadoEj.Size = new System.Drawing.Size(132, 24);
            this.cbEstadoEj.TabIndex = 9;
            // 
            // tbIsbn
            // 
            this.tbIsbn.Location = new System.Drawing.Point(150, 28);
            this.tbIsbn.Name = "tbIsbn";
            this.tbIsbn.ReadOnly = true;
            this.tbIsbn.Size = new System.Drawing.Size(132, 22);
            this.tbIsbn.TabIndex = 8;
            // 
            // lbEstado
            // 
            this.lbEstado.AutoSize = true;
            this.lbEstado.Location = new System.Drawing.Point(85, 93);
            this.lbEstado.Name = "lbEstado";
            this.lbEstado.Size = new System.Drawing.Size(50, 16);
            this.lbEstado.TabIndex = 7;
            this.lbEstado.Text = "Estado";
            // 
            // lbIsbn
            // 
            this.lbIsbn.AutoSize = true;
            this.lbIsbn.Location = new System.Drawing.Point(55, 31);
            this.lbIsbn.Name = "lbIsbn";
            this.lbIsbn.Size = new System.Drawing.Size(80, 16);
            this.lbIsbn.TabIndex = 6;
            this.lbIsbn.Text = "Isbn de libro";
            // 
            // btVerLibro
            // 
            this.btVerLibro.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.btVerLibro.Location = new System.Drawing.Point(235, 148);
            this.btVerLibro.Name = "btVerLibro";
            this.btVerLibro.Size = new System.Drawing.Size(103, 42);
            this.btVerLibro.TabIndex = 10;
            this.btVerLibro.Text = "Ver libro";
            this.btVerLibro.UseVisualStyleBackColor = true;
            // 
            // CtrlDatosEjBusq
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btVerLibro);
            this.Controls.Add(this.cbEstadoEj);
            this.Controls.Add(this.tbIsbn);
            this.Controls.Add(this.lbEstado);
            this.Controls.Add(this.lbIsbn);
            this.Name = "CtrlDatosEjBusq";
            this.Size = new System.Drawing.Size(388, 225);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbEstadoEj;
        private System.Windows.Forms.TextBox tbIsbn;
        private System.Windows.Forms.Label lbEstado;
        private System.Windows.Forms.Label lbIsbn;
        private System.Windows.Forms.Button btVerLibro;
    }
}
