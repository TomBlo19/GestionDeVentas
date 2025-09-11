using GestionDeVentas.Admin;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace GestionDeVentas.Gerent
{
    public partial class FormGerentePanel : Form
    {
        private bool isFormOpen = false;

        public FormGerentePanel()
        {
            InitializeComponent();
        }

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

            form.FormClosed += (s, e) =>
            {
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

        private void FormGerentePanel_Load(object sender, EventArgs e)
        {
            this.ShowWelcomeView();

            try
            {
                // Carga tu logo aquí
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
            welcomeLabel.Text = "¡Bienvenido al Panel de Gerente!";
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

            this.mainPanel.Resize += (sender, e) =>
            {
                this.pictureBoxWelcome.Location = new Point(
                    (this.mainPanel.Width - this.pictureBoxWelcome.Width) / 2,
                    (this.mainPanel.Height - this.pictureBoxWelcome.Height) / 2
                );
            };

            try
            {
                // Carga tu imagen de bienvenida para el gerente
                //this.pictureBoxWelcome.Image = global::GestionDeVentas.Properties.Resources.imagen_gerente_bienvenida;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la imagen de bienvenida: " + ex.Message, "Error de Imagen", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            lblGerenteWelcome.Text = "Gerente";
            lblGerenteWelcome.TextAlign = ContentAlignment.MiddleRight;
        }

        // Métodos del menú lateral
        private void lblInicio_Click(object sender, EventArgs e)
        {
            ShowWelcomeView();
        }

        private void lblDashboard_Click(object sender, EventArgs e)
        {
            LoadForm(new FormDashboard());
        }

        private void lblReportes_Click(object sender, EventArgs e)
        {
            
            LoadForm(new FormReportes());
        }

        private void lblRendimientoVendedores_Click(object sender, EventArgs e)
        {
            // Carga el formulario de Rendimiento de Vendedores
            LoadForm(new FormRendimientoVendedores());
        }

        private void lblCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBoxWelcome_Click(object sender, EventArgs e)
        {

        }

        private void topBarPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblGerenteWelcome_Click(object sender, EventArgs e)
        {

        }

        private void pictureBoxLogo_Click(object sender, EventArgs e)
        {

        }
    }
}