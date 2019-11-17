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
            canciones = new List<Clases.Canciones>();
            lbContenido.Visibility = Visibility.Hidden;
            LeerBaseDatos();
            Inicio();
        }
        
        private void GvMusic_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BtnNuevo_Click(object sender, RoutedEventArgs e)
        {
            Añadir();
        }

        private void BtnEditar_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Este botón se encuentra inhabiliado actualmente.");
        }

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            Eliminar();
        }

        private void BtnView_Click(object sender, RoutedEventArgs e)
        {
            wbVideo.Visibility = Visibility.Visible;
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            wbVideo.Visibility = Visibility.Hidden;
            Inicio();
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
                canciones = (conn.Table<Clases.Canciones>().ToList()).OrderByDescending(s => s.Id).ToList();
            }
            if (canciones != null)
            {
                lvMusic.ItemsSource = canciones;
            }
            if (lvMusic.Items.Count <=0)
            {
                lbContenido.Visibility = Visibility.Visible;
            }
        }

        void Inicio()
        {
            spBotones.Visibility = Visibility.Visible;
            spDelete.Visibility = Visibility.Hidden;
            spAdd.Visibility = Visibility.Hidden;
        }
        
        void Añadir()
        {
            spBotones.Visibility = Visibility.Hidden;
            spDelete.Visibility = Visibility.Hidden;
            spAdd.Visibility = Visibility.Visible;
        }

        void Eliminar()
        {
            spBotones.Visibility = Visibility.Hidden;
            spDelete.Visibility = Visibility.Visible;
            spAdd.Visibility = Visibility.Hidden;
        }

        private void lvMusic_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BtnAddNew_Click(object sender, RoutedEventArgs e)
        {
            Canciones songs = new Canciones()
            {
                Nombre = tbTitulo.Text.Trim(),
                Artista = tbArtista.Text.Trim(),
                Genero = cbAddGeneros.Text.Trim(),
                Lista = cbAddToLista.Text.Trim(),
                Link = tbLink.Text.Trim()
            };
            using (SQLiteConnection conexion = new SQLiteConnection(App.databasePath))
            {
                conexion.CreateTable<Canciones>();
                conexion.Insert(songs);
            }
            Añadido add = new Añadido();
            add.Added.Visibility = Visibility.Visible;
            add.Added.Visibility = Visibility.Hidden;
            add.Title = "Añadiendo";
            add.Show();
            Close();
            this.Hide();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            using (SQLiteConnection conexion = new SQLiteConnection(App.databasePath))
            {
                string sentenciaSQL = "delete from Canciones where Nombre = '" + tbCancionDelete.Text + "'";
                conexion.Execute(sentenciaSQL);
            }
            Añadido add = new Añadido();
            add.Added.Visibility = Visibility.Hidden;
            add.Added.Visibility = Visibility.Visible;
            add.Title = "Eliminando.";
            add.Show();
            Close();
            this.Hide();
        }
    }
}
