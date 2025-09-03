using GestionDeVentas.Admin;
using System;
using System.Drawing;
using System.Windows.Forms;

// El namespace ahora es AdmSuperior para ser consistente con el login
namespace GestionDeVentas.AdmSuperior
{
    public partial class FormAdminSuperior : Form
    {
        private bool isFormOpen = false;

        public FormAdminSuperior()
        {
            InitializeComponent();
        }

        // ... (el resto de tu código de FormAdminSuperior.cs) ...
        // No necesitas cambiar nada más, solo el namespace de arriba

        private void LoadForm(Form form)
        {
            if (isFormOpen)
            {
                MessageBox.Show("Ya hay una ventana abierta. Cierra la ventana actual para abrir otra.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            isFormOpen = true;
            this.mainPanel.Controls.Clear();
            this.pictureBoxWelcome.Visible = false;

            form.FormClosed += (s, e) => {
                isFormOpen = false;
                this.mainPanel.Controls.Clear();
                ShowWelcomeView();
            };

            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            this.mainPanel.Controls.Add(form);
            form.Show();
        }

        private void FormAdminSuperior_Load(object sender, EventArgs e)
        {
            this.ShowWelcomeView();

            try
            {
                this.pictureBoxLogo.Image = global::GestionDeVentas.Properties.Resources.logo_empresa;
                this.pictureBoxLogo.SizeMode = PictureBoxSizeMode.Zoom;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el logo de la empresa: " + ex.Message, "Error de Imagen", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowWelcomeView()
        {
            this.mainPanel.Controls.Clear();
            isFormOpen = false;

            Label welcomeLabel = new Label();
            welcomeLabel.Text = "¡Bienvenido al Panel de Administración Superior!";
            welcomeLabel.Font = new Font("Arial", 20, FontStyle.Bold);
            welcomeLabel.ForeColor = System.Drawing.Color.Gray;
            welcomeLabel.Dock = DockStyle.Top;
            welcomeLabel.TextAlign = ContentAlignment.MiddleCenter;
            welcomeLabel.Padding = new Padding(0, 30, 0, 0);
            welcomeLabel.Height = 80;

            this.pictureBoxWelcome.Visible = true;
            this.pictureBoxWelcome.Dock = DockStyle.None;
            this.pictureBoxWelcome.Size = new Size(250, 250);
            this.pictureBoxWelcome.SizeMode = PictureBoxSizeMode.Zoom;
            this.pictureBoxWelcome.BackColor = Color.Transparent;

            this.mainPanel.Controls.Add(welcomeLabel);
            this.mainPanel.Controls.Add(this.pictureBoxWelcome);
            welcomeLabel.BringToFront();

            this.pictureBoxWelcome.Location = new Point(
                (this.mainPanel.Width - this.pictureBoxWelcome.Width) / 2,
                (this.mainPanel.Height - this.pictureBoxWelcome.Height) / 2
            );

            welcomeLabel.Location = new Point(
                (this.mainPanel.Width - welcomeLabel.Width) / 2,
                (this.mainPanel.Height - welcomeLabel.Height - this.pictureBoxWelcome.Height) / 2
            );

            this.mainPanel.Resize += (sender, e) => {
                this.pictureBoxWelcome.Location = new Point(
                    (this.mainPanel.Width - this.pictureBoxWelcome.Width) / 2,
                    (this.mainPanel.Height - this.pictureBoxWelcome.Height) / 2
                );
                welcomeLabel.Location = new Point(
                    (this.mainPanel.Width - welcomeLabel.Width) / 2,
                    (this.mainPanel.Height - welcomeLabel.Height - this.pictureBoxWelcome.Height) / 2
                );
            };

            try
            {
                this.pictureBoxWelcome.Image = global::GestionDeVentas.Properties.Resources.logoAdm;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la imagen de bienvenida: " + ex.Message, "Error de Imagen", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            lblAdminWelcome.Text = "Administrador Superior";
            lblAdminWelcome.TextAlign = ContentAlignment.MiddleRight;
        }

        private void lblInicio_Click(object sender, EventArgs e)
        {
            ShowWelcomeView();
        }

        private void lblRegistrarUsuario_Click(object sender, EventArgs e)
        {
            LoadForm(new FormRegistrarUsuario());
        }

        private void lblListarUsuario_Click(object sender, EventArgs e)
        {
            LoadForm(new ListarUsuario());
        }

        private void lblGestionarUsuarios_Click(object sender, EventArgs e)
        {
            // Este método ahora está vacío
        }

        private void lblListarVentas_Click(object sender, EventArgs e)
        {
            LoadForm(new ListarVentas());
        }

        private void lblCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBoxWelcome_Click(object sender, EventArgs e)
        {
            // Este método está vacío
        }
    }
}