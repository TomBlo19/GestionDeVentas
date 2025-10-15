namespace GestionDeVentas.AdmSuperior
{
    partial class FormBackup
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblOrigen;
        private System.Windows.Forms.TextBox txtCarpetaOrigen;
        private System.Windows.Forms.Button btnElegirOrigen;
        private System.Windows.Forms.Button btnCrearBackup;
        private System.Windows.Forms.Panel panelContenido;
        private System.Windows.Forms.Button btnCerrar;   // NUEVO

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelContenido = new System.Windows.Forms.Panel();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnCrearBackup = new System.Windows.Forms.Button();
            this.btnElegirOrigen = new System.Windows.Forms.Button();
            this.txtCarpetaOrigen = new System.Windows.Forms.TextBox();
            this.lblOrigen = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.panelContenido.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelContenido
            // 
            this.panelContenido.BackColor = System.Drawing.Color.White;
            this.panelContenido.Controls.Add(this.btnCerrar);
            this.panelContenido.Controls.Add(this.btnCrearBackup);
            this.panelContenido.Controls.Add(this.btnElegirOrigen);
            this.panelContenido.Controls.Add(this.txtCarpetaOrigen);
            this.panelContenido.Controls.Add(this.lblOrigen);
            this.panelContenido.Controls.Add(this.lblTitulo);
            this.panelContenido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContenido.Location = new System.Drawing.Point(0, 0);
            this.panelContenido.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelContenido.Name = "panelContenido";
            this.panelContenido.Size = new System.Drawing.Size(600, 347);
            this.panelContenido.TabIndex = 0;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.btnCerrar.ForeColor = System.Drawing.Color.Black;
            this.btnCerrar.Location = new System.Drawing.Point(570, 8);
            this.btnCerrar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(22, 24);
            this.btnCerrar.TabIndex = 6;
            this.btnCerrar.Text = "X";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnCrearBackup
            // 
            this.btnCrearBackup.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btnCrearBackup.Location = new System.Drawing.Point(22, 139);
            this.btnCrearBackup.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCrearBackup.Name = "btnCrearBackup";
            this.btnCrearBackup.Size = new System.Drawing.Size(172, 35);
            this.btnCrearBackup.TabIndex = 1;
            this.btnCrearBackup.Text = "Crear BackUp (.zip)";
            this.btnCrearBackup.UseVisualStyleBackColor = true;
            this.btnCrearBackup.Click += new System.EventHandler(this.btnCrearBackup_Click);
            // 
            // btnElegirOrigen
            // 
            this.btnElegirOrigen.Font = new System.Drawing.Font("Arial", 10F);
            this.btnElegirOrigen.Location = new System.Drawing.Point(476, 90);
            this.btnElegirOrigen.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnElegirOrigen.Name = "btnElegirOrigen";
            this.btnElegirOrigen.Size = new System.Drawing.Size(94, 22);
            this.btnElegirOrigen.TabIndex = 3;
            this.btnElegirOrigen.Text = "Examinar...";
            this.btnElegirOrigen.UseVisualStyleBackColor = true;
            this.btnElegirOrigen.Click += new System.EventHandler(this.btnElegirOrigen_Click);
            // 
            // txtCarpetaOrigen
            // 
            this.txtCarpetaOrigen.Font = new System.Drawing.Font("Arial", 10F);
            this.txtCarpetaOrigen.Location = new System.Drawing.Point(22, 91);
            this.txtCarpetaOrigen.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtCarpetaOrigen.Name = "txtCarpetaOrigen";
            this.txtCarpetaOrigen.Size = new System.Drawing.Size(446, 23);
            this.txtCarpetaOrigen.TabIndex = 4;
            // 
            // lblOrigen
            // 
            this.lblOrigen.Font = new System.Drawing.Font("Arial", 10F);
            this.lblOrigen.Location = new System.Drawing.Point(19, 69);
            this.lblOrigen.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblOrigen.Name = "lblOrigen";
            this.lblOrigen.Size = new System.Drawing.Size(257, 17);
            this.lblOrigen.TabIndex = 5;
            this.lblOrigen.Text = "Carpeta a respaldar / restaurar:";
            // 
            // lblTitulo
            // 
            this.lblTitulo.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(17, 17);
            this.lblTitulo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(343, 26);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "BackUp de la Aplicación";
            // 
            // FormBackup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 347);
            this.Controls.Add(this.panelContenido);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormBackup";
            this.Text = "BackUp";
            this.Load += new System.EventHandler(this.FormBackup_Load);
            this.panelContenido.ResumeLayout(false);
            this.panelContenido.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}
