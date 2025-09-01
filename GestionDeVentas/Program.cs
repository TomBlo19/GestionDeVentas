using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using GestionDeVentas.Gerente; // Cambiado para referenciar la carpeta vendedor

namespace GestionDeVentas
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Modifica esta línea para iniciar el FormVendedor
            Application.Run(new FormGerente());
        }
    }
}