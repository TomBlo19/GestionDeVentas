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

        private void EstilizarSidebar()
        {
            foreach (Control ctrl in this.sidePanel.Controls)
            {
                if (ctrl is Label lbl && lbl != this.lblVendedorPanel)
                {
                    lbl.ForeColor = Color.FromArgb(40, 40, 40);
                    lbl.BackColor = Color.Transparent;
                    lbl.MouseEnter += (s, e) => { lbl.BackColor = Color.FromArgb(210, 190, 170); };
                    lbl.MouseLeave += (s, e) => { lbl.BackColor = Color.Transparent; };
                }
            }
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
            EstilizarSidebar();

            try
            {
                this.pictureBoxLogo.Image = global::GestionDeVentas.Properties.Resources.logo_empresa;
                this.pictureBoxLogo.SizeMode = PictureBoxSizeMode.Zoom;
            }
            catch { }
        }

        private void ShowWelcomeView()
        {
            this.mainPanel.Controls.Clear();
            isFormOpen = false;

            Label welcomeLabel = new Label();
            welcomeLabel.Text = "¡Bienvenido al Panel de Ventas!";
            welcomeLabel.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            welcomeLabel.ForeColor = Color.Gray;
            welcomeLabel.Dock = DockStyle.Top;
            welcomeLabel.TextAlign = ContentAlignment.MiddleCenter;
            welcomeLabel.Padding = new Padding(0, 30, 0, 0);
            welcomeLabel.Height = 80;

            this.pictureBoxWelcome.Visible = true;
            this.pictureBoxWelcome.Dock = DockStyle.None;
            this.pictureBoxWelcome.Size = new Size(200, 200);
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
                this.pictureBoxWelcome.Image = global::GestionDeVentas.Properties.Resources.logo_empresa;
            }
            catch { }

            lblVendedorWelcome.Text = "Vendedor";
        }

        private void lblInicio_Click(object sender, EventArgs e) => ShowWelcomeView();
        private void lblListarProductos_Click(object sender, EventArgs e) => LoadForm(new ListarProductos());
        private void lblListarVentas_Click(object sender, EventArgs e) => LoadForm(new FormVentas());
        private void lblAñadirCliente_Click(object sender, EventArgs e) => LoadForm(new FormRegistrarCliente());

        private void lblFacturacion_Click(object sender, EventArgs e) => LoadForm(new FormFactura());

        private void lblCerrarSesion_Click(object sender, EventArgs e)
        {
            var confirmar = MessageBox.Show("¿Seguro que desea cerrar sesión?", "Cerrar sesión",
                                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmar == DialogResult.Yes)
            {
                if (Application.OpenForms["inicioSesion"] != null)
                    Application.OpenForms["inicioSesion"].Show();

                this.Close();
            }
        }
    }
}
