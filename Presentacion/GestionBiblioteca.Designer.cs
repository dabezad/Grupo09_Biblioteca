namespace Presentacion
{
    partial class GestionBiblioteca
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

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.msPrincipal = new System.Windows.Forms.MenuStrip();
            this.tsmiUsuario = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAltaUsu = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiBajaUsu = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiBusqUsu = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiLibros = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAltaLib = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiBajaLib = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiBusqLib = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiEjemplares = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPrestamos = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiConfiguracion = new System.Windows.Forms.ToolStripMenuItem();
            this.msPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // msPrincipal
            // 
            this.msPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiUsuario,
            this.tsmiLibros,
            this.tsmiEjemplares,
            this.tsmiPrestamos,
            this.tsmiConfiguracion});
            this.msPrincipal.Location = new System.Drawing.Point(0, 0);
            this.msPrincipal.Name = "msPrincipal";
            this.msPrincipal.Size = new System.Drawing.Size(800, 24);
            this.msPrincipal.TabIndex = 0;
            this.msPrincipal.Text = "menuStrip1";
            // 
            // tsmiUsuario
            // 
            this.tsmiUsuario.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAltaUsu,
            this.tsmiBajaUsu,
            this.tsmiBusqUsu});
            this.tsmiUsuario.Name = "tsmiUsuario";
            this.tsmiUsuario.Size = new System.Drawing.Size(64, 20);
            this.tsmiUsuario.Text = "Usuarios";
            // 
            // tsmiAltaUsu
            // 
            this.tsmiAltaUsu.Name = "tsmiAltaUsu";
            this.tsmiAltaUsu.Size = new System.Drawing.Size(180, 22);
            this.tsmiAltaUsu.Text = "Alta";
            this.tsmiAltaUsu.Click += new System.EventHandler(this.tsmiAltaUsu_Click);
            // 
            // tsmiBajaUsu
            // 
            this.tsmiBajaUsu.Name = "tsmiBajaUsu";
            this.tsmiBajaUsu.Size = new System.Drawing.Size(180, 22);
            this.tsmiBajaUsu.Text = "Baja";
            // 
            // tsmiBusqUsu
            // 
            this.tsmiBusqUsu.Name = "tsmiBusqUsu";
            this.tsmiBusqUsu.Size = new System.Drawing.Size(180, 22);
            this.tsmiBusqUsu.Text = "Búsqueda";
            // 
            // tsmiLibros
            // 
            this.tsmiLibros.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAltaLib,
            this.tsmiBajaLib,
            this.tsmiBusqLib});
            this.tsmiLibros.Name = "tsmiLibros";
            this.tsmiLibros.Size = new System.Drawing.Size(51, 20);
            this.tsmiLibros.Text = "Libros";
            // 
            // tsmiAltaLib
            // 
            this.tsmiAltaLib.Name = "tsmiAltaLib";
            this.tsmiAltaLib.Size = new System.Drawing.Size(126, 22);
            this.tsmiAltaLib.Text = "Alta";
            // 
            // tsmiBajaLib
            // 
            this.tsmiBajaLib.Name = "tsmiBajaLib";
            this.tsmiBajaLib.Size = new System.Drawing.Size(126, 22);
            this.tsmiBajaLib.Text = "Baja";
            // 
            // tsmiBusqLib
            // 
            this.tsmiBusqLib.Name = "tsmiBusqLib";
            this.tsmiBusqLib.Size = new System.Drawing.Size(126, 22);
            this.tsmiBusqLib.Text = "Búsqueda";
            // 
            // tsmiEjemplares
            // 
            this.tsmiEjemplares.Name = "tsmiEjemplares";
            this.tsmiEjemplares.Size = new System.Drawing.Size(76, 20);
            this.tsmiEjemplares.Text = "Ejemplares";
            this.tsmiEjemplares.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // tsmiPrestamos
            // 
            this.tsmiPrestamos.Name = "tsmiPrestamos";
            this.tsmiPrestamos.Size = new System.Drawing.Size(74, 20);
            this.tsmiPrestamos.Text = "Préstamos";
            // 
            // tsmiConfiguracion
            // 
            this.tsmiConfiguracion.Name = "tsmiConfiguracion";
            this.tsmiConfiguracion.Size = new System.Drawing.Size(95, 20);
            this.tsmiConfiguracion.Text = "Configuración";
            // 
            // GestionBiblioteca
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.msPrincipal);
            this.MainMenuStrip = this.msPrincipal;
            this.Name = "GestionBiblioteca";
            this.Text = "Gestion de biblioteca";
            this.msPrincipal.ResumeLayout(false);
            this.msPrincipal.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msPrincipal;
        private System.Windows.Forms.ToolStripMenuItem tsmiUsuario;
        private System.Windows.Forms.ToolStripMenuItem tsmiLibros;
        private System.Windows.Forms.ToolStripMenuItem tsmiEjemplares;
        private System.Windows.Forms.ToolStripMenuItem tsmiPrestamos;
        private System.Windows.Forms.ToolStripMenuItem tsmiConfiguracion;
        private System.Windows.Forms.ToolStripMenuItem tsmiAltaUsu;
        private System.Windows.Forms.ToolStripMenuItem tsmiBajaUsu;
        private System.Windows.Forms.ToolStripMenuItem tsmiBusqUsu;
        private System.Windows.Forms.ToolStripMenuItem tsmiAltaLib;
        private System.Windows.Forms.ToolStripMenuItem tsmiBajaLib;
        private System.Windows.Forms.ToolStripMenuItem tsmiBusqLib;
    }
}

