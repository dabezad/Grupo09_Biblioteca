namespace Presentacion
{
    partial class FormInicial
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
            this.btIniciarSesion = new System.Windows.Forms.Button();
            this.btRegistrar = new System.Windows.Forms.Button();
            this.lbUsuario = new System.Windows.Forms.Label();
            this.lbContraseña = new System.Windows.Forms.Label();
            this.tbUsuario = new System.Windows.Forms.TextBox();
            this.tbContraseña = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btIniciarSesion
            // 
            this.btIniciarSesion.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btIniciarSesion.Location = new System.Drawing.Point(70, 166);
            this.btIniciarSesion.Name = "btIniciarSesion";
            this.btIniciarSesion.Size = new System.Drawing.Size(104, 33);
            this.btIniciarSesion.TabIndex = 0;
            this.btIniciarSesion.Text = "Iniciar sesión";
            this.btIniciarSesion.UseVisualStyleBackColor = true;
            this.btIniciarSesion.Click += new System.EventHandler(this.btIniciarSesion_Click);
            // 
            // btRegistrar
            // 
            this.btRegistrar.Location = new System.Drawing.Point(264, 166);
            this.btRegistrar.Name = "btRegistrar";
            this.btRegistrar.Size = new System.Drawing.Size(93, 33);
            this.btRegistrar.TabIndex = 1;
            this.btRegistrar.Text = "Registrarse";
            this.btRegistrar.UseVisualStyleBackColor = true;
            this.btRegistrar.Click += new System.EventHandler(this.btRegistrar_Click);
            // 
            // lbUsuario
            // 
            this.lbUsuario.AutoSize = true;
            this.lbUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUsuario.Location = new System.Drawing.Point(109, 37);
            this.lbUsuario.Name = "lbUsuario";
            this.lbUsuario.Size = new System.Drawing.Size(61, 16);
            this.lbUsuario.TabIndex = 2;
            this.lbUsuario.Text = "Usuario";
            // 
            // lbContraseña
            // 
            this.lbContraseña.AutoSize = true;
            this.lbContraseña.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbContraseña.Location = new System.Drawing.Point(88, 102);
            this.lbContraseña.Name = "lbContraseña";
            this.lbContraseña.Size = new System.Drawing.Size(86, 16);
            this.lbContraseña.TabIndex = 3;
            this.lbContraseña.Text = "Contraseña";
            // 
            // tbUsuario
            // 
            this.tbUsuario.Location = new System.Drawing.Point(193, 34);
            this.tbUsuario.Name = "tbUsuario";
            this.tbUsuario.Size = new System.Drawing.Size(118, 22);
            this.tbUsuario.TabIndex = 4;
            // 
            // tbContraseña
            // 
            this.tbContraseña.Location = new System.Drawing.Point(193, 99);
            this.tbContraseña.Name = "tbContraseña";
            this.tbContraseña.PasswordChar = '*';
            this.tbContraseña.Size = new System.Drawing.Size(118, 22);
            this.tbContraseña.TabIndex = 5;
            // 
            // FormInicial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 228);
            this.Controls.Add(this.tbContraseña);
            this.Controls.Add(this.tbUsuario);
            this.Controls.Add(this.lbContraseña);
            this.Controls.Add(this.lbUsuario);
            this.Controls.Add(this.btRegistrar);
            this.Controls.Add(this.btIniciarSesion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormInicial";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestión de biblioteca ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btIniciarSesion;
        private System.Windows.Forms.Button btRegistrar;
        private System.Windows.Forms.Label lbUsuario;
        private System.Windows.Forms.Label lbContraseña;
        private System.Windows.Forms.TextBox tbUsuario;
        private System.Windows.Forms.TextBox tbContraseña;
    }
}