namespace Presentacion
{
    partial class FormBusqPorClave
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
            this.lbClave = new System.Windows.Forms.Label();
            this.cbClave = new System.Windows.Forms.ComboBox();
            this.btCerrar = new System.Windows.Forms.Button();
            this.bsClave = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bsClave)).BeginInit();
            this.SuspendLayout();
            // 
            // lbClave
            // 
            this.lbClave.AutoSize = true;
            this.lbClave.Location = new System.Drawing.Point(153, 73);
            this.lbClave.Name = "lbClave";
            this.lbClave.Size = new System.Drawing.Size(0, 16);
            this.lbClave.TabIndex = 0;
            // 
            // cbClave
            // 
            this.cbClave.DataSource = this.bsClave;
            this.cbClave.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbClave.FormattingEnabled = true;
            this.cbClave.Location = new System.Drawing.Point(210, 70);
            this.cbClave.Name = "cbClave";
            this.cbClave.Size = new System.Drawing.Size(178, 24);
            this.cbClave.TabIndex = 1;
            // 
            // btCerrar
            // 
            this.btCerrar.Location = new System.Drawing.Point(210, 253);
            this.btCerrar.Name = "btCerrar";
            this.btCerrar.Size = new System.Drawing.Size(80, 30);
            this.btCerrar.TabIndex = 2;
            this.btCerrar.Text = "Cerrar";
            this.btCerrar.UseVisualStyleBackColor = true;
            this.btCerrar.Click += new System.EventHandler(this.btCerrar_Click);
            // 
            // bsClave
            // 
            this.bsClave.DataSource = typeof(LogicaNegocio.LNSala);
            // 
            // FormBusqPorClave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 335);
            this.Controls.Add(this.btCerrar);
            this.Controls.Add(this.cbClave);
            this.Controls.Add(this.lbClave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormBusqPorClave";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.bsClave)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbClave;
        private System.Windows.Forms.ComboBox cbClave;
        private System.Windows.Forms.Button btCerrar;
        private System.Windows.Forms.BindingSource bsClave;
    }
}