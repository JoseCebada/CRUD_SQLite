using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CRUD_SQLite
{
    /// <summary>
    /// Lógica de interacción para Añadido.xaml
    /// </summary>
    public partial class Añadido : Window
    {
        public Añadido()
        {
            InitializeComponent();
        }

        private void Add_Closing_1(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MainWindow Lobby = new MainWindow();
            Lobby.Show();
            this.Hide();

        }
    }
}
