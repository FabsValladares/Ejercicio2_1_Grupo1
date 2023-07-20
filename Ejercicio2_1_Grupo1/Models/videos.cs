using SQLite;
using System;
using System.Collections.Generic;
using System.Text;


using Xamarin.Forms;

namespace Ejercicio2_1_Grupo1.Models
{
    public class videos
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }

        [MaxLength(200)]
        public string nombre { get; set; }

        [MaxLength(200)]
        public string videoUrl { get; set; }

        [MaxLength(100)]
        public string descripcion { get; set; }
    }
}