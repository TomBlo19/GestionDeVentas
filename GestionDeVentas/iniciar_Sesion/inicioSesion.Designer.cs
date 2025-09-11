namespace gestionDeVentas
{
    partial class inicioSesion
    {
        private System.ComponentModel.IContainer components = null;

        // Controles
        private System.Windows.Forms.Panel panelLogin;
        private System.Windows.Forms.TableLayoutPanel table;
        private System.Windows.Forms.PictureBox logoTYV;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TableLayoutPanel passLayout;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.CheckBox chkVer;
        private System.Windows.Forms.Button btnIngresar;
        private System.Windows.Forms.ErrorProvider errorProvider1;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panelLogin = new System.Windows.Forms.Panel();
            this.table = new System.Windows.Forms.TableLayoutPanel();
            this.logoTYV = new System.Windows.Forms.PictureBox();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.passLayout = new System.Windows.Forms.TableLayoutPanel();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.chkVer = new System.Windows.Forms.CheckBox();
            this.btnIngresar = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panelLogin.SuspendLayout();
            this.table.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoTYV)).BeginInit();
            this.passLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelLogin
            // 
            this.panelLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(248)))), ((int)(((byte)(244)))));
            this.panelLogin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelLogin.Controls.Add(this.table);
            this.panelLogin.Location = new System.Drawing.Point(55, 38);
            this.panelLogin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelLogin.Name = "panelLogin";
            this.panelLogin.Size = new System.Drawing.Size(461, 382);
            this.panelLogin.TabIndex = 0;
            // 
            // table
            // 
            this.table.ColumnCount = 1;
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.table.Controls.Add(this.logoTYV, 0, 0);
            this.table.Controls.Add(this.lblTitulo, 0, 1);
            this.table.Controls.Add(this.lblUsuario, 0, 2);
            this.table.Controls.Add(this.txtUsuario, 0, 3);
            this.table.Controls.Add(this.lblPassword, 0, 4);
            this.table.Controls.Add(this.passLayout, 0, 5);
            this.table.Controls.Add(this.btnIngresar, 0, 6);
            this.table.Dock = System.Windows.Forms.DockStyle.Fill;
            this.table.Location = new System.Drawing.Point(0, 0);
            this.table.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.table.Name = "table";
            this.table.Padding = new System.Windows.Forms.Padding(27, 17, 27, 17);
            this.table.RowCount = 7;
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 128F));
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49F));
            this.table.Size = new System.Drawing.Size(459, 380);
            this.table.TabIndex = 0;
            this.table.Paint += new System.Windows.Forms.PaintEventHandler(this.table_Paint);
            // 
            // logoTYV
            // 
            this.logoTYV.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.logoTYV.Image = global::GestionDeVentas.Properties.Resources.logoTYV;
            this.logoTYV.Location = new System.Drawing.Point(161, 21);
            this.logoTYV.Margin = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.logoTYV.Name = "logoTYV";
            this.logoTYV.Size = new System.Drawing.Size(137, 124);
            this.logoTYV.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.logoTYV.TabIndex = 0;
            this.logoTYV.TabStop = false;
            // 
            // lblTitulo
            // 
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(64)))), ((int)(((byte)(44)))));
            this.lblTitulo.Location = new System.Drawing.Point(30, 145);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(399, 43);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "INICIAR SESIÓN";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblUsuario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(64)))), ((int)(((byte)(44)))));
            this.lblUsuario.Location = new System.Drawing.Point(27, 194);
            this.lblUsuario.Margin = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(68, 20);
            this.lblUsuario.TabIndex = 2;
            this.lblUsuario.Text = "Usuario";
            // 
            // txtUsuario
            // 
            this.txtUsuario.BackColor = System.Drawing.Color.White;
            this.txtUsuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUsuario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtUsuario.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtUsuario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.txtUsuario.Location = new System.Drawing.Point(27, 218);
            this.txtUsuario.Margin = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(405, 30);
            this.txtUsuario.TabIndex = 0;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(64)))), ((int)(((byte)(44)))));
            this.lblPassword.Location = new System.Drawing.Point(27, 256);
            this.lblPassword.Margin = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(97, 20);
            this.lblPassword.TabIndex = 3;
            this.lblPassword.Text = "Contraseña";
            // 
            // passLayout
            // 
            this.passLayout.ColumnCount = 2;
            this.passLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.passLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.passLayout.Controls.Add(this.txtPassword, 0, 0);
            this.passLayout.Controls.Add(this.chkVer, 1, 0);
            this.passLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.passLayout.Location = new System.Drawing.Point(27, 280);
            this.passLayout.Margin = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.passLayout.Name = "passLayout";
            this.passLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.passLayout.Size = new System.Drawing.Size(405, 32);
            this.passLayout.TabIndex = 4;
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.White;
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.txtPassword.Location = new System.Drawing.Point(0, 0);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(0, 0, 11, 0);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '•';
            this.txtPassword.Size = new System.Drawing.Size(308, 30);
            this.txtPassword.TabIndex = 1;
            // 
            // chkVer
            // 
            this.chkVer.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkVer.AutoSize = true;
            this.chkVer.Location = new System.Drawing.Point(319, 7);
            this.chkVer.Margin = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.chkVer.Name = "chkVer";
            this.chkVer.Size = new System.Drawing.Size(86, 20);
            this.chkVer.TabIndex = 2;
            this.chkVer.Text = "Ver clave";
            this.chkVer.CheckedChanged += new System.EventHandler(this.chkVer_CheckedChanged);
            // 
            // btnIngresar
            // 
            this.btnIngresar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(64)))), ((int)(((byte)(44)))));
            this.btnIngresar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnIngresar.FlatAppearance.BorderSize = 0;
            this.btnIngresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIngresar.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnIngresar.ForeColor = System.Drawing.Color.White;
            this.btnIngresar.Location = new System.Drawing.Point(27, 326);
            this.btnIngresar.Margin = new System.Windows.Forms.Padding(0, 14, 0, 0);
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.Size = new System.Drawing.Size(405, 37);
            this.btnIngresar.TabIndex = 3;
            this.btnIngresar.Text = "INICIAR SESIÓN";
            this.btnIngresar.UseVisualStyleBackColor = false;
            this.btnIngresar.Click += new System.EventHandler(this.btnIngresar_Click);
            this.btnIngresar.MouseEnter += new System.EventHandler(this.btnIngresar_MouseEnter);
            this.btnIngresar.MouseLeave += new System.EventHandler(this.btnIngresar_MouseLeave);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // inicioSesion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(236)))), ((int)(((byte)(225)))));
            this.ClientSize = new System.Drawing.Size(587, 479);
            this.Controls.Add(this.panelLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "inicioSesion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.inicioSesion_Load);
            this.panelLogin.ResumeLayout(false);
            this.table.ResumeLayout(false);
            this.table.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoTYV)).EndInit();
            this.passLayout.ResumeLayout(false);
            this.passLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion
    }
}