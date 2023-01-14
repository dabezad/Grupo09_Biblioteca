namespace Presentacion
{
    partial class FormListadoEjs
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
            this.dgEjemplares = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgEjemplares)).BeginInit();
            this.SuspendLayout();
            // 
            // dgEjemplares
            // 
            this.dgEjemplares.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgEjemplares.Location = new System.Drawing.Point(13, 13);
            this.dgEjemplares.Name = "dgEjemplares";
            this.dgEjemplares.RowHeadersWidth = 51;
            this.dgEjemplares.RowTemplate.Height = 24;
            this.dgEjemplares.Size = new System.Drawing.Size(759, 542);
            this.dgEjemplares.TabIndex = 0;
            // 
            // FormListadoEjs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 573);
            this.Controls.Add(this.dgEjemplares);
            this.Name = "FormListadoEjs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listado de ejemplares";
            this.Load += new System.EventHandler(this.FormListadoEjs_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgEjemplares)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgEjemplares;
    }
}