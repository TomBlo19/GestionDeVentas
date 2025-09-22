// FormAdminSuperior.Designer.cs
using GestionDeVentas.Properties;

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
            this.iconCerrarSesion = new System.Windows.Forms.PictureBox();
            this.lblBackup = new System.Windows.Forms.Label();
            this.iconBackup = new System.Windows.Forms.PictureBox();
            this.lblListarUsuario = new System.Windows.Forms.Label();
            this.iconListarUsuario = new System.Windows.Forms.PictureBox();
            this.lblRegistrarUsuario = new System.Windows.Forms.Label();
            this.iconRegistrarUsuario = new System.Windows.Forms.PictureBox();
            this.lblInicio = new System.Windows.Forms.Label();
            this.iconInicio = new System.Windows.Forms.PictureBox();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.pictureBoxWelcome = new System.Windows.Forms.PictureBox();
            this.topBarPanel = new System.Windows.Forms.Panel();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.lblAdminWelcome = new System.Windows.Forms.Label();
            this.logoPanel.SuspendLayout();
            this.sidePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconCerrarSesion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconBackup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconListarUsuario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconRegistrarUsuario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconInicio)).BeginInit();
            this.mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWelcome)).BeginInit();
            this.topBarPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // logoPanel
            // 
            this.logoPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(190)))), ((int)(((byte)(170)))));
            this.logoPanel.Controls.Add(this.lblAdminPanel);
            this.logoPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.logoPanel.Location = new System.Drawing.Point(0, 0);
            this.logoPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.logoPanel.Name = "logoPanel";
            this.logoPanel.Size = new System.Drawing.Size(333, 98);
            this.logoPanel.TabIndex = 12;
            // 
            // lblAdminPanel
            // 
            this.lblAdminPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAdminPanel.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdminPanel.ForeColor = System.Drawing.Color.Black;
            this.lblAdminPanel.Location = new System.Drawing.Point(0, 0);
            this.lblAdminPanel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAdminPanel.Name = "lblAdminPanel";
            this.lblAdminPanel.Size = new System.Drawing.Size(333, 98);
            this.lblAdminPanel.TabIndex = 0;
            this.lblAdminPanel.Text = "Admin. superior panel";
            this.lblAdminPanel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAdminPanel.Click += new System.EventHandler(this.lblAdminPanel_Click);
            // 
            // sidePanel
            // 
            this.sidePanel.AutoScroll = true;
            this.sidePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(220)))), ((int)(((byte)(200)))));
            this.sidePanel.Controls.Add(this.lblCerrarSesion);
            this.sidePanel.Controls.Add(this.iconCerrarSesion);
            this.sidePanel.Controls.Add(this.lblBackup);
            this.sidePanel.Controls.Add(this.iconBackup);
            this.sidePanel.Controls.Add(this.lblListarUsuario);
            this.sidePanel.Controls.Add(this.iconListarUsuario);
            this.sidePanel.Controls.Add(this.lblRegistrarUsuario);
            this.sidePanel.Controls.Add(this.iconRegistrarUsuario);
            this.sidePanel.Controls.Add(this.lblInicio);
            this.sidePanel.Controls.Add(this.iconInicio);
            this.sidePanel.Controls.Add(this.logoPanel);
            this.sidePanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidePanel.Location = new System.Drawing.Point(0, 0);
            this.sidePanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.sidePanel.Name = "sidePanel";
            this.sidePanel.Size = new System.Drawing.Size(333, 554);
            this.sidePanel.TabIndex = 0;
            // 
            // lblCerrarSesion
            // 
            this.lblCerrarSesion.Font = new System.Drawing.Font("Arial", 11.25F);
            this.lblCerrarSesion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lblCerrarSesion.Location = new System.Drawing.Point(67, 320);
            this.lblCerrarSesion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCerrarSesion.Name = "lblCerrarSesion";
            this.lblCerrarSesion.Size = new System.Drawing.Size(133, 28);
            this.lblCerrarSesion.TabIndex = 13;
            this.lblCerrarSesion.Text = "Cerrar sesión";
            this.lblCerrarSesion.Click += new System.EventHandler(this.lblCerrarSesion_Click);
            // 
            // iconCerrarSesion
            // 
            this.iconCerrarSesion.Image = global::GestionDeVentas.Properties.Resources.icon_logout;
            this.iconCerrarSesion.Location = new System.Drawing.Point(20, 320);
            this.iconCerrarSesion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.iconCerrarSesion.Name = "iconCerrarSesion";
            this.iconCerrarSesion.Size = new System.Drawing.Size(32, 30);
            this.iconCerrarSesion.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.iconCerrarSesion.TabIndex = 12;
            this.iconCerrarSesion.TabStop = false;
            this.iconCerrarSesion.Click += new System.EventHandler(this.lblCerrarSesion_Click);
            // 
            // lblBackup
            // 
            this.lblBackup.Font = new System.Drawing.Font("Arial", 11.25F);
            this.lblBackup.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lblBackup.Location = new System.Drawing.Point(67, 271);
            this.lblBackup.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBackup.Name = "lblBackup";
            this.lblBackup.Size = new System.Drawing.Size(133, 28);
            this.lblBackup.TabIndex = 11;
            this.lblBackup.Text = "BackUp";
            this.lblBackup.Click += new System.EventHandler(this.lblBackup_Click);
            // 
            // iconBackup
            // 
            this.iconBackup.Image = global::GestionDeVentas.Properties.Resources.icon_manage;
            this.iconBackup.Location = new System.Drawing.Point(20, 271);
            this.iconBackup.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.iconBackup.Name = "iconBackup";
            this.iconBackup.Size = new System.Drawing.Size(32, 30);
            this.iconBackup.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.iconBackup.TabIndex = 10;
            this.iconBackup.TabStop = false;
            this.iconBackup.Click += new System.EventHandler(this.lblBackup_Click);
            // 
            // lblListarUsuario
            // 
            this.lblListarUsuario.Font = new System.Drawing.Font("Arial", 11.25F);
            this.lblListarUsuario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lblListarUsuario.Location = new System.Drawing.Point(67, 222);
            this.lblListarUsuario.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblListarUsuario.Name = "lblListarUsuario";
            this.lblListarUsuario.Size = new System.Drawing.Size(133, 28);
            this.lblListarUsuario.TabIndex = 9;
            this.lblListarUsuario.Text = "Listar Usuario";
            this.lblListarUsuario.Click += new System.EventHandler(this.lblListarUsuario_Click);
            // 
            // iconListarUsuario
            // 
            this.iconListarUsuario.Image = global::GestionDeVentas.Properties.Resources.icon_client;
            this.iconListarUsuario.Location = new System.Drawing.Point(20, 222);
            this.iconListarUsuario.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.iconListarUsuario.Name = "iconListarUsuario";
            this.iconListarUsuario.Size = new System.Drawing.Size(32, 30);
            this.iconListarUsuario.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.iconListarUsuario.TabIndex = 8;
            this.iconListarUsuario.TabStop = false;
            this.iconListarUsuario.Click += new System.EventHandler(this.lblListarUsuario_Click);
            // 
            // lblRegistrarUsuario
            // 
            this.lblRegistrarUsuario.Font = new System.Drawing.Font("Arial", 11.25F);
            this.lblRegistrarUsuario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lblRegistrarUsuario.Location = new System.Drawing.Point(67, 172);
            this.lblRegistrarUsuario.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRegistrarUsuario.Name = "lblRegistrarUsuario";
            this.lblRegistrarUsuario.Size = new System.Drawing.Size(173, 28);
            this.lblRegistrarUsuario.TabIndex = 7;
            this.lblRegistrarUsuario.Text = "Registrar Usuario";
            this.lblRegistrarUsuario.Click += new System.EventHandler(this.lblRegistrarUsuario_Click);
            // 
            // iconRegistrarUsuario
            // 
            this.iconRegistrarUsuario.Image = global::GestionDeVentas.Properties.Resources.icon_add;
            this.iconRegistrarUsuario.Location = new System.Drawing.Point(20, 172);
            this.iconRegistrarUsuario.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.iconRegistrarUsuario.Name = "iconRegistrarUsuario";
            this.iconRegistrarUsuario.Size = new System.Drawing.Size(32, 30);
            this.iconRegistrarUsuario.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.iconRegistrarUsuario.TabIndex = 6;
            this.iconRegistrarUsuario.TabStop = false;
            this.iconRegistrarUsuario.Click += new System.EventHandler(this.lblRegistrarUsuario_Click);
            // 
            // lblInicio
            // 
            this.lblInicio.Font = new System.Drawing.Font("Arial", 11.25F);
            this.lblInicio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lblInicio.Location = new System.Drawing.Point(67, 123);
            this.lblInicio.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInicio.Name = "lblInicio";
            this.lblInicio.Size = new System.Drawing.Size(133, 28);
            this.lblInicio.TabIndex = 5;
            this.lblInicio.Text = "Inicio";
            this.lblInicio.Click += new System.EventHandler(this.lblInicio_Click);
            // 
            // iconInicio
            // 
            this.iconInicio.Image = global::GestionDeVentas.Properties.Resources.icon_home;
            this.iconInicio.Location = new System.Drawing.Point(20, 123);
            this.iconInicio.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.iconInicio.Name = "iconInicio";
            this.iconInicio.Size = new System.Drawing.Size(32, 30);
            this.iconInicio.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.iconInicio.TabIndex = 4;
            this.iconInicio.TabStop = false;
            this.iconInicio.Click += new System.EventHandler(this.lblInicio_Click);
            // 
            // mainPanel
            // 
            this.mainPanel.AutoScroll = true;
            this.mainPanel.BackColor = System.Drawing.Color.White;
            this.mainPanel.Controls.Add(this.pictureBoxWelcome);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(333, 98);
            this.mainPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(734, 456);
            this.mainPanel.TabIndex = 2;
            // 
            // pictureBoxWelcome
            // 
            this.pictureBoxWelcome.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxWelcome.Image = global::GestionDeVentas.Properties.Resources.logoAdm;
            this.pictureBoxWelcome.Location = new System.Drawing.Point(233, 102);
            this.pictureBoxWelcome.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBoxWelcome.Name = "pictureBoxWelcome";
            this.pictureBoxWelcome.Size = new System.Drawing.Size(268, 249);
            this.pictureBoxWelcome.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxWelcome.TabIndex = 0;
            this.pictureBoxWelcome.TabStop = false;
            // 
            // topBarPanel
            // 
            this.topBarPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(76)))), ((int)(((byte)(41)))));
            this.topBarPanel.Controls.Add(this.pictureBoxLogo);
            this.topBarPanel.Controls.Add(this.lblAdminWelcome);
            this.topBarPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topBarPanel.Location = new System.Drawing.Point(333, 0);
            this.topBarPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.topBarPanel.Name = "topBarPanel";
            this.topBarPanel.Size = new System.Drawing.Size(734, 98);
            this.topBarPanel.TabIndex = 1;
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBoxLogo.Image = global::GestionDeVentas.Properties.Resources.logo_empresa;
            this.pictureBoxLogo.Location = new System.Drawing.Point(314, 12);
            this.pictureBoxLogo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(107, 74);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxLogo.TabIndex = 0;
            this.pictureBoxLogo.TabStop = false;
            // 
            // lblAdminWelcome
            // 
            this.lblAdminWelcome.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblAdminWelcome.AutoSize = true;
            this.lblAdminWelcome.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdminWelcome.ForeColor = System.Drawing.Color.White;
            this.lblAdminWelcome.Location = new System.Drawing.Point(501, 37);
            this.lblAdminWelcome.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAdminWelcome.Name = "lblAdminWelcome";
            this.lblAdminWelcome.Size = new System.Drawing.Size(228, 22);
            this.lblAdminWelcome.TabIndex = 1;
            this.lblAdminWelcome.Text = "Administrador Superior";
            this.lblAdminWelcome.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FormAdminSuperior
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.topBarPanel);
            this.Controls.Add(this.sidePanel);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormAdminSuperior";
            this.Text = "Admin Panel Superior";
            this.Load += new System.EventHandler(this.FormAdminSuperior_Load);
            this.logoPanel.ResumeLayout(false);
            this.sidePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.iconCerrarSesion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconBackup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconListarUsuario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconRegistrarUsuario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconInicio)).EndInit();
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
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Panel topBarPanel;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.Label lblAdminWelcome;
        private System.Windows.Forms.PictureBox pictureBoxWelcome;
        private System.Windows.Forms.Label lblInicio;
        private System.Windows.Forms.PictureBox iconInicio;
        private System.Windows.Forms.Label lblCerrarSesion;
        private System.Windows.Forms.PictureBox iconCerrarSesion;
        private System.Windows.Forms.Label lblBackup;
        private System.Windows.Forms.PictureBox iconBackup;
        private System.Windows.Forms.Label lblListarUsuario;
        private System.Windows.Forms.PictureBox iconListarUsuario;
        private System.Windows.Forms.Label lblRegistrarUsuario;
        private System.Windows.Forms.PictureBox iconRegistrarUsuario;
    }
}