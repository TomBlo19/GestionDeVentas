namespace GestionDeVentas.AdmSuperior
{
    partial class FormAdminSuperior
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.logoPanel = new System.Windows.Forms.Panel();
            this.lblAdminPanel = new System.Windows.Forms.Label();
            this.sidePanel = new System.Windows.Forms.Panel();
            this.lblCerrarSesion = new System.Windows.Forms.Label();
            this.lblBackup = new System.Windows.Forms.Label();
            this.lblGestionarUsuarios = new System.Windows.Forms.Label();
            this.lblListarUsuario = new System.Windows.Forms.Label();
            this.lblRegistrarUsuario = new System.Windows.Forms.Label();
            this.lblInicio = new System.Windows.Forms.Label();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.pictureBoxWelcome = new System.Windows.Forms.PictureBox();
            this.lblAdminWelcome = new System.Windows.Forms.Label();
            this.topBarPanel = new System.Windows.Forms.Panel();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.logoPanel.SuspendLayout();
            this.sidePanel.SuspendLayout();
            this.mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWelcome)).BeginInit();
            this.topBarPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // logoPanel
            // 
            this.logoPanel.Controls.Add(this.lblAdminPanel);
            this.logoPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.logoPanel.Location = new System.Drawing.Point(0, 0);
            this.logoPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.logoPanel.Name = "logoPanel";
            this.logoPanel.Size = new System.Drawing.Size(267, 92);
            this.logoPanel.TabIndex = 9;
            // 
            // lblAdminPanel
            // 
            this.lblAdminPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblAdminPanel.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdminPanel.Location = new System.Drawing.Point(0, 0);
            this.lblAdminPanel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAdminPanel.Name = "lblAdminPanel";
            this.lblAdminPanel.Size = new System.Drawing.Size(267, 92);
            this.lblAdminPanel.TabIndex = 0;
            this.lblAdminPanel.Text = "Admin Superior";
            this.lblAdminPanel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sidePanel
            // 
            this.sidePanel.AutoScroll = true;
            this.sidePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(224)))), ((int)(((byte)(215)))));
            this.sidePanel.Controls.Add(this.lblCerrarSesion);
            this.sidePanel.Controls.Add(this.lblBackup);
            this.sidePanel.Controls.Add(this.lblGestionarUsuarios);
            this.sidePanel.Controls.Add(this.lblListarUsuario);
            this.sidePanel.Controls.Add(this.lblRegistrarUsuario);
            this.sidePanel.Controls.Add(this.lblInicio);
            this.sidePanel.Controls.Add(this.logoPanel);
            this.sidePanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidePanel.Location = new System.Drawing.Point(0, 0);
            this.sidePanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.sidePanel.Name = "sidePanel";
            this.sidePanel.Size = new System.Drawing.Size(267, 554);
            this.sidePanel.TabIndex = 0;
            this.sidePanel.Paint += new System.Windows.Forms.PaintEventHandler(this.sidePanel_Paint);
            // 
            // lblCerrarSesion
            // 
            this.lblCerrarSesion.BackColor = System.Drawing.Color.Transparent;
            this.lblCerrarSesion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblCerrarSesion.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCerrarSesion.Font = new System.Drawing.Font("Arial", 11.25F);
            this.lblCerrarSesion.ForeColor = System.Drawing.Color.Black;
            this.lblCerrarSesion.Location = new System.Drawing.Point(0, 281);
            this.lblCerrarSesion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCerrarSesion.Name = "lblCerrarSesion";
            this.lblCerrarSesion.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.lblCerrarSesion.Size = new System.Drawing.Size(267, 37);
            this.lblCerrarSesion.TabIndex = 8;
            this.lblCerrarSesion.Text = "Cerrar sesión";
            this.lblCerrarSesion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCerrarSesion.Click += new System.EventHandler(this.lblCerrarSesion_Click);
            // 
            // lblBackup
            // 
            this.lblBackup.BackColor = System.Drawing.Color.Transparent;
            this.lblBackup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblBackup.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblBackup.Font = new System.Drawing.Font("Arial", 11.25F);
            this.lblBackup.ForeColor = System.Drawing.Color.Black;
            this.lblBackup.Location = new System.Drawing.Point(0, 244);
            this.lblBackup.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBackup.Name = "lblBackup";
            this.lblBackup.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.lblBackup.Size = new System.Drawing.Size(267, 37);
            this.lblBackup.TabIndex = 9;
            this.lblBackup.Text = "BackUp";
            this.lblBackup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblBackup.Click += new System.EventHandler(this.lblBackup_Click);
            // 
            // lblGestionarUsuarios
            // 
            this.lblGestionarUsuarios.BackColor = System.Drawing.Color.Transparent;
            this.lblGestionarUsuarios.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblGestionarUsuarios.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblGestionarUsuarios.Font = new System.Drawing.Font("Arial", 11.25F);
            this.lblGestionarUsuarios.ForeColor = System.Drawing.Color.Black;
            this.lblGestionarUsuarios.Location = new System.Drawing.Point(0, 207);
            this.lblGestionarUsuarios.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGestionarUsuarios.Name = "lblGestionarUsuarios";
            this.lblGestionarUsuarios.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.lblGestionarUsuarios.Size = new System.Drawing.Size(267, 37);
            this.lblGestionarUsuarios.TabIndex = 10;
            this.lblGestionarUsuarios.Text = "Gestionar Usuarios";
            this.lblGestionarUsuarios.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblGestionarUsuarios.Click += new System.EventHandler(this.lblGestionarUsuarios_Click);
            // 
            // lblListarUsuario
            // 
            this.lblListarUsuario.BackColor = System.Drawing.Color.Transparent;
            this.lblListarUsuario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblListarUsuario.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblListarUsuario.Font = new System.Drawing.Font("Arial", 11.25F);
            this.lblListarUsuario.ForeColor = System.Drawing.Color.Black;
            this.lblListarUsuario.Location = new System.Drawing.Point(0, 170);
            this.lblListarUsuario.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblListarUsuario.Name = "lblListarUsuario";
            this.lblListarUsuario.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.lblListarUsuario.Size = new System.Drawing.Size(267, 37);
            this.lblListarUsuario.TabIndex = 12;
            this.lblListarUsuario.Text = "Listar Usuario";
            this.lblListarUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblListarUsuario.Click += new System.EventHandler(this.lblListarUsuario_Click);
            // 
            // lblRegistrarUsuario
            // 
            this.lblRegistrarUsuario.BackColor = System.Drawing.Color.Transparent;
            this.lblRegistrarUsuario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblRegistrarUsuario.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRegistrarUsuario.Font = new System.Drawing.Font("Arial", 11.25F);
            this.lblRegistrarUsuario.ForeColor = System.Drawing.Color.Black;
            this.lblRegistrarUsuario.Location = new System.Drawing.Point(0, 133);
            this.lblRegistrarUsuario.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRegistrarUsuario.Name = "lblRegistrarUsuario";
            this.lblRegistrarUsuario.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.lblRegistrarUsuario.Size = new System.Drawing.Size(267, 37);
            this.lblRegistrarUsuario.TabIndex = 2;
            this.lblRegistrarUsuario.Text = "Registrar Usuario";
            this.lblRegistrarUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblRegistrarUsuario.Click += new System.EventHandler(this.lblRegistrarUsuario_Click);
            // 
            // lblInicio
            // 
            this.lblInicio.BackColor = System.Drawing.Color.Transparent;
            this.lblInicio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblInicio.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblInicio.Font = new System.Drawing.Font("Arial", 11.25F);
            this.lblInicio.ForeColor = System.Drawing.Color.Black;
            this.lblInicio.Location = new System.Drawing.Point(0, 92);
            this.lblInicio.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInicio.Name = "lblInicio";
            this.lblInicio.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.lblInicio.Size = new System.Drawing.Size(267, 41);
            this.lblInicio.TabIndex = 0;
            this.lblInicio.Text = "Inicio";
            this.lblInicio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblInicio.Click += new System.EventHandler(this.lblInicio_Click);
            // 
            // mainPanel
            // 
            this.mainPanel.AutoScroll = true;
            this.mainPanel.Controls.Add(this.pictureBoxWelcome);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(267, 92);
            this.mainPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(800, 462);
            this.mainPanel.TabIndex = 2;
            // 
            // pictureBoxWelcome
            // 
            this.pictureBoxWelcome.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pictureBoxWelcome.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxWelcome.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBoxWelcome.Name = "pictureBoxWelcome";
            this.pictureBoxWelcome.Size = new System.Drawing.Size(800, 462);
            this.pictureBoxWelcome.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxWelcome.TabIndex = 0;
            this.pictureBoxWelcome.TabStop = false;
            this.pictureBoxWelcome.Click += new System.EventHandler(this.pictureBoxWelcome_Click);
            // 
            // lblAdminWelcome
            // 
            this.lblAdminWelcome.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAdminWelcome.AutoSize = true;
            this.lblAdminWelcome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(224)))), ((int)(((byte)(215)))));
            this.lblAdminWelcome.Font = new System.Drawing.Font("Arial", 11.25F);
            this.lblAdminWelcome.ForeColor = System.Drawing.Color.Black;
            this.lblAdminWelcome.Location = new System.Drawing.Point(579, 33);
            this.lblAdminWelcome.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAdminWelcome.Name = "lblAdminWelcome";
            this.lblAdminWelcome.Size = new System.Drawing.Size(204, 22);
            this.lblAdminWelcome.TabIndex = 0;
            this.lblAdminWelcome.Text = "Administrador Superior";
            this.lblAdminWelcome.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // topBarPanel
            // 
            this.topBarPanel.AutoScroll = true;
            this.topBarPanel.BackColor = System.Drawing.Color.Black;
            this.topBarPanel.BackgroundImage = global::GestionDeVentas.Properties.Resources.fondo;
            this.topBarPanel.Controls.Add(this.pictureBoxLogo);
            this.topBarPanel.Controls.Add(this.lblAdminWelcome);
            this.topBarPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topBarPanel.Location = new System.Drawing.Point(267, 0);
            this.topBarPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.topBarPanel.Name = "topBarPanel";
            this.topBarPanel.Size = new System.Drawing.Size(800, 92);
            this.topBarPanel.TabIndex = 1;
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBoxLogo.Image = global::GestionDeVentas.Properties.Resources.logoTYV;
            this.pictureBoxLogo.Location = new System.Drawing.Point(359, 14);
            this.pictureBoxLogo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(89, 69);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxLogo.TabIndex = 1;
            this.pictureBoxLogo.TabStop = false;
            this.pictureBoxLogo.Click += new System.EventHandler(this.pictureBoxLogo_Click);
            // 
            // FormAdminSuperior
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.topBarPanel);
            this.Controls.Add(this.sidePanel);
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormAdminSuperior";
            this.Text = "Admin Panel Superior";
            this.Load += new System.EventHandler(this.FormAdminSuperior_Load);
            this.logoPanel.ResumeLayout(false);
            this.sidePanel.ResumeLayout(false);
            this.mainPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWelcome)).EndInit();
            this.topBarPanel.ResumeLayout(false);
            this.topBarPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel logoPanel;
        private System.Windows.Forms.Label lblAdminPanel;
        private System.Windows.Forms.Panel sidePanel;
        private System.Windows.Forms.Label lblCerrarSesion;
        private System.Windows.Forms.Label lblGestionarUsuarios;
        private System.Windows.Forms.Label lblRegistrarUsuario;
        private System.Windows.Forms.Label lblInicio;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.PictureBox pictureBoxWelcome;
        private System.Windows.Forms.Label lblAdminWelcome;
        private System.Windows.Forms.Panel topBarPanel;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.Label lblListarUsuario;
        private System.Windows.Forms.Label lblBackup;     // <-- NUEVO
    }
}
