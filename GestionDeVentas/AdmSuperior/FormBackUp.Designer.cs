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
        private System.Windows.Forms.Button btnRestaurar;
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
            this.btnCerrar = new System.Windows.Forms.Button();  // NUEVO
            this.btnRestaurar = new System.Windows.Forms.Button();
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
            this.panelContenido.Controls.Add(this.btnCerrar);   // NUEVO
            this.panelContenido.Controls.Add(this.btnRestaurar);
            this.panelContenido.Controls.Add(this.btnCrearBackup);
            this.panelContenido.Controls.Add(this.btnElegirOrigen);
            this.panelContenido.Controls.Add(this.txtCarpetaOrigen);
            this.panelContenido.Controls.Add(this.lblOrigen);
            this.panelContenido.Controls.Add(this.lblTitulo);
            this.panelContenido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContenido.Location = new System.Drawing.Point(0, 0);
            this.panelContenido.Name = "panelContenido";
            this.panelContenido.Size = new System.Drawing.Size(800, 427);
            this.panelContenido.TabIndex = 0;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(200, 50, 50);
            this.btnCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(255, 80, 80);
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.btnCerrar.ForeColor = System.Drawing.Color.Black;
            this.btnCerrar.Location = new System.Drawing.Point(760, 10); // esquina derecha arriba
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(30, 30);
            this.btnCerrar.TabIndex = 6;
            this.btnCerrar.Text = "X";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnRestaurar
            // 
            this.btnRestaurar.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btnRestaurar.Location = new System.Drawing.Point(280, 171);
            this.btnRestaurar.Name = "btnRestaurar";
            this.btnRestaurar.Size = new System.Drawing.Size(251, 43);
            this.btnRestaurar.TabIndex = 2;
            this.btnRestaurar.Text = "Restaurar desde BackUp";
            this.btnRestaurar.UseVisualStyleBackColor = true;
            this.btnRestaurar.Click += new System.EventHandler(this.btnRestaurar_Click);
            // 
            // btnCrearBackup
            // 
            this.btnCrearBackup.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btnCrearBackup.Location = new System.Drawing.Point(29, 171);
            this.btnCrearBackup.Name = "btnCrearBackup";
            this.btnCrearBackup.Size = new System.Drawing.Size(229, 43);
            this.btnCrearBackup.TabIndex = 1;
            this.btnCrearBackup.Text = "Crear BackUp (.zip)";
            this.btnCrearBackup.UseVisualStyleBackColor = true;
            this.btnCrearBackup.Click += new System.EventHandler(this.btnCrearBackup_Click);
            // 
            // btnElegirOrigen
            // 
            this.btnElegirOrigen.Font = new System.Drawing.Font("Arial", 10F);
            this.btnElegirOrigen.Location = new System.Drawing.Point(634, 111);
            this.btnElegirOrigen.Name = "btnElegirOrigen";
            this.btnElegirOrigen.Size = new System.Drawing.Size(126, 27);
            this.btnElegirOrigen.TabIndex = 3;
            this.btnElegirOrigen.Text = "Examinar...";
            this.btnElegirOrigen.UseVisualStyleBackColor = true;
            this.btnElegirOrigen.Click += new System.EventHandler(this.btnElegirOrigen_Click);
            // 
            // txtCarpetaOrigen
            // 
            this.txtCarpetaOrigen.Font = new System.Drawing.Font("Arial", 10F);
            this.txtCarpetaOrigen.Location = new System.Drawing.Point(29, 112);
            this.txtCarpetaOrigen.Name = "txtCarpetaOrigen";
            this.txtCarpetaOrigen.Size = new System.Drawing.Size(594, 27);
            this.txtCarpetaOrigen.TabIndex = 4;
            // 
            // lblOrigen
            // 
            this.lblOrigen.Font = new System.Drawing.Font("Arial", 10F);
            this.lblOrigen.Location = new System.Drawing.Point(25, 85);
            this.lblOrigen.Name = "lblOrigen";
            this.lblOrigen.Size = new System.Drawing.Size(343, 21);
            this.lblOrigen.TabIndex = 5;
            this.lblOrigen.Text = "Carpeta a respaldar / restaurar:";
            // 
            // lblTitulo
            // 
            this.lblTitulo.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(23, 21);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(457, 32);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "BackUp de la Aplicación";
            // 
            // FormBackup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 427);
            this.Controls.Add(this.panelContenido);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormBackup";
            this.Text = "BackUp";
            this.Load += new System.EventHandler(this.FormBackup_Load);
            this.panelContenido.ResumeLayout(false);
            this.panelContenido.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}
