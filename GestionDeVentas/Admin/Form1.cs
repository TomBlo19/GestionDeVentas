using GestionDeVentas.AdmSuperior;
using GestionDeVentas.Gerente;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace GestionDeVentas.Admin
{
    public partial class Form1 : Form
    {
        private bool isFormOpen = false;

        public Form1()
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

            form.FormClosed += (s, e) => {
                isFormOpen = false;
                this.mainPanel.Controls.Clear();
                ShowWelcomeView();
            };

            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill; // Importante para que el formulario hijo se adapte
            this.mainPanel.Controls.Add(form);
            form.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
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
            welcomeLabel.Text = "¡Bienvenido al Panel de Administración!";
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

            // Centra dinámicamente el PictureBox y el Label en el mainPanel
            this.mainPanel.Controls.Add(welcomeLabel);
            this.mainPanel.Controls.Add(this.pictureBoxWelcome);

            welcomeLabel.BringToFront(); // Asegura que el texto esté encima

            // Centrar el PictureBox en el mainPanel
            this.pictureBoxWelcome.Location = new Point(
                (this.mainPanel.Width - this.pictureBoxWelcome.Width) / 2,
                (this.mainPanel.Height - this.pictureBoxWelcome.Height) / 2
            );

            // Ajustar la posición del label para que esté sobre la imagen
            welcomeLabel.Location = new Point(
                (this.mainPanel.Width - welcomeLabel.Width) / 2,
                (this.mainPanel.Height - welcomeLabel.Height - this.pictureBoxWelcome.Height) / 2
            );

            // Suscribirse al evento Resize para que se recoloque si la ventana cambia de tamaño
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

            lblAdminWelcome.Text = "Administrador";
            lblAdminWelcome.TextAlign = ContentAlignment.MiddleRight;
        }

        // Métodos de los botones del menú lateral
        private void lblInicio_Click(object sender, EventArgs e)
        {
            ShowWelcomeView();
        }

        private void lblListarProductos_Click(object sender, EventArgs e)
        {
            LoadForm(new ListarProductos());
        }

        private void lblRegistrarPrenda_Click(object sender, EventArgs e)
        {
            LoadForm(new FormRegistrarProducto());
        }

        private void lblGestionarPrendas_Click(object sender, EventArgs e)
        {
            LoadForm(new FormGestionProductos());
        }

       

        // Mantén los métodos vacíos si son necesarios, pero elimina los clics que ya no tienen botón
        private void lblAdminWelcome_Click(object sender, EventArgs e) { }
        private void lblAdminPanel_Click(object sender, EventArgs e) { }
        private void mainPanel_Paint(object sender, PaintEventArgs e) { }
        private void pictureBoxWelcome_Click(object sender, EventArgs e) { }

        private void pictureBoxWelcome_Click_1(object sender, EventArgs e)
        {

        }

        private void lblAdminWelcome_Click_1(object sender, EventArgs e)
        {

        }

        private void lblCerrarSesion_Click(object sender, EventArgs e)
        {
            LoadForm(new FormGestionarUsuarios());

        }


        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            var confirmar = MessageBox.Show("¿Seguro que desea cerrar sesión?",
                                           "Cerrar sesión",
                                         MessageBoxButtons.YesNo,
                                           MessageBoxIcon.Question);

            if (confirmar == DialogResult.Yes)
            {
                Application.OpenForms["inicioSesion"].Show(); // 🔹 Vuelve a mostrar el login
                this.Close(); // 🔹 Cierra el panel actual
            }
        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            LoadForm(new FormRegistrarProveedor());
        }

        private void lblAdminPanel_Click_1(object sender, EventArgs e)
        {

        }

        private void lblAdminPanel_Click_2(object sender, EventArgs e)
        {

        }

        private void iconInicio_Click(object sender, EventArgs e)
        {

        }

        private void iconRegistrarPrenda_Click(object sender, EventArgs e)
        {

        }

        private void iconListarProductos_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_2(object sender, EventArgs e)
        {
            var confirmar = MessageBox.Show("¿Seguro que desea cerrar sesión?",
                                           "Cerrar sesión",
                                           MessageBoxButtons.YesNo,
                                           MessageBoxIcon.Question);

            if (confirmar == DialogResult.Yes)
            {
                Application.OpenForms["inicioSesion"].Show(); // 🔹 Vuelve a mostrar el login
                this.Close(); // 🔹 Cierra el panel actual
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            LoadForm(new FormReportesGerente());
        }
    }


    

    public class FormGestionarPrendas : Form { }
    public class FormModificarUsuario : Form { }
}