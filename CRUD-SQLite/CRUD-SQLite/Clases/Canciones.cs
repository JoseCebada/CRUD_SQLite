using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;


namespace CRUD_SQLite.Clases
{
    class Canciones
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Artista { get; set; }
        public string Genero { get; set; }
        public string Lista { get; set; }
        public string Link { get; set; }

        public override string ToString()
        {
            return $"{Nombre} - {Artista} - {Genero} - {Lista} - {Link}";
        }
    }
}
