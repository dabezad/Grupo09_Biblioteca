namespace Presentacion
{
    partial class FormListadoUsu
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
            this.lbClave = new System.Windows.Forms.ListBox();
            this.bsClaves = new System.Windows.Forms.BindingSource(this.components);
            this.lbDato = new System.Windows.Forms.ListBox();
            this.bsDatos = new System.Windows.Forms.BindingSource(this.components);
            this.btOrdClave = new System.Windows.Forms.Button();
            this.btOrdDato = new System.Windows.Forms.Button();
            this.btCerrar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bsClaves)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // lbClave
            // 
            this.lbClave.DataSource = this.bsClaves;
            this.lbClave.FormattingEnabled = true;
            this.lbClave.ItemHeight = 16;
            this.lbClave.Location = new System.Drawing.Point(72, 115);
            this.lbClave.Name = "lbClave";
            this.lbClave.Size = new System.Drawing.Size(160, 228);
            this.lbClave.TabIndex = 0;
            // 
            // bsClaves
            // 
            this.bsClaves.DataSource = typeof(LogicaNegocio.LNBiblioteca);
            // 
            // lbDato
            // 
            this.lbDato.DataSource = this.bsDatos;
            this.lbDato.FormattingEnabled = true;
            this.lbDato.ItemHeight = 16;
            this.lbDato.Location = new System.Drawing.Point(427, 115);
            this.lbDato.Name = "lbDato";
            this.lbDato.Size = new System.Drawing.Size(160, 228);
            this.lbDato.TabIndex = 1;
            // 
            // bsDatos
            // 
            this.bsDatos.DataSource = typeof(LogicaNegocio.LNBiblioteca);
            // 
            // btOrdClave
            // 
            this.btOrdClave.Location = new System.Drawing.Point(72, 60);
            this.btOrdClave.Name = "btOrdClave";
            this.btOrdClave.Size = new System.Drawing.Size(160, 37);
            this.btOrdClave.TabIndex = 2;
            this.btOrdClave.Text = "DNI";
            this.btOrdClave.UseVisualStyleBackColor = true;
            this.btOrdClave.Click += new System.EventHandler(this.btOrdClave_Click);
            // 
            // btOrdDato
            // 
            this.btOrdDato.Location = new System.Drawing.Point(427, 60);
            this.btOrdDato.Name = "btOrdDato";
            this.btOrdDato.Size = new System.Drawing.Size(160, 37);
            this.btOrdDato.TabIndex = 3;
            this.btOrdDato.Text = "Nombre";
            this.btOrdDato.UseVisualStyleBackColor = true;
            this.btOrdDato.Click += new System.EventHandler(this.btOrdDato_Click);
            // 
            // btCerrar
            // 
            this.btCerrar.Location = new System.Drawing.Point(290, 375);
            this.btCerrar.Name = "btCerrar";
            this.btCerrar.Size = new System.Drawing.Size(75, 30);
            this.btCerrar.TabIndex = 4;
            this.btCerrar.Text = "Cerrar";
            this.btCerrar.UseVisualStyleBackColor = true;
            this.btCerrar.Click += new System.EventHandler(this.btCerrar_Click);
            // 
            // FormListadoUsu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 450);
            this.Controls.Add(this.btCerrar);
            this.Controls.Add(this.btOrdDato);
            this.Controls.Add(this.btOrdClave);
            this.Controls.Add(this.lbDato);
            this.Controls.Add(this.lbClave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormListadoUsu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listado de usuarios";
            this.Load += new System.EventHandler(this.FormListadoUsu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsClaves)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDatos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbClave;
        private System.Windows.Forms.ListBox lbDato;
        private System.Windows.Forms.BindingSource bsClaves;
        private System.Windows.Forms.BindingSource bsDatos;
        private System.Windows.Forms.Button btOrdClave;
        private System.Windows.Forms.Button btOrdDato;
        private System.Windows.Forms.Button btCerrar;
    }
}