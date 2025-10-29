using System.Windows.Forms;

namespace GestionDeVentas.Admin
{
    partial class ListarUsuario
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            // 🔧 Inicialización del contenedor (evita error del diseñador)
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();

            // 🎨 Paleta de colores TYV
            System.Drawing.Color marronOscuro = System.Drawing.Color.FromArgb(80, 50, 40);
            System.Drawing.Color marronMedio = System.Drawing.Color.FromArgb(150, 120, 100);
            System.Drawing.Color cremaFondo = System.Drawing.Color.FromArgb(250, 240, 230);
            System.Drawing.Color textoOscuro = System.Drawing.Color.FromArgb(64, 64, 64);

            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.topPanel = new System.Windows.Forms.Panel();
            this.tableLayoutPanelFiltros = new System.Windows.Forms.TableLayoutPanel();
            this.lblBuscarPor = new System.Windows.Forms.Label();
            this.cboBuscarPor = new System.Windows.Forms.ComboBox();
            this.txtFiltro = new System.Windows.Forms.TextBox();
            this.lblFiltrarRol = new System.Windows.Forms.Label();
            this.cmbFiltrarRol = new System.Windows.Forms.ComboBox();
            this.lblFiltrarEstado = new System.Windows.Forms.Label();
            this.cmbFiltrarEstado = new System.Windows.Forms.ComboBox();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.dataGridViewUsuarios = new System.Windows.Forms.DataGridView();

            this.topPanel.SuspendLayout();
            this.tableLayoutPanelFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsuarios)).BeginInit();
            this.SuspendLayout();

            // 
            // topPanel
            // 
            this.topPanel.BackColor = marronOscuro;
            this.topPanel.Controls.Add(this.btnCerrar);
            this.topPanel.Controls.Add(this.tableLayoutPanelFiltros);
            this.topPanel.Controls.Add(this.lblTitulo);
            this.topPanel.Dock = DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(800, 80);
            this.topPanel.TabIndex = 0;

            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.btnCerrar.BackColor = marronOscuro;
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatStyle = FlatStyle.Flat;
            this.btnCerrar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnCerrar.ForeColor = System.Drawing.Color.White;
            this.btnCerrar.Location = new System.Drawing.Point(760, 0);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(40, 40);
            this.btnCerrar.TabIndex = 7;
            this.btnCerrar.Text = "X";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(160, 60, 45);
            this.toolTip1.SetToolTip(this.btnCerrar, "Cerrar ventana");
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);

            // 
            // lblTitulo
            // 
            this.lblTitulo.BackColor = marronOscuro;
            this.lblTitulo.Dock = DockStyle.Top;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(800, 40);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "LISTAR USUARIOS";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // 
            // tableLayoutPanelFiltros
            // 
            this.tableLayoutPanelFiltros.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.tableLayoutPanelFiltros.ColumnCount = 7;
            this.tableLayoutPanelFiltros.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80F));
            this.tableLayoutPanelFiltros.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
            this.tableLayoutPanelFiltros.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            this.tableLayoutPanelFiltros.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40F));
            this.tableLayoutPanelFiltros.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
            this.tableLayoutPanelFiltros.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 60F));
            this.tableLayoutPanelFiltros.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));

            this.tableLayoutPanelFiltros.Controls.Add(this.lblBuscarPor, 0, 0);
            this.tableLayoutPanelFiltros.Controls.Add(this.cboBuscarPor, 1, 0);
            this.tableLayoutPanelFiltros.Controls.Add(this.txtFiltro, 2, 0);
            this.tableLayoutPanelFiltros.Controls.Add(this.lblFiltrarRol, 3, 0);
            this.tableLayoutPanelFiltros.Controls.Add(this.cmbFiltrarRol, 4, 0);
            this.tableLayoutPanelFiltros.Controls.Add(this.lblFiltrarEstado, 5, 0);
            this.tableLayoutPanelFiltros.Controls.Add(this.cmbFiltrarEstado, 6, 0);
            this.tableLayoutPanelFiltros.Location = new System.Drawing.Point(25, 40);
            this.tableLayoutPanelFiltros.Name = "tableLayoutPanelFiltros";
            this.tableLayoutPanelFiltros.RowCount = 1;
            this.tableLayoutPanelFiltros.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            this.tableLayoutPanelFiltros.Size = new System.Drawing.Size(750, 30);
            this.tableLayoutPanelFiltros.TabIndex = 1;

            // 
            // lblBuscarPor
            // 
            this.lblBuscarPor.AutoSize = true;
            this.lblBuscarPor.Dock = DockStyle.Fill;
            this.lblBuscarPor.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblBuscarPor.ForeColor = System.Drawing.Color.White;
            this.lblBuscarPor.Text = "Buscar:";
            this.lblBuscarPor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // 
            // cboBuscarPor / txtFiltro / cmbFiltrarRol / cmbFiltrarEstado
            // 
            this.cboBuscarPor.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtFiltro.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbFiltrarRol.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbFiltrarEstado.Font = new System.Drawing.Font("Segoe UI", 10F);

            // 
            // lblFiltrarRol
            // 
            this.lblFiltrarRol.AutoSize = true;
            this.lblFiltrarRol.Dock = DockStyle.Fill;
            this.lblFiltrarRol.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblFiltrarRol.ForeColor = System.Drawing.Color.White;
            this.lblFiltrarRol.Text = "Rol:";
            this.lblFiltrarRol.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // 
            // lblFiltrarEstado
            // 
            this.lblFiltrarEstado.AutoSize = true;
            this.lblFiltrarEstado.Dock = DockStyle.Fill;
            this.lblFiltrarEstado.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblFiltrarEstado.ForeColor = System.Drawing.Color.White;
            this.lblFiltrarEstado.Text = "Estado:";
            this.lblFiltrarEstado.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // 
            // dataGridViewUsuarios
            // 
            this.dataGridViewUsuarios.AllowUserToAddRows = false;
            this.dataGridViewUsuarios.AllowUserToDeleteRows = false;
            this.dataGridViewUsuarios.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.dataGridViewUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewUsuarios.BackgroundColor = cremaFondo;
            this.dataGridViewUsuarios.BorderStyle = BorderStyle.None;

            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = marronOscuro;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = marronMedio;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.dataGridViewUsuarios.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;

            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle2.ForeColor = textoOscuro;
            dataGridViewCellStyle2.SelectionBackColor = marronMedio;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            this.dataGridViewUsuarios.DefaultCellStyle = dataGridViewCellStyle2;

            this.dataGridViewUsuarios.Location = new System.Drawing.Point(12, 86);
            this.dataGridViewUsuarios.Name = "dataGridViewUsuarios";
            this.dataGridViewUsuarios.ReadOnly = true;
            this.dataGridViewUsuarios.RowHeadersVisible = false;
            this.dataGridViewUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewUsuarios.Size = new System.Drawing.Size(776, 352);

            // 
            // ListarUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridViewUsuarios);
            this.Controls.Add(this.topPanel);
            this.FormBorderStyle = FormBorderStyle.None;
            this.Name = "ListarUsuario";
            this.Text = "ListarUsuario";
            this.Load += new System.EventHandler(this.ListarUsuario_Load);

            this.topPanel.ResumeLayout(false);
            this.tableLayoutPanelFiltros.ResumeLayout(false);
            this.tableLayoutPanelFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsuarios)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.DataGridView dataGridViewUsuarios;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelFiltros;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.TextBox txtFiltro;
        private System.Windows.Forms.Label lblFiltrarRol;
        private System.Windows.Forms.ComboBox cmbFiltrarRol;
        private System.Windows.Forms.Label lblBuscarPor;
        private System.Windows.Forms.ComboBox cboBuscarPor;
        private System.Windows.Forms.Label lblFiltrarEstado;
        private System.Windows.Forms.ComboBox cmbFiltrarEstado;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
