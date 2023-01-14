namespace Presentacion
{
    partial class FormListPrest
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
            this.dgPrestamos = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgPrestamos)).BeginInit();
            this.SuspendLayout();
            // 
            // dgPrestamos
            // 
            this.dgPrestamos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgPrestamos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPrestamos.Location = new System.Drawing.Point(17, 16);
            this.dgPrestamos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgPrestamos.Name = "dgPrestamos";
            this.dgPrestamos.RowHeadersWidth = 51;
            this.dgPrestamos.RowTemplate.ReadOnly = true;
            this.dgPrestamos.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgPrestamos.Size = new System.Drawing.Size(1120, 390);
            this.dgPrestamos.TabIndex = 0;
            // 
            // FormListPrest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1150, 421);
            this.Controls.Add(this.dgPrestamos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormListPrest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listado de todos los préstamos";
            this.Load += new System.EventHandler(this.FormListPrest_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgPrestamos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgPrestamos;
    }
}