namespace Presentacion
{
    partial class CtrlDatosLibRecorrido
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
            this.tbEditorial = new System.Windows.Forms.TextBox();
            this.tbAutor = new System.Windows.Forms.TextBox();
            this.tbTitulo = new System.Windows.Forms.TextBox();
            this.lbEditorial = new System.Windows.Forms.Label();
            this.lbAutor = new System.Windows.Forms.Label();
            this.lbTitulo = new System.Windows.Forms.Label();
            this.lbNumEjs = new System.Windows.Forms.Label();
            this.tbNumEjs = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tbEditorial
            // 
            this.tbEditorial.Location = new System.Drawing.Point(104, 143);
            this.tbEditorial.Name = "tbEditorial";
            this.tbEditorial.ReadOnly = true;
            this.tbEditorial.Size = new System.Drawing.Size(140, 22);
            this.tbEditorial.TabIndex = 14;
            // 
            // tbAutor
            // 
            this.tbAutor.Location = new System.Drawing.Point(104, 80);
            this.tbAutor.Name = "tbAutor";
            this.tbAutor.ReadOnly = true;
            this.tbAutor.Size = new System.Drawing.Size(140, 22);
            this.tbAutor.TabIndex = 13;
            // 
            // tbTitulo
            // 
            this.tbTitulo.Location = new System.Drawing.Point(104, 23);
            this.tbTitulo.Name = "tbTitulo";
            this.tbTitulo.ReadOnly = true;
            this.tbTitulo.Size = new System.Drawing.Size(140, 22);
            this.tbTitulo.TabIndex = 12;
            // 
            // lbEditorial
            // 
            this.lbEditorial.AutoSize = true;
            this.lbEditorial.Location = new System.Drawing.Point(40, 146);
            this.lbEditorial.Name = "lbEditorial";
            this.lbEditorial.Size = new System.Drawing.Size(56, 16);
            this.lbEditorial.TabIndex = 11;
            this.lbEditorial.Text = "Editorial";
            // 
            // lbAutor
            // 
            this.lbAutor.AutoSize = true;
            this.lbAutor.Location = new System.Drawing.Point(42, 83);
            this.lbAutor.Name = "lbAutor";
            this.lbAutor.Size = new System.Drawing.Size(38, 16);
            this.lbAutor.TabIndex = 10;
            this.lbAutor.Text = "Autor";
            // 
            // lbTitulo
            // 
            this.lbTitulo.AutoSize = true;
            this.lbTitulo.Location = new System.Drawing.Point(40, 28);
            this.lbTitulo.Name = "lbTitulo";
            this.lbTitulo.Size = new System.Drawing.Size(40, 16);
            this.lbTitulo.TabIndex = 9;
            this.lbTitulo.Text = "Titulo";
            // 
            // lbNumEjs
            // 
            this.lbNumEjs.AutoSize = true;
            this.lbNumEjs.Location = new System.Drawing.Point(3, 206);
            this.lbNumEjs.Name = "lbNumEjs";
            this.lbNumEjs.Size = new System.Drawing.Size(93, 16);
            this.lbNumEjs.TabIndex = 15;
            this.lbNumEjs.Text = "Nº ejemplares";
            // 
            // tbNumEjs
            // 
            this.tbNumEjs.Location = new System.Drawing.Point(104, 203);
            this.tbNumEjs.Name = "tbNumEjs";
            this.tbNumEjs.ReadOnly = true;
            this.tbNumEjs.Size = new System.Drawing.Size(140, 22);
            this.tbNumEjs.TabIndex = 16;
            // 
            // CtrlDatosLibRecorrido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tbNumEjs);
            this.Controls.Add(this.lbNumEjs);
            this.Controls.Add(this.tbEditorial);
            this.Controls.Add(this.tbAutor);
            this.Controls.Add(this.tbTitulo);
            this.Controls.Add(this.lbEditorial);
            this.Controls.Add(this.lbAutor);
            this.Controls.Add(this.lbTitulo);
            this.Name = "CtrlDatosLibRecorrido";
            this.Size = new System.Drawing.Size(272, 262);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbEditorial;
        private System.Windows.Forms.TextBox tbAutor;
        private System.Windows.Forms.TextBox tbTitulo;
        private System.Windows.Forms.Label lbEditorial;
        private System.Windows.Forms.Label lbAutor;
        private System.Windows.Forms.Label lbTitulo;
        private System.Windows.Forms.Label lbNumEjs;
        private System.Windows.Forms.TextBox tbNumEjs;
    }
}
