using gestionDeVentas;
using GestionDeVentas.Admin; // Se necesita este using para el Form1
using GestionDeVentas.Gerent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

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

            // Inicia la aplicación con el formulario de inicio de sesión
            Application.Run(new inicioSesion());
        }
    }
}