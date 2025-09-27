// FormAdminSuperior.cs
using GestionDeVentas.Admin;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace GestionDeVentas.AdmSuperior
{
    public partial class FormAdminSuperior : Form
    {
        private bool isFormOpen = false;

        public FormAdminSuperior()
        {
            InitializeComponent();
            EstilizarSidebar();
        }

        private void EstilizarSidebar()
        {
            // Aplica el efecto de hover a todos los PictureBox y Labels en el sidePanel.
            foreach (Control ctrl in this.sidePanel.Controls)
            {
                // Si es un Label, le agregamos el evento de MouseEnter y MouseLeave
                if (ctrl is Label lbl && lbl != this.lblAdminPanel)
                {
                    lbl.ForeColor = Color.FromArgb(40, 40, 40); // Color por defecto
                    lbl.Cursor = Cursors.Hand;
                    lbl.MouseEnter += (s, e) => { lbl.BackColor = Color.FromArgb(210, 190, 170); }; // Color al pasar el mouse
                    lbl.MouseLeave += (s, e) => { lbl.BackColor = Color.Transparent; }; // Color al salir
                }
                // Si es un PictureBox (icono), le delegamos el evento al Label que tiene al lado.
                // Esto asegura que ambos cambien de color al mismo tiempo.
                else if (ctrl is PictureBox pb)
                {
                    pb.Cursor = Cursors.Hand;
                    pb.MouseEnter += (s, e) => {
                        // Buscamos el Label asociado y le cambiamos el color
                        string lblName = "lbl" + pb.Name.Substring(4);
                        if (this.sidePanel.Controls.ContainsKey(lblName))
                        {
                            this.sidePanel.Controls[lblName].BackColor = Color.FromArgb(210, 190, 170);
                        }
                    };
                    pb.MouseLeave += (s, e) => {
                        string lblName = "lbl" + pb.Name.Substring(4);
                        if (this.sidePanel.Controls.ContainsKey(lblName))
                        {
                            this.sidePanel.Controls[lblName].BackColor = Color.Transparent;
                        }
                    };
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

            // Configuramos el PictureBox de bienvenida
            this.pictureBoxWelcome.Visible = true;
            this.pictureBoxWelcome.Dock = DockStyle.None; // Para centrarlo manualmente
            this.pictureBoxWelcome.Size = new Size(200, 200);
            this.pictureBoxWelcome.SizeMode = PictureBoxSizeMode.Zoom;
            this.pictureBoxWelcome.BackColor = Color.Transparent;
            this.pictureBoxWelcome.Image = global::GestionDeVentas.Properties.Resources.logoAdm;

            // Centramos la imagen de bienvenida
            this.pictureBoxWelcome.Location = new Point(
                (this.mainPanel.Width - this.pictureBoxWelcome.Width) / 2,
                (this.mainPanel.Height - this.pictureBoxWelcome.Height) / 2
            );

            // Reagregamos los controles
            this.mainPanel.Controls.Add(this.pictureBoxWelcome);
            this.pictureBoxWelcome.BringToFront();

            // Configuramos el Label de bienvenida
            Label welcomeLabel = new Label();
            welcomeLabel.Text = "¡Bienvenido al Panel de Administración Superior!";
            welcomeLabel.Font = new Font("Arial", 18, FontStyle.Bold);
            welcomeLabel.ForeColor = Color.Black;
            welcomeLabel.Dock = DockStyle.Top;
            welcomeLabel.TextAlign = ContentAlignment.MiddleCenter;
            welcomeLabel.Padding = new Padding(0, 30, 0, 0);
            welcomeLabel.Height = 80;
            welcomeLabel.BackColor = Color.White;
            this.mainPanel.Controls.Add(welcomeLabel);
            welcomeLabel.BringToFront();

            // Nos aseguramos de que se centre dinámicamente al cambiar el tamaño de la ventana
            this.mainPanel.Resize += (sender, e) =>
            {
                this.pictureBoxWelcome.Location = new Point(
                    (this.mainPanel.Width - this.pictureBoxWelcome.Width) / 2,
                    (this.mainPanel.Height - this.pictureBoxWelcome.Height) / 2
                );
            };
        }

        private void lblInicio_Click(object sender, EventArgs e) => ShowWelcomeView();
        private void lblRegistrarUsuario_Click(object sender, EventArgs e) => LoadForm(new FormRegistrarUsuario());
        private void lblListarUsuario_Click(object sender, EventArgs e) => LoadForm(new ListarUsuario());
        private void lblBackup_Click(object sender, EventArgs e) => LoadForm(new FormBackup());

        private void lblCerrarSesion_Click(object sender, EventArgs e)
        {
            var confirmar = MessageBox.Show("¿Seguro que desea cerrar sesión?",
                                            "Cerrar sesión",
                                            MessageBoxButtons.YesNo,
                                            MessageBoxIcon.Question);

            if (confirmar == DialogResult.Yes)
            {
                if (Application.OpenForms["inicioSesion"] != null)
                {
                    Application.OpenForms["inicioSesion"].Show();
                }
                this.Close();
            }
        }

        private void lblAdminPanel_Click(object sender, EventArgs e)
        {

        }

        private void mainPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}