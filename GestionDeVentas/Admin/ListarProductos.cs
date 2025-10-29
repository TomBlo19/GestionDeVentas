using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;
using Datos;
using Modelos;

namespace GestionDeVentas.Admin
{
    public partial class ListarProductos : Form
    {
        private DataTable dataTableProductos = new DataTable();
        private readonly ProductoDatos productoDatos = new ProductoDatos();

        public ListarProductos()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            dataGridViewProductos.CellFormatting += dataGridViewProductos_CellFormatting;
        }

        private void ListarProductos_Load(object sender, EventArgs e)
        {
            // --- Carga de Datos ---
            dataTableProductos.Columns.Add("Id", typeof(int));
            dataTableProductos.Columns.Add("Código", typeof(string));
            dataTableProductos.Columns.Add("Nombre", typeof(string));
            dataTableProductos.Columns.Add("Marca", typeof(string));
            dataTableProductos.Columns.Add("Stock", typeof(int));
            dataTableProductos.Columns.Add("Talle", typeof(string));
            dataTableProductos.Columns.Add("Categoría", typeof(string));
            dataTableProductos.Columns.Add("Estado", typeof(string));

            CargarProductosEnDataTable();
            dataGridViewProductos.DataSource = dataTableProductos;

            if (dataGridViewProductos.Columns.Contains("Id"))
                dataGridViewProductos.Columns["Id"].Visible = false;
            if (dataGridViewProductos.Columns.Contains("Estado"))
                dataGridViewProductos.Columns["Estado"].Visible = false;

            // --- Carga de Filtros ---
            CargarFiltros();

            // --- Conexión de Eventos ---
            txtBusqueda.TextChanged += new EventHandler(filtros_Aplicar);
            cboBuscarPor.SelectedIndexChanged += new EventHandler(filtros_Aplicar);
            cmbCategoria.SelectedIndexChanged += new EventHandler(filtros_Aplicar);

            // ✨ CORRECCIÓN VISUAL: Posicionamiento correcto del DataGridView
            // Se elimina el Dock.Fill y se usa Anchor para que se redimensione bien.
            dataGridViewProductos.Dock = DockStyle.None; // Quitar el Dock.Fill
            dataGridViewProductos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            // Calcular la posición y tamaño para que no se solape con el panel superior
            int padding = 16;
            dataGridViewProductos.Location = new Point(padding, topPanel.Height + 5);
            dataGridViewProductos.Size = new Size(this.ClientSize.Width - (padding * 2), this.ClientSize.Height - topPanel.Height - padding);
        }

        private void CargarProductosEnDataTable()
        {
            dataTableProductos.Rows.Clear();
            var productos = productoDatos.ObtenerProductos();

            foreach (var p in productos)
            {
                dataTableProductos.Rows.Add(p.Id, p.Codigo, p.Nombre, p.Marca, p.Stock, p.TalleNombre, p.CategoriaNombre, p.Estado);
            }
        }

        private void CargarFiltros()
        {
            // ✨ CAMBIO: Se agrega "Marca" a las opciones de búsqueda.
            cboBuscarPor.Items.Clear();
            cboBuscarPor.Items.Add("Nombre");
            cboBuscarPor.Items.Add("Código");
            cboBuscarPor.Items.Add("Marca");
            cboBuscarPor.SelectedIndex = 0;

            // Carga de Categorías
            var categorias = dataTableProductos.AsEnumerable()
                                               .Select(row => row.Field<string>("Categoría"))
                                               .Distinct().OrderBy(c => c).ToList();
            cmbCategoria.Items.Clear();
            cmbCategoria.Items.Add("Todas");
            cmbCategoria.Items.AddRange(categorias.ToArray());
            cmbCategoria.SelectedIndex = 0;

            // ✨ CAMBIO: Se elimina por completo la carga del ComboBox de Marcas.
        }

        private void AplicarFiltros()
        {
            StringBuilder rowFilter = new StringBuilder();

            // 1. ✨ CAMBIO: Filtro unificado por Nombre, Código o Marca.
            string textoBusqueda = txtBusqueda.Text.Trim().Replace("'", "''");
            if (!string.IsNullOrEmpty(textoBusqueda))
            {
                string criterio = cboBuscarPor.SelectedItem.ToString();
                rowFilter.Append($"[{criterio}] LIKE '%{textoBusqueda}%'");
            }

            // 2. Filtro por Categoría (sin cambios, sigue igual)
            string filtroCategoria = cmbCategoria.SelectedItem?.ToString();
            if (filtroCategoria != "Todas" && !string.IsNullOrEmpty(filtroCategoria))
            {
                if (rowFilter.Length > 0) rowFilter.Append(" AND ");
                rowFilter.Append($"Categoría = '{filtroCategoria.Replace("'", "''")}'");
            }

            // ✨ CAMBIO: Se elimina la lógica del ComboBox de marca que estaba aquí.

            dataTableProductos.DefaultView.RowFilter = rowFilter.ToString();
        }

        private void filtros_Aplicar(object sender, EventArgs e)
        {
            AplicarFiltros();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridViewProductos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dataGridViewProductos.Columns.Contains("Estado"))
            {
                var row = dataGridViewProductos.Rows[e.RowIndex];
                string estado = row.Cells["Estado"].Value?.ToString();

                if (estado != null && estado.Equals("Inactivo", StringComparison.OrdinalIgnoreCase))
                {
                    e.CellStyle.BackColor = Color.LightCoral;
                    e.CellStyle.ForeColor = Color.White;
                    e.CellStyle.SelectionBackColor = Color.DarkRed;
                    e.CellStyle.SelectionForeColor = Color.White;
                }
                else
                {
                    e.CellStyle.BackColor = (e.RowIndex % 2 == 0) ? Color.FromArgb(250, 240, 230) : Color.White;
                    e.CellStyle.ForeColor = SystemColors.ControlText;
                    e.CellStyle.SelectionBackColor = SystemColors.Highlight;
                    e.CellStyle.SelectionForeColor = SystemColors.HighlightText;
                }
            }
        }
    }
}