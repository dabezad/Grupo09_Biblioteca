﻿namespace Presentacion
{
    partial class FormListPrestEnProc
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dgPrestEnProceso = new System.Windows.Forms.DataGridView();
            this.bsDatos = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgPrestEnProceso)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // dgPrestEnProceso
            // 
            this.dgPrestEnProceso.AllowUserToDeleteRows = false;
            this.dgPrestEnProceso.AutoGenerateColumns = false;
            this.dgPrestEnProceso.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPrestEnProceso.DataSource = this.bsDatos;
            this.dgPrestEnProceso.Location = new System.Drawing.Point(12, 12);
            this.dgPrestEnProceso.Name = "dgPrestEnProceso";
            this.dgPrestEnProceso.RowHeadersWidth = 51;
            this.dgPrestEnProceso.RowTemplate.Height = 24;
            this.dgPrestEnProceso.Size = new System.Drawing.Size(776, 147);
            this.dgPrestEnProceso.TabIndex = 0;
            // 
            // bsDatos
            // 
            this.bsDatos.DataSource = typeof(LogicaNegocio.LNBiblioteca);
            // 
            // FormListPrestEnProc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgPrestEnProceso);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormListPrestEnProc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listado de préstamos en proceso";
            this.Load += new System.EventHandler(this.FormListPrestEnProc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgPrestEnProceso)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDatos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgPrestEnProceso;
        private System.Windows.Forms.BindingSource bsDatos;
    }
}