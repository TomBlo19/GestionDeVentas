using System.Windows.Forms;
using System.Drawing;

namespace GestionDeVentas.Admin
{
    partial class FormGestionarUsuarios
    {
        private System.ComponentModel.IContainer components = null;

        // UI
        private Panel panelTop;
        private Label lblTitulo;
        private Button btnCerrar;

        private Panel panelFiltros;
        private TextBox txtBusqueda;
        private ComboBox cmbFiltroEstado;

        private DataGridView dgvUsuarios;

        private Panel panelBottom;
        private Button btnAccion;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelTop = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.panelFiltros = new System.Windows.Forms.Panel();
            this.Estado = new System.Windows.Forms.Label();
            this.txtBusqueda = new System.Windows.Forms.TextBox();
            this.cmbFiltroEstado = new System.Windows.Forms.ComboBox();
            this.dgvUsuarios = new System.Windows.Forms.DataGridView();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.btnAccion = new System.Windows.Forms.Button();
            this.panelTop.SuspendLayout();
            this.panelFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.panelTop.Controls.Add(this.lblTitulo);
            this.panelTop.Controls.Add(this.btnCerrar);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(960, 50);
            this.panelTop.TabIndex = 3;
            // 
            // lblTitulo
            // 
            this.lblTitulo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(275, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.lblTitulo.Size = new System.Drawing.Size(204, 50);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Gestión de Clientes";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnCerrar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.ForeColor = System.Drawing.Color.White;
            this.btnCerrar.Location = new System.Drawing.Point(920, 0);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(40, 50);
            this.btnCerrar.TabIndex = 1;
            this.btnCerrar.Text = "X";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // panelFiltros
            // 
            this.panelFiltros.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelFiltros.Controls.Add(this.Estado);
            this.panelFiltros.Controls.Add(this.txtBusqueda);
            this.panelFiltros.Controls.Add(this.cmbFiltroEstado);
            this.panelFiltros.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFiltros.Location = new System.Drawing.Point(0, 50);
            this.panelFiltros.Name = "panelFiltros";
            this.panelFiltros.Size = new System.Drawing.Size(960, 48);
            this.panelFiltros.TabIndex = 2;
            // 
            // Estado
            // 
            this.Estado.AutoSize = true;
            this.Estado.Location = new System.Drawing.Point(294, 17);
            this.Estado.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Estado.Name = "Estado";
            this.Estado.Size = new System.Drawing.Size(43, 13);
            this.Estado.TabIndex = 2;
            this.Estado.Text = "Estado:";
            // 
            // txtBusqueda
            // 
            this.txtBusqueda.Location = new System.Drawing.Point(30, 15);
            this.txtBusqueda.Name = "txtBusqueda";
            this.txtBusqueda.Size = new System.Drawing.Size(260, 20);
            this.txtBusqueda.TabIndex = 0;
            this.txtBusqueda.TextChanged += new System.EventHandler(this.txtBusqueda_TextChanged);
            this.txtBusqueda.Enter += new System.EventHandler(this.txtBusqueda_Enter);
            this.txtBusqueda.Leave += new System.EventHandler(this.txtBusqueda_Leave);
            // 
            // cmbFiltroEstado
            // 
            this.cmbFiltroEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiltroEstado.Items.AddRange(new object[] {
            "Todos",
            "Activo",
            "Inactivo"});
            this.cmbFiltroEstado.Location = new System.Drawing.Point(340, 12);
            this.cmbFiltroEstado.Name = "cmbFiltroEstado";
            this.cmbFiltroEstado.Size = new System.Drawing.Size(140, 21);
            this.cmbFiltroEstado.TabIndex = 1;
            this.cmbFiltroEstado.SelectedIndexChanged += new System.EventHandler(this.cmbFiltroEstado_SelectedIndexChanged);
            // 
            // dgvUsuarios
            // 
            this.dgvUsuarios.AllowUserToAddRows = false;
            this.dgvUsuarios.AllowUserToDeleteRows = false;
            this.dgvUsuarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUsuarios.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvUsuarios.ColumnHeadersHeight = 29;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvUsuarios.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvUsuarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUsuarios.EnableHeadersVisualStyles = false;
            this.dgvUsuarios.Location = new System.Drawing.Point(0, 98);
            this.dgvUsuarios.MultiSelect = false;
            this.dgvUsuarios.Name = "dgvUsuarios";
            this.dgvUsuarios.ReadOnly = true;
            this.dgvUsuarios.RowHeadersWidth = 51;
            this.dgvUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsuarios.Size = new System.Drawing.Size(960, 398);
            this.dgvUsuarios.TabIndex = 0;
            this.dgvUsuarios.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsuarios_CellContentClick);
            this.dgvUsuarios.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvUsuarios_CellFormatting);
            this.dgvUsuarios.SelectionChanged += new System.EventHandler(this.dgvUsuarios_SelectionChanged);
            // 
            // panelBottom
            // 
            this.panelBottom.BackColor = System.Drawing.Color.White;
            this.panelBottom.Controls.Add(this.btnAccion);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 496);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(960, 64);
            this.panelBottom.TabIndex = 1;
            // 
            // btnAccion
            // 
            this.btnAccion.BackColor = System.Drawing.Color.Red;
            this.btnAccion.FlatAppearance.BorderSize = 0;
            this.btnAccion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccion.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnAccion.ForeColor = System.Drawing.Color.White;
            this.btnAccion.Location = new System.Drawing.Point(16, 12);
            this.btnAccion.Name = "btnAccion";
            this.btnAccion.Size = new System.Drawing.Size(220, 40);
            this.btnAccion.TabIndex = 0;
            this.btnAccion.Text = "Desactivar Cliente";
            this.btnAccion.UseVisualStyleBackColor = false;
            this.btnAccion.Click += new System.EventHandler(this.btnAccion_Click);
            // 
            // FormGestionarUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 560);
            this.Controls.Add(this.dgvUsuarios);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelFiltros);
            this.Controls.Add(this.panelTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormGestionarUsuarios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestión de Clientes";
            this.Load += new System.EventHandler(this.FormGestionarUsuarios_Load);
            this.panelTop.ResumeLayout(false);
            this.panelFiltros.ResumeLayout(false);
            this.panelFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
            this.panelBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private Label Estado;
    }
}
