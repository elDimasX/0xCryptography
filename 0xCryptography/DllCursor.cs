using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace _0xCryptography
{
    class DllCursor
    {
        // Deixa o cursor em forma de mão
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr LoadCursor(IntPtr hInstance, int lpCursorName);

        // Cursor em forma de mão
        private static readonly Cursor CursorMao = new Cursor(LoadCursor(IntPtr.Zero, 32649));

        /// <summary>
        /// Configurar o cursor nos controles
        /// </summary>
        public static void SetHandCursor(Control body)
        {
            // Procure todos os controles no corpo que nós foi passado
            foreach (Control control in body.Controls)
            {
                // Int
                int i;

                // Se for um cursor em forma de mão padrão
                if (control.Cursor == Cursors.Hand)
                {
                    // Altere o cursor
                    control.Cursor = CursorMao;
                }

                // Procure outros paineis na FORM
                for (i = 0; i < 2; i++)
                {
                    // Sete de novo
                    SetHandCursor(control);
                }
            }
        }
    }
}