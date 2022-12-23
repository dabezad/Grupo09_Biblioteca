namespace Presentacion
{
    partial class FormClave
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
            this.lbClave = new System.Windows.Forms.Label();
            this.tbClave = new System.Windows.Forms.TextBox();
            this.btAceptar = new System.Windows.Forms.Button();
            this.btCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbClave
            // 
            this.lbClave.AutoSize = true;
            this.lbClave.Location = new System.Drawing.Point(170, 73);
            this.lbClave.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbClave.Name = "lbClave";
            this.lbClave.Size = new System.Drawing.Size(0, 16);
            this.lbClave.TabIndex = 0;
            // 
            // tbClave
            // 
            this.tbClave.Location = new System.Drawing.Point(210, 70);
            this.tbClave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbClave.Name = "tbClave";
            this.tbClave.Size = new System.Drawing.Size(132, 22);
            this.tbClave.TabIndex = 2;
            // 
            // btAceptar
            // 
            this.btAceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btAceptar.Location = new System.Drawing.Point(92, 240);
            this.btAceptar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btAceptar.Name = "btAceptar";
            this.btAceptar.Size = new System.Drawing.Size(100, 28);
            this.btAceptar.TabIndex = 3;
            this.btAceptar.Text = "Aceptar";
            this.btAceptar.UseVisualStyleBackColor = true;
            // 
            // btCancelar
            // 
            this.btCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancelar.Location = new System.Drawing.Point(301, 240);
            this.btCancelar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(100, 28);
            this.btCancelar.TabIndex = 4;
            this.btCancelar.Text = "Cancelar";
            this.btCancelar.UseVisualStyleBackColor = true;
            // 
            // FormClave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 336);
            this.Controls.Add(this.btCancelar);
            this.Controls.Add(this.btAceptar);
            this.Controls.Add(this.tbClave);
            this.Controls.Add(this.lbClave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormClave";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FormClave_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbClave;
        private System.Windows.Forms.TextBox tbClave;
        private System.Windows.Forms.Button btAceptar;
        private System.Windows.Forms.Button btCancelar;
    }
}