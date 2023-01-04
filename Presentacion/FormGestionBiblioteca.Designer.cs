namespace Presentacion
{
    partial class FormGestionBiblioteca
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
            this.tsmiEjPrest = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPrestCad = new System.Windows.Forms.ToolStripMenuItem();
            this.listadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiLibros = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiEjemplares = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPrestamos = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiConfiguracion = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCerrarSes = new System.Windows.Forms.ToolStripMenuItem();
            this.búsquedaPorDNIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRecorrido = new System.Windows.Forms.ToolStripMenuItem();
            this.msPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // msPrincipal
            // 
            this.msPrincipal.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.msPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiUsuario,
            this.tsmiLibros,
            this.tsmiEjemplares,
            this.tsmiPrestamos,
            this.tsmiConfiguracion});
            this.msPrincipal.Location = new System.Drawing.Point(0, 0);
            this.msPrincipal.Name = "msPrincipal";
            this.msPrincipal.Size = new System.Drawing.Size(1067, 28);
            this.msPrincipal.TabIndex = 0;
            this.msPrincipal.Text = "menuStrip1";
            // 
            // tsmiUsuario
            // 
            this.tsmiUsuario.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAltaUsu,
            this.tsmiBajaUsu,
            this.tsmiBusqUsu,
            this.listadoToolStripMenuItem});
            this.tsmiUsuario.Name = "tsmiUsuario";
            this.tsmiUsuario.Size = new System.Drawing.Size(79, 24);
            this.tsmiUsuario.Text = "Usuarios";
            // 
            // tsmiAltaUsu
            // 
            this.tsmiAltaUsu.Name = "tsmiAltaUsu";
            this.tsmiAltaUsu.Size = new System.Drawing.Size(224, 26);
            this.tsmiAltaUsu.Text = "Alta";
            this.tsmiAltaUsu.Click += new System.EventHandler(this.tsmiAltaUsu_Click);
            // 
            // tsmiBajaUsu
            // 
            this.tsmiBajaUsu.Name = "tsmiBajaUsu";
            this.tsmiBajaUsu.Size = new System.Drawing.Size(224, 26);
            this.tsmiBajaUsu.Text = "Baja";
            this.tsmiBajaUsu.Click += new System.EventHandler(this.tsmiBajaUsu_Click);
            // 
            // tsmiBusqUsu
            // 
            this.tsmiBusqUsu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.búsquedaPorDNIToolStripMenuItem,
            this.tsmiRecorrido,
            this.tsmiEjPrest,
            this.tsmiPrestCad});
            this.tsmiBusqUsu.Name = "tsmiBusqUsu";
            this.tsmiBusqUsu.Size = new System.Drawing.Size(224, 26);
            this.tsmiBusqUsu.Text = "Búsqueda";
            this.tsmiBusqUsu.Click += new System.EventHandler(this.tsmiBusqUsu_Click);
            // 
            // tsmiEjPrest
            // 
            this.tsmiEjPrest.Name = "tsmiEjPrest";
            this.tsmiEjPrest.Size = new System.Drawing.Size(261, 26);
            this.tsmiEjPrest.Text = "Ver ejemplares prestados";
            this.tsmiEjPrest.Click += new System.EventHandler(this.tsmiEjPrest_Click);
            // 
            // tsmiPrestCad
            // 
            this.tsmiPrestCad.Name = "tsmiPrestCad";
            this.tsmiPrestCad.Size = new System.Drawing.Size(261, 26);
            this.tsmiPrestCad.Text = "Ver préstamos caducados";
            // 
            // listadoToolStripMenuItem
            // 
            this.listadoToolStripMenuItem.Name = "listadoToolStripMenuItem";
            this.listadoToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.listadoToolStripMenuItem.Text = "Listado";
            this.listadoToolStripMenuItem.Click += new System.EventHandler(this.listadoToolStripMenuItem_Click);
            // 
            // tsmiLibros
            // 
            this.tsmiLibros.Name = "tsmiLibros";
            this.tsmiLibros.Size = new System.Drawing.Size(63, 24);
            this.tsmiLibros.Text = "Libros";
            // 
            // tsmiEjemplares
            // 
            this.tsmiEjemplares.Name = "tsmiEjemplares";
            this.tsmiEjemplares.Size = new System.Drawing.Size(96, 24);
            this.tsmiEjemplares.Text = "Ejemplares";
            // 
            // tsmiPrestamos
            // 
            this.tsmiPrestamos.Name = "tsmiPrestamos";
            this.tsmiPrestamos.Size = new System.Drawing.Size(91, 24);
            this.tsmiPrestamos.Text = "Préstamos";
            // 
            // tsmiConfiguracion
            // 
            this.tsmiConfiguracion.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiCerrarSes});
            this.tsmiConfiguracion.Name = "tsmiConfiguracion";
            this.tsmiConfiguracion.Size = new System.Drawing.Size(116, 24);
            this.tsmiConfiguracion.Text = "Configuración";
            // 
            // tsmiCerrarSes
            // 
            this.tsmiCerrarSes.Name = "tsmiCerrarSes";
            this.tsmiCerrarSes.Size = new System.Drawing.Size(177, 26);
            this.tsmiCerrarSes.Text = "Cerrar sesión";
            // 
            // búsquedaPorDNIToolStripMenuItem
            // 
            this.búsquedaPorDNIToolStripMenuItem.Name = "búsquedaPorDNIToolStripMenuItem";
            this.búsquedaPorDNIToolStripMenuItem.Size = new System.Drawing.Size(261, 26);
            this.búsquedaPorDNIToolStripMenuItem.Text = "Búsqueda por DNI";
            this.búsquedaPorDNIToolStripMenuItem.Click += new System.EventHandler(this.búsquedaPorDNIToolStripMenuItem_Click);
            // 
            // tsmiRecorrido
            // 
            this.tsmiRecorrido.Name = "tsmiRecorrido";
            this.tsmiRecorrido.Size = new System.Drawing.Size(261, 26);
            this.tsmiRecorrido.Text = "Recorrido uno a uno";
            this.tsmiRecorrido.Click += new System.EventHandler(this.tsmiRecorrido_Click);
            // 
            // FormGestionBiblioteca
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.msPrincipal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.msPrincipal;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormGestionBiblioteca";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.msPrincipal.ResumeLayout(false);
            this.msPrincipal.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStripMenuItem tsmiUsuario;
        private System.Windows.Forms.ToolStripMenuItem tsmiConfiguracion;
        private System.Windows.Forms.ToolStripMenuItem tsmiAltaUsu;
        private System.Windows.Forms.ToolStripMenuItem tsmiBajaUsu;
        private System.Windows.Forms.ToolStripMenuItem tsmiBusqUsu;
        protected System.Windows.Forms.ToolStripMenuItem tsmiLibros;
        protected internal System.Windows.Forms.MenuStrip msPrincipal;
        protected System.Windows.Forms.ToolStripMenuItem tsmiEjemplares;
        private System.Windows.Forms.ToolStripMenuItem tsmiCerrarSes;
        protected System.Windows.Forms.ToolStripMenuItem tsmiPrestamos;
        private System.Windows.Forms.ToolStripMenuItem listadoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiEjPrest;
        private System.Windows.Forms.ToolStripMenuItem tsmiPrestCad;
        private System.Windows.Forms.ToolStripMenuItem búsquedaPorDNIToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiRecorrido;
    }
}

