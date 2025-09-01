namespace gestionDeVentas
{
    partial class FormGerente
    {
        /// <summary>
        /// Limpieza de recursos.
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador

        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panelSidebar = new System.Windows.Forms.Panel();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.btnRendimiento = new System.Windows.Forms.Button();
            this.btnReportes = new System.Windows.Forms.Button();
            this.btnListarVentas = new System.Windows.Forms.Button();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.btnInicio = new System.Windows.Forms.Button();
            this.lblTituloSidebar = new System.Windows.Forms.Label();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.pnlAvatar = new System.Windows.Forms.Panel();
            this.panelMain = new System.Windows.Forms.Panel();
            this.tableMain = new System.Windows.Forms.TableLayoutPanel();
            this.flowKpis = new System.Windows.Forms.FlowLayoutPanel();
            this.cardKpi1 = new System.Windows.Forms.Panel();
            this.lblKpi1Val = new System.Windows.Forms.Label();
            this.lblKpi1 = new System.Windows.Forms.Label();
            this.cardKpi2 = new System.Windows.Forms.Panel();
            this.lblKpi2Val = new System.Windows.Forms.Label();
            this.lblKpi2 = new System.Windows.Forms.Label();
            this.cardKpi3 = new System.Windows.Forms.Panel();
            this.lblKpi3Val = new System.Windows.Forms.Label();
            this.lblKpi3 = new System.Windows.Forms.Label();
            this.panelFiltros = new System.Windows.Forms.Panel();
            this.btnExportar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.cboVendedor = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtHasta = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtDesde = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.tableCharts = new System.Windows.Forms.TableLayoutPanel();
            this.chartVendedores = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartCategorias = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dgvVentas = new System.Windows.Forms.DataGridView();
            this.panelSidebar.SuspendLayout();
            this.panelHeader.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.tableMain.SuspendLayout();
            this.flowKpis.SuspendLayout();
            this.cardKpi1.SuspendLayout();
            this.cardKpi2.SuspendLayout();
            this.cardKpi3.SuspendLayout();
            this.panelFiltros.SuspendLayout();
            this.tableCharts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartVendedores)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartCategorias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVentas)).BeginInit();
            this.SuspendLayout();
            // 
            // panelSidebar
            // 
            this.panelSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(221)))), ((int)(((byte)(211)))));
            this.panelSidebar.Controls.Add(this.btnCerrarSesion);
            this.panelSidebar.Controls.Add(this.btnRendimiento);
            this.panelSidebar.Controls.Add(this.btnReportes);
            this.panelSidebar.Controls.Add(this.btnListarVentas);
            this.panelSidebar.Controls.Add(this.btnDashboard);
            this.panelSidebar.Controls.Add(this.btnInicio);
            this.panelSidebar.Controls.Add(this.lblTituloSidebar);
            this.panelSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSidebar.Location = new System.Drawing.Point(0, 0);
            this.panelSidebar.Name = "panelSidebar";
            this.panelSidebar.Size = new System.Drawing.Size(297, 768);
            this.panelSidebar.TabIndex = 0;
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.FlatAppearance.BorderSize = 0;
            this.btnCerrarSesion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrarSesion.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnCerrarSesion.Location = new System.Drawing.Point(23, 352);
            this.btnCerrarSesion.Margin = new System.Windows.Forms.Padding(3, 11, 3, 3);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(251, 38);
            this.btnCerrarSesion.TabIndex = 6;
            this.btnCerrarSesion.Text = "Cerrar sesión";
            this.btnCerrarSesion.UseVisualStyleBackColor = true;
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);
            // 
            // btnRendimiento
            // 
            this.btnRendimiento.FlatAppearance.BorderSize = 0;
            this.btnRendimiento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRendimiento.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnRendimiento.Location = new System.Drawing.Point(23, 297);
            this.btnRendimiento.Name = "btnRendimiento";
            this.btnRendimiento.Size = new System.Drawing.Size(251, 38);
            this.btnRendimiento.TabIndex = 5;
            this.btnRendimiento.Text = "Rendimiento Vendedores";
            this.btnRendimiento.UseVisualStyleBackColor = true;
            // 
            // btnReportes
            // 
            this.btnReportes.FlatAppearance.BorderSize = 0;
            this.btnReportes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReportes.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnReportes.Location = new System.Drawing.Point(23, 252);
            this.btnReportes.Name = "btnReportes";
            this.btnReportes.Size = new System.Drawing.Size(251, 38);
            this.btnReportes.TabIndex = 4;
            this.btnReportes.Text = "Reportes";
            this.btnReportes.UseVisualStyleBackColor = true;
            // 
            // btnListarVentas
            // 
            this.btnListarVentas.FlatAppearance.BorderSize = 0;
            this.btnListarVentas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnListarVentas.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnListarVentas.Location = new System.Drawing.Point(23, 207);
            this.btnListarVentas.Name = "btnListarVentas";
            this.btnListarVentas.Size = new System.Drawing.Size(251, 38);
            this.btnListarVentas.TabIndex = 3;
            this.btnListarVentas.Text = "Listar Ventas";
            this.btnListarVentas.UseVisualStyleBackColor = true;
            // 
            // btnDashboard
            // 
            this.btnDashboard.FlatAppearance.BorderSize = 0;
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboard.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnDashboard.Location = new System.Drawing.Point(23, 162);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Size = new System.Drawing.Size(251, 38);
            this.btnDashboard.TabIndex = 2;
            this.btnDashboard.Text = "Dashboard";
            this.btnDashboard.UseVisualStyleBackColor = true;
            // 
            // btnInicio
            // 
            this.btnInicio.FlatAppearance.BorderSize = 0;
            this.btnInicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInicio.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnInicio.Location = new System.Drawing.Point(23, 117);
            this.btnInicio.Name = "btnInicio";
            this.btnInicio.Size = new System.Drawing.Size(251, 38);
            this.btnInicio.TabIndex = 1;
            this.btnInicio.Text = "Inicio";
            this.btnInicio.UseVisualStyleBackColor = true;
            this.btnInicio.Click += new System.EventHandler(this.btnInicio_Click);
            // 
            // lblTituloSidebar
            // 
            this.lblTituloSidebar.AutoSize = true;
            this.lblTituloSidebar.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold);
            this.lblTituloSidebar.Location = new System.Drawing.Point(21, 32);
            this.lblTituloSidebar.Name = "lblTituloSidebar";
            this.lblTituloSidebar.Size = new System.Drawing.Size(252, 41);
            this.lblTituloSidebar.TabIndex = 0;
            this.lblTituloSidebar.Text = "Panel de Gerente";
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.Black;
            this.panelHeader.Controls.Add(this.lblUsuario);
            this.panelHeader.Controls.Add(this.pnlAvatar);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(297, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1166, 68);
            this.panelHeader.TabIndex = 1;
            // 
            // lblUsuario
            // 
            this.lblUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblUsuario.ForeColor = System.Drawing.Color.White;
            this.lblUsuario.Location = new System.Drawing.Point(1017, 28);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(81, 28);
            this.lblUsuario.TabIndex = 1;
            this.lblUsuario.Text = "Gerente";
            // 
            // pnlAvatar
            // 
            this.pnlAvatar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pnlAvatar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.pnlAvatar.Location = new System.Drawing.Point(549, 13);
            this.pnlAvatar.Name = "pnlAvatar";
            this.pnlAvatar.Size = new System.Drawing.Size(55, 43);
            this.pnlAvatar.TabIndex = 0;
            this.pnlAvatar.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlAvatar_Paint);
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelMain.Controls.Add(this.tableMain);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(297, 68);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(14, 13, 14, 13);
            this.panelMain.Size = new System.Drawing.Size(1166, 700);
            this.panelMain.TabIndex = 2;
            // 
            // tableMain
            // 
            this.tableMain.ColumnCount = 1;
            this.tableMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableMain.Controls.Add(this.flowKpis, 0, 1);
            this.tableMain.Controls.Add(this.panelFiltros, 0, 0);
            this.tableMain.Controls.Add(this.tableCharts, 0, 2);
            this.tableMain.Controls.Add(this.dgvVentas, 0, 3);
            this.tableMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableMain.Location = new System.Drawing.Point(14, 13);
            this.tableMain.Name = "tableMain";
            this.tableMain.RowCount = 4;
            this.tableMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 73F));
            this.tableMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 102F));
            this.tableMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 256F));
            this.tableMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableMain.Size = new System.Drawing.Size(1138, 674);
            this.tableMain.TabIndex = 0;
            // 
            // flowKpis
            // 
            this.flowKpis.BackColor = System.Drawing.Color.Transparent;
            this.flowKpis.Controls.Add(this.cardKpi1);
            this.flowKpis.Controls.Add(this.cardKpi2);
            this.flowKpis.Controls.Add(this.cardKpi3);
            this.flowKpis.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowKpis.Location = new System.Drawing.Point(3, 76);
            this.flowKpis.Name = "flowKpis";
            this.flowKpis.Padding = new System.Windows.Forms.Padding(0, 6, 0, 6);
            this.flowKpis.Size = new System.Drawing.Size(1132, 96);
            this.flowKpis.TabIndex = 0;
            // 
            // cardKpi1
            // 
            this.cardKpi1.BackColor = System.Drawing.Color.White;
            this.cardKpi1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cardKpi1.Controls.Add(this.lblKpi1Val);
            this.cardKpi1.Controls.Add(this.lblKpi1);
            this.cardKpi1.Location = new System.Drawing.Point(9, 15);
            this.cardKpi1.Margin = new System.Windows.Forms.Padding(9, 9, 9, 9);
            this.cardKpi1.Name = "cardKpi1";
            this.cardKpi1.Padding = new System.Windows.Forms.Padding(14, 13, 14, 13);
            this.cardKpi1.Size = new System.Drawing.Size(343, 75);
            this.cardKpi1.TabIndex = 0;
            // 
            // lblKpi1Val
            // 
            this.lblKpi1Val.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblKpi1Val.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Bold);
            this.lblKpi1Val.Location = new System.Drawing.Point(169, 13);
            this.lblKpi1Val.Name = "lblKpi1Val";
            this.lblKpi1Val.Size = new System.Drawing.Size(160, 43);
            this.lblKpi1Val.TabIndex = 1;
            this.lblKpi1Val.Text = "$0";
            this.lblKpi1Val.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblKpi1
            // 
            this.lblKpi1.AutoSize = true;
            this.lblKpi1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblKpi1.Location = new System.Drawing.Point(14, 15);
            this.lblKpi1.Name = "lblKpi1";
            this.lblKpi1.Size = new System.Drawing.Size(120, 23);
            this.lblKpi1.TabIndex = 0;
            this.lblKpi1.Text = "Ingresos (mes)";
            // 
            // cardKpi2
            // 
            this.cardKpi2.BackColor = System.Drawing.Color.White;
            this.cardKpi2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cardKpi2.Controls.Add(this.lblKpi2Val);
            this.cardKpi2.Controls.Add(this.lblKpi2);
            this.cardKpi2.Location = new System.Drawing.Point(370, 15);
            this.cardKpi2.Margin = new System.Windows.Forms.Padding(9, 9, 9, 9);
            this.cardKpi2.Name = "cardKpi2";
            this.cardKpi2.Padding = new System.Windows.Forms.Padding(14, 13, 14, 13);
            this.cardKpi2.Size = new System.Drawing.Size(343, 75);
            this.cardKpi2.TabIndex = 1;
            // 
            // lblKpi2Val
            // 
            this.lblKpi2Val.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblKpi2Val.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Bold);
            this.lblKpi2Val.Location = new System.Drawing.Point(169, 13);
            this.lblKpi2Val.Name = "lblKpi2Val";
            this.lblKpi2Val.Size = new System.Drawing.Size(160, 43);
            this.lblKpi2Val.TabIndex = 1;
            this.lblKpi2Val.Text = "0";
            this.lblKpi2Val.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblKpi2
            // 
            this.lblKpi2.AutoSize = true;
            this.lblKpi2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblKpi2.Location = new System.Drawing.Point(14, 15);
            this.lblKpi2.Name = "lblKpi2";
            this.lblKpi2.Size = new System.Drawing.Size(145, 23);
            this.lblKpi2.TabIndex = 0;
            this.lblKpi2.Text = "Ventas (unidades)";
            // 
            // cardKpi3
            // 
            this.cardKpi3.BackColor = System.Drawing.Color.White;
            this.cardKpi3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cardKpi3.Controls.Add(this.lblKpi3Val);
            this.cardKpi3.Controls.Add(this.lblKpi3);
            this.cardKpi3.Location = new System.Drawing.Point(731, 15);
            this.cardKpi3.Margin = new System.Windows.Forms.Padding(9, 9, 9, 9);
            this.cardKpi3.Name = "cardKpi3";
            this.cardKpi3.Padding = new System.Windows.Forms.Padding(14, 13, 14, 13);
            this.cardKpi3.Size = new System.Drawing.Size(343, 75);
            this.cardKpi3.TabIndex = 2;
            // 
            // lblKpi3Val
            // 
            this.lblKpi3Val.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblKpi3Val.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Bold);
            this.lblKpi3Val.Location = new System.Drawing.Point(169, 13);
            this.lblKpi3Val.Name = "lblKpi3Val";
            this.lblKpi3Val.Size = new System.Drawing.Size(160, 43);
            this.lblKpi3Val.TabIndex = 1;
            this.lblKpi3Val.Text = "0%";
            this.lblKpi3Val.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblKpi3
            // 
            this.lblKpi3.AutoSize = true;
            this.lblKpi3.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblKpi3.Location = new System.Drawing.Point(14, 15);
            this.lblKpi3.Name = "lblKpi3";
            this.lblKpi3.Size = new System.Drawing.Size(162, 23);
            this.lblKpi3.TabIndex = 0;
            this.lblKpi3.Text = "Crecimiento (mens.)";
            // 
            // panelFiltros
            // 
            this.panelFiltros.BackColor = System.Drawing.Color.White;
            this.panelFiltros.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelFiltros.Controls.Add(this.btnExportar);
            this.panelFiltros.Controls.Add(this.btnBuscar);
            this.panelFiltros.Controls.Add(this.cboVendedor);
            this.panelFiltros.Controls.Add(this.label3);
            this.panelFiltros.Controls.Add(this.dtHasta);
            this.panelFiltros.Controls.Add(this.label2);
            this.panelFiltros.Controls.Add(this.dtDesde);
            this.panelFiltros.Controls.Add(this.label1);
            this.panelFiltros.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFiltros.Location = new System.Drawing.Point(3, 3);
            this.panelFiltros.Name = "panelFiltros";
            this.panelFiltros.Size = new System.Drawing.Size(1132, 67);
            this.panelFiltros.TabIndex = 1;
            // 
            // btnExportar
            // 
            this.btnExportar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportar.BackColor = System.Drawing.Color.SeaGreen;
            this.btnExportar.FlatAppearance.BorderSize = 0;
            this.btnExportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnExportar.ForeColor = System.Drawing.Color.White;
            this.btnExportar.Location = new System.Drawing.Point(1004, 14);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(109, 36);
            this.btnExportar.TabIndex = 7;
            this.btnExportar.Text = "Exportar";
            this.btnExportar.UseVisualStyleBackColor = false;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(884, 14);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(109, 36);
            this.btnBuscar.TabIndex = 6;
            this.btnBuscar.Text = "Aplicar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // cboVendedor
            // 
            this.cboVendedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboVendedor.FormattingEnabled = true;
            this.cboVendedor.Location = new System.Drawing.Point(622, 20);
            this.cboVendedor.Name = "cboVendedor";
            this.cboVendedor.Size = new System.Drawing.Size(233, 24);
            this.cboVendedor.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(542, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Vendedor:";
            // 
            // dtHasta
            // 
            this.dtHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtHasta.Location = new System.Drawing.Point(375, 20);
            this.dtHasta.Name = "dtHasta";
            this.dtHasta.Size = new System.Drawing.Size(146, 22);
            this.dtHasta.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(320, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Hasta:";
            // 
            // dtDesde
            // 
            this.dtDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDesde.Location = new System.Drawing.Point(144, 20);
            this.dtDesde.Name = "dtDesde";
            this.dtDesde.Size = new System.Drawing.Size(146, 22);
            this.dtDesde.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Desde:";
            // 
            // tableCharts
            // 
            this.tableCharts.ColumnCount = 2;
            this.tableCharts.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableCharts.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableCharts.Controls.Add(this.chartVendedores, 0, 0);
            this.tableCharts.Controls.Add(this.chartCategorias, 1, 0);
            this.tableCharts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableCharts.Location = new System.Drawing.Point(3, 178);
            this.tableCharts.Name = "tableCharts";
            this.tableCharts.RowCount = 1;
            this.tableCharts.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableCharts.Size = new System.Drawing.Size(1132, 250);
            this.tableCharts.TabIndex = 2;
            // 
            // chartVendedores
            // 
            chartArea5.AxisX.MajorGrid.Enabled = false;
            chartArea5.AxisY.MajorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea5.Name = "ChartArea1";
            this.chartVendedores.ChartAreas.Add(chartArea5);
            this.chartVendedores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartVendedores.Location = new System.Drawing.Point(3, 3);
            this.chartVendedores.Name = "chartVendedores";
            series5.ChartArea = "ChartArea1";
            series5.Name = "Series1";
            this.chartVendedores.Series.Add(series5);
            this.chartVendedores.Size = new System.Drawing.Size(560, 244);
            this.chartVendedores.TabIndex = 0;
            this.chartVendedores.Text = "chart1";
            // 
            // chartCategorias
            // 
            chartArea6.AxisX.MajorGrid.Enabled = false;
            chartArea6.AxisY.MajorGrid.Enabled = false;
            chartArea6.Name = "ChartArea1";
            this.chartCategorias.ChartAreas.Add(chartArea6);
            this.chartCategorias.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartCategorias.Location = new System.Drawing.Point(569, 3);
            this.chartCategorias.Name = "chartCategorias";
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series6.Name = "Series1";
            this.chartCategorias.Series.Add(series6);
            this.chartCategorias.Size = new System.Drawing.Size(560, 244);
            this.chartCategorias.TabIndex = 1;
            this.chartCategorias.Text = "chart2";
            // 
            // dgvVentas
            // 
            this.dgvVentas.AllowUserToAddRows = false;
            this.dgvVentas.AllowUserToDeleteRows = false;
            this.dgvVentas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvVentas.BackgroundColor = System.Drawing.Color.White;
            this.dgvVentas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVentas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvVentas.Location = new System.Drawing.Point(3, 434);
            this.dgvVentas.Name = "dgvVentas";
            this.dgvVentas.ReadOnly = true;
            this.dgvVentas.RowHeadersVisible = false;
            this.dgvVentas.RowHeadersWidth = 51;
            this.dgvVentas.RowTemplate.Height = 28;
            this.dgvVentas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVentas.Size = new System.Drawing.Size(1132, 237);
            this.dgvVentas.TabIndex = 3;
            // 
            // FormGerente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1463, 768);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.panelSidebar);
            this.MinimumSize = new System.Drawing.Size(1255, 722);
            this.Name = "FormGerente";
            this.Text = "Panel de Gerente";
            this.Load += new System.EventHandler(this.FormGerente_Load);
            this.panelSidebar.ResumeLayout(false);
            this.panelSidebar.PerformLayout();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelMain.ResumeLayout(false);
            this.tableMain.ResumeLayout(false);
            this.flowKpis.ResumeLayout(false);
            this.cardKpi1.ResumeLayout(false);
            this.cardKpi1.PerformLayout();
            this.cardKpi2.ResumeLayout(false);
            this.cardKpi2.PerformLayout();
            this.cardKpi3.ResumeLayout(false);
            this.cardKpi3.PerformLayout();
            this.panelFiltros.ResumeLayout(false);
            this.panelFiltros.PerformLayout();
            this.tableCharts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartVendedores)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartCategorias)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVentas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelSidebar;
        private System.Windows.Forms.Label lblTituloSidebar;
        private System.Windows.Forms.Button btnInicio;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Button btnListarVentas;
        private System.Windows.Forms.Button btnReportes;
        private System.Windows.Forms.Button btnRendimiento;
        private System.Windows.Forms.Button btnCerrarSesion;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Panel pnlAvatar;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.TableLayoutPanel tableMain;
        private System.Windows.Forms.FlowLayoutPanel flowKpis;
        private System.Windows.Forms.Panel cardKpi1;
        private System.Windows.Forms.Label lblKpi1Val;
        private System.Windows.Forms.Label lblKpi1;
        private System.Windows.Forms.Panel cardKpi2;
        private System.Windows.Forms.Label lblKpi2Val;
        private System.Windows.Forms.Label lblKpi2;
        private System.Windows.Forms.Panel cardKpi3;
        private System.Windows.Forms.Label lblKpi3Val;
        private System.Windows.Forms.Label lblKpi3;
        private System.Windows.Forms.Panel panelFiltros;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.ComboBox cboVendedor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtHasta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtDesde;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableCharts;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartVendedores;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartCategorias;
        private System.Windows.Forms.DataGridView dgvVentas;
    }
}
