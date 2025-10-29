namespace GestionDeVentas.AdmSuperior
{
    partial class FormBackup
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitulo, lblDestino, lblUltimoBackup;
        private System.Windows.Forms.TextBox txtDestino;
        private System.Windows.Forms.Button btnElegirDestino, btnBackupBD, btnAbrirCarpeta, btnCerrar;
        private System.Windows.Forms.Panel panelContenido;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelContenido = new System.Windows.Forms.Panel();
            this.btnAbrirCarpeta = new System.Windows.Forms.Button();
            this.lblUltimoBackup = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnBackupBD = new System.Windows.Forms.Button();
            this.btnElegirDestino = new System.Windows.Forms.Button();
            this.txtDestino = new System.Windows.Forms.TextBox();
            this.lblDestino = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.panelContenido.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelContenido
            // 
            this.panelContenido.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(240)))), ((int)(((byte)(230)))));
            this.panelContenido.Controls.Add(this.btnAbrirCarpeta);
            this.panelContenido.Controls.Add(this.lblUltimoBackup);
            this.panelContenido.Controls.Add(this.btnCerrar);
            this.panelContenido.Controls.Add(this.btnBackupBD);
            this.panelContenido.Controls.Add(this.btnElegirDestino);
            this.panelContenido.Controls.Add(this.txtDestino);
            this.panelContenido.Controls.Add(this.lblDestino);
            this.panelContenido.Controls.Add(this.lblTitulo);
            this.panelContenido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContenido.Location = new System.Drawing.Point(0, 0);
            this.panelContenido.Name = "panelContenido";
            this.panelContenido.Size = new System.Drawing.Size(800, 450);
            this.panelContenido.TabIndex = 0;
            // 
            // btnAbrirCarpeta
            // 
            this.btnAbrirCarpeta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(170)))), ((int)(((byte)(120)))));
            this.btnAbrirCarpeta.Enabled = false;
            this.btnAbrirCarpeta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbrirCarpeta.Font = new System.Drawing.Font("Arial", 9F);
            this.btnAbrirCarpeta.Location = new System.Drawing.Point(380, 170);
            this.btnAbrirCarpeta.Name = "btnAbrirCarpeta";
            this.btnAbrirCarpeta.Size = new System.Drawing.Size(208, 43);
            this.btnAbrirCarpeta.TabIndex = 0;
            this.btnAbrirCarpeta.Text = "Abrir Carpeta Último Backup";
            this.btnAbrirCarpeta.UseVisualStyleBackColor = false;
            this.btnAbrirCarpeta.Click += new System.EventHandler(this.btnAbrirCarpeta_Click);
            this.btnAbrirCarpeta.MouseEnter += new System.EventHandler(this.BtnHoverEnter);
            this.btnAbrirCarpeta.MouseLeave += new System.EventHandler(this.BtnHoverLeave);
            // 
            // lblUltimoBackup
            // 
            this.lblUltimoBackup.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Italic);
            this.lblUltimoBackup.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(50)))), ((int)(((byte)(40)))));
            this.lblUltimoBackup.Location = new System.Drawing.Point(29, 230);
            this.lblUltimoBackup.Name = "lblUltimoBackup";
            this.lblUltimoBackup.Size = new System.Drawing.Size(740, 50);
            this.lblUltimoBackup.TabIndex = 1;
            this.lblUltimoBackup.Text = "Último backup: sin registros";
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.btnCerrar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(50)))), ((int)(((byte)(40)))));
            this.btnCerrar.Location = new System.Drawing.Point(760, 10);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(29, 30);
            this.btnCerrar.TabIndex = 3;
            this.btnCerrar.Text = "X";
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnBackupBD
            // 
            this.btnBackupBD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(50)))), ((int)(((byte)(40)))));
            this.btnBackupBD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackupBD.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btnBackupBD.ForeColor = System.Drawing.Color.White;
            this.btnBackupBD.Location = new System.Drawing.Point(29, 170);
            this.btnBackupBD.Name = "btnBackupBD";
            this.btnBackupBD.Size = new System.Drawing.Size(333, 43);
            this.btnBackupBD.TabIndex = 4;
            this.btnBackupBD.Text = "Crear Backup Base de Datos";
            this.btnBackupBD.UseVisualStyleBackColor = false;
            this.btnBackupBD.Click += new System.EventHandler(this.btnBackupBD_Click);
            this.btnBackupBD.MouseEnter += new System.EventHandler(this.BtnHoverEnter);
            this.btnBackupBD.MouseLeave += new System.EventHandler(this.BtnHoverLeave);
            // 
            // btnElegirDestino
            // 
            this.btnElegirDestino.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(170)))), ((int)(((byte)(120)))));
            this.btnElegirDestino.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnElegirDestino.Font = new System.Drawing.Font("Arial", 10F);
            this.btnElegirDestino.Location = new System.Drawing.Point(625, 112);
            this.btnElegirDestino.Name = "btnElegirDestino";
            this.btnElegirDestino.Size = new System.Drawing.Size(125, 28);
            this.btnElegirDestino.TabIndex = 5;
            this.btnElegirDestino.Text = "Examinar...";
            this.btnElegirDestino.UseVisualStyleBackColor = false;
            this.btnElegirDestino.Click += new System.EventHandler(this.btnElegirDestino_Click);
            this.btnElegirDestino.MouseEnter += new System.EventHandler(this.BtnHoverEnter);
            this.btnElegirDestino.MouseLeave += new System.EventHandler(this.BtnHoverLeave);
            // 
            // txtDestino
            // 
            this.txtDestino.Font = new System.Drawing.Font("Arial", 10F);
            this.txtDestino.Location = new System.Drawing.Point(29, 114);
            this.txtDestino.Name = "txtDestino";
            this.txtDestino.Size = new System.Drawing.Size(580, 27);
            this.txtDestino.TabIndex = 6;
            // 
            // lblDestino
            // 
            this.lblDestino.Font = new System.Drawing.Font("Arial", 10F);
            this.lblDestino.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(50)))), ((int)(((byte)(40)))));
            this.lblDestino.Location = new System.Drawing.Point(25, 90);
            this.lblDestino.Name = "lblDestino";
            this.lblDestino.Size = new System.Drawing.Size(100, 23);
            this.lblDestino.TabIndex = 7;
            this.lblDestino.Text = "Carpeta destino (.bak/.zip):";
            // 
            // lblTitulo
            // 
            this.lblTitulo.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(50)))), ((int)(((byte)(40)))));
            this.lblTitulo.Location = new System.Drawing.Point(25, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(510, 47);
            this.lblTitulo.TabIndex = 8;
            this.lblTitulo.Text = "Backup de la Aplicación TYV";
            // 
            // FormBackup
            // 
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelContenido);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormBackup";
            this.Text = "FormBackup";
            this.Load += new System.EventHandler(this.FormBackup_Load);
            this.panelContenido.ResumeLayout(false);
            this.panelContenido.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}
