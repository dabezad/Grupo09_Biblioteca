namespace Presentacion
{
    partial class FormDatos
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
            this.btAceptar = new System.Windows.Forms.Button();
            this.btCancelar = new System.Windows.Forms.Button();
            this.lbClave = new System.Windows.Forms.Label();
            this.tbClave = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btAceptar
            // 
            this.btAceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btAceptar.Location = new System.Drawing.Point(120, 383);
            this.btAceptar.Margin = new System.Windows.Forms.Padding(4);
            this.btAceptar.Name = "btAceptar";
            this.btAceptar.Size = new System.Drawing.Size(100, 28);
            this.btAceptar.TabIndex = 0;
            this.btAceptar.UseVisualStyleBackColor = true;
            // 
            // btCancelar
            // 
            this.btCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancelar.Location = new System.Drawing.Point(300, 383);
            this.btCancelar.Margin = new System.Windows.Forms.Padding(4);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(100, 28);
            this.btCancelar.TabIndex = 1;
            this.btCancelar.Text = "Cancelar";
            this.btCancelar.UseVisualStyleBackColor = true;
            // 
            // lbClave
            // 
            this.lbClave.AutoSize = true;
            this.lbClave.Location = new System.Drawing.Point(153, 73);
            this.lbClave.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbClave.Name = "lbClave";
            this.lbClave.Size = new System.Drawing.Size(0, 16);
            this.lbClave.TabIndex = 2;
            // 
            // tbClave
            // 
            this.tbClave.Location = new System.Drawing.Point(210, 70);
            this.tbClave.Margin = new System.Windows.Forms.Padding(4);
            this.tbClave.Name = "tbClave";
            this.tbClave.ReadOnly = true;
            this.tbClave.Size = new System.Drawing.Size(132, 22);
            this.tbClave.TabIndex = 3;
            // 
            // FormDatos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(503, 502);
            this.Controls.Add(this.tbClave);
            this.Controls.Add(this.lbClave);
            this.Controls.Add(this.btCancelar);
            this.Controls.Add(this.btAceptar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "FormDatos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FormAlta_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btAceptar;
        private System.Windows.Forms.Button btCancelar;
        private System.Windows.Forms.Label lbClave;
        private System.Windows.Forms.TextBox tbClave;
    }
}