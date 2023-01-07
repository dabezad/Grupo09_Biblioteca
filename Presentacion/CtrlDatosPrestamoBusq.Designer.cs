namespace Presentacion
{
    partial class CtrlDatosPrestamoBusq
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
            this.lbusuario = new System.Windows.Forms.Label();
            this.lbejemplares = new System.Windows.Forms.Label();
            this.lbfecharealizado = new System.Windows.Forms.Label();
            this.lbfechadevolucion = new System.Windows.Forms.Label();
            this.tbusuario = new System.Windows.Forms.TextBox();
            this.tbfecha = new System.Windows.Forms.TextBox();
            this.tbdevolucion = new System.Windows.Forms.TextBox();
            this.btejemplares = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbusuario
            // 
            this.lbusuario.AutoSize = true;
            this.lbusuario.Location = new System.Drawing.Point(16, 33);
            this.lbusuario.Name = "lbusuario";
            this.lbusuario.Size = new System.Drawing.Size(43, 13);
            this.lbusuario.TabIndex = 2;
            this.lbusuario.Text = "Usuario";
            // 
            // lbejemplares
            // 
            this.lbejemplares.AutoSize = true;
            this.lbejemplares.Location = new System.Drawing.Point(16, 63);
            this.lbejemplares.Name = "lbejemplares";
            this.lbejemplares.Size = new System.Drawing.Size(58, 13);
            this.lbejemplares.TabIndex = 3;
            this.lbejemplares.Text = "Ejemplares";
            // 
            // lbfecharealizado
            // 
            this.lbfecharealizado.AutoSize = true;
            this.lbfecharealizado.Location = new System.Drawing.Point(16, 92);
            this.lbfecharealizado.Name = "lbfecharealizado";
            this.lbfecharealizado.Size = new System.Drawing.Size(37, 13);
            this.lbfecharealizado.TabIndex = 4;
            this.lbfecharealizado.Text = "Fecha";
            // 
            // lbfechadevolucion
            // 
            this.lbfechadevolucion.AutoSize = true;
            this.lbfechadevolucion.Location = new System.Drawing.Point(16, 122);
            this.lbfechadevolucion.Name = "lbfechadevolucion";
            this.lbfechadevolucion.Size = new System.Drawing.Size(61, 13);
            this.lbfechadevolucion.TabIndex = 5;
            this.lbfechadevolucion.Text = "Devolución";
            // 
            // tbusuario
            // 
            this.tbusuario.Location = new System.Drawing.Point(88, 30);
            this.tbusuario.Name = "tbusuario";
            this.tbusuario.ReadOnly = true;
            this.tbusuario.Size = new System.Drawing.Size(100, 20);
            this.tbusuario.TabIndex = 6;
            // 
            // tbfecha
            // 
            this.tbfecha.Location = new System.Drawing.Point(88, 89);
            this.tbfecha.Name = "tbfecha";
            this.tbfecha.ReadOnly = true;
            this.tbfecha.Size = new System.Drawing.Size(100, 20);
            this.tbfecha.TabIndex = 7;
            // 
            // tbdevolucion
            // 
            this.tbdevolucion.Location = new System.Drawing.Point(88, 119);
            this.tbdevolucion.Name = "tbdevolucion";
            this.tbdevolucion.ReadOnly = true;
            this.tbdevolucion.Size = new System.Drawing.Size(100, 20);
            this.tbdevolucion.TabIndex = 9;
            // 
            // btejemplares
            // 
            this.btejemplares.Location = new System.Drawing.Point(88, 60);
            this.btejemplares.Name = "btejemplares";
            this.btejemplares.Size = new System.Drawing.Size(100, 23);
            this.btejemplares.TabIndex = 10;
            this.btejemplares.Text = "Ver ejemplares";
            this.btejemplares.UseVisualStyleBackColor = true;
            // 
            // CtrlDatosPrestamoBusq
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btejemplares);
            this.Controls.Add(this.tbdevolucion);
            this.Controls.Add(this.tbfecha);
            this.Controls.Add(this.tbusuario);
            this.Controls.Add(this.lbfechadevolucion);
            this.Controls.Add(this.lbfecharealizado);
            this.Controls.Add(this.lbejemplares);
            this.Controls.Add(this.lbusuario);
            this.Name = "CtrlDatosPrestamoBusq";
            this.Size = new System.Drawing.Size(225, 222);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbusuario;
        private System.Windows.Forms.Label lbejemplares;
        private System.Windows.Forms.Label lbfecharealizado;
        private System.Windows.Forms.Label lbfechadevolucion;
        private System.Windows.Forms.TextBox tbusuario;
        private System.Windows.Forms.TextBox tbfecha;
        private System.Windows.Forms.TextBox tbdevolucion;
        private System.Windows.Forms.Button btejemplares;
    }
}
