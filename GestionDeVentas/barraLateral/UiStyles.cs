using System.Drawing;
using System.Windows.Forms;

namespace gestionDeVentas
{
	public static class UiStyles
	{
		public static readonly Color SidebarBack = Color.FromArgb(231, 221, 211); // beige
		public static readonly Color SidebarText = Color.Black;
		public static readonly Font SidebarTitleFont = new Font("Segoe UI", 18f, FontStyle.Bold);
		public static readonly Font SidebarItemFont = new Font("Segoe UI", 12f, FontStyle.Regular);

		// LLAMADA PÚBLICA
		public static void ApplySidebarStyle(Panel sidebar, Label titulo = null)
		{
			if (sidebar == null) return;
			sidebar.BackColor = SidebarBack;

			// Título (si lo pasás)
			if (titulo != null)
			{
				titulo.Font = SidebarTitleFont;
				titulo.ForeColor = SidebarText;
			}

			// Aplica a todos los descendientes (no solo hijos directos)
			ApplyToChildrenRecursive(sidebar, titulo);
		}

		// APLICA A TODOS LOS HIJOS RECURSIVAMENTE
		private static void ApplyToChildrenRecursive(Control parent, Label titulo)
		{
			foreach (Control c in parent.Controls)
			{
				if (c is Button b)
				{
					b.FlatStyle = FlatStyle.Flat;
					b.FlatAppearance.BorderSize = 0;
					b.Font = SidebarItemFont;
					b.ForeColor = SidebarText;
					b.BackColor = Color.Transparent;
					b.TextAlign = ContentAlignment.MiddleLeft;
					b.Padding = new Padding(6, 0, 0, 0);
					b.Cursor = Cursors.Hand;
				}
				else if (c is LinkLabel ll)
				{
					ll.Font = SidebarItemFont;
					ll.LinkColor = SidebarText;
					ll.ActiveLinkColor = SidebarText;
					ll.VisitedLinkColor = SidebarText;
				}
				else if (c is Label lbl && lbl != titulo)
				{
					lbl.Font = SidebarItemFont;
					lbl.ForeColor = SidebarText;
					lbl.BackColor = Color.Transparent;
				}
				else
				{
					// Si es un Panel/GroupBox/TableLayoutPanel, asegurar fondo beige
					if (c is Panel || c is GroupBox || c is TableLayoutPanel)
						c.BackColor = SidebarBack;
				}

				// Recurse
				if (c.HasChildren)
					ApplyToChildrenRecursive(c, titulo);
			}
		}
	}
}

