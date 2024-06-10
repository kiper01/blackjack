using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace blackjack
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            CardsDeck deck = new CardsDeck(); // task 8
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm(deck));
        }
    }
}
