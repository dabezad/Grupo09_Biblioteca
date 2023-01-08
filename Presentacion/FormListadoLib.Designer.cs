namespace Presentacion
{
    partial class FormListadoLib
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
            this.btCerrar = new System.Windows.Forms.Button();
            this.btOrdTit = new System.Windows.Forms.Button();
            this.btOrdClave = new System.Windows.Forms.Button();
            this.lbTitulo = new System.Windows.Forms.ListBox();
            this.bsTit = new System.Windows.Forms.BindingSource(this.components);
            this.lbClave = new System.Windows.Forms.ListBox();
            this.bsClave = new System.Windows.Forms.BindingSource(this.components);
            this.lbAutor = new System.Windows.Forms.ListBox();
            this.bsAut = new System.Windows.Forms.BindingSource(this.components);
            this.lbEditorial = new System.Windows.Forms.ListBox();
            this.bsEdi = new System.Windows.Forms.BindingSource(this.components);
            this.btOrdAut = new System.Windows.Forms.Button();
            this.btOrdEdit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bsTit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsClave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsEdi)).BeginInit();
            this.SuspendLayout();
            // 
            // btCerrar
            // 
            this.btCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCerrar.Location = new System.Drawing.Point(461, 356);
            this.btCerrar.Name = "btCerrar";
            this.btCerrar.Size = new System.Drawing.Size(82, 32);
            this.btCerrar.TabIndex = 9;
            this.btCerrar.Text = "Cerrar";
            this.btCerrar.UseVisualStyleBackColor = true;
            // 
            // btOrdTit
            // 
            this.btOrdTit.Location = new System.Drawing.Point(292, 42);
            this.btOrdTit.Name = "btOrdTit";
            this.btOrdTit.Size = new System.Drawing.Size(170, 37);
            this.btOrdTit.TabIndex = 8;
            this.btOrdTit.Text = "Titulo";
            this.btOrdTit.UseVisualStyleBackColor = true;
            this.btOrdTit.Click += new System.EventHandler(this.btOrdTit_Click);
            // 
            // btOrdClave
            // 
            this.btOrdClave.Location = new System.Drawing.Point(41, 42);
            this.btOrdClave.Name = "btOrdClave";
            this.btOrdClave.Size = new System.Drawing.Size(170, 37);
            this.btOrdClave.TabIndex = 7;
            this.btOrdClave.Text = "ISBN";
            this.btOrdClave.UseVisualStyleBackColor = true;
            this.btOrdClave.Click += new System.EventHandler(this.btOrdClave_Click);
            // 
            // lbTitulo
            // 
            this.lbTitulo.DataSource = this.bsTit;
            this.lbTitulo.FormattingEnabled = true;
            this.lbTitulo.ItemHeight = 16;
            this.lbTitulo.Location = new System.Drawing.Point(292, 97);
            this.lbTitulo.Name = "lbTitulo";
            this.lbTitulo.Size = new System.Drawing.Size(170, 228);
            this.lbTitulo.TabIndex = 6;
            // 
            // lbClave
            // 
            this.lbClave.DataSource = this.bsClave;
            this.lbClave.FormattingEnabled = true;
            this.lbClave.ItemHeight = 16;
            this.lbClave.Location = new System.Drawing.Point(41, 97);
            this.lbClave.Name = "lbClave";
            this.lbClave.Size = new System.Drawing.Size(170, 228);
            this.lbClave.TabIndex = 5;
            // 
            // lbAutor
            // 
            this.lbAutor.DataSource = this.bsAut;
            this.lbAutor.FormattingEnabled = true;
            this.lbAutor.ItemHeight = 16;
            this.lbAutor.Location = new System.Drawing.Point(543, 97);
            this.lbAutor.Name = "lbAutor";
            this.lbAutor.Size = new System.Drawing.Size(170, 228);
            this.lbAutor.TabIndex = 10;
            // 
            // lbEditorial
            // 
            this.lbEditorial.DataSource = this.bsEdi;
            this.lbEditorial.FormattingEnabled = true;
            this.lbEditorial.ItemHeight = 16;
            this.lbEditorial.Location = new System.Drawing.Point(788, 97);
            this.lbEditorial.Name = "lbEditorial";
            this.lbEditorial.Size = new System.Drawing.Size(170, 228);
            this.lbEditorial.TabIndex = 11;
            // 
            // btOrdAut
            // 
            this.btOrdAut.Location = new System.Drawing.Point(543, 42);
            this.btOrdAut.Name = "btOrdAut";
            this.btOrdAut.Size = new System.Drawing.Size(170, 37);
            this.btOrdAut.TabIndex = 12;
            this.btOrdAut.Text = "Autor";
            this.btOrdAut.UseVisualStyleBackColor = true;
            this.btOrdAut.Click += new System.EventHandler(this.btOrdAut_Click);
            // 
            // btOrdEdit
            // 
            this.btOrdEdit.Location = new System.Drawing.Point(788, 41);
            this.btOrdEdit.Name = "btOrdEdit";
            this.btOrdEdit.Size = new System.Drawing.Size(170, 38);
            this.btOrdEdit.TabIndex = 13;
            this.btOrdEdit.Text = "Editorial";
            this.btOrdEdit.UseVisualStyleBackColor = true;
            this.btOrdEdit.Click += new System.EventHandler(this.btOrdEdit_Click);
            // 
            // FormListadoLib
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1003, 413);
            this.Controls.Add(this.btOrdEdit);
            this.Controls.Add(this.btOrdAut);
            this.Controls.Add(this.lbEditorial);
            this.Controls.Add(this.lbAutor);
            this.Controls.Add(this.btCerrar);
            this.Controls.Add(this.btOrdTit);
            this.Controls.Add(this.btOrdClave);
            this.Controls.Add(this.lbTitulo);
            this.Controls.Add(this.lbClave);
            this.Name = "FormListadoLib";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listado de libros";
            this.Load += new System.EventHandler(this.FormListadoLib_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsTit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsClave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsEdi)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btCerrar;
        private System.Windows.Forms.Button btOrdTit;
        private System.Windows.Forms.Button btOrdClave;
        private System.Windows.Forms.ListBox lbTitulo;
        private System.Windows.Forms.ListBox lbClave;
        private System.Windows.Forms.BindingSource bsClave;
        private System.Windows.Forms.BindingSource bsTit;
        private System.Windows.Forms.ListBox lbAutor;
        private System.Windows.Forms.ListBox lbEditorial;
        private System.Windows.Forms.Button btOrdAut;
        private System.Windows.Forms.Button btOrdEdit;
        private System.Windows.Forms.BindingSource bsAut;
        private System.Windows.Forms.BindingSource bsEdi;
    }
}