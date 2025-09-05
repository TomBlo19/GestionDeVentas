using GestionDeVentas.Admin;
using GestionDeVentas.Gerente;
using GestionDeVentas.Vendedor;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace GestionDeVentas.vendedor
{
    public partial class FormVendedor : Form
    {
        private bool isFormOpen = false;

        public FormVendedor()
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
            form.Dock = DockStyle.Fill;
            this.mainPanel.Controls.Add(form);
            form.Show();
        }

        private void FormVendedor_Load(object sender, EventArgs e)
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
            welcomeLabel.Text = "¡Bienvenido al Panel de Ventas!";
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

            this.mainPanel.Resize += (sender, e) => {
                this.pictureBoxWelcome.Location = new Point(
                    (this.mainPanel.Width - this.pictureBoxWelcome.Width) / 2,
                    (this.mainPanel.Height - this.pictureBoxWelcome.Height) / 2
                );
            };

            try
            {
                // Carga tu imagen de bienvenida de vendedor
                this.pictureBoxWelcome.Image = global::GestionDeVentas.Properties.Resources.logo_empresa;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la imagen de bienvenida: " + ex.Message, "Error de Imagen", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            lblVendedorWelcome.Text = "Vendedor";
            lblVendedorWelcome.TextAlign = ContentAlignment.MiddleRight;
        }

        // Métodos del menú lateral
        private void lblInicio_Click(object sender, EventArgs e)
        {
            ShowWelcomeView();
        }

        private void lblListarProductos_Click(object sender, EventArgs e)
        {
            // Carga el formulario de listar productos
            LoadForm(new ListarProductos());
        }

        private void lblListarVentas_Click(object sender, EventArgs e)
        {
            // Carga un formulario vacío para pruebas
            Form tempForm = new Form();
            tempForm.Text = "Formulario de Listar Ventas (Vacío)";
            LoadForm(tempForm);
        }

        private void lblAñadirCliente_Click(object sender, EventArgs e)
        {
            LoadForm(new FormRegistrarCliente());
        }

        private void lblCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //terminar
        private void lblFacturacion_Click(object sender, EventArgs e)
        {
            LoadForm(new FormFactura());
        }

        private void pictureBoxWelcome_Click(object sender, EventArgs e)
        {
            // Este método está vacío, no se necesita acción aquí
        }
    }
}