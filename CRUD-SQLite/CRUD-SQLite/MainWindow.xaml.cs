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
using System.Windows.Navigation;
using System.Windows.Shapes;
using CRUD_SQLite.Clases;
using SQLite;

namespace CRUD_SQLite
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Clases.Canciones> canciones;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void GvMusic_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BtnNuevo_Click(object sender, RoutedEventArgs e)
        {
            Canciones songs = new Canciones()
            {
                Nombre = tbTitulo.Text,
                Artista = tbArtista.Text,
                Genero = cbAddGeneros.Text,
                Lista = cbAddToLista.Text,
                Link = tbLink.Text
            };
            using (SQLiteConnection conexion = new SQLiteConnection(App.databasePath))
            {
                conexion.CreateTable<Canciones>();
                conexion.Insert(songs);
            }
            Close();
            this.Close();
            MessageBox.Show("Añadido correctamente");
        }

        private void BtnEditar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnView_Click(object sender, RoutedEventArgs e)
        {
            wbVideo.Visibility = Visibility.Visible;
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            wbVideo.Visibility = Visibility.Hidden;
        }

        private void BtnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CbMostrar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void CbAddToLista_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        void LeerBaseDatos()
        {
            using (SQLite.SQLiteConnection conn =
                new SQLite.SQLiteConnection(App.databasePath))
            {
                conn.CreateTable<Clases.Canciones>();
                canciones = (conn.Table<Clases.Canciones>().ToList()).
                    OrderBy(c => c.Nombre).ToList();
            }
            if (canciones != null)
            {
                lvMusic.ItemsSource = canciones;
            }
        }

        private void lvMusic_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
